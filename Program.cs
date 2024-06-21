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
                for (int i = 0; i < minutes; i++)
                {
                    sum += customers[i];
                }

                int left = 0, right = minutes - 1;
                (int, int, int) bestWindow = (sum, left, right);

                while (right < customers.Length - 1)
                {
                    sum += customers[++right] - customers[left++];
                    if (sum > bestWindow.Item1) bestWindow = (sum, left, right);
                }

                sum = bestWindow.Item1;

                for (int i = 0; i < bestWindow.Item2; i++)
                {
                    if (grumpy[i] == 0) sum += customers[i];
                }
                for (int i = bestWindow.Item3; i < customers.Length - 1; i++)
                {
                    if (grumpy[i] == 0) sum += customers[i];
                }

                return sum;
            }
        }
    }
}
