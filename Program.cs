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
                BucketSort(nums, 10);

                Dictionary<int, int> counts = new();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (!counts.ContainsKey(nums[i])) counts.Add(nums[i], 1);
                    else counts[nums[i]]++;
                }

                return counts.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();

                void BucketSort(int[] arr, int K)
                {
                    List<List<int>> buckets = new();
                    for (int i = 0; i < K; i++) buckets.Add([]);
                    int offset = arr.Min();
                    int max = arr.Max() - offset;
                    double size = (double)(max / K);
                    if (size < 1d) size = 1d;

                    foreach (int i in arr)
                    {
                        int index = (int)((i - offset) / size);
                        if (index == K) buckets[K - 1].Add(i);
                        else buckets[index].Add(i);
                    }

                    foreach (var bucket in buckets) bucket.Sort();

                    List<int> sorted = [];
                    foreach (var bucket in buckets) sorted.AddRange(bucket);

                    for (int i = 0; i < arr.Length; i++) arr[i] = sorted[i];
                }
            }
        }
    }
}
