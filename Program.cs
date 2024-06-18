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
                Array.Sort(worker);
                Array.Sort(difficulty, profit);

                int i = 0, j = 0, res = 0, max = 0;

                while (j < worker.Length)
                {
                    if (i < difficulty.Length && worker[j] >= difficulty[i])
                    {
                        max = Math.Max(max, profit[i]);
                        i++;
                    }
                    else
                    {
                        res += max;
                        j++;
                    }
                }

                return res;
            }
        }
    }
}
