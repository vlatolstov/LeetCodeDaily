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
            int[][] a = [[2, 1, 1], [1, 1, 0], [0, 1, 1]];
            Console.WriteLine(sol.OrangesRotting(a));
        }
        public class Solution
        {
            public int OrangesRotting(int[][] grid)
            {
                int[][] dir = [[1, 0], [-1, 0], [0, 1], [0, -1]];
                int curRotten = 2;

                for (int i = 0; i < 10; i++)
                {
                    for (int raw = 0; raw < grid.Length; raw++)
                    {
                        for (int col = 0; col < grid[raw].Length; col++)
                        {
                            if (grid[raw][col] == curRotten)
                            {
                                foreach (var d in dir)
                                {
                                    if (raw > 0 && raw < grid.Length - 1 &&
                                        col > 0 && col < grid[raw].Length - 1 &&
                                        grid[raw + d[0]][col + d[1]] == 1)
                                    {
                                        grid[raw + d[0]][col + d[1]] = curRotten + 1;
                                    }
                                }
                            }
                        }
                    }
                    curRotten++;
                }

                for (int raw = 0; raw <= grid.Length; raw++)
                    for (int col = 0; col <= grid[raw].Length; col++)
                        if (grid[raw][col] == 1) return -1;

                return curRotten + 1;
            }
        }
    }
}
