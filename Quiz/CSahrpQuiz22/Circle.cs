using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSahrpQuiz22
{
    internal class Circle
    {
        public double radiusP { get; set; }
        public double areaP { get; set; }
        public double circumferenceP { get; set; }

        public Circle(double radius)
        {
            this.radiusP = radius;
            this.areaP = Math.PI * (radius * radius);
            this.circumferenceP = 2 * Math.PI * radius;
        }
        public override string ToString()
        {
            return $"(I am a Circle my radius is {this.radiusP} my {this.areaP} and my Circumference is {this.circumferenceP})";
        }
        public static Circle operator +(Circle lhs, Circle rhs) => new Circle(Math.Sqrt((lhs.areaP + rhs.areaP) / Math.PI));

        public static Circle operator -(Circle lhs, Circle rhs)
        {
            if (lhs.areaP < rhs.areaP)
            {
                return new Circle(Math.Sqrt((rhs.areaP - lhs.areaP) / Math.PI));
            }
            else 
            {
                return new Circle(Math.Sqrt((lhs.areaP - rhs.areaP) / Math.PI));
            }           
        }
        public static Circle operator *(Circle lhs, Circle rhs) => new Circle(Math.Sqrt((lhs.areaP * rhs.areaP) / Math.PI));
    }
}
