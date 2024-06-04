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
            string a = "aabbddbbssbbfbsbdAAAASssSFKDNJJJJFDnnnDNbNDNNNNNNNNNNNNnnnnnnnnnn";
            Console.WriteLine(sol.LongestPalindrome(a));
        }
        public class Solution
        {
            public int LongestPalindrome(string s)
            {
                Dictionary<char, int> d = [];

                for (int i = 0; i < s.Length; i++) if (!d.TryAdd(s[i], 1)) d[s[i]]++;

                int length = 0;
                bool odd = false;

                foreach (int val in d.Values)
                {
                    if (val % 2 == 0) length += val;
                    else
                    {
                        odd = true;
                        length += val - 1;
                    }
                }

                return odd ? length + 1 : length;
            }
        }
    }
}
