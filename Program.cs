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
            Console.WriteLine(sol.MaxProfitAssignment([68, 35, 52, 47, 86], [67, 17, 1, 81, 3], [92, 10, 85, 84, 82]));
        }
        public class Solution
        {
            public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
            {
                var jobs = difficulty.Zip(profit).OrderByDescending(j => j.Second).ToArray();
                var minDiff = jobs.Min(j => j.First);
                int res = 0;

                foreach (var w in worker)
                {
                    if (w < minDiff) continue;

                    for (int i = 0; i < jobs.Length; i++)
                    {
                        if (w >= jobs[i].First)
                        {
                            res += jobs[i].Second;
                            break;
                        }
                    }
                }

                return res;
            }
        }
    }
}
