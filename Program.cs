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
                    .OrderBy(z => z.Second)
                    .ToList();

                PriorityQueue<int, int> q = new();
                int i = 0, n = profits.Length;

                while (k > 0)
                {
                    while (i < n && zip[i].Second <= w)
                    {
                        q.Enqueue(zip[i].First, -zip[i].First);
                        i++;
                    }

                    if (q.Count == 0)
                    {
                        break;
                    }

                    w += q.Dequeue();
                    k--;
                }

                return w;
            }
        }
    }
}
