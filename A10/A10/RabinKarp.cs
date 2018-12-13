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
            List<long> occurrences = new List<long>();
            int startIdx = 0;
            int foundIdx = 0;
            while ((foundIdx = text.IndexOf(pattern, startIdx)) >= startIdx)
            {
                startIdx = foundIdx + 1;
                occurrences.Add(foundIdx);
            }
            return occurrences.ToArray();
        }


        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            int textLength = T.Length;
            long[] hashesResult = new long[textLength - P + 1];
            string lastSubstring = string.Empty;
            for (int i = textLength - P; i < textLength; i++)
                lastSubstring += T[i];
            hashesResult[textLength - P] = PolyHash(lastSubstring, p, x);
            long y = 1;

            for (int i = 1; i <= P; i++)
                y = (y * x) % p;
            // y = (long)Math.Pow(x, P) % p;

            for (int i = textLength - P - 1; i >= 0; i--)
                hashesResult[i] = (x * hashesResult[i + 1] + T[i] - y * T[i + P]) % p;
            return hashesResult;
        }

        private static long PolyHash(string lastSubstring, long p, long x)
        {
            throw new NotImplementedException();
        }
    }
}
