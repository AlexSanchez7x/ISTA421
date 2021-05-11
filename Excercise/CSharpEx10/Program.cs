using System;
namespace CSharpEx10
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.WriteLine("Base Number Conversion");
                Console.WriteLine("Enter 0 to exit. Press Enter to continue");
                string exit = Console.ReadLine();
                if (exit == "0")
                    Environment.Exit(0);
                Console.WriteLine("Please enter a number to convert from 2|8|10|16");
                string n2 = Console.ReadLine();
                int from = int.Parse(n2);
                Console.Write("Please enter the integer to convert: ");
                string n1 = Console.ReadLine();
                bool success = Int32.TryParse(n1, out int number);
                if (success)
                    Console.WriteLine($"Number: {number}, Base: {from}");
                else
                    Console.WriteLine($"Number: {n1}, Base: {from} ");
                int result = 0;
                string str_result = "";
                if (from == 10)
                {
                    result = Dec2Binary(number);
                    Console.WriteLine("Binary: {0}", result);
                    result = Dec2Oct(number);
                    Console.WriteLine("Octal Number is: " + result);
                    str_result = Dec2Hex(number);
                    Console.WriteLine("Decimal to to Hex is: " + str_result);
                }
                else if (from == 2)
                {
                    result = Binary2Decimal(number);
                    Console.WriteLine($"Decimal Number is: {result} ");
                    result = Binary2Octal(number);
                    Console.WriteLine("Binary to Octal is " + result);
                    str_result = Binary2Hex(number);
                    Console.WriteLine("Binary to Hex is: " + str_result);
                }
                else if (from == 8)
                {
                    result = Octal2Binary(number);
                    Console.WriteLine("The equivalent Binary  Number: {0}", result);
                    result = Octo2Decimal(number);
                    Console.WriteLine("Here be the Octal to Decimol: " + result);
                    str_result = Octal2Hex(number);
                    Console.WriteLine("Octal to Hex number is: " + str_result);
                }
                else if (from == 16)
                {
                    result = Hex2Decimal(n1);
                    Console.WriteLine("Hex to Decimal is " + result);
                    result = Hex2Octal(n1);
                    Console.WriteLine("Hex to Octal is " + result);
                    result = Hex2Binary(n1);
                    Console.WriteLine("Hex to Binary is " + result);
                }
            }
        }
        private static int Hex2Binary(string HexNumber)
        {
            int Hex2Dec = Hex2Decimal(HexNumber);
            int Dec2Bi = Dec2Binary(Hex2Dec);
            return Dec2Bi;
        }
        private static int Hex2Octal(string n1)
        {
            int Hex2Dec = Hex2Decimal(n1);
            int Deci2Oct = Dec2Oct(Hex2Dec);
            return Deci2Oct;
        }

        private static int Hex2Decimal(string HexNumber)
        {
            int len = HexNumber.Length;
            int base1 = 1;
            int dec_val = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (HexNumber[i] >= '0' && HexNumber[i] <= '9')
                {
                    dec_val += (HexNumber[i] - 48) * base1;
                    base1 = base1 * 16;
                }
                else if (HexNumber[i] >= 'A' && HexNumber[i] <= 'F')
                {
                    dec_val += (HexNumber[i] - 55) * base1;
                    base1 = base1 * 16;
                }
            }
            return dec_val;
        }
        private static string Octal2Hex(int OctalNumber)
        {
            int Oct2Dec = Octo2Decimal(OctalNumber);
            string Dec2Hexx = Dec2Hex(OctalNumber);
            return Dec2Hexx;
        }
        private static int Octo2Decimal(int OctalNumber)
        {
            int Oct2Dec = Octal2Binary(OctalNumber);
            int bin2dec = Binary2Decimal(Oct2Dec);
            return bin2dec;
        }
        private static int Octal2Binary(int OctNumber)
        {
            int p = 1;
            int dec = 0,
            i = 1, j, d;
            int binno = 0;
            for (j = OctNumber; j > 0; j = j / 10)
            {
                d = j % 10;
                if (i == 1)
                    p = p * 1;
                else
                    p = p * 8;
                dec = dec + (d * p);
                i++;
            }
            i = 1;
            for (j = dec; j > 0; j = j / 2)
            {
                binno = binno + (dec % 2) * i;
                i = i * 10;
                dec = dec / 2;
            }
            return binno;
        }
        private static string Binary2Hex(int BinaryNumber)
        {
            string HexAnswer = "";
            int Bi2Hex = Binary2Decimal(BinaryNumber);
            return HexAnswer = Dec2Hex(Bi2Hex);
        }
        private static int Binary2Decimal(int BinaryNumber)
        {
            int num = BinaryNumber;
            int dec_value = 0;
            int base1 = 1;
            int temp = num;
            while (temp > 0)
            {
                int last_digit = temp % 10;
                temp = temp / 10;
                dec_value += last_digit * base1;
                base1 = base1 * 2;
            }
             return dec_value;
        }
        private static int Binary2Octal(int BinaryNumber)
        {
            int Bi2Oc = Binary2Decimal(BinaryNumber);
            int Dec2oc = Dec2Oct(Bi2Oc);
            return Dec2oc;
        }
        private static string Dec2Hex(int DecNumber)
        {
            int i = 0;
            int rem = 0;
            string HexNumber = "";
            string TheAnswer = "";
            while (DecNumber != 0)
            {
                rem = DecNumber % 16;
                if (rem < 10)
                    rem = rem + 48;
                else
                    rem = rem + 55;
                HexNumber += Convert.ToChar(rem);
                DecNumber = DecNumber / 16;
            }
            for (i = HexNumber.Length - 1; i >= 0; i--)
            {
                TheAnswer += HexNumber[i];
            }
            return TheAnswer;
        }
        private static int Dec2Oct(int DecNumber)
        {
            string temp = "";
            int OctNumber = 0;
            
            while (DecNumber != 0)
            {
                temp += DecNumber % 8;
                DecNumber = DecNumber / 8;
            }
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                OctNumber = OctNumber * 10 + temp[i] - 0x30;
            }
            
            return OctNumber;
        }
        private static int Dec2Binary(int DecNumber)
        {
            string result;
            result = "";
            while (DecNumber > 1)
            {
                int remainder = DecNumber % 2;
                result = Convert.ToString(remainder) + result;
                DecNumber /= 2;
            }
            result = Convert.ToString(DecNumber) + result;
            return Int32.Parse(result);
        }
    }
}