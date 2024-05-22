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
            string a = "aab";
            string b = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Console.WriteLine(sol.MinCut(a));
            Console.WriteLine(sol.MinCut(b));
        }
        public class Solution
        {
            public int MinCut(string s)
            {
                int n = s.Length;
                if (n <= 1) return 0;

                // Initialize bool matrix to show palindromes from each letter to each
                // and for all adjacent letters.
                // case "aab"
                //    a    a    b              legend:
                // a  t    t    f              t - true (from 'x' to 'y' in '[x,y]' is palindrome
                // a  X    t    f              f - false (not palindrome)
                // b  X    X    t              X - blank space, don't needed
                bool[,] isPalindrome = new bool[n, n];
                for (int i = 0; i < n; i++)
                {
                    isPalindrome[i, i] = true;
                    if (i < n - 1 && s[i] == s[i + 1]) isPalindrome[i, i + 1] = true;
                }

                // Filling up the matrix with substrings
                // from length = 3 (because length = 1 and length = 2 filled on initialization).
                for (int length = 3; length <= n; length++) //length of palindrome
                {
                    //x index
                    for (int i = 0; i <= n - length; i++)
                    {
                        //y index
                        int j = i + length - 1;
                        //If distinct letters are equals AND previous substring is palindrome.
                        isPalindrome[i, j] = s[i] == s[j] && isPalindrome[i + 1, j - 1];
                    }
                }


                //Initialize int array to store count of cuts needed to reach i's letter in string
                int[] minCuts = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (isPalindrome[0, i]) minCuts[i] = 0; //if it is palindrome - no cuts needed
                    else
                    {
                        minCuts[i] = i; //worst case: we need to cut all letters
                        for (int j = 1; j <= i; j++) //check minimum cuts needed previously and add THIS cut
                        {
                            if (isPalindrome[j, i]) minCuts[i] = Math.Min(minCuts[i], minCuts[j - 1] + 1);
                        }
                    }
                }

                //return last element that shows minCuts needed to reach end of the string
                return minCuts[^1];
            }
        }
    }
}
