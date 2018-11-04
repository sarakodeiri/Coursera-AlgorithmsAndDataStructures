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

        public static void MinimumSteps(long n, List<long> Steps) //method for creating an array with the min steps for each number
        {
            //var WhichOnes = new List<long>();
            List<(long, long)> WhichOnes = new List<(long, long)>();

            if (n % 3 == 0)
                WhichOnes.Add((n / 3, Steps[(int)n/3]));
            if (n % 2 == 0)
                WhichOnes.Add((n / 2, Steps[(int)n / 2]));
            WhichOnes.Add((n - 1, Steps[(int)n-1]));

            List<(long, long)> bikhod = WhichOnes.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToList();
           // (long, long) blah = bikhod[0];
            Steps.Add(bikhod[0].Item2 + 1);
        } 

        public static long[] Solve(long n)
        {
            var steps = new List<long>() { 0, 0 };
            for (int i = 2; i <= n; i++)
                MinimumSteps(i, steps);
            List<long> actionHistory = new List<long>();
            var tempList = new double[] {double.MaxValue, double.MaxValue, double.MaxValue };
            actionHistory.Add(n);

            do
            {
                if (n%3 == 0)
                    tempList[0] = steps[(int)n / 3];

                if (n%2 == 0)
                    tempList[1] = steps[(int)n / 2];

                tempList[2] = n - 1;

                int minIndex = Array.IndexOf(tempList, tempList.Min());

                switch (minIndex)
                {
                    case 0: actionHistory.Add(n / 3); n /= 3; break;
                    case 1: actionHistory.Add(n / 2); n /= 2; break;
                    case 2: actionHistory.Add(n - 1); n--; break;
                }
            } while (n != 1);

            actionHistory.Reverse();

            return actionHistory.ToArray();

        }
    }
}
