using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main()
        {
            var sol = new Solution();
            int[][] a = [[0, 6, 0], [5, 8, 7], [0, 9, 0]];
            Console.WriteLine(sol.GetMaximumGold(a));
            int[][] b = [[1, 0, 7], [2, 0, 6], [3, 4, 5], [0, 3, 0], [9, 0, 20]];
            Console.WriteLine(sol.GetMaximumGold(b));
        }
        public class Solution
        {
            public int GetMaximumGold(int[][] grid)
            {
                int m = grid.Length;
                int n = grid[0].Length;

                var maximums = new int[m][];
                for (int i = 0; i < m; i++) maximums[i] = new int[n];
                HashSet<(int, int)> visited = new();

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        if (grid[i][j] != 0)
                        {
                            maximums[i][j] = DFS(grid, i, j, 0);
                            visited.Clear();
                        }

                int max = 0;
                for (int i = 0; i < m; i++)
                    for(int j  = 0; j < n; j++)
                        max = Math.Max(max, maximums[i][j]);

                return max;

                int DFS(int[][] grid, int i, int j, int sum)
                {
                    if (visited.Contains((i, j)) || i < 0 || j < 0 || i > m - 1 || j > n - 1)
                    {
                        return sum;
                    }
                    visited.Add((i, j));
                    sum += grid[i][j];
                    sum = Math.Max(sum, DFS(grid, i - 1, j, sum));
                    sum = Math.Max(sum, DFS(grid, i + 1, j, sum));
                    sum = Math.Max(sum, DFS(grid, i, j - 1, sum));
                    sum = Math.Max(sum, DFS(grid, i, j + 1, sum));

                    return sum;
                }
            }
        }
    }
}
