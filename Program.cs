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
            int[] arr1 = [1, 2, 3, 4, 5, 6, 7];
            sol.Rotate(arr1, 3);
            int[] arr2 = [-1, -100, 3, 99];
            sol.Rotate(arr2, 2);
        }
        public class Solution
        {
            public void Rotate(int[] nums, int k)
            {
                int temp = nums[0];
                for (int n = 0; n < k; n++)
                {
                    for (int i = 1; i < nums.Length; i++)
                    {
                        temp ^= nums[i];
                        nums[i] ^= temp;
                        temp ^= nums[i];
                    }
                    nums[0] = temp;
                }
            }
        }
    }
}
