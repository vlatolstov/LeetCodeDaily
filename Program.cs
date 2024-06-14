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
            public int MinIncrementForUnique(int[] nums)
            {
                HashSet<int> h = [];
                int res = 0;

                foreach (int i in nums)
                {
                    int cur = i;
                    while (!h.Add(cur))
                    {
                        cur++;
                        res++;
                    }
                }

                return res;
            }
        }
    }
}
