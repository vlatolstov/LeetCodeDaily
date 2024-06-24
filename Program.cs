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

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        for (int j = i; j < i + k; j++)
                        {
                            try
                            {
                                nums[j] ^= 1;
                            }
                            catch (IndexOutOfRangeException)
                            {
                                return -1;
                            }
                        }
                        res++;
                    }
                }
                return res;
            }
        }
    }
}
