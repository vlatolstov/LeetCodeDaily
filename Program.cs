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
            IList<string> d1 = ["cat", "bat", "rat"];
            string s1 = "the cattle was rattled by the battery";
            Console.WriteLine(sol.ReplaceWords(d1, s1));
            IList<string> d2 = ["a", "b", "c"];
            string s2 = "aadsfasf absbs bbab cadsfafs";
            Console.WriteLine(sol.ReplaceWords(d2, s2));
        }
        public class Solution
        {
            public string ReplaceWords(IList<string> dictionary, string sentence)
            {
                Dictionary<char, HashSet<string>> dict = [];

                foreach (string word in dictionary)
                {
                    if (!dict.ContainsKey(word[0])) dict.Add(word[0], []);
                    dict[word[0]].Add(word);
                }

                string[] words = sentence.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    int length = int.MaxValue;

                    if (dict.TryGetValue(word[0], out HashSet<string>? value))
                    {
                        foreach (string root in value)
                        {
                            if (root.Length >= length
                                || root.Length > word.Length) continue;
                            string sub = word[..root.Length];
                            if (sub == root)
                            {
                                length = Math.Min(root.Length, length);
                                words[i] = root;
                            }
                        }
                    }
                }
                return String.Join(' ', words);
            }
        }
    }
}
