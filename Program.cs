using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public class Solution
        {
            public int MinDays(int[] bloomDay, int m, int k)
            {
                if (m * k > bloomDay.Length) return -1;

                int start = 0;
                int end = 0;

                foreach (int day in bloomDay) end = Math.Max(end, day);

                int res = -1;

                while (start <= end)
                {
                    int mid = start + (end - start) / 2;
                    if (NumOfBouquets(bloomDay, mid, k) >= m)
                    {
                        res = mid;
                        end = mid - 1;
                    }
                    else start = mid + 1; 
                }

                return res;
            }

            private int NumOfBouquets(int[] bloomDay, int day, int k)
            {
                int numOfBouquets = 0, flowers = 0;

                foreach (int bloom in bloomDay)
                {
                    if (bloom <= day)
                    {
                        flowers++;
                        if (flowers == k)
                        {
                            numOfBouquets++;
                            flowers = 0;
                        }
                    }
                    else
                    {
                        flowers = 0;
                    }
                }

                return numOfBouquets;
            }
        }
    }
}
