using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class EditDistance: Processor
    {
        public EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            int[,] distance = new int[n + 1, m + 1];

            for (int i = 0; i < n + 1; i++)
                distance[i, 0] = i;

            for (int j = 0; j < m + 1; j++)
                distance[0, j] = j;

            for (int j = 1; j < m+1; j++)
                for (int i = 1; i < n+1; i++)
                {
                    int insert = distance[i, j - 1] + 1;
                    int delete = distance[i - 1, j] + 1;
                    int match = distance[i - 1, j - 1];
                    int mismatch = distance[i - 1, j - 1] + 1;

                    if (str1[i - 1] != str2[j - 1])
                        distance[i, j] = new[] {insert, delete, mismatch}.Min();
                    else
                        distance[i, j] = new[] {insert, delete, match}.Min();

                }

            return distance[n, m];
        }

    }
}
