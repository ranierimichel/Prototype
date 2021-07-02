using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePrototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Point : IPrototype<Point>
    {
        public int X, Y;
        public Point() { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point DeepCopy()
        {
            return new Point(X, Y);
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X} / {nameof(Y)}: {Y}"; 
        }
    }

    public class Line : IPrototype<Line>
    {
        public Point Start, End;
        public Line() { }
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
        }
        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}{Environment.NewLine}{nameof(End)}: {End}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var start = new Point(1, 1);
            var end = new Point(2, 2);
            var line1 = new Line(start, end);
            var line2 = line1.DeepCopy();
            line2.Start.X = 5;
            line2.Start.Y = 5;
            line2.End.X = 10;
            line2.End.Y = 10;
            Console.WriteLine("Line1:");
            Console.WriteLine(line1);
            Console.WriteLine("Line2:");
            Console.WriteLine(line2);
        }
    }
}
