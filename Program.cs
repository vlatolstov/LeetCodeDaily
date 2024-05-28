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
            string s1 = "abcd", t1 = "bcdf";
            Console.WriteLine(sol.EqualSubstring(s1, t1, 3));
            string s2 = "krpgjbjjznpzdfy", t2 = "nxargkbydxmsgby";
            Console.WriteLine(sol.EqualSubstring(s2, t2, 14));
        }
        public class Solution
        {
            public int EqualSubstring(string s, string t, int maxCost)
            {
                int[] diff = new int[s.Length];
                for (int i = 0; i < diff.Length; i++) diff[i] = Math.Abs(s[i] - t[i]);

                int left = 0, right = 0, score = 0, res = 0;

                while (left < diff.Length)
                {
                    if (left > right) right = left;
                    if (score < 0) score = 0;
                    while (right < diff.Length && score + diff[right] <= maxCost)
                    {
                        score += diff[right];
                        right++;
                    }
                    res = Math.Max(res, right - left);
                    score -= diff[left];
                    left++;
                }
                return res;
            }
        }
    }
}
