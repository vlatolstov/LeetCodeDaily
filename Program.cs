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
            string s1 = "catsanddog";
            List<string> dict1 = ["cat", "cats", "and", "sand", "dog"];
            foreach (string s in sol.WordBreak(s1, dict1)) Console.WriteLine(s);
            string s2 = "a";
            List<string> dict2 = ["a"];
            foreach (string s in sol.WordBreak(s2, dict2)) Console.WriteLine(s);
        }
        public class Solution
        {
            public IList<string> WordBreak(string s, IList<string> wordDict)
            {
                HashSet<string> valid = new(wordDict);
                IList<string> result = [];
                BFS (0, 0, []);
                return result;

                void BFS(int l, int r, IList<string> sentence)
                {
                    if (r == s.Length)
                    {
                        result.Add(String.Join(" ", sentence));
                        return;
                    }
                    while (r <= s.Length)
                    {
                        var cur = s.Substring(l, r - l);
                        if (valid.Contains(cur))
                        {
                            sentence.Add(cur);
                            BFS (r, r, new List<string>(sentence));
                            sentence.RemoveAt(sentence.Count - 1);
                        }
                        r++;
                    }
                }
            }
        }
    }
}
