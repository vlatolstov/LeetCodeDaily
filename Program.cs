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
                HashSet<(int, int)> valid = []; //<(int,int)> for left and right indexes
                Queue<(int, int, int)> q = []; //<(int,int,int)> for left, right indexes and odds count
                q.Enqueue((0, 0, nums[0] % 2));

                while (q.Count > 0)
                {
                    int size = q.Count;
                    for (int i = 0; i < size; i++)
                    {
                        var cur = q.Dequeue();
                        int l = cur.Item1;
                        int r = cur.Item2;
                        int odds = cur.Item3;

                        if (odds == k && valid.Add((l, r)))
                        {
                            if (l < r) q.Enqueue((l + 1, r, odds - nums[l] % 2));
                        }

                        if (r < nums.Length - 1) q.Enqueue((l, r + 1, odds + nums[r + 1] % 2));
                    }
                }

                return valid.Count;

            }
        }
    }
}
