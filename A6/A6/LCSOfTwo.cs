using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo: Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            int n = seq1.Length;
            int m = seq2.Length;

            int[,] allData = new int[n + 1, m + 1];

            for (int i = 0; i < n + 1; i++)
                allData[i, 0] = 0;

            for (int j = 0; j < m + 1; j++)
                allData[0, j] = 0;

            for (int i = 1; i < n + 1; i++)
                for (int j = 1; j < m + 1; j++)
                {
                    if (seq1[i - 1] == seq2[j - 1])
                        allData[i, j] = 1 + allData[i - 1, j - 1];
                    else
                        allData[i, j] = Math.Max(allData[i, j - 1], allData[i - 1, j]);
                }
            return allData[seq1.Length, seq2.Length];
        }
    }
}
