using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LINQ_Queries
{
    class Answer
    {
        internal void Quiz01(int[] intArray)
        {
            foreach (var item in intArray)
                Console.WriteLine($" {item} ");
            Console.WriteLine("-----");
            var myEven = intArray.Where(i => i % 2 == 0).Select(i=>1);
            foreach (var item in myEven)
                Console.Write($" {item} ");
        }

        internal void Quiz02(int[] intArray)
        {
            foreach (var item in intArray)
                Console.WriteLine($" {item} ");
            Console.WriteLine("-----");
            var positives = intArray.Where(i => i > 0).Select(i => i);
            foreach (var item in positives)
                Console.Write($" {item} ");
        }

        internal void Quiz03(int[] intArray)
        {
            foreach (var item in intArray)
                Console.WriteLine($" {item} ");
            Console.WriteLine("-----");
            var squares = intArray.Select(i => i*i);
            foreach (var item in squares)
                Console.Write($" {item} ");
        }

        internal void Quiz04(int[] intArray)
        {
            foreach(var item in intArray)
                Console.WriteLine($" {item} ");
            Console.WriteLine("-----");
            var count = intArray.GroupBy(i => i);
            foreach (var item in count)
                Console.WriteLine($" {item.Key} has {item.Count()} item ");
        }
    }
}