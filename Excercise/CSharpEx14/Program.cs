using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CSharpEx14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] PlainText;
            int[] SingleKey;
            int[] MultiKey;

            
            
            Console.WriteLine("Please Enter Plain Text");
            string PT = Console.ReadLine();
            Console.WriteLine("Please Enter Single Key");
            string SK = Console.ReadLine();
            Console.WriteLine("Please Enter Multi Key");
            string MK = Console.ReadLine();
            //Console.WriteLine((int)'A');

            PlainText = CleanPT(PT);
            SingleKey = CleanPT(SK);
            MultiKey = CleanPT(MK);

            string EncryptSK = SingleTextEncode(PlainText,SingleKey);
            string EncryptMK = MultiTextEncode(PlainText, MultiKey);
            string EncryptCK = ContinousEncode(PlainText, MultiKey);

            string DecryptSk = DecryptSK(EncryptSK, SingleKey);
            string DecryptMk = DecryptMK(EncryptMK, MultiKey);
            string DecryptCk = DecryptCK(EncryptCK, MultiKey);

            //Console.WriteLine(PlainText);
            Console.WriteLine($"You entered | " + PT + " | as plain text");
            Console.WriteLine($"You entered | " + SK + " | as your single key");
            Console.WriteLine($"You entered | " + MK + " | as your multi key");
            Console.WriteLine();

            Console.WriteLine($"Encrypted message with Single Key is {EncryptSK}");
            Console.WriteLine($"Encrypted message with Multi Key is {EncryptMK}");
            Console.WriteLine($"Encrypted message with Conti Key is {EncryptCK}");
            Console.WriteLine();

            Console.WriteLine($"Decrypted message with single key is {DecryptSk}");
            Console.WriteLine($"Decrypted message with multi key is {DecryptMk}");
            Console.WriteLine($"Decrypted message with continuous key is {DecryptCk}");
        }

        private static string DecryptCK(string encryptCK, int[] multiKey)
        {
            int IndexCounter = 0;
            int CKINDEX = 0;
            int BackToAscii = 0;
            string ReturnDCK = "";
            foreach (var EncCKchar in encryptCK)
            {
                if (IndexCounter <= multiKey.Length-1)
                {
                    //multikey stuff
                    BackToAscii = (int)EncCKchar - (multiKey[IndexCounter] - 64);
                    if (BackToAscii < 65)
                    {
                        BackToAscii += 26; //CATWEATTACKATD
                    }
                    IndexCounter++;
                    ReturnDCK += (char)BackToAscii;
                }
                else
                {
                    //PlainTextStuff
                    BackToAscii = (int)EncCKchar - ((int)ReturnDCK[CKINDEX]-64);
                    if (BackToAscii < 65)
                    {
                        BackToAscii += 26; //CATWEATTACKATD
                    }
                    IndexCounter++;
                    CKINDEX++;
                    ReturnDCK += (char)BackToAscii;
                }              
            }            
            return ReturnDCK;
        }

        private static string DecryptMK(string encryptMK, int[] multiKey)
        {
            int MKINDEX = 0;
            string ReturnDMK = "";
            int BackToMKCode = 0;
            foreach (var EncChar in encryptMK)
            {
                if (BackToMKCode < 65)
                {
                    BackToMKCode += 26;
                }
                BackToMKCode = (int)EncChar - (multiKey[MKINDEX]-64);
                MKINDEX++;
                if(MKINDEX >= multiKey.Length)
                {
                    MKINDEX = 0;
                }
                ReturnDMK += (char)BackToMKCode;
            }

            return ReturnDMK;
        }

        private static string DecryptSK(string encryptSK, int[] singleKey)
        {
            int BackToCode = 0;
            string ReturnDSK = "";
            foreach (var Thang in encryptSK)
            {
                BackToCode = (int)Thang - (singleKey[0] - 64);               
                if(BackToCode < 65)
                {
                    BackToCode += 26;
                }
                ReturnDSK += (char)BackToCode;
            }
            return ReturnDSK;
        }

        private static string ContinousEncode(int[] plainText, int[] multiKey)
        {
            int CodeValue = 0;
            int PTInex = 0;
            int AddPieceToCKPT = 0;
            int[] CKKeyValue = new int [multiKey.Length];
            int CKKeyIndex = 0;
            string ContiString = "";
            int[] PTMKArray = new int[plainText.Length + multiKey.Length];
           
            foreach (int CKPiece in multiKey)
            {
                //Populates first half of PTMKArray
                PTMKArray[PTInex] = CKPiece - 64;
                PTInex++;
            }
            foreach(int PTpeez in plainText)
            {
                //Populates second half of PTMKArray
                PTMKArray[PTInex] += PTpeez - 64;
                PTInex++;
            }
            PTInex = 0;
            foreach (int ptPiece in plainText)
            {
                CodeValue = PTMKArray[PTInex] + ptPiece;
                PTInex++;
                if (CodeValue > 90)
                {
                    CodeValue -= 26;
                }                
                ContiString += (char)CodeValue;
            }
            return ContiString;
        }

        private static string MultiTextEncode(int[] plainText, int[] multiKey)
        {
            int AddPieceToIndex;
            int HTCIndex = 0;
            int[] HoldTheCode = new int[multiKey.Length];
            string EncodedMKString = "" ;
            foreach(int MKpiece in multiKey)
            {
                HoldTheCode[HTCIndex] = MKpiece - 64;
                HTCIndex++;
            }
            HTCIndex = 0;
            foreach (int piece in plainText)
            {
                if (HTCIndex >= multiKey.Length)
                {
                    HTCIndex = 0;
                }
                AddPieceToIndex = piece + HoldTheCode[HTCIndex];
                HTCIndex++;
                if (AddPieceToIndex > 90)
                {
                    AddPieceToIndex -= 26;
                }
                EncodedMKString += (char)AddPieceToIndex;
            }
            return EncodedMKString;
        }
        private static string SingleTextEncode(int[] plainText, int[] singleKey)
        {
            int EncodedAscii = 0;
            int EncoderPlus;
            string EncodedString = "";
            EncoderPlus = singleKey[0]-64;
            //Console.WriteLine("EncoderPlus>>>> " + EncoderPlus);
            foreach(int piece in plainText)
            {
                EncodedAscii = piece + EncoderPlus;
                if(EncodedAscii > 90)
                {
                    int encodeSub = EncodedAscii - 26;
                    EncodedString += (char)encodeSub;
                }
                else
                {
                    EncodedString += (char)EncodedAscii;
                }
            }
            return EncodedString;

        }
        private static int[] CleanPT(string PT)
        {
            string ValidData = "";
            int[] CleanRet;
            string words = "";
            string[] PTSplit = PT.Split(' ');
            int index = 0;
            //PT = Console.ReadLine();
            foreach (var Word in PTSplit)
            {
                //Console.WriteLine(Convert.ToInt32(Word));
                words = Word.ToUpper();
                ValidData += Regex.Match( words, "^[A-Z]+$");
            }
            CleanRet = new int[ValidData.Length];
            foreach (var Letter in ValidData)
            {
                CleanRet[index] = ((int)Letter);
                index++;
            }            
            return CleanRet;
        }


        //step 1:grab user input
        //a.plain text ->string
        //b.single key ->string
        //c.multi key ->string
        //step 1.a: CLEAN THE USER INPUT**
        //1.a.1: cleans the plain text input -> int[]
        //1.a.2: cleans the single key input-> int[]
        //1.a.3: cleans the multi key input -> int[]

        //step 2:encode the plain text
        //a.encode plain text with single key ->string
        //b.encode plain text with multi key ->string
        //c.encode the plain text with continous key ->string

        //step 3: display encoded messages
        //a.print out encoded plain text with single key ->string
        //b.print out the encoded plain text with multi key ->string
        //c.print out the encoded plain text with continious key ->string


        //step 4: decode the encoded message
        //a.decode the encoded single key message ->string
        //b.decode the encoded multi key message ->string
        //c.decode the encoded continuous key message->string
        
        //step 5: print out the decoded messages
        //a.print out the decoded single key message->string
        //b.print out the decoded multi key message->string
        //c.print out the decoded continous key message->string
    }
}