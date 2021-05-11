using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEx18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euler's Number");
            EulersNumber();
        }

        private static void EulersNumber()
        {//Write a method returns E, 2.7182818284590455, to an acceptable error.
         //
            //(1 + 1 / n) ^ n when n is infinity
            float E;
            double zero = 0.0;
            double positive = 1.0 / zero;
            double beforeE;
            double beforeE2;
            double beforeE3;

            Console.WriteLine(positive);// Outputs "Infinity"
            double negative = -1 / zero;
            Console.WriteLine(negative); // Outputs "Infinity"
            float MathisFun;



            //MathisFun = (1 + 1 / 100000);
            //Console.WriteLine("Here " + Math.Pow(MathisFun, (float)10000)); //only outputs 1

            for (int index = 0; index < 10001; index++)
            {
                beforeE = (1.0 + 1.0 / negative);
                beforeE2 = Math.Pow(beforeE, negative);
                Console.WriteLine("Is This it? " + beforeE2);
                beforeE3 = beforeE2 * 1.0 + 1.0 / 1.0;
                E = (float)beforeE3;
                Console.WriteLine($"I hope this is E: {E}");
            }


            //Math.E();



        }
        //We've learned that the number e is sometimes called Euler's number and is approximately 2.71828. 
        //Like the number pi, it is an irrational number and goes on forever.The two ways to calculate this
        //number is by calculating(1 + 1 / n)^n when n is infinity and by adding on to the series 1 + 1/1!
    }
}
