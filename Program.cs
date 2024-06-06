using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new();
            Console.WriteLine(sol.IsNStraightHand([1, 2, 3, 6, 2, 3, 4, 7, 8], 3));
            Console.WriteLine(sol.IsNStraightHand([1, 2, 3, 4, 5], 4));
            Console.WriteLine(sol.IsNStraightHand([2, 1], 2));
        }
        public class Solution
        {
            public bool IsNStraightHand(int[] hand, int groupSize)
            {
                if (hand.Length % groupSize != 0) return false;

                Dictionary<int, int> d = [];
                for (int i = 0; i < hand.Length; i++) if (!d.TryAdd(hand[i], 1)) d[hand[i]]++;
                d = d.OrderBy(d => d.Key).ToDictionary();

                foreach (int key in d.Keys)
                {
                    while (d[key] > 0)
                    {
                        for (int i = 1; i < groupSize; i++)
                        {
                            if (!d.ContainsKey(key + i) || d[key + i]-- == 0) return false;
                        }
                        d[key]--;
                    }
                }

                return true;
            }
        }
    }
}