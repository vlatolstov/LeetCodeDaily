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
            int[] a1 = [4, 1, 5, 9], b1 = [1, 3, 2, 6];
            Console.WriteLine(sol.MinMovesToSeat(a1, b1));
        }
        public class Solution
        {
            public int MinMovesToSeat(int[] seats, int[] students)
            {
                return seats
                    .OrderBy(seat => seat)
                    .Zip(students.OrderBy(student => student), (seat, student) => Math.Abs(seat - student))
                    .Sum();
            }
        }
    }
}
