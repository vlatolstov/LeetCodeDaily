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
            int[] a = [3, 2, 3];
            Console.WriteLine(sol.MajorityElement(a));

        }
        public class Solution
        {
            public int MajorityElement(int[] nums)
            {
                Array.Sort(nums);
                int elem = nums[0];
                int cur = 1;
                if (nums.Length == 1) return elem;

                (int, int) max = (elem, cur);

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] == elem)
                    {
                        cur++;
                    }
                    else
                    {
                        max = max.Item2 > cur ? max : (elem, cur);
                        elem = nums[i];
                        cur = 1;
                    }
                }
                max = max.Item2 > cur ? max : (elem, cur);
                return max.Item1;
            }
        }
    }
}
