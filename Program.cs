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
            public long KthLargestLevelSum(TreeNode root, int k) {

                List<long> sums = [];
                Queue<TreeNode> q = [];
                q.Enqueue(root);

                while (q.Count > 0) {
                    int size = q.Count;
                    long sum = 0;

                    for (int i = 0; i < size; i++) {
                        var curNode = q.Dequeue();
                        sum += curNode.val;

                        if (curNode.left != null)
                            q.Enqueue(curNode.left);

                        if (curNode.right != null)
                            q.Enqueue(curNode.right);
                    }

                    sums.Add(sum);
                }

                if (sums.Count < k)
                    return -1;

                return sums.OrderByDescending(x => x).ElementAt(k - 1);
            }
        }
    }
}
