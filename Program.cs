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
            Console.WriteLine(sol.JudgeSquareSum(2));
        }
        public class Solution
        {
            public bool JudgeSquareSum(int c)
            {
                int a = 0;
                while (a * a <= c)
                {
                    var bSqr = c - a * a; 
                    var b = Math.Sqrt(bSqr);
                    if (b % 1 == 0) return true;
                    a++;
                }
                return false;
            }
        }
    }
}
