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
            
        }
        public class Solution
        {
            public IList<string> CommonChars(string[] words)
            {
                Dictionary<char, int> d = [];

                for (int i = 0; i < words[0].Length; i++) if (!d.TryAdd(words[0][i], 1)) d[words[0][i]]++;

                for (int i = 1; i < words.Length; i++)
                {
                    var temp = new Dictionary<char, int>();

                    for (int j = 0; j < words[i].Length; j++) if (!temp.TryAdd(words[i][j], 1)) temp[words[i][j]]++;

                    foreach (var key in d.Keys)
                    {
                        if (!temp.TryGetValue(key, out int value)) d.Remove(key);
                        else d[key] = Math.Min(d[key], value);
                    }
                }

                List<string> res = [];

                foreach (var kvp in d)
                {
                    for (int i = 0; i < kvp.Value; i++)
                    {
                        res.Add(kvp.Key.ToString());
                    }
                }

                return res;
            }
        }
    }
}
