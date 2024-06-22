using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new();
            int[] nums1 = [1, 1, 2, 1, 1];
            Console.WriteLine(sol.NumberOfSubarrays(nums1, 3));
            int[] nums2 = [2, 4, 6];
            Console.WriteLine(sol.NumberOfSubarrays(nums2, 1));
            int[] nums3 = [2, 2, 2, 1, 2, 2, 1, 2, 2, 2];
            Console.WriteLine(sol.NumberOfSubarrays(nums3, 2));
            int[] nums4 = [1, 1, 1, 1, 1];
            Console.WriteLine(sol.NumberOfSubarrays(nums4, 1));
        }
        public class Solution
        {
            public int NumberOfSubarrays(int[] nums, int k)
            {
                int res = 0;
                Queue<int> q = []; //right index

                int odds = 0;

                //prefix sum of odd numbers
                for (int i = 0;  i < nums.Length; i++)
                {
                    odds += nums[i] % 2;
                    nums[i] = odds;
                    if (odds >= k) q.Enqueue(i);
                }

                while (q.Count > 0)
                {
                    var r = q.Dequeue();
                    if (nums[r] == k) res++;
                    for (int l = 0; l <= r; l++)
                    {
                        var cur = nums[r] - nums[l];
                        if (cur == k) res++;
                        if (cur < k) break;
                    }
                }
                return res;
            }
        }
    }
}
