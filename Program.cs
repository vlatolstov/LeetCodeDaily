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
            int[] a = [6,1000,10000,100000];
            Console.WriteLine(sol.MaxProfit(a));
        }
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                if (prices == null || prices.Length == 0) return 0;

                int maxProfit = 0;
                int lowestPrice = prices[0];

                for (int i = 1; i < prices.Length; i++)
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - lowestPrice);
                    lowestPrice = Math.Min(lowestPrice, prices[i]);
                }

                return maxProfit;
            }
        }
    }
}
