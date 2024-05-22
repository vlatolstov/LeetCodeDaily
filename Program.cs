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
            string a = "aab";
            foreach (var list in sol.Partition(a)) Console.WriteLine(String.Join(',', list));
        }
        public class Solution
        {
            public IList<IList<string>> Partition(string s)
            {
                List<IList<string>> res = [];
                List<string> substrings = [];
                Backtracking(0, substrings, new StringBuilder());
                return res;

                void Backtracking (int start, IList<string> substrings, StringBuilder sb)
                {
                    res.Add(new List<string>(substrings));
                    for (int i = start; i < s.Length; i++)
                    {
                        sb.Append(s[i]);
                        string sub = sb.ToString();
                        if (IsPalindrome(sub))
                        {
                            substrings.Add(sub);
                            Backtracking(start + 1, substrings, new StringBuilder());
                        }
                    }
                }
                bool IsPalindrome(string substring)
                {
                    int n = substring.Length, l = 0, r = n - 1;
                    while (l < r)
                    {
                        if (substring[l] != substring[r]) return false;
                        l++; r--;
                    }
                    return true;
                }
            }
        }
    }
}
