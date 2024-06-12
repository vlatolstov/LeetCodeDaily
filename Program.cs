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
            int[] a = [2, 0, 2, 1, 1, 0];
            sol.SortColors(a);
            Console.WriteLine(String.Join(", ", a));
            int[] b = [2, 0, 1];
            sol.SortColors(b);
            Console.WriteLine(String.Join(", ", b));
        }
        public class Solution
        {
            public void SortColors(int[] nums)
            {
                int l = 0, r = nums.Length - 1, pos = 0;

                while (pos <= r)
                {
                    switch (nums[pos])
                    {
                        case 0:
                            (nums[l], nums[pos]) = (nums[pos], nums[l]);
                            l++;
                            break;
                        case 1:
                            break;
                        case 2:
                            (nums[r], nums[pos]) = (nums[pos], nums[r]);
                            r--;
                            break;
                    }
                    pos++;
                }
            }
        }
    }
}

