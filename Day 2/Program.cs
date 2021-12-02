using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    class Program
    {
        public static List<string> data = File.ReadAllLines("E:\\Code\\Advent of Code\\Day 2\\data.txt").ToList();

        static void Main(string[] args)
        {
            // Get input
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());

        }

        public static int Part1()
        {
            int forward = data.Where(x => x.Contains("forward")).Select(x => int.Parse(x.Last().ToString())).Sum();
            int depth = data.Where(x => x.Contains("down")).Select(x => int.Parse(x.Last().ToString())).Sum();

            depth = depth - data.Where(x => x.Contains("up")).Select(x => int.Parse(x.Last().ToString())).Sum();

            return (depth * forward);
        }

        public static int Part2()
        {
            int forward = 0;
            int depth = 0; int aim = 0;

            data.ForEach(x =>
            {
                int amt = int.Parse(x.Last()
                    .ToString());
                if (x.Contains("forward"))
                {
                    forward += amt;
                    depth += aim * amt;
                }
                else if (x.Contains("down"))
                {
                    aim += amt;
                }
                else if (x.Contains("up"))
                {
                    aim -= amt;
                }

            });
            return (forward * depth);
            //var forward = 0;
            //var depth = 0;
            //var aim = 0;

            //foreach (var i in data)
            //{
            //    var data = i.Split();
            //    var value = int.Parse(data[1]);

            //    if (data[0] == "forward")
            //    {
            //        forward += value;
            //        depth += aim * value;
            //    }
            //    else if (data[0] == "down")
            //    {
            //        aim += value;
            //    }
            //    else
            //    {
            //        aim -= value;
            //    }
            //}
            //return (forward * depth);

        }
    }
}
