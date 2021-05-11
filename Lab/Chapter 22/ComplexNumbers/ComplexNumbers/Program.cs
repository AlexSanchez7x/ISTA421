using System;

namespace ComplexNumbers
{
    class Program
    {
        static void doWork()
        {
            Complex first = new Complex(10, 4);
            Complex second = new Complex(5, 2);
            Console.WriteLine($"first is ");
            Console.WriteLine($"second is ");
            Complex temp = first + second;
            Console.WriteLine($"Add: result is ");
            temp = first - second;
            Console.WriteLine($"Subtract: result is ");
            temp = first * second;
            Console.WriteLine($"Multiply: result is ");
            temp = first / second;
            Console.WriteLine($"Divide: result is ");
            Console.WriteLine("===========================");
            Console.WriteLine(temp.ToString());

            if (temp == first)
            {
                Console.WriteLine("Comparison: temp == first");
            }
            else
            {
                Console.WriteLine("Comparison: temp != first");
            }
            if (temp == temp)
            {
                Console.WriteLine("Comparison: temp == temp");
            }
            else
            {
                Console.WriteLine("Comparison: temp != temp");
            }
            Console.WriteLine($"Current value of temp is ");
            if (temp == 2)
            {
                Console.WriteLine("Comparison after conversion: temp == 2");
            }
            else
            {
                Console.WriteLine("Comparison after conversion: temp != 2");
            }
            temp += 2;
            Console.WriteLine($"Value after adding 2: temp = ");
            Console.WriteLine($"Int value after conversion: tempInt == ");
            Console.WriteLine($"Value after adding 2: temp = ");
        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
