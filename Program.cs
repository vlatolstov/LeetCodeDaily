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
            string a = "aabbaabbaa";
            foreach (var list in sol.Partition(a)) Console.WriteLine(String.Join(',', list));
        }
        public class Solution
        {
            public IList<IList<string>> Partition(string s)
            {
                List<IList<string>> res = [];
                Backtracking(s, res, new List<string>(), 0);
                return res;
            }

            void Backtracking(string s, IList<IList<string>> res, List<string> cur, int start)
            {
                if (start >= s.Length) res.Add(new List<string>(cur));

                for (int end  = start; end < s.Length; end++)
                {
                    if (IsPalindrome(s, start, end))
                    {
                        cur.Add(s.Substring(start, end - start + 1));
                        Backtracking(s,res, cur, end + 1);
                        cur.RemoveAt(cur.Count - 1);
                    }
                }
            }

            bool IsPalindrome(string s, int left, int right)
            {
                while (left< right)
                {
                    if (s[left++] != s[right--]) return false;
                }
                return true;
            }
        }
    }
}
