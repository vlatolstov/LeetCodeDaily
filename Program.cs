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

            int[] nums1 = [1, 2, 1]; int[][] edges1 = [[0, 1], [0, 2]]; int k1 = 3;
            int[] nums2 = [2, 3]; int[][] edges2 = [[0, 1]]; int k2 = 7;
            int[] nums3 = [7, 7, 7, 7, 7, 7]; int[][] edges3 = [[0, 1], [0, 2], [0, 3], [0, 4], [0, 5]]; int k3 = 3;
            int[] nums4 = [24, 78, 1, 97, 44]; int[][] edges4 = [[0, 2], [1, 2], [4, 2], [3, 4]]; int k4 = 6;
            Console.WriteLine(sol.MaximumValueSum(nums1, k1, edges1));
            Console.WriteLine(sol.MaximumValueSum(nums2, k2, edges2));
            Console.WriteLine(sol.MaximumValueSum(nums3, k3, edges3));
            Console.WriteLine(sol.MaximumValueSum(nums4, k4, edges4));
        }
        public class Solution
        {
            public long MaximumValueSum(int[] nums, int k, int[][] edges)
            {
                List<(int, int, int)> benefit = [];
                (int, int, int) minBenefit = (int.MaxValue, 0, 0);
                (int, int, int) maxBenefit = (0, 0, 0);
                (int, int, int) minDecrease = (0, 0, int.MinValue);

                for (int i = 0; i < nums.Length; i++)
                {
                    int x = nums[i];
                    int XOR = nums[i] ^ k;
                    int diff = XOR - x;
                    var cur = (XOR, i, diff);
                    if (diff > 0)
                    {
                        benefit.Add(cur);
                        minBenefit = minBenefit.Item1 < cur.XOR ? minBenefit : cur;
                        maxBenefit = maxBenefit.Item1 < cur.XOR ? cur : maxBenefit;
                    }
                    if (diff <= 0) minDecrease = minDecrease.Item3 > cur.diff ? minDecrease : cur;
                }

                if (benefit.Count % 2 == 1)
                {
                    if (maxBenefit.Item3 > Math.Abs(minDecrease.Item3)) benefit.Add(minDecrease);
                    else benefit.Remove(minBenefit);
                }

                foreach (var change in benefit) nums[change.Item2] = change.Item1;

                long sum = 0;
                foreach (int elem in nums) sum += elem;
                return sum;
            }
        }
    }
}
