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
            Console.WriteLine(string.Join(", ", sol.MaximumBeauty([[10, 1000]], [5])));
        }
        public class Solution {
            public int[] MaximumBeauty(int[][] items, int[] queries) {

                var ordered = items
                    .GroupBy(item => item[0])
                    .Select(item => new int[] { item.Key, item.Max(x => x[1]) })
                    .OrderBy(item => item[0])
                    .ToArray();

                int best = ordered[0][1];

                for (int i = 1; i < ordered.Length; i++) {
                    if (ordered[i][1] > best) {
                        best = ordered[i][1];
                    }
                    else {
                        ordered[i][1] = best;
                    }
                }

                int[] answer = new int[queries.Length];

                for (int i = 0; i < queries.Length; i++) {
                    answer[i] = BinarySearch(0, ordered.Length - 1, queries[i]);
                }

                return answer;



                int BinarySearch(int left, int right, int price) {

                    if (left <= right) {

                        int mid = (left + right) / 2;

                        if (ordered[mid][0] == price) {
                            return ordered[mid][1];
                        }

                        if (mid == 0 &&  ordered[mid][0] > price) {
                            return 0;
                        }

                        if (ordered[mid][0] > price && ordered[mid - 1][0] < price) {
                            return ordered[mid - 1][1];
                        }

                        if (mid == ordered.Length - 1) {
                            return ordered[mid][1];
                        }

                        if (ordered[mid][0] > price) {
                            return BinarySearch(left, mid - 1, price);
                        }
                        else {
                            return BinarySearch(mid + 1, right, price);
                        }
                    }
                    else {
                        return 0;
                    }

                }
            }
        }
    }
}
