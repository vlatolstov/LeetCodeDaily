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
            
        }
        public class Solution
        {
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
