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
            //var b = Enumerable.Range(1, 1000).ToArray();
            //Console.WriteLine(sol.MaxProfit(b));
        }
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                Dictionary<int, List<(int, int)>> graph = [];

                for (int i = 0; i < prices.Length; i++)
                {
                    graph.Add(i, []);
                    for (int j = i + 1; j < prices.Length; j++)
                    {
                        int profit = prices[j] - prices[i];
                        if (profit > 0) graph[i].Add((j, profit));
                    }
                }
                int max = 0;
                BFS(0, 0);

                return max;

                void BFS(int pos, int sum)
                {
                    if (pos >= graph.Count)
                    {
                        max = Math.Max(max, sum);
                        return;
                    }

                    for (int i = pos; i < graph.Count; i++)
                    {
                        foreach (var kvp in graph[i])
                        {
                            sum += kvp.Item2;
                            BFS(kvp.Item1 + 1, sum);
                            sum -= kvp.Item2;
                        }
                    }
                   
                }
            }
        }
    }
}
