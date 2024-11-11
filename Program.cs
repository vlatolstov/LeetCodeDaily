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
            Console.WriteLine(sol.PrimeSubOperation([4, 9, 6, 10]));
            Console.WriteLine(sol.PrimeSubOperation([6, 8, 11, 12]));
            Console.WriteLine(sol.PrimeSubOperation([5, 8, 3]));
        }
        public class Solution {

            public bool PrimeSubOperation(int[] nums) {

                if (nums == null) {
                    return false;
                }

                if (nums.Length <= 1) {
                    return true;
                }

                //problem restrictions - nums[i] <= 1000'
                Primes primes = new(1000);
                var hs = primes.GetPrimesHashSet();

                int cur = 1;

                for (int i = 0; i < nums.Length;) {
                    int dif = nums[i] - cur;

                    if (dif < 0) {
                        return false;
                    }

                    if (hs.Contains(dif) || dif == 0) {
                        i++;
                        cur++;
                    }
                    else {
                        cur++;
                    }
                }

                return true;
            }

        }

        public class Primes {
            private readonly int[] _primes;
            private readonly int _n;

            /// <summary>
            /// Creates object that stores prime numbers up to some integer.
            /// </summary>
            /// <param name="n">Generates numbers up to this point.</param>
            public Primes(int n) {
                //Sieve of Sundaram
                List<int> primes = [];
                int nNew = (int)Math.Sqrt(n);
                int[] marked = new int[n / 2 + 500];

                for (int i = 1; i < (nNew - 1) / 2; i++) {
                    for (int j = (i * (i + 1)) << 1; j < n / 2; j = j + 2 * i + 1) {
                        marked[j] = 1;
                    }
                }

                primes.Add(2);

                for (int i = 1; i < n / 2; i++) {
                    if (marked[i] == 0) {
                        primes.Add(2 * i + 1);
                    }
                }
                _n = n;
                _primes = [.. primes];
            }

            public HashSet<int> GetPrimesHashSet() {
                return new HashSet<int>(_primes);
            }

            public int NearestLesserPrime(int num) {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(num, _n);
                return BinarySearch(0, _primes.Length - 1, num);
            }

            private int BinarySearch(int l, int r, int num) {
                if (l <= r) {

                    int mid = (l + r) / 2;

                    if (mid == 0 || mid == _primes.Length - 1) {
                        return _primes[mid];
                    }

                    if (_primes[mid] == num) {
                        return _primes[mid - 1];
                    }

                    if (num > _primes[mid] && num < _primes[mid + 1]) {
                        return _primes[mid];
                    }

                    if (num > _primes[mid]) {
                        return BinarySearch(mid + 1, r, num);
                    }
                    else {
                        return BinarySearch(l, mid - 1, num);
                    }
                }
                return -1;
            }
        }
    }
}
