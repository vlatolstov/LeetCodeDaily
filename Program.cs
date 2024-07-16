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
            Console.WriteLine(sol.FindJudge(2, [[1, 2]]));
            Console.WriteLine(sol.FindJudge(3, [[1, 3], [2, 3]]));
            Console.WriteLine(sol.FindJudge(3, [[1, 3], [2, 3], [3, 1]]));
        }
        public class Solution
        {
            public int FindJudge(int n, int[][] trust)
            {
                var all = new int[n + 1, 2];

                foreach (var arr in trust)
                {
                    all[arr[0], 0]++;
                    all[arr[1], 1]++;
                }

                for (int i = 1; i < n + 1; i++)
                {
                    if (all[i, 0] == 0 && all[i, 1] == n - 1) return i;
                }

                return -1;
            }
        }
    }
}
