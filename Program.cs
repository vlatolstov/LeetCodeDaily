using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new();
            int[][] a = [[2, 1, 1], [1, 1, 0], [0, 1, 1]];
            Console.WriteLine(sol.OrangesRotting(a));
        }
        public class Solution
        {
            public int OrangesRotting(int[][] grid)
            {
                int[][] dir = [[1, 0], [-1, 0], [0, 1], [0, -1]];
                int rotten = 0;
                int total = 0;
                Queue<Orange> oranges = [];
                int res = 0;

                for (int raw = 0; raw < grid.Length; raw++)
                    for (int col = 0; col < grid[raw].Length; col++)
                    {
                        if (grid[raw][col] == 2)
                        {
                            oranges.Enqueue(new Orange(raw, col));
                            rotten++;
                        }
                        if (grid[raw][col] != 0) total++;
                    }

                while (oranges.Count > 0)
                {
                    if (rotten == total) break;
                    int n = oranges.Count;
                    for (int i = 0; i < n; i++)
                    {
                        Orange cur = oranges.Dequeue();
                        foreach (var d in dir)
                        {
                            int dRaw = cur.raw + d[0];
                            int dCol = cur.col + d[1];

                            if (dRaw >= 0 && dRaw < grid.Length &&
                                dCol >= 0 && dCol < grid[0].Length)
                            {
                                if (grid[dRaw][dCol] == 1)
                                {
                                    grid[dRaw][dCol] = 2;
                                    oranges.Enqueue(new Orange(dRaw, dCol));
                                    rotten++;
                                }
                            }
                        }
                    }
                    res++;
                }

                return rotten == total ? res : -1;
            }

            public struct Orange(int raw, int col)
            {
                public int raw = raw;
                public int col = col;
            }
        }
    }
}
