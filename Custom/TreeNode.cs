using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily.Custom {
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode CreateTree(int?[] values, int index = 0) {
            if (index >= values.Length || values[index] == null) {
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
