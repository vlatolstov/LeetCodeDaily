using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using LeetCodeDaily.Custom;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {
        }
        public class Solution {
            public int[] GetMaximumXor(int[] nums, int maximumBit) {

                Stack<int> XORs = [];
                int curXOR = nums[0];
                XORs.Push(curXOR);

                for (int i = 1; i < nums.Length; i++) {
                    curXOR ^= nums[i];
                    XORs.Push(curXOR);
                }

                int targetXOR = (int)Math.Pow(2, maximumBit) - 1;
                int[] result = new int[nums.Length];

                for (int i = 0; i < result.Length; i++) {
                    result[i] = XORs.Pop() ^ targetXOR;
                }

                return result;
            }
        }
    }
}
