using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using LeetCodeDaily.Custom;
using System.ComponentModel.Design;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {

        }
        public class Solution {
            private List<int> levelSums;
            public TreeNode ReplaceValueInTree(TreeNode root) {
                levelSums = [];

                CalculateLevelSums(root, 0);

                ChangeValue(root, 0, 0);

                return root;
            }

            private void CalculateLevelSums(TreeNode root, int depth) {
                if (root == null)
                    return;

                if (depth >= levelSums.Count) {
                    levelSums.Add(root.val);
                }
                else {
                    levelSums[depth] += root.val;
                }

                CalculateLevelSums(root.left, depth + 1);
                CalculateLevelSums(root.right, depth + 1);
            }

            private void ChangeValue(TreeNode root, int value, int depth) {
                if (root == null)
                    return;

                root.val = value;

                int nextValue = depth + 1 < levelSums.Count ? levelSums[depth + 1] : 0;
                nextValue -= root.left == null ? 0 : root.left.val;
                nextValue -= root.right == null ? 0 : root.right.val;

                ChangeValue(root.left, nextValue, depth + 1);
                ChangeValue(root.right, nextValue, depth + 1);
            }
        }
    }
}
