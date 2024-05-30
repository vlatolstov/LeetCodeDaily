using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Runtime.ExceptionServices;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new();
            int[] a = [2, 3, 1, 6, 7];
            Console.WriteLine(sol.CountTriplets(a));
            int[] b = [1, 1, 1, 1, 1];
            Console.WriteLine(sol.CountTriplets(b));
        }
        public class Solution
        {
            public int CountTriplets(int[] arr)
            {
                if (arr.Length < 2 || arr == null) return 0;

                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    int length = 1;
                    int XOR = arr[i];
                    for (int k = i + 1; k < arr.Length; k++)
                    {
                        length++;
                        XOR ^= arr[k];
                        if (XOR == 0) count += length - 1;
                    }
                }
                return count;
            }
        }
    }
}
