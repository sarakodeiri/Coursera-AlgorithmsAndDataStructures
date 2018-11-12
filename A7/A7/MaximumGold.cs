using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximumGold : Processor
    {
        public MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            int n = goldBars.Length;
            long[,] value = new long[W + 1, n + 1];

            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= W; j++)
                    if (i==0 || j==0)
                        value[0, i] = 0;
            
            for (int i = 1; i < n + 1; i++)
                for (int w = 1; w < W + 1; w++)
                    if (goldBars[i - 1] <= w)
                        value[w, i] = Math.Max(value[w, i - 1], value[w - goldBars[i - 1], i - 1] + goldBars[i - 1]);
                    else
                        value[w, i] = value[w, i - 1];
            
            return value[W, n];
        }
    }
}
