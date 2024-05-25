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
                if (k == nums.Length) return;

                if (k % 2 == 0 && nums.Length % 2 == 0)
                {
                    int next = k;
                    int temp = nums[0];

                    for (int n = 0; n < nums.Length / 2; n++)
                    {
                        if (next > nums.Length - 1) next = next - nums.Length;

                        temp ^= nums[next];
                        nums[next] ^= temp;
                        temp ^= nums[next];
                        next += k;
                    }
                    next = k + 1;
                    temp = nums[1];
                    for (int n = 0; n < nums.Length / 2; n++)
                    {
                        if (next > nums.Length - 1) next = next - nums.Length;

                        temp ^= nums[next];
                        nums[next] ^= temp;
                        temp ^= nums[next];
                        next += k;
                    }
                }
                else
                {
                    int next = k;
                    int temp = nums[0];
                    for (int n = 0; n < nums.Length; n++)
                    {
                        if (next > nums.Length - 1) next = next - nums.Length;

                        temp ^= nums[next];
                        nums[next] ^= temp;
                        temp ^= nums[next];
                        next += k;
                    }
                }
            }
        }
    }
}
