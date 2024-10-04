using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {
            Solution sol = new();
            Console.WriteLine(sol.DividePlayers([3, 2, 5, 1, 3, 4]));
            Console.WriteLine(sol.DividePlayers([3, 4]));
            Console.WriteLine(sol.DividePlayers([1, 1, 2, 3]));
        }
        public class Solution {
            public long DividePlayers(int[] skill) {
                int totalSkillSum = 0;
                int teamsCount = skill.Length / 2;

                foreach (int s in skill)
                    totalSkillSum += s;

                if (totalSkillSum % teamsCount != 0)
                    return -1;

                int teamSkill = totalSkillSum / teamsCount;
                Dictionary<int, int> counts = [];
                long chemistry = 0;

                foreach (int a in skill) {
                    int b = teamSkill - a;

                    if (counts.TryGetValue(b, out int count)) {
                        if (count == 1) {
                            counts.Remove(b);
                        }
                        else {
                            counts[b]--;
                        }
                        chemistry += a * b;
                    }
                    else {
                        if (!counts.TryAdd(a, 1)) {
                            counts[a]++;
                        }
                    }
                }

                return counts.Count == 0 ? chemistry : -1;
            }
        }
    }
}
