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
            string s1 = "krpgjbjjznpzdfy", t1 = "nxargkbydxmsgby";
            Console.WriteLine(sol.EqualSubstring(s1, t1, 14));
        }
        public class Solution
        {
            public int EqualSubstring(string s, string t, int maxCost)
            {
                int res = 0;
                DFS(0, 0, 0);
                return res;

                void DFS(int i, int curCost, int length)
                {
                    if (i == s.Length) return;

                    int diff = Math.Abs(s[i] - t[i]);
                    if (curCost + diff <= maxCost)
                    {
                        length++;
                        DFS(i + 1, curCost + diff, length);
                    }
                    DFS(i + 1, 0, 0);
                    res = Math.Max(res, length);
                }
            }
        }
    }
}
