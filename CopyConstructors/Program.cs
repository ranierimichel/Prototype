using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyConstructors
{
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(paramName: nameof(other));
            }
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Address)}: {Address}"; 
        }
                
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {          
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {            
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}"; 
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var maria = new Person(new[] { "Maria", "Antonia" }, new Address("Rua1", 123));
            var lara = new Person(maria);
            lara.Names = new[] { "Lara", "Silva" };
            lara.Address = new Address("Rua2", 321);

            Console.WriteLine(maria);
            Console.WriteLine(lara);
        }
    }
}
