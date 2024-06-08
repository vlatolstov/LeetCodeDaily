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
            Console.WriteLine(sol.CheckSubarraySum([5,0,0,0], 3));
        }
        public class Solution
        {
            public bool CheckSubarraySum(int[] nums, int k)
            {
                if (nums == null || nums.Length < 2) return false;

                Queue<(int, int[])> q = [];
                int left = 0, right = 1, firstSum = nums[left] + nums[right];
                q.Enqueue((firstSum, [left, right]));

                while (q.Count > 0)
                {
                    int size = q.Count; 
                    for (int i = 0; i < size; i++)
                    {
                        var cur = q.Dequeue();
                        int curSum = cur.Item1;
                        int l = cur.Item2[0];
                        int r = cur.Item2[1];

                        if (curSum % k == 0 || curSum == 0) return true;
                        if (r < nums.Length - 1)
                        {
                            curSum += nums[++r];
                            q.Enqueue((curSum, [l, r]));
                        }
                        if (l < nums.Length - 2) q.Enqueue((curSum - nums[l++], [l, r]));
                    }
                }

                return false;
            }
        }
    }
}
