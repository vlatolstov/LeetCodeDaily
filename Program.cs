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
            int[] a = [1, 2, 1, 3, 2, 5];
            Console.WriteLine(string.Join(" ", sol.SingleNumber(a)));
            int[] b = [-1, 0];
            Console.WriteLine(string.Join(" ", sol.SingleNumber(b)));
            int[] c = [0, 1];
            Console.WriteLine(string.Join(" ", sol.SingleNumber(c)));
        }
        public class Solution
        {
            public int[] SingleNumber(int[] nums)
            {
                HashSet<int> res = [];

                for (int i = 0; i < nums.Length; i++)
                {
                    if (res.Contains(nums[i])) res.Remove(nums[i]);
                    else res.Add(nums[i]);
                }

                return [.. res];
            }
        }
    }
}
