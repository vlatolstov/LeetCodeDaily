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
            int[] a = [1, 2, 3];
            sol.Subsets(a);
        }
        public class Solution
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                Queue<(IList<int>, int)> q = [];
                HashSet<IList<int>> res = [];
                q.Enqueue((nums.ToList(), 0));
                
                while (q.Count > 0)
                {
                    int n = q.Count;
                    for (int i = 0; i < n; i++)
                    {
                        var cur = q.Dequeue();
                        var subset = cur.Item1;
                        var index = cur.Item2;
                        res.Add(subset);
                        if (index < subset.Count)
                        {
                            IList<int> newSubset = [];
                            for (int j = 0; j < subset.Count; j++)
                            {
                                if (j != index) newSubset.Add(subset[j]);
                            }
                            q.Enqueue((subset, index + 1));
                            q.Enqueue((newSubset, 0));
                        }
                    }
                }
                return [.. res];
            }
        }
    }
}
