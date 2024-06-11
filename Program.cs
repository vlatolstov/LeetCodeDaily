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
            Solution sol = new Solution();
            int[] a = [2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19], b = [2, 1, 4, 3, 9, 6];
            Console.WriteLine(String.Join(", ", sol.RelativeSortArray(a,b)));
        }
        public class Solution
        {
            public int[] RelativeSortArray(int[] arr1, int[] arr2)
            {
                int[] res = new int[arr1.Length];
                List<int> other = [];
                Dictionary<int, int> hm = arr2.ToDictionary(k => k, k => 0);

                for (int i = 0; i < arr1.Length; i++)
                {
                    if (hm.ContainsKey(arr1[i])) hm[arr1[i]]++;
                    else other.Add(arr1[i]);
                }

                int index = 0;
                foreach (var kvp in hm)
                {
                    for (int i = 0; i < kvp.Value; i++) res[index++] = kvp.Key;
                }

                other.Sort();
                for (int i = 0; i < other.Count; i++)
                {
                    res[index++] = other[i];
                }

                return res;
            }
        }
    }
}
