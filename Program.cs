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

        }
        public class Solution
        {
            public double MincostToHireWorkers(int[] quality, int[] wage, int k)
            {
                int n = quality.Length;
                List<(int, double)> ratios = new();

                for (int i = 0; i < n; i++)
                    ratios.Add((quality[i], (double)wage[i] / quality[i]));

                ratios = ratios.OrderBy(x => x.Item2).ToList();

                int totalQuality = 0;
                double res = 0;
                PriorityQueue<int, int> q = new();

                for (int i = 0; i < n; i++)
                {
                    q.Enqueue(ratios[i].Item1, -1 * ratios[i].Item1);
                    totalQuality += ratios[i].Item1;

                    if (i + 1 >= k)
                    {
                        res = res == 0 ? totalQuality * ratios[i].Item2 : Math.Min(res, totalQuality * ratios[i].Item2);
                        totalQuality -= q.Dequeue();
                    }
                }

                return res;
            }

        }
    }
}
