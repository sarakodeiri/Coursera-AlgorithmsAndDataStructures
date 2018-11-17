using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long BinaryOperater(long a, char op, long b)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;

                default:
                    return -1;
            }
        }

        public (long, long) MinAndMax(int i, int j, List<char> op, long[,] min, long[,] max)
        {
            long finalMin = long.MaxValue;
            long finalMax = long.MinValue;
            for (int k = i; k < j; k++)
            {
                long a = BinaryOperater(max[i, k], op[k], max[k + 1, j]);
                long b = BinaryOperater(max[i, k], op[k], min[k + 1, j]);
                long c = BinaryOperater(min[i, k], op[k], max[k + 1, j]);
                long d = BinaryOperater(min[i, k], op[k], min[k + 1, j]);
                var allData = new[] { a, b, c, d };

                finalMin = Math.Min(allData.Min(), finalMin);
                finalMax = Math.Max(allData.Max(), finalMax);
            }

            return (finalMin, finalMax);
        }

        public long Solve(string expression)
        {
            //expression.ToCharArray();
            int n = expression.Length;
            List<long> digits = new List<long>();
            List<char> ops = new List<char>();

            for (int i = 0; i < n; i++) //separating numbers and operators
                if (i % 2 == 0)
                    digits.Add(long.Parse(expression[i].ToString()));
                else
                    ops.Add(expression[i]);
            
            int m = digits.Count;

            long[,] minData = new long[m, m];
            long[,] maxData = new long[m, m];

            for (int i = 0; i < m; i++)
            {
                minData[i, i] = digits[i];
                maxData[i, i] = digits[i];
            }

            //Parantheses part of the pseudo code
            for (int s = 0; s < m; s++)
                for (int i = 0; i < m - s - 1; i++)
                {
                    int j = i + s + 1;
                    var temp = MinAndMax(i, j, ops, minData, maxData);
                    minData[i, j] = temp.Item1;
                    maxData[i, j] = temp.Item2;
                }

            return maxData[0, m - 1];
        }
    }
}
