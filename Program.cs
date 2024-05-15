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

        }
        public class Solution
        {
            public int MaximumSafenessFactor(IList<IList<int>> grid)
            {
                int[][] dir = [[0, 1], [0, -1], [1, 0], [-1, 0]];
                int n = grid.Count;
                Queue<(int, int)> q = [];

                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (grid[r][c] == 1)
                        {
                            q.Enqueue((r, c));
                            grid[r][c] = 0;
                        }
                        else { grid[r][c] = -1; }
                    }
                }

                while (q.Count > 0)
                {
                    int size = q.Count;
                    for (int i = 0; i < size; i++)
                    {
                        var cur = q.Dequeue();
                        foreach (var d in dir)
                        {
                            int dr = cur.Item1 + d[0];
                            int dc = cur.Item2 + d[1];
                            int val = grid[cur.Item1][cur.Item2];
                            if ((dr > 0 || dc > 0 || dr < n || dc < n) && grid[dr][dc] == -1)
                            {
                                grid[dr][dc] = val + 1;
                                q.Enqueue((dr, dc));
                            }
                        }
                    }
                }

                PriorityQueue<(int, int, int), int> priorityQueue = new();
                priorityQueue.Enqueue((0, 0, grid[0][0]), -grid[0][0]);
                grid[0][0] = -1;

                while (priorityQueue.Count > 0)
                {
                    var cur = priorityQueue.Dequeue();
                    if (cur.Item1 == n - 1 && cur.Item2 == n - 1) return cur.Item3;

                    foreach (var d in dir)
                    {
                        int dr = cur.Item1 + d[0];
                        int dc = cur.Item2 + d[1];
                        if ((dr > 0 || dc > 0 || dr < n || dc < n) && grid[dr][dc] != -1)
                        {
                            priorityQueue.Enqueue((dr, dc, grid[dr][dc]), -Math.Min(cur.Item3, grid[dr][dc]));
                            grid[dr][dc] = -1;
                        }
                    }
                }

                return -1;
            }
        }
    }
}
