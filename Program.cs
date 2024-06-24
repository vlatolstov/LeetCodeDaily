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
            Console.WriteLine(sol.MinKBitFlips([0, 0, 0, 1, 0, 1, 1, 0], 3));
        }
        public class Solution
        {
            public int MinKBitFlips(int[] nums, int k)
            {
                int res = 0;
                int flipRange = 0;
                int flipCount = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    int cur = nums[i];
                    if (flipCount > 0) cur = flipCount % 2 == 0 ? cur : cur ^ 1;

                    if (cur == 0)
                    {
                        res++;
                        flipRange += k;
                    }

                    flipRange--;
                    if (flipRange < 0) flipRange = 0;
                    flipCount = flipRange == 0 ? 0 : flipRange / k + 1;
                    if (flipRange > nums.Length - i) return -1;
                }
                return res;
            }
        }
    }
}
