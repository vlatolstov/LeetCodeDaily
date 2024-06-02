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
            public void ReverseString(char[] s)
            {
                int l = 0, r = s.Length - 1;

                while (l < r)
                {
                    s[l] ^= s[r];
                    s[r] ^= s[l];
                    s[l] ^= s[r];
                    l++;
                    r--;
                }
            }
        }
    }
}