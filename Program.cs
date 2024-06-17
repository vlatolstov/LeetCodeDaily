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
                var l = 0L;
                var r = (long)Math.Sqrt(c);

                while (l <= r)
                {
                    var sqrSum = l * l + r * r;
                    if (sqrSum == c) return true;
                    if (sqrSum > c) --r; 
                    else --l;
                }

                return false;
            }
        }
    }
}
