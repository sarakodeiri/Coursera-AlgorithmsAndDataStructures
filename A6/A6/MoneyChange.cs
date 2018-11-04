using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public static long Solve(long n)
        {
            long[] minCoins = new long[n+1];
            for (int i = 0; i < n+1; i++)
                minCoins[i] = long.MaxValue;
            minCoins[0] = 0;

            for (int i = 1; i < n+1; i++)
                for (int j = 0; j < COINS.Length; j++)
                    if (i - COINS[j] >= 0 && COINS[j] <= n && minCoins[i - COINS[j]] < minCoins[i])
                        minCoins[i] = minCoins[i - COINS[j]] + 1;
            
            return minCoins[n];
        }
    }
}
