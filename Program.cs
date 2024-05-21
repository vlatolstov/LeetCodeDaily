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
                Queue<IList<int>> q = [];
                q.Enqueue([]);
                int index = 0;

                while (q.Count > 0 && index < nums.Length)
                {
                    int n = q.Count;
                    for (int i = 0; i < n; i++)
                    {
                        var cur = q.Dequeue();
                        var next = new List<int>(cur) { nums[index] };

                        q.Enqueue(cur);
                        q.Enqueue(next);
                    }
                    index++;
                }

                List<IList<int>> res = [];
                while (q.Count > 0) res.Add(q.Dequeue());
                return res;
            }
        }
    }
}
