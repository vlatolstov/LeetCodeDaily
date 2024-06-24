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
                var count = 0;
                int flip = 0;
                
                for (var i = 0; i < nums.Length; i++)
                {
                    if (i >= k)
                    {
                        flip ^= 1 - nums[i - k];
                    }
                    if (nums[i] == flip)
                    {
                        if (i + k > nums.Length)
                        {
                            return -1;
                        }
                        nums[i] = 0;
                        flip ^= 1;
                        count++;
                    }
                    else
                    {
                        nums[i] = 1;
                    }
                }
                return count;
            }
        }
    }
}
