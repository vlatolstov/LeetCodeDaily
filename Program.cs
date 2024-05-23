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
            int[] a = [2, 4, 6];
            Console.WriteLine(sol.BeautifulSubsets(a, 2));
            int[] b = [1];
            Console.WriteLine(sol.BeautifulSubsets(b, 1));
            int[] c = [2, 2, 2, 2, 6, 6, 6, 6];
            Console.WriteLine(sol.BeautifulSubsets(c, 2));
            int[] d = [4, 2, 5, 9, 10, 3];
            Console.WriteLine(sol.BeautifulSubsets(d, 1));
        }
        public class Solution
        {
            public int BeautifulSubsets(int[] nums, int k)
            {
                List<(int, int)> l = [];

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int n = 0; n < l.Count; n++) 
                    {
                        var kvp = l[n];
                        if (Math.Abs(kvp.Item1 - nums[i]) != k)
                        {
                            kvp.Item2 *= 2;
                            l[n] = kvp;
                        }
                    }
                    l.Add((nums[i], 1));
                }

                return l.Select(kvp => kvp.Item2).Sum();
            }
        }
    }
}
