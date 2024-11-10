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

            public int MinimumSubarrayLength(int[] nums, int k) {
                int left = 0, right = 0;
                int minLength = int.MaxValue;
                int[] bitCounts = new int[32];

                while (right < nums.Length) {
                    ChangeBitCounts(bitCounts, nums[right], 1);

                    while (left <= right && ConvertBitCountToOR(bitCounts) >= k) {
                        minLength = Math.Min(minLength, right - left + 1);

                        ChangeBitCounts(bitCounts, nums[left], -1);
                        left++;
                    }

                    right++;
                }

                return minLength == int.MaxValue ? -1 : minLength;
            }

            private void ChangeBitCounts(int[] bitCounts, int num, int change) {
                for (int pos = 0; pos < 32; pos++) {
                    if (((num >> pos) & 1) == 1) {
                        bitCounts[pos] += change;
                    }
                }
            }

            private int ConvertBitCountToOR(int[] bitCounts) {
                int num = 0;

                for (int pos = 0; pos < 32; pos++) {
                    if (bitCounts[pos] != 0) {
                        num |= 1 << pos;
                    }
                }

                return num;
            }
        }
    }
}
