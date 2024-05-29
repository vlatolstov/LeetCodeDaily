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
            string a = "1101";
            Console.WriteLine(sol.NumSteps(a));
            string b = "10";
            Console.WriteLine(sol.NumSteps(b));
            string c = "1";
            Console.WriteLine(sol.NumSteps(c));
            string d = "1000000000000010000100100000100010000000101011101101000101";
            Console.WriteLine(sol.NumSteps(d));
            string e = "1111110011101010110011100100101110010100101110111010111110110010";
            Console.WriteLine(sol.NumSteps(e));
        }
        public class Solution
        {
            public int NumSteps(string s)
            {
                int i = s.Length - 1;
                int transpose = 0;
                int steps = 0;

                while (i > 0)
                {
                    char bit = s[i];

                    switch (bit, transpose > 0)
                    {
                        case ('1', true):
                            bit = '0';
                            break;
                        case ('0', true):
                            bit = '1';
                            transpose--;
                            break;
                        default:
                            break;
                    }

                    if (bit == '0') i--;
                    else
                    {
                        transpose++;
                        steps++;
                        i--;
                    }

                    steps++;
                }

                return steps + transpose;
            }
        }
    }
}
