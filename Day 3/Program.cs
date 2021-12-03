using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    public class Program
    {
        public static List<string> data = File.ReadAllLines("E:\\Code\\Advent of Code\\Day 3\\data.txt").ToList();
        public static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {Part1()}");
            Console.WriteLine($"Part 2: {Part2()}");
        }

        public static int Part1()
        {
            var positions = data.SelectMany(x => x.Select((y, z) => (Digit: y, Position: z))).ToList();

            var str = string.Empty;

            for(int i=0; i< data[0].Length; i++)
            {
                str += positions.Where(x => x.Position == i).GroupBy(x => x.Digit).OrderByDescending(x => x.Count()).First().Key;
            }

            var convert = Convert.ToInt32(str,2);
            var common = Convert.ToInt32(new string(str.Select(x => x == '0' ? '1' : '0').ToArray()), 2);
            return (convert * common);
        }
        public static int Part2()
        {
            var oxygen = data;
            var scrubber = data;

            for(int i=0; i < data[0].Length && oxygen.Count() > 1; i++)
            {
                oxygen = Filter(oxygen, i, '1');
            }

            for (int i = 0; i < data[0].Length && scrubber.Count() > 1; i++)
            {
                scrubber = Filter(scrubber, i, '0');
            }

            var common = Convert.ToInt32(oxygen[0], 2);
            var leastCommon = Convert.ToInt32(scrubber[0], 2);
            return (common * leastCommon);
        }

        public static List<string> Filter(List<string> data, int position, char defaultDigit)
        {
            var positions = data.SelectMany(x => x.Select((y, i) => (Digit: y, Position: i))).ToList();
            var digits = positions.Where(x => x.Position == position).GroupBy(x => x.Digit);

            var sortedDigits = defaultDigit == '0'
                ? digits.OrderBy(x => x.Count()).ToArray()
                : digits.OrderByDescending(x => x.Count()).ToArray();

            var filterCriteria = digits.Count() == 1 ? sortedDigits[0].Key : sortedDigits[0].Count() == sortedDigits[1].Count() ? defaultDigit : sortedDigits[0].Key;
            return data.Where(x => x[position] == filterCriteria).ToList();
        }
    }
    
}
