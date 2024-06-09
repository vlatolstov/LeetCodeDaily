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
            int[] a = [4, 5, 0, -2, -3, 1];
            Console.WriteLine(sol.SubarraysDivByK(a, 5));
            int[] b = [-1, 2, 9];
            Console.WriteLine(sol.SubarraysDivByK(b, 2));
        }
        public class Solution
        {
            public int SubarraysDivByK(int[] nums, int k)
            {
                Dictionary<int, int> prefixSum = []; //key is modulo of current sum, val is count
                prefixSum[0] = 1;
                int count = 0;
                int sum = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    int mod = sum % k;
                    if (mod < 0) mod += k;
                    if (prefixSum.TryGetValue(mod, out int value)) count += value;
                    if (!prefixSum.TryAdd(mod, 1)) prefixSum[mod]++;
                }
                return count;
            }
        }
    }
}
