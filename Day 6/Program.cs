using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<int> input = File.ReadAllLines("E:\\Code\\Advent of Code\\Day 1\\data.txt").Select(int.Parse).ToList();
            List<int> input = File.ReadAllLines(args.FirstOrDefault() ?? "D:\\Advent of Code 2021\\Day 6\\data.txt").SelectMany(x => x.Split(',')).Select(int.Parse).ToList();

            Console.WriteLine($"Part 1 Result = {CountFish(input, 80)} ");
            Console.WriteLine($"Part 2 Result = {CountFish(input, 256)} ");
        }

        static long CountFish(IEnumerable<int> input, int gen)
        {
            var fish = new long[9];
            foreach (var age in input)
            {
                fish[age]++;
            }

            for (int i = 0; i < gen; ++i)
            {
                fish[(i + 7) % 9] += fish[i % 9];
            }
            return fish.Sum();
        }
    }
}
