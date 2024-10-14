using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using LeetCodeDaily.Custom;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {
            Solution sol = new();
            Console.WriteLine(sol.MaxKelements([10, 10, 10, 10, 10], 5));
            Console.WriteLine(sol.MaxKelements([1, 10, 3, 3, 3], 3));
        }
        public class Solution {
            public long MaxKelements(int[] nums, int k) {

                var pq = new PriorityQueue<int, int>();

                foreach (int num in nums) {
                    pq.Enqueue(num, -num);
                }

                long score = 0;

                while (k > 0) {
                    
                    int max = pq.Dequeue();
                    score += max;

                    max = (int)Math.Ceiling((decimal)max / 3);
                    pq.Enqueue(max, - max);

                    k--;
                }

                return score;
            }
        }
    }
}
