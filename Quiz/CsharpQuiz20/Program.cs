using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpQuiz20
{

    class Program
    {
        public delegate void MyShot();
        static void Main(string[] args)
        {
            Console.WriteLine("This is C Sharp quiz 20.");
            var FAS1 = new Shotgun();
            var FAS2 = new Rifle();
            var FAS3 = new Pistol();
            MyShot FASound1 = FAS1.Sound;
            MyShot FASound2 = FAS2.Sound;
            MyShot FASound3 = FAS3.Sound;
            MyShot AllShots = FASound1 + FASound2;
            AllShots += FASound3;
            AllShots();
        }
        class Shotgun //: IFirearm
        {
            public void Sound()
            {
                Console.WriteLine("I am a shotgun and I go Boom.");
            }
        }
        class Rifle //: IFirearm
        {
            public void Sound()
            {
                Console.WriteLine("I am a rifle and I go Bang.");
            }
        }
        class Pistol //: IFirearm
        {
            public void Sound()
            {
                Console.WriteLine("I am a pistol and I go Pop.");
            }
        }
    }
}
