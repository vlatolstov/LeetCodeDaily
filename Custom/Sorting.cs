using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily
{
    public static class Sorting
    {
        private const int NUM_DIGITS = 10;
        public static void RadixSort(int[] arr)
        {
            int max = int.MinValue;
            foreach (int i in arr) max = Math.Max(max, i);

            int place = 1;
            while (max / place > 0)
            {
                CountingSort(arr, place);
                place *= 10;
            }
        }
        private static void CountingSort(int[] arr, int place)
        {
            var counts = new int[NUM_DIGITS];

            foreach (int i in arr) counts[i / place % NUM_DIGITS]++;

            int startIndex = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int count = counts[i];
                counts[i] = startIndex;
                startIndex += count;
            }

            var sorted = new int[arr.Length];
            foreach (int i in arr)
            {
                int cur = i / place;
                sorted[counts[cur % NUM_DIGITS]] = i;
                counts[cur % NUM_DIGITS]++;
            }

            for (int i = 0; i < arr.Length; i++) arr[i] = sorted[i];
        }
        public static void BucketSort(int[] arr, int K)
        {
            List<List<int>> buckets = [];
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

        public static int[] HeapSort(int[] nums)
        {
            for (int i = nums.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(nums, nums.Length, i);
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                var temp = nums[i];
                nums[i] = nums[0];
                nums[0] = temp;
                Heapify(nums, i, 0);
            }

            return nums;
        }

        private static void Heapify(int[] arr, int heapSize, int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            int largest = index;

            if (left < heapSize && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                var temp = arr[index];
                arr[index] = arr[largest];
                arr[largest] = temp;
                Heapify(arr, heapSize, largest);
            }
        }
    }
}
