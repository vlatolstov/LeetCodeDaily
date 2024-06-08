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
            int[] a = [422, 224, 184, 178, 189, 290, 196, 236, 281, 464, 351, 193, 49, 76, 0, 298, 193, 176, 158, 514, 312, 143, 475, 322, 206, 67, 524, 424, 76, 99, 473, 256, 364, 292, 141, 186, 190, 69, 433, 205, 93, 72, 476, 393, 512, 468, 160, 201, 226, 394, 47, 140, 389, 51, 142, 135, 349, 244, 16, 356, 440, 188, 16, 133, 58, 394, 7, 517, 56, 480, 400, 146, 169, 439, 102, 374, 370, 242, 4, 264, 120, 218, 196, 173, 215, 411, 501, 321, 319, 147, 369, 458, 319, 174, 379, 46, 129, 353, 330, 101];
            Console.WriteLine(sol.CheckSubarraySum(a, 479));
            int[] b = [23, 2, 6, 4, 7];
            Console.WriteLine(sol.CheckSubarraySum(b, 13));
            int[] c = [405, 504, 203, 96, 43, 50, 214, 327, 120, 345, 33, 314, 377, 62, 431, 379, 114, 208, 106, 345, 391, 513, 9, 405, 452, 186, 295, 33, 423, 122, 355, 311, 192, 429, 320, 360, 85, 96, 32, 258, 407, 71, 436, 370, 365, 199, 443, 521, 262, 232, 355, 241, 250, 10, 258, 324, 335, 446, 474, 385, 74, 101, 111, 162, 349, 149, 51, 399, 371, 139, 199, 264, 118, 155, 134, 518, 388, 113, 520, 441, 384, 449, 14, 104, 267, 92, 477, 50, 505, 368, 466, 519, 105, 443, 31, 21, 485, 146, 115, 94];
            Console.WriteLine(sol.CheckSubarraySum(c, 337));
        }
        public class Solution
        {
            public bool CheckSubarraySum(int[] nums, int k)
            {
                if (nums == null || nums.Length < 2) return false;
                int l = 0, r = 1, sum = nums[l] + nums[r];
                bool hasGood = false;
                BFS(sum, l, r);
                return hasGood;

                void BFS(int sum, int l, int r)
                {
                    if (sum % k == 0 || sum == 0) hasGood = true;
                    if (hasGood || r >= nums.Length - 1 || l >= r) return;

                    sum += nums[r + 1];
                    BFS(sum - nums[l], l + 1, r + 1);
                    BFS(sum, l, r + 1);
                }
            }
        }
    }
}
