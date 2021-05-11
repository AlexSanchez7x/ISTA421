using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CShapEx15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wake Up Samurai");
            CodeCracker();
            SingleThread();
        }

    

        private static void CodeCracker()
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1.Single Threaded Cracker\n2.MultiThreaded Cracker\n3.Exit");
            Console.ResetColor();
            input = Console.ReadLine();

            if (input == "1")
            {//single thred
                Console.WriteLine("You Chose Single Thread");
                CodeCracker();
            }
            if (input == "2")
            {// multi thread 
                Console.WriteLine("You Chose Multi Thread");
                CodeCracker();

            }
            if (input == "3")
            {
                Console.WriteLine("See ya Space Cowboy");
            }
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("That is not a valid input! Press anything! Press anything to continue");
            //    Console.ResetColor();
            //    Console.ReadLine();
            //    Console.Clear();
            //    CodeCracker();
            //}
        }
        private static void SingleThread()
        {

            //1. write program that generates all printable characters
            //2. prompt the user to enter a password => They can Choose The Length
            //3. apply logic for start time, crack the password, stop time => four characters in several minutes
            string input = "";
            string cracked = "";
            Console.WriteLine("Enter Password: ");
            input = Console.ReadLine();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            SingleThread(input); ;
            watch.Stop();
            Console.WriteLine($"Single Thread completed in {watch.Elapsed}.");
            watch.Reset();
            watch.Start();
            MultiThread(input);
            watch.Stop();
            Console.WriteLine($"Multi Thread completed in {watch.Elapsed}.");


        }

        private static void MultiThread(string input)
        {
            int ASCIIstart = 32;
            char[] validchar = new char[95];
            string ValidGuess = "";
            for (int start = 0; start < 95; start++)
            {
                validchar[start] = (char)ASCIIstart;
                ASCIIstart++;
            }
            ParallelDive("", 0, input, validchar, ValidGuess);
        }

        private static void ParallelDive(string prefix, int level, string input, char[] validchar, string validGuess)
        {
            level++;
            Parallel.ForEach(validchar, MultiChar =>
           {
               validGuess = prefix + MultiChar;
               //Console.WriteLine(validguess);
               if (validGuess == input)
               {
                   Console.WriteLine($"Password match found. Your password is {validGuess}");
               }
               if (level < input.Length)
               {
                   Dive(prefix + MultiChar, level, input, validchar, validGuess);
               }

           });
        }

        private static void SingleThread(string input)
        {
            int ASCIIstart = 32;
            char[] validchar = new char[95];
            string ValidGuess = "";
            for (int start = 0; start < 95; start++)
            {
                validchar[start] = (char)ASCIIstart;
                ASCIIstart++;
            }
            Dive("",0,input,validchar, ValidGuess);

            //return PASSWORD;
        }

        private static void Dive(string prefix, int level, string input, char[] validchar, string validguess)
        {
            level++;
            foreach(var item in validchar)
            {
                validguess = prefix + item;
                //Console.WriteLine(validguess);
                if (validguess == input)
                {
                    Console.WriteLine($"Password match found. Your password is {validguess}");
                }
                if (level < input.Length)
                {
                    Dive(prefix+item,level,input,validchar, validguess);
                }


            }

        }
    }
}