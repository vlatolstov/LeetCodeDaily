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
            public long MinimumSteps(string s) {
                long steps = 0;
                int whiteCount = 0;
                char white = '0';

                for (int i = s.Length - 1; i >= 0; i--) {
                    if (s[i] == white) {
                        whiteCount++;
                    }
                    else {
                        steps += whiteCount;
                    }
                }

                return steps;
            }
        }
    }
}
