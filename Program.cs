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
            int[] a = [3, 5];
            int[] b = [0, 0];
            int[] c = [0, 4, 3, 0, 4];
            Console.WriteLine(sol.SpecialArray(a));
            Console.WriteLine(sol.SpecialArray(b));
            Console.WriteLine(sol.SpecialArray(c));
        }
        public class Solution
        {
            public int SpecialArray(int[] nums)
            {
                int[] count = new int[1001];

                for (int i = 0; i < nums.Length; i++) count[nums[i]]++;

                int goe = 0; //greater or equal

                for (int x = count.Length - 1; x >= 0; x--)
                {
                    if (x == count[x] + goe) return x;
                    goe += count[x];
                }

                return -1;
            }
        }
    }
}
