using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LeetCodeDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var a = TreeNode.CreateTree([1, 3, 3, 3, 2]);
            var b = TreeNode.CreateTree([1, 2, null, 2, null, 2]);
            var c = TreeNode.CreateTree([1, 1, 1]);
            sol.RemoveLeafNodes(a, 3);
            sol.RemoveLeafNodes(b, 2);
            sol.RemoveLeafNodes(c, 1);
        }
        public class Solution
        {
            public TreeNode RemoveLeafNodes(TreeNode root, int target)
            {
                void PostOrderTraversal(TreeNode node)
                {
                    if (node == null) return;
                    PostOrderTraversal(node.left);
                    PostOrderTraversal(node.right);
                    if (node.left != null &&
                        (node.left.left == null && node.left.right == null && node.left.val == target)) node.left = null;
                    if (node.right != null &&
                        (node.right.right == null && node.right.left == null && node.right.val == target)) node.right = null;
                }
                PostOrderTraversal(root);
                if (root.left == null && root.right == null && root.val == target) root = null;
                return root;
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
