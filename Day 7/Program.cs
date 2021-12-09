using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(args.FirstOrDefault() ?? "C:\\Users\\l00152147\\source\\repos\\Rehgallag\\Advent-of-Code-2021\\Day 7\\data.txt").SelectMany(x => x.Split(',')).Select(int.Parse).ToList();
            
            var min = data.Min();
            var max = data.Max();
            var range = Enumerable.Range(min, max - min + 1);

            var part1 = range.Min(i => data.Sum(n => Distance(n, i)));
            Console.WriteLine($"Part 1: {part1}");

            var part2 = range.Min(i => data.Sum(n => SumTo(Distance(n, i))));
            Console.WriteLine($"Part 2: {part2}");

        }

        static int Distance(int a, int b)
        {
           return Math.Abs(a - b);
        }

        static int SumTo(int num)
        {
            return (num * (num + 1)) / 2;
        }


    }
}
