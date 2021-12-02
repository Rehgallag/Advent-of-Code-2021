using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    class Program
    { 
        
        static void Main(string[] args)
        {
            // Get inputs
            List<int> numbers = File.ReadAllLines("E:\\Code\\Advent of Code\\Day 1\\data.txt").Select(int.Parse).ToList();

            // part1
            int counter = numbers.Where((num, index) => index > 0 && num > numbers[index - 1]).Count();
            Console.WriteLine(counter);

            // part 2
            int counter2 = numbers.Where((num, index) => index > 2 && num > numbers[index - 3]).Count();
            Console.WriteLine(counter2);
        }
        
    }
}
