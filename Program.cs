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
            Solution sol = new();

            string[] words1 = ["dog", "cat", "dad", "good"];
            char[] letters1 = ['a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o'];
            int[] scores1 = [1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

            Console.WriteLine(sol.MaxScoreWords(words1, letters1, scores1));

        }
        public class Solution
        {
            public int MaxScoreWords(string[] words, char[] letters, int[] score)
            {
                var list = BuildStringsWithPossibleLetters([], [], 0, words, CountLetters(letters));

                int max = 0;
                foreach (var possible in list)
                {
                    string total = String.Concat(possible);
                    max = Math.Max(max, TotalScoreOfString(total, score));
                }

                return max;
            }

            int[] CountLetters(char[] letters)
            {
                int[] count = new int[26];
                for (int i = 0; i < letters.Length; i++) count[letters[i] - 'a']++;
                return count;
            }
            IList<IList<string>> BuildStringsWithPossibleLetters(
                IList<IList<string>> allPossible,
                IList<string> cur,
                int word, 
                string[] words, 
                int[] count)
            {
                if (word == words.Length)
                {
                    allPossible.Add(cur);
                    return allPossible;
                }

                BuildStringsWithPossibleLetters(allPossible, cur, word + 1, words, count);

                if (WordCanBeAdded(words[word], count, out int[] newCount))
                {
                    count = newCount;
                    cur.Add(words[word]);

                    BuildStringsWithPossibleLetters(allPossible, new List<string>(cur), word + 1, words, count);

                    RestoreCount(words[word], count);
                    cur.RemoveAt(cur.Count - 1);
                }

                return allPossible;
            }

            bool WordCanBeAdded(string word, int[] count, out int[] newCount)
            {
                newCount = new int[count.Length];
                Array.Copy(count, newCount, count.Length);

                foreach (char c in word)
                {
                    int i = c - 'a';
                    if (--newCount[i] < 0) return false;
                }
                return true;
            }

            void RestoreCount(string word, int[] count)
            {
                foreach (char c in word) count[c - 'a']++;
            }

            int TotalScoreOfString(string s, int[] scores)
            {
                int sum = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    int score = scores[c - 'a'];
                    sum += score;
                }
                return sum;
            }
        }
    }
}
