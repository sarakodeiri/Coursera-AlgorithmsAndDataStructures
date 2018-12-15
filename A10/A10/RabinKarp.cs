using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class RabinKarp : Processor
    {
        public RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            List<long> positions = new List<long>();
            long pHash = PolyHash(pattern, 0, pattern.Length);
            long[] hashSet = PreComputeHashes(text, pattern.Length,
                HashingWithChain.BigPrimeNumber, HashingWithChain.ChosenX);
            for (int i = 0; i < hashSet.Length; i++)
                if (hashSet[i] == pHash)
                    if (String.Equals(text.Substring(i, pattern.Length), pattern))
                        positions.Add(i);
            return positions.ToArray();
        }

        public static long[] PreComputeHashes(
            string T,
            int P, 
            long p, 
            long x)
        {
            int textLength = T.Length;
            long[] hashesResult = new long[textLength - P + 1];
            hashesResult[textLength - P] = PolyHash(T, T.Length - P, P, p, x);

            long y = 1;
            for (int i = 1; i <= P; i++)
                y = (y * x) % p;

            for (int i = textLength - P - 1; i >= 0; i--)
                hashesResult[i] = ((x * hashesResult[i + 1] + T[i] - y * T[i + P]) % p + p) % p;
            return hashesResult;
        }

        public static long PolyHash(
            string str, int start, int count,
            long p = 1000000007, long x = 263)
        {
            long hash = 0;
            for (int i = start + count - 1; i >= start; i--)
                hash = (hash * x + str[i]) % p;

            return hash;
        }
    }
}
