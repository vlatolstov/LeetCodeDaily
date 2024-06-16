using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MinPatches([1, 3], 6));
        }
        public class Solution
        {
            public int MinPatches(int[] nums, int n)
            {
                var achieved = 0L;
                var added = 0;

                foreach (int i in nums)
                {
                    while (i > achieved + 1)
                    {
                        achieved += achieved + 1;
                        added++;
                        if (n < achieved) return added;
                    }
                    achieved += i;
                    if (n < achieved) break;
                }

                while (n > achieved)
                {
                    achieved += achieved + 1;
                    added++;
                }

                return added;
            }
        }
    }
}
