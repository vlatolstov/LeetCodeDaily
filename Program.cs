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
            int[][] a = [[0, 0, 1, 1], [1, 0, 1, 0], [1, 1, 0, 0]];
            Console.WriteLine(sol.MatrixScore(a));
            int[][] b = [[0]];
            Console.WriteLine(sol.MatrixScore(b));
        }
        public class Solution
        {
            public int MatrixScore(int[][] grid)
            {
                int m = grid.Length;
                int n = grid[0].Length;

                for (int i = 0; i < m; i++) if (grid[i][0] == 0) FlipRaw(grid, i);

                for (int j = 0; j < n; j++)
                {
                    int ratio = 0;
                    for (int i = 0; i < m; i++) ratio += grid[i][j] == 0 ? -1 : 1;
                    if (ratio < 0) FlipCol(grid, j);
                }

                int sum = 0;
                foreach(var raw  in grid) sum += Convert.ToInt32(String.Concat(raw), 2);
                return sum;

                void FlipRaw(int[][] grid, int i)
                {
                    for (int j = 0; j < n; j++)
                    {
                        grid[i][j] = grid[i][j] == 0 ? 1 : 0;
                    }
                }
                void FlipCol(int[][] grid, int j)
                {
                    for (int i = 0; i < m; i++)
                    {
                        grid[i][j] = grid[i][j] == 0 ? 1 : 0;
                    }
                }
            }
        }
    }
}
