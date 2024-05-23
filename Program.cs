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
            int[] a = [2, 4, 6];
            Console.WriteLine(sol.BeautifulSubsets(a, 2));
            int[] b = [1];
            Console.WriteLine(sol.BeautifulSubsets(b, 1));
            int[] c = [2, 2, 2, 2, 6, 6, 6, 6];
            Console.WriteLine(sol.BeautifulSubsets(c, 2));
            int[] d = [4, 2, 5, 9, 10, 3];
            Console.WriteLine(sol.BeautifulSubsets(d, 1));
        }
        public class Solution
        {
            public int BeautifulSubsets(int[] nums, int k)
            {
                Array.Sort(nums);
                int res = 0;
                DFS(0, []);
                return res;

                void DFS(int i, IList<int> list)
                {
                    if (i == nums.Length)
                    {
                        if (list.Count > 0) res++;
                        return;
                    }

                    DFS(i + 1, list);
                    if (list.Count == 0 || (!list.Contains(nums[i] - k) && !list.Contains(nums[i] + k)))
                    {
                        list.Add(nums[i]);
                        DFS(i + 1, list);
                        list.RemoveAt(list.Count - 1);
                    }
                }
            }
        }
    }
}
