using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEx12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Math Games");
            GameMaster();
            
        }

        private static void GameMaster()
        {
            Console.WriteLine("To add enter 1");
            Console.WriteLine("To subtract enter 2");
            Console.WriteLine("To multiply enter 3");
            Console.WriteLine("To divide enter 4");
            Console.WriteLine("To quit the game enter 0");
            

            //Int32.TryParse(Console.ReadLine(), out int probType);
            string probType = Console.ReadLine();
            

            if (probType == "1")
            {
                GameA();
            }
            else if (probType == "2")
            {
                GameS();
            }
            else if (probType == "3")
            {
                GameM();
            }
            else if (probType == "4")
            {
                GameD();
            }
            else if (probType == "0")
            {
                Console.WriteLine("~Thank you for a playing my game~");
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Sorry, You made an invalid choice");
            }
            GameMaster();
        }
        private static string Report(int score, int numProblem)
        {
            double percent = (double)score / (double)numProblem * 100;
            string report = $"You got {score} out of {numProblem} correct. Your score is {percent}%";
            return report;
        }

        private static void GameD()
        {
            int numProb;
            Console.WriteLine("Enter number of Problems between 1 and 12:");
            numProb = Int32.Parse(Console.ReadLine());
            Random RQNum = new Random();
            int score = 0;
            for (int i = 0; i < numProb; i++)
            {
                double A = RQNum.Next(1, 101);
                double B = RQNum.Next(1, 101);

                if (i == numProb)
                {
                    Console.WriteLine($"You asked for {numProb} questions");
                    GameD();
                }
                else if (numProb > 12)
                {
                    Console.WriteLine("Sorry that's too many questions");
                    GameD();
                }
                else
                {
                    Console.Write($"{A} / {B} = ");
                    string userAnswer = Console.ReadLine();
                    double correctAnswer = Math.Round(A / B, 2);
                    Double.TryParse(userAnswer, out double ca);
                    if (ca == correctAnswer || ca == Math.Round(correctAnswer, 2))
                    {
                        Console.WriteLine($"Correct the answer is {Math.Round(correctAnswer, 2)}");
                        Console.WriteLine();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Inorrect. The correct answer is {Math.Round(correctAnswer, 2)}");
                        Console.WriteLine();
                    }
                }       
            }
            string reportCard = Report(score, numProb);
            Console.WriteLine(reportCard);
            Console.WriteLine();
        }
        private static void GameM()
        {
            int score = 0;
            int numProb;
            Console.WriteLine("Enter number of Problems between 1 and 12:");
            numProb = Int32.Parse(Console.ReadLine());
            Random RQNum = new Random();
            for (int i = 0; i < numProb; i++)
            {
                int A = RQNum.Next(0, 101);
                int B = RQNum.Next(0, 101);
                if (i == numProb)
                {
                    Console.WriteLine($"You asked for {numProb} questions");
                    GameM();
                }
                else if (numProb > 12)
                {
                    Console.WriteLine("Sorry that's too many questions");
                    GameM();
                }
                else
                {
                    Console.Write($"{A} * {B} = ");
                    int userAnswer = Int32.Parse(Console.ReadLine());
                    if (userAnswer == A * B)
                    {
                        Console.WriteLine("Correct");
                        Console.WriteLine();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Inorrect. The correct answer is {A * B}");
                        Console.WriteLine();
                    }
                }
            }
            string reportCard = Report(score, numProb);
            Console.WriteLine(reportCard);
            Console.WriteLine();
        }
        private static void GameS()
        {
            int score = 0;
            int numProb;
            Console.WriteLine("Enter number of Problems between 1 and 12:");
            numProb = Int32.Parse(Console.ReadLine());
            Random RQNum = new Random();
            int Big;
            int smol;
            for (int i = 0; i < numProb; i++)
            {
                int A = RQNum.Next(0, 101);
                int B = RQNum.Next(0, 101);
                if(A > B)
                {
                    Big = A;
                    smol = B;
                }
                else if(B > A)
                {
                    Big = B;
                    smol = A;
                }
                else
                {
                    Big = A;
                    smol = B;
                }
                if (i == numProb)
                {
                    Console.WriteLine($"You asked for {numProb} questions");
                    GameS();
                }
                else if (numProb > 12)
                {
                    Console.WriteLine("Sorry that's too many questions");
                    GameS();
                }
                else
                {
                    Console.Write($"{Big} - {smol} = ");
                    int userAnswer = Int32.Parse(Console.ReadLine());
                    if (userAnswer == Big - smol)
                    {
                        Console.WriteLine("Correct");
                        Console.WriteLine();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Inorrect. The correct answer is {Big - smol}");
                        Console.WriteLine();
                    }
                }
            }
            string reportCard = Report(score, numProb);
            Console.WriteLine(reportCard);
            Console.WriteLine();
        }
        private static void GameA()
        {
            int score = 0;
            int numProb;
            Console.WriteLine("Enter number of Problems between 1 and 12:");
            numProb = Int32.Parse(Console.ReadLine());
            Random RQNum = new Random();
            for (int i = 0; i < numProb; i++)
            {
                int A = RQNum.Next(0, 101);
                int B = RQNum.Next(0, 101);
                if (i == numProb)
                {
                    Console.WriteLine($"You asked for {numProb} questions");
                    GameA();
                }
                else if (numProb > 12)
                {
                    Console.WriteLine("Sorry that's too many questions");
                    GameA();
                }
                else
                {
                    Console.Write($"{A} + {B} = ");
                    int userAnswer = Int32.Parse(Console.ReadLine());
                    if (userAnswer == A + B)
                    {
                        Console.WriteLine("Correct");
                        Console.WriteLine();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Inorrect. The correct answer is {A + B}");
                        Console.WriteLine();
                    }
                }
            }
            string reportCard = Report(score, numProb);
            Console.WriteLine(reportCard);
            Console.WriteLine();
        }
    }
}

