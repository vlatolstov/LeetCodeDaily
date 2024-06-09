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
            int[] a = [4, 5, 0, -2, -3, 1];
            Console.WriteLine(sol.SubarraysDivByK(a, 5));
            int[] b = [-1, 2, 9];
            Console.WriteLine(sol.SubarraysDivByK(b, 2));
        }
        public class Solution
        {
            public int SubarraysDivByK(int[] nums, int k)
            {
                int[] mods = new int[k];
                mods[0] = 1;

                int prefixSum = 0;
                int count = 0;

                foreach (int i in nums)
                {
                    prefixSum += i;
                    int mod = prefixSum % k;
                    if (mod < 0) mod += k;
                    count += mods[mod];
                    mods[mod]++;
                }

                return count;
            }
        }
    }
}
