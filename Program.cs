using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new();
            Console.WriteLine(sol.FindMaximizedCapital(
                2,
                0,
                [1, 2, 3],
                [0, 1, 1]));
            Console.WriteLine(sol.FindMaximizedCapital(
                3,
                0,
                [1, 2, 3],
                [0, 1, 2]));
            Console.WriteLine(sol.FindMaximizedCapital(
                6,
                1,
                [1, 2, 3, 4, 5, 6],
                [0, 1, 2, 6, 6, 12]));
        }
        public class Solution
        {
            public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
            {
                var zip = profits
                    .Zip(capital)
                    .ToList();

                for (int i = 0; i < k; i++)
                {
                    var bestProfit = zip
                        .Where(z => z.Second <= w)
                        .OrderByDescending(z => z.First)
                        .Select((z, index) => (z.First, index))
                        .First();
                    w += bestProfit.First;
                    zip.RemoveAt(bestProfit.index);
                }

                return w;
            }
        }
    }
}
