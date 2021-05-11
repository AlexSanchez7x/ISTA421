using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace CSharpEx13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testBank = Initialize();
            Console.WriteLine($"How many questions would you like to answer? " + $"Enter From 1 to {testBank.Count}:");
            int howMany = int.Parse(Console.ReadLine());
            List<string> test = MakeTest(testBank, howMany);
            Console.WriteLine("________________________\n" +
                              "Press any key to start.\n" +
                              "_________________________");
            Console.ReadLine();


            int Tscore = GiveTest(test);
            Console.WriteLine();
            Console.WriteLine($"You answered {Tscore} out of {howMany} correctly " +
                              $"and your grade is {(double)Tscore / howMany * 100.0} \n");
        }
        private static List<string> Initialize()
        {
            string first = " ";
            string tBpiece = " ";
            var dataTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"C:\Users\Okami\MSSA2021\ISTA421\Excercise\HistoryTest.csv")), true))
            {
                dataTable.Load(csvReader);
            }
            List<string> tB = new List<string>();

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                first += dataTable.Columns[i] + "@";

            }
            tB.Add(first);
            for (int rows = 0; rows < dataTable.Rows.Count; rows++)
            {
                for (int columns = 0; columns < dataTable.Columns.Count; columns++)
                {

                    tBpiece += dataTable.Rows[rows][columns] + "@";

                }
                tBpiece += "|";
            }
            string[] tBSplit = tBpiece.Split('|');
            for (int index = 0; index < tBSplit.Length - 1; index++)
            {
                tB.Add(tBSplit[index]);
            }
            return tB;
        }
        private static int GiveTest(List<string> test)
        {
            int score = 0;
            foreach(var GQuestion in test)
            {
                int counter = 1;
                int Jum;
                List<string> ExJum = new List<string>();
                Random Jumble = new Random();
                string Answer = "";
                string[] GiveSplit = GQuestion.Split('@');
                Answer = GiveSplit[1];
                Console.WriteLine("\n"+ GiveSplit[0]);
                for (int index = 1; index < GiveSplit.Length-1; index++)
                {
                    Jum = Jumble.Next(1, 5);
                    if (ExJum.Contains(GiveSplit[Jum]))
                    {
                        index--;
                    }
                    else
                    {
                        ExJum.Add(GiveSplit[Jum]);
                    }
                }
                foreach (string Jitem in ExJum)
                {
                    Console.WriteLine($"{counter}. {Jitem}");
                    counter++;
                }
                int.TryParse(Console.ReadLine(), out int Uinput);
                Console.WriteLine($"{ExJum[Uinput-1]}");
                if (ExJum[Uinput - 1] == Answer)
                {
                    Console.WriteLine($"\nLucky Guess\n");
                    score++;
                }
                else 
                {
                    Console.WriteLine($"Dum Dum the answer is {Answer}");
                }
            }
            return score;
        }
        private static List<string> MakeTest(List<string> testBank, int howMany)
        {
            //string testHandout;
            int QuestionsNum;
            Random QuizJumble = new Random();
            List<string> Test = new List<string>();
            for (int index = 0; index < howMany; index++)
            {
                QuestionsNum = QuizJumble.Next(0, 15);
                if (Test.Contains(testBank[QuestionsNum]))
                {
                    index--;
                }
                else
                {
                    Test.Add(testBank[QuestionsNum]);
                }
            }
            return Test;
        }
    }
}