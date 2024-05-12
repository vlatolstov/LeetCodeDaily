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
            var sol = new Solution();

            int[][] a = [[9, 9, 8, 1], [5, 6, 2, 6], [8, 2, 6, 4], [6, 2, 2, 2]];
            int[][] b = [[1, 1, 1, 1, 1], [1, 1, 1, 1, 1], [1, 1, 2, 1, 1], [1, 1, 1, 1, 1], [1, 1, 1, 1, 1]];

            sol.LargestLocal(a);
            sol.LargestLocal(b);
        }
        public class Solution
        {
            public int[][] LargestLocal(int[][] grid)
            {
                int n = grid.Length;
                var res = new int[n - 2][];
                for (int i = 0; i < n - 2; i++)
                {
                    res[i] = new int[n - 2];
                    for (int j = 0; j < n - 2; j++)
                    {
                        res[i][j] = Recursive(grid, i + 1, j + 1);
                    }
                }

                return res;

                int Recursive(int[][] grid, int i, int j)
                {
                    int max = 0;
                    for (int raw = i - 1; raw <= i + 1; raw++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            max = Math.Max(max, grid[raw][col]);
                        }
                    }
                    return max;
                }

            }
        }
    }
}
