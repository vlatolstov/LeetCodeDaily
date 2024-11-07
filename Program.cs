using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using LeetCodeDaily.Custom;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {
        }
        public class Solution {

            public int LargestCombination(int[] candidates) {
                int[] bitCounts = new int[24];

                foreach (int candidate in candidates) {
                    int num = candidate;
                    int sign = 0;

                    while (num > 0) {
                        bitCounts[sign] += num % 2;
                        num /= 2;
                        sign++;
                    }
                }

                int maxLength = 0;

                foreach (int bits in bitCounts) {
                    maxLength = Math.Max(maxLength, bits);
                }

                return maxLength;
            }
        }
    }
}
