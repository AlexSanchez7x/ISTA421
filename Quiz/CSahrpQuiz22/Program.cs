using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSahrpQuiz22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This i s C# quiz 22");
            Console.WriteLine();
            Circle a = new Circle(3);
            Console.WriteLine(a.ToString());
            Circle b = new Circle(4);
            Console.WriteLine(b.ToString());
            Console.WriteLine();
            Console.WriteLine("new + operator");
            Circle c = a + b;
            Console.WriteLine(c.ToString());
            Console.WriteLine();
            Console.WriteLine("new - operator");
            c = a - b;
            Console.WriteLine(c.ToString());
            Console.WriteLine();
            Console.WriteLine("new * operator");
            c = a * b;
            Console.WriteLine(c.ToString());
        }
    }
}
