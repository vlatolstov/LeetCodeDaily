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
            Console.WriteLine(string.Join(", ", sol.MaximumBeauty([[1, 2], [3, 2], [2, 4], [5, 6], [3, 5]], [1, 2, 3, 4, 5, 6])));
        }
        public class Solution {
            public int[] MaximumBeauty(int[][] items, int[] queries) {

                int n = 0;
                foreach (var item in items) {
                    n = Math.Max(n, item[0]);
                }

                int[] bestBeautyForPrice = new int[n + 1];

                foreach (var item in items) {
                    int price = item[0];
                    int beauty = item[1];
                    bestBeautyForPrice[price] = beauty;
                }

                int bestPrice = bestBeautyForPrice[0];

                for (int i = 1; i < bestBeautyForPrice.Length; i++) {
                    if (bestBeautyForPrice[i] < bestPrice) {
                        bestBeautyForPrice[i] = bestPrice;
                    }
                    else {
                        bestPrice = bestBeautyForPrice[i];
                    }
                }

                int[] answer = new int[queries.Length];

                for (int q = 0; q < queries.Length; q++) {
                    if (queries[q] > n) {
                        answer[q] = bestBeautyForPrice[n];
                    }
                    else {
                        answer[q] = bestBeautyForPrice[queries[q]];
                    }
                }

                return answer;
            }
        }
    }
}
