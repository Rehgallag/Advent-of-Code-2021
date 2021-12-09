using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(args.FirstOrDefault() ?? "C:\\Users\\L00152147\\source\repos\\Advent-of-Code-2021\\Day 8\\data.txt")
                .Select(x =>
                {
                    return x.Split('|')[1].Split(' ').Select(y => y.Trim()).ToList();
                }).ToList();

            int tally = 0;

            foreach(var d in data)
            {
                // 2, 3, 4, 7
                tally += d.Count(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7);
            }

            Console.WriteLine($"Part 1: {tally}");
        }
    }
}
