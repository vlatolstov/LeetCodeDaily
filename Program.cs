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

        }
        public class Solution
        {
            const int mod = 1000000007;
            public int CheckRecord(int n)
            {
                if (n == 1) return 3;

                long[,,] dp = new long[n + 1, 2, 3];
                dp[0, 0, 0] = 1;

                for (int i = 1; i <= n; i++)
                    for (int A = 0; A <= 1; A++)
                        for (int L = 0; L < 3; L++)
                        {
                            dp[i, A, 0] = (dp[i, A, 0] + dp[i - 1, A, L]) % mod;
                            if (A > 0) dp[i, A, 0] = (dp[i, A, 0] + dp[i - 1, A - 1, L]) % mod;
                            if (L < 2) dp[i, A, L + 1] = (dp[i, A, L + 1] + dp[i - 1, A, L]) % mod;
                        }

                long res = 0;

                for (int A = 0; A <= 1; A++)
                    for (int L = 0; L < 3; L++)
                        res = (res + dp[n, A, L]) % mod;

                return (int)res;
            }
        }
    }
}
