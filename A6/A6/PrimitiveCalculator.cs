using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator: Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public void MinimumSteps(long n, List<long> Steps)
        {
            var WhichOnes = new List<double>() { n - 1, n / 2, n / 3};
            WhichOnes.Where(x => (int)x == x);
            Steps.Add(Steps[(int)WhichOnes.Min()] + 1);
        }

        public long[] Solve(long n)
        {
            var steps = new List<long>() { 0, 0 };
            for (int i = 2; i <= n; i++)
                MinimumSteps(i, steps);
            //Write your code here
            return new long[] { 0 };
        }
    }
}
