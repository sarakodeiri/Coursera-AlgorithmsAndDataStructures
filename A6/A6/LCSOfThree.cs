using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfThree: Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            int n = seq1.Length;
            int m = seq2.Length;
            int p = seq3.Length;

            int[,,] allData = new int[n + 1, m + 1, p + 1];

            for (int i = 1; i < n + 1; i++)
                allData[i, 0, 0] = 0;

            for (int j = 1; j < m + 1; j++)
                allData[0, j, 0] = 0;

            for (int k = 1; k < p + 1; k++)
                allData[0, 0, k] = 0;

            for (int i = 1; i < n + 1; i++)
                for (int j = 1; j < m + 1; j++)
                    for (int k = 1; k < p + 1; k++)
                        if (seq1[i - 1] == seq2[j - 1] && seq1[i - 1] == seq3[k - 1])
                            allData[i, j, k] = allData[i - 1, j - 1, k - 1] + 1;
                        else
                            allData[i, j, k] = new[] { allData[i - 1, j, k], allData[i, j - 1, k], allData[i, j, k - 1] }.Max();
                    
            return allData[n, m, p];
        }
    }
}
