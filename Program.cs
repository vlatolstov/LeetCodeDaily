using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {

        }
        public class Solution {
            public int MinAddToMakeValid(string s) {

                int open = 0;
                int close = 0;

                foreach (char c in s) {

                    if (c == '(') {
                        open++;
                    }

                    else {

                        if (open > 0)
                            open--;
                        else
                            close++;
                    }
                }

                return open + close;
            }
        }
    }
}
