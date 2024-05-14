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
                List<int> sums = [];
                Queue<Path> q = new();

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        if (grid[i][j] != 0)
                            q.Enqueue(new Path(j, i, grid[i][j]));

                while (q.Count > 0)
                {
                    int size = q.Count;
                    for (int i = 0; i < size; i++)
                    {
                        var cur = q.Dequeue();

                        if (cur.y > 0 && grid[cur.y - 1][cur.x] != 0 && !cur.visited.Contains((cur.x, cur.y - 1)))
                        {
                            cur.visited.Add((cur.x, cur.y - 1));
                            q.Enqueue(new Path(cur.x, cur.y, cur.sum + grid[cur.y - 1][cur.x], cur.visited));
                        }
                        if (cur.y < m - 1 && grid[cur.y + 1][cur.x] != 0 && !cur.visited.Contains((cur.x, cur.y + 1)))
                        {
                            cur.visited.Add((cur.x, cur.y + 1));
                            q.Enqueue(new Path(cur.x, cur.y, cur.sum + grid[cur.y + 1][cur.x], cur.visited));
                        }
                        if (cur.x > 0 && grid[cur.y][cur.x - 1] != 0 && !cur.visited.Contains((cur.x - 1, cur.y)))
                        {
                            cur.visited.Add((cur.x - 1, cur.y));
                            q.Enqueue(new Path(cur.x, cur.y, cur.sum + grid[cur.y][cur.x - 1], cur.visited));
                        }
                        if (cur.x < n - 1 && grid[cur.y][cur.x + 1] != 0 && !cur.visited.Contains((cur.x + 1, cur.y)))
                        {
                            cur.visited.Add((cur.x + 1, cur.y));
                            q.Enqueue(new Path(cur.x, cur.y, cur.sum + grid[cur.y][cur.x + 1], cur.visited));
                        }
                        else { sums.Add(cur.sum); }
                    }
                }

                return sums.Max();
            }

            public class Path
            {
                public int sum = 0;
                public int x;
                public int y;
                public HashSet<(int, int)> visited = [];

                public Path(int j, int i, int val)
                {
                    sum = val;
                    x = j;
                    y = i;
                    visited.Add((i, j));
                }
                public Path(int j, int i, int val, HashSet<(int, int)> vis)
                {
                    sum = val;
                    x = j;
                    y = i;
                    visited = vis;
                }
                public override string ToString()
                {
                    return $"sum = {sum} ({y},{x})";
                }
            }
        }
    }
}
