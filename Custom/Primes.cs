using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily.Custom
{
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
