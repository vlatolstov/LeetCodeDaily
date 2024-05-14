using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main()
        {
            var sol = new Solution();
            int[][] a = [[0, 6, 0], [5, 8, 7], [0, 9, 0]];
            Console.WriteLine(sol.GetMaximumGold(a));
            int[][] b = [[1, 0, 7, 0, 0, 0], [2, 0, 6, 0, 1, 0], [3, 5, 6, 7, 4, 2], [4, 3, 1, 0, 2, 0], [3, 0, 5, 0, 20, 0]];
            Console.WriteLine(sol.GetMaximumGold(b));
        }
        public class Solution
        {
            public int GetMaximumGold(int[][] grid)
            {
                int m = grid.Length;
                int n = grid[0].Length;
                int max = 0;

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        if (grid[i][j] != 0)
                            max = Math.Max(max, DFS(i, j));

                return max;

                int DFS(int i, int j)
                {
                    if (i < 0 || j < 0 || i == m || j == n || grid[i][j] == 0) 
                        return 0;

                    int cur = grid[i][j];
                    grid[i][j] = 0;

                    int sum = cur + 
                        Math.Max(DFS(i - 1, j), 
                        Math.Max(DFS(i + 1, j), 
                        Math.Max(DFS(i, j - 1), 
                        DFS(i, j + 1))));

                    grid[i][j] = cur;
                    return sum;
                }
            }
        }
    }
}
