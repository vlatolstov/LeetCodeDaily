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
            Console.WriteLine(sol.MaxSatisfied([4, 10, 10], [1, 1, 0], 2));
        }
        public class Solution
        {
            public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
            {
                int sum = 0;
                for (int i = 0; i < customers.Length; i++)
                {
                    if (grumpy[i] == 0) sum += customers[i];
                }

                for (int i = 0; i < minutes; i++)
                {
                    if (grumpy[i] == 1) sum += customers[i];
                }

                int maxSum = sum, left = 0, right = minutes;

                while (right < customers.Length)
                {
                    if (grumpy[left] == 1) sum -= customers[left];
                    if (grumpy[right] == 1) sum += customers[right];
                    maxSum = Math.Max(maxSum, sum);
                    left++;
                    right++;
                }

                return maxSum;
            }
        }
    }
}
