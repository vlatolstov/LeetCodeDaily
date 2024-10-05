using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {

        }
        public class Solution {
            public bool CheckInclusion(string s1, string s2) {

                if (s1.Length > s2.Length) {
                    return false;
                }

                int[] counts = new int[26];

                for (int i = 0; i < s1.Length; i++) {
                    counts[s1[i] - 'a']++;
                    counts[s2[i] - 'a']--;
                }

                if (IsValid(counts))
                    return true;

                for (int i = s1.Length; i < s2.Length; i++) {
                    counts[s2[i] - 'a']--;
                    counts[s2[i - s1.Length] - 'a']++;

                    if (IsValid(counts))
                        return true;
                }

                return false;
            }

            private bool IsValid(int[] counts) {
                foreach (int i in counts) {
                    if (i != 0)
                        return false;
                }
                return true;
            }
        }
    }
}
