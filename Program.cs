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
            public bool CanSortArray(int[] nums) {
                if (nums.Length == 1)
                    return true;

                Stack<Segment> segments = [];

                for (int i = 0; i < nums.Length; i++) {
                    int num = nums[i];
                    int setBitCount = CountSetBits(nums[i]);

                    if (!segments.TryPop(out Segment top)) {
                        segments.Push(new(num, num, setBitCount));
                    }
                    else {
                        if (top.setBits == setBitCount) {
                            top.min = Math.Min(top.min, num);
                            top.max = Math.Max(top.max, num);
                            segments.Push(top);
                        }
                        else {
                            segments.Push(top);
                            segments.Push(new(num, num, setBitCount));
                        }
                    }
                }

                if (segments.Count == 0)
                    return false;

                var cur = segments.Pop();

                while (segments.Count > 0) {
                    var top = segments.Pop();

                    if (cur.min < top.max) {
                        return false;
                    }

                    cur = top;
                }

                return true;
            }

            private int CountSetBits(int num) {

                int count = 0;

                while (num > 0) {
                    if (num % 2 == 1)
                        count++;
                    num /= 2;
                }

                return count;
            }

            public struct Segment(int min, int max, int setBits) {
                public int min = min;
                public int max = max;
                public int setBits = setBits;
            }
        }
    }
}
