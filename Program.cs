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
            int[] a = [1, 1, 1, 2, 2, 3];
            int[] b = [-1, -1];
            int[] c = [5, -3, 9, 1, 7, 7, 9, 10, 2, 2, 10, 10, 3, -1, 3, 7, -9, -1, 3, 3];
            Console.WriteLine(String.Concat(sol.TopKFrequent(a, 2)));
            Console.WriteLine(String.Concat(sol.TopKFrequent(b, 1)));
            Console.WriteLine(String.Concat(sol.TopKFrequent(c, 3)));
        }
        public class Solution
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                if (nums.Length == 1) return nums;

                Dictionary<int, int> counts = new();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!counts.ContainsKey(nums[i])) counts.Add(nums[i], 1);
                    else counts[nums[i]]++;
                }

                PriorityQueue<int, int> pq = new(Comparer<int>.Create((a,b) => a.CompareTo(b)));

                foreach (var kvp in counts)
                {
                    pq.Enqueue(kvp.Key, kvp.Value);
                    if (pq.Count > k) pq.Dequeue();
                }

                int[] res = [k];
                for (int i = 0; i < res.Length; i++) res[i] = pq.Dequeue();
                return res;
            }
        }
    }
}
