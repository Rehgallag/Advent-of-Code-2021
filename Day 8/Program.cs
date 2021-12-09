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
            var data = File.ReadAllLines(args.FirstOrDefault() ?? "D:\\Advent of Code 2021\\data.txt")
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

            // Part 2
            var data2 = File.ReadAllLines(args.FirstOrDefault() ?? "D:\\Advent of Code 2021\\data.txt")
                .Select(x =>
                {
                    var splitData = x.Split('|');

                    var leftRight = splitData.Select(y =>
                    {
                        return y.Trim().Split(' ').Select(z => z.Trim()).ToList();
                    }).ToList();

                    return new
                    {
                        left = leftRight[0],
                        right = leftRight[1]
                    };

                }).ToList();

            int tally2 = 0;

            foreach(var d in data2)
            {
                // 1,4,7,8
                var d1 = d.left.Single(x => x.Length == 2);
                var d4 = d.left.Single(x => x.Length == 4);
                var d7 = d.left.Single(x => x.Length == 3);
                var d8 = d.left.Single(x => x.Length == 7);

                //2,3,5         //15
                List<string> getTwoThreeFive = d.left.Where(x => x.Length == 5).ToList();

                //0,6,9         //16
                List<string> getZeroSixNine = d.left.Where(x => x.Length == 6).ToList();

                //3 contains 1
                var d3 = getTwoThreeFive.Single(x => d1.All(x.Contains));
                getTwoThreeFive.Remove(d3);

                // 9 contains 3
                var d9 = getZeroSixNine.Single(x => d3.All(x.Contains));
                getZeroSixNine.Remove(d9);

                // 0 contains 1

                var d0 = getZeroSixNine.Single(x => d1.All(x.Contains));
                getZeroSixNine.Remove(d0);
                var d6 = getZeroSixNine.Single();

                // 6 contains 5
                var d5 = getTwoThreeFive.Single(x => x.All(d6.Contains));
                getTwoThreeFive.Remove(d5);
                var d2 = getTwoThreeFive.Single();

                //order numbers

                List<string> nums = new List<string>
                {
                    string.Join(string.Empty, d0.OrderBy(x => x)),
                    string.Join(string.Empty, d1.OrderBy(x => x)),
                    string.Join(string.Empty, d2.OrderBy(x => x)),
                    string.Join(string.Empty, d3.OrderBy(x => x)),
                    string.Join(string.Empty, d4.OrderBy(x => x)),
                    string.Join(string.Empty, d5.OrderBy(x => x)),
                    string.Join(string.Empty, d6.OrderBy(x => x)),
                    string.Join(string.Empty, d7.OrderBy(x => x)),
                    string.Join(string.Empty, d8.OrderBy(x => x)),
                    string.Join(string.Empty, d9.OrderBy(x => x))
                };

                string result = string.Empty;
                foreach(var num in d.right)
                {
                    var n = string.Join("", num.OrderBy(x => x));

                    result += nums.IndexOf(n);
                }
                tally2 += int.Parse(result);

                
            }
            Console.WriteLine($"Part 2: {tally2}");

        }
    }
}
