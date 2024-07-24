using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily.Sorting
{
    public class Sorting
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

        public static void CountingSort(int[] arr, int place)
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

    }
}
