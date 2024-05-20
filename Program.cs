using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.XPath;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            int[] a = [1, 3];
            Console.WriteLine(sol.SubsetXORSum(a));

            int[] b = [5, 1, 6];
            Console.WriteLine(sol.SubsetXORSum(b));

            int[] c = [3, 4, 5, 6, 7, 8];
            Console.WriteLine(sol.SubsetXORSum(c));

        }
        public class Solution
        {
            public int SubsetXORSum(int[] nums)
            {
                return Recursion(0, 0);

                int Recursion(int sum, int i)
                {
                    if (i == nums.Length) return sum;
                    return Recursion(sum, i + 1) + Recursion(sum ^ nums[i], i + 1);
                }
            }
        }
    }
}
