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
            sol.Rotate(arr1, 2);
            int[] arr2 = [-1, -100, 3, 99];
            sol.Rotate(arr2, 2);
        }
        public class Solution
        {
            public void Rotate(int[] nums, int k)
            {
                if (k == 0 || nums.Length == 1 || nums.Length == k)
                    return;

                int startIndex = 0;
                int nextPlace = 0;
                int element = nums[nextPlace];

                for (int i = 1; i <= nums.Length; i++)
                {
                    nextPlace = (nextPlace + k) % nums.Length;
                    (element, nums[nextPlace]) = (nums[nextPlace], element);

                    if (nextPlace == startIndex)
                    {
                        startIndex++;
                        nextPlace++;
                        element = nums[nextPlace];
                    }
                }
            }
        }
    }
}
