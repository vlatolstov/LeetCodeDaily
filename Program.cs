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
            public bool EvaluateTree(TreeNode root)
            {
                return root.val switch
                {
                    0 => false,
                    1 => true,
                    2 => EvaluateTree(root.left) || EvaluateTree(root.right),
                    3 => EvaluateTree(root.left) && EvaluateTree(root.right),
                    _ => false,
                };
            }
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode CreateTree(int?[] values, int index = 0)
        {
            if (index >= values.Length || values[index] == null)
            {
                return null;
            }
            TreeNode node = new TreeNode();
            node.left = CreateTree(values, 2 * index + 1);
            node.right = CreateTree(values, 2 * index + 2);
            node.val = (int)values[index];
            return node;
        }
    }
}
