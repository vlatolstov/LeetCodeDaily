using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily.Custom {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }

        public static ListNode CreateLinkedList(int[] vals) {
            if (vals.Length == 0)
                return null;

            ListNode head = new(vals[0]);
            ListNode cur = head;

            for (int i = 1; i < vals.Length; i++) {
                cur.next = new(vals[i]);
                cur = cur.next;
            }

            return head;
        }
    }
}
