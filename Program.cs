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
            public int AppendCharacters(string s, string t)
            {
                int l = 0, r = 0;

                while (l < s.Length && r < t.Length)
                {
                    if (s[l] == t[r]) { l++; r++; }
                    else l++;
                }
                return t.Length - r;
            }
        }
    }
}
