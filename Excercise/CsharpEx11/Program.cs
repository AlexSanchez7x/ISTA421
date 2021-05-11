using System;

namespace CsharpEx11
{
    class Program
    {
        public struct Datum2
        {
            public int x;
            public int y;
        }
        struct Datum3
        {
            public int x3;
            public int y3;
            public int z3;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("This is the Vector Exercise");
            bool again = true;
            while (again)
            {
                Console.WriteLine("Enter 2 to Calculate 2 element vector" +
                    " 3 to calculate 3 element vector, 0 to quit");
                string input = Console.ReadLine();
                if (input == "2")
                {
                    Console.WriteLine("\nTwo element vector");
                    CalcDist2();

                }
                else if (input == "3")
                {
                    Console.WriteLine("\nThree element vector");
                    CalcDist3();
                }
                else if (input == "0")
                {
                    again = false;
                }
                else
                {
                    Console.WriteLine("\n Input not recognized");

                }
            }
        }
        //private static void CalcDist3()
        //{
        //    double DatumPointDistance3 = 0;
        //    Datum3 RandomPoint3 = new Datum3();
        //    RandomPoint3.x3 = 0;
        //    RandomPoint3.y3 = 0;
        //    RandomPoint3.z3 = 0;
        //    Datum3[] D3 = new Datum3[1000];
        //    D3[999] = RandomPoint3;
        //    Random randomVector3 = new Random();
        //}

        private static void CalcDist3()
        {
            double DatumPointDistance3 = 0;
            Datum3 RandomPoint3 = new Datum3();
            RandomPoint3.x3 = 0;
            RandomPoint3.y3 = 0;
            RandomPoint3.z3 = 0;
            int index;
            Datum3[] D3 = new Datum3[1000];
            //D3[999] = RandomPoint3;
            Random randomVector3 = new Random();
            for (index = 0; index - 1 < 999; index++)
            {
                RandomPoint3.x3 = randomVector3.Next(1, 1001);
                RandomPoint3.y3 = randomVector3.Next(1, 1001);
                RandomPoint3.z3 = randomVector3.Next(1, 1001);
                D3[index] = RandomPoint3;
            }
            //this was a math testDatumPointDistance3 = DistMATH3(D3[RandomPoint3.x3], D3[RandomPoint3.y3]);
            //this was a math test Console.WriteLine(DatumPointDistance3);
            double allItem3 = 0;
            int BigIteration = 1;
            int EVCheck = 0;
            int ICheck = 0;
            double ShortestDist3 = double.MaxValue;         
            foreach (Datum3 Iteration3 in D3)
            {
                foreach (Datum3 everything3 in D3)
                {
                    if (EVCheck > 999)
                    {
                        EVCheck = 0;
                    }
                    //Console.WriteLine($"Test ICHECK: {ICheck} Test EVCheck: {EVCheck}");
                    if (EVCheck != ICheck)
                    {
                        allItem3 = DistMATH3(everything3, Iteration3);
                        //Console.WriteLine($"This is the equated Distance: {allItem2} This is how many times: {BigIteration}");
                        BigIteration += 1;
                        if (allItem3 < ShortestDist3)
                        {
                            ShortestDist3 = allItem3;
                            Console.WriteLine($"Point {EVCheck} ({everything3.x3},{everything3.y3},{everything3.z3}) , Point {ICheck} ({Iteration3.x3},{Iteration3.y3},{Iteration3.z3})");
                            Console.WriteLine($"have the Shortest Distance of {ShortestDist3}");
                        }
                    }
                    EVCheck++;
                }
                ICheck++;
            }
            //Console.WriteLine(everything2 + " Look HERE " + Iteration);
            //Console.WriteLine($"This is the big Iteration {BigIteration}");
        }
        private static double DistMATH3(Datum3 p1, Datum3 p2)
        {
            double EQDist = Math.Sqrt(Math.Pow((p1.x3 - p2.x3), 2) + Math.Pow((p1.y3 - p2.y3), 2) + Math.Pow((p1.z3 - p2.z3),2));
            //Console.WriteLine(p1.x + " " + p2.x + " , " + p1.y + " " + p2.y);
            return EQDist;
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////
        /// </summary>
        private static void CalcDist2()
        {
            double DatumPointDistance = 0;
            Datum2 RandomPoint = new Datum2();
            RandomPoint.x = 0;
            RandomPoint.y = 0;
            int index;
            Datum2[] D2 = new Datum2[100];
            //D2[99] = RandomPoint;
            Random randomVector = new Random();
            for (index = 0; index - 1 < 99; index++)
            {
                RandomPoint.x = randomVector.Next(1, 101);
                RandomPoint.y = randomVector.Next(1, 101);

                D2[index] = RandomPoint;
            }
            //this was a math testDatumPointDistance = DistMATH(D2[RandomPoint.x], D2[RandomPoint.y]);
            //this was a math test Console.WriteLine(DatumPointDistance);
            double allItem2 = 0;
            int BigIteration = 1;
            int EVCheck = 0;
            int ICheck = 0;
            double ShortestDist2 = double.MaxValue;
            foreach (Datum2 Iteration in D2)
            {
                foreach (Datum2 everything2 in D2)
                {
                    if(EVCheck > 99)
                    {
                        EVCheck = 0;
                    }
                    //Console.WriteLine($"Test ICHECK: {ICheck} Test EVCheck: {EVCheck}");
                    if (EVCheck != ICheck)
                    {
                        allItem2 = DistMATH(everything2, Iteration);
                        //Console.WriteLine($"This is the equated Distance: {allItem2} This is how many times: {BigIteration}");
                        BigIteration += 1;
                        if (allItem2 < ShortestDist2)
                        {
                            ShortestDist2 = allItem2;
                            Console.WriteLine($"Point {EVCheck} ({everything2.x},{everything2.y}) , Point {ICheck} ({Iteration.x},{Iteration.y})");
                            Console.WriteLine($" have the Shortest Distance of {ShortestDist2}");
                        }
                    }
                    EVCheck++;
                }
                ICheck++;
            }
            //Console.WriteLine(everything2 + " Look HERE " + Iteration);
            //Console.WriteLine($"This is the big Iteration {BigIteration}");
        }
        private static double DistMATH(Datum2 p1, Datum2 p2)
        {
            double EQDist = Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
            //Console.WriteLine(p1.x + " " + p2.x + " , " + p1.y + " " + p2.y);
            return EQDist;
        }
    }
}
