using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        public class Solution
        {
            private const int INF = int.MaxValue;
            public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
            {
                int[,] distance = new int[26,26];
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (i == j) distance[i, j] = 0;
                        else distance[i, j] = INF;
                    }
                }

                for (int i = 0; i < original.Length; i++)
                {
                    int o = original[i] - 'a';
                    int c = changed[i] - 'a';
                    distance[o,c] = Math.Min(distance[o,c], cost[i]);
                }

                for (int k = 0; k < 26; k++)
                {
                    for (int i = 0; i < 26; i++)
                    {
                        for (int j = 0; j < 26; j++)
                        {
                            if (distance[i, k] < INF && distance[k, j] < INF)
                            {
                                distance[i,j] = Math.Min(distance[i,j], distance[i, k] + distance[k,j]);
                            }
                        }
                    }
                }

                long res = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    int s = source[i] - 'a';
                    int t = target[i] - 'a';
                    int minCost = distance[s,t];
                    if (minCost == INF) return -1;
                    res += minCost;
                }

                return res;
            }
        }
    }
}
