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
            public int MaxDistance(int[] position, int m)
            {
                Array.Sort(position);

                int min = 1, max = position[^1] - position[0];

                while (min <= max)
                {
                    int mid = min + (max - min) / 2;
                    if (PossibleToPlace(mid)) min = mid + 1;
                    else max = mid - 1;
                }

                return max;

                bool PossibleToPlace(int maxDistance)
                {
                    int placed = 1, lastBall = position[0];

                    foreach (int pos in position)
                    {
                        if (pos - lastBall >= maxDistance)
                        {
                            placed++;
                            lastBall = pos;
                        }
                        if (placed == m) return true;
                    }
                    return false;
                }
            }
        }
    }
}
