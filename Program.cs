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
            string a = "1";
            Console.WriteLine(sol.NumSteps(a));
        }
        public class Solution
        {
            public int NumSteps(string s)
            {
                long x = ToDecimal(s);
                int steps = 0;

                while (x != 1)
                {
                    if (x % 2 == 0)
                    {
                        x /= 2;
                    }
                    else
                    {
                        x += 1;
                    }
                    steps++;
                }
                return steps;

                long ToDecimal(string binary)
                {
                    long val = 0;
                    int length = binary.Length;

                    for (int i = 0; i < length; i++)
                    {
                        char bit = binary[length - 1 - i];
                        if (bit == '1') val += (long)Math.Pow(2, i);
                    }

                    return val;
                }
            }
        }
    }
}
