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
            int[] a = [7, 1, 5, 3, 6, 4];
            Console.WriteLine(sol.MaxProfit(a));
            var b = Enumerable.Range(1, 1000).ToArray();
            Console.WriteLine(sol.MaxProfit(b));
        }
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                int max = 0;
                DFS(0, 0);
                return max;

                void DFS (int l, int sum)
                {
                    if (l >= prices.Length)
                    {
                        max = Math.Max(max, sum);
                        return;
                    }

                    for (int r = l; r < prices.Length; r++)
                    {
                        int profit = prices[r] - prices[l];
                        if (profit > 0)
                        {
                            sum += profit;
                            DFS(r + 1, sum);
                            sum -= profit;
                        }
                    }
                    DFS(l + 1, sum);
                }
            }
        }
    }
}
