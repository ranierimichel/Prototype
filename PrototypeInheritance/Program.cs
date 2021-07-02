using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeInheritance
{

    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class Address : IDeepCopyable<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {

        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public void CopyTo(Address target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}," +
                   $" {nameof(HouseNumber)}: {HouseNumber}";     
        }
    }

    public class Person : IDeepCopyable<Person>
    {
        public string[] Names;
        public Address Address;

        public Person()
        {

        }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public void CopyTo(Person target)
        {
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, " +
                   $"{nameof(Address)}: {Address}";
        }
    }

    public class Employee : Person, IDeepCopyable<Employee>
    {
        public int Salary;

        public Employee()
        {

        }

        public Employee(string[] names, Address address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }

        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person) where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var toto = new Employee();
            toto.Names = new[] { "Maria", "Antonia" };
            toto.Address = new Address
            {
                HouseNumber = 123,
                StreetName = "Rua1"
            };
            toto.Salary = 321000;

            var lara = toto.DeepCopy();
            lara.Names[0] = "Lara";
            lara.Names[1] = "Silva";
            lara.Address.HouseNumber++;
            lara.Salary = 123000;
            Console.WriteLine(toto);
            Console.WriteLine(lara);

        }
    }
}
