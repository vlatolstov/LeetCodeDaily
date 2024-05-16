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
            var sol = new Solution();
            int[] a = [2, 3, 1, 1, 4];
            Console.WriteLine(sol.CanJump(a));
            
            int[] b = [3, 2, 1, 0, 4];
            Console.WriteLine(sol.CanJump(b));

        }
        public class Solution
        {
            public bool CanJump(int[] nums)
            {
                if (nums.Length == 1) return true;
                if (nums[0] == 0) return false;
                int gap = 0;

                for (int i = nums.Length - 2; i >= 0; i--)
                {
                    gap++;
                    int cur = nums[i];
                    if (cur != 0)
                    {
                        if (cur < gap) return false;
                        gap = 0;
                    }
                }
                return true;
            }
        }
    }
}
