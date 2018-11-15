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

        public long Solve(string expression)
        {
            expression.ToCharArray();
            int n = expression.Length;
            List<long> digits = new List<long>();
            List<char> ops = new List<char>();

            for (int i = 0; i < n; i++) //separating numbers and operators
                if (i % 2 == 0)
                    digits.Add(long.Parse(expression[i].ToString()));
                else
                    ops.Add(expression[i]);
            
            int m = digits.Count;
            long[,] minTable = new long[m + 1, m + 1];
            long[,] maxTable = new long[m + 1, m + 1];

            for (int i = 0; i < m + 1; i++)
                for (int j = 0; j < m + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        minTable[i, j] = 0;
                        maxTable[i, j] = 0;
                    }

                    minTable[i, i] = digits[i];
                    maxTable[i, i] = digits[i];
                }

            for (int s = 1; s <= m - 1; s++)
                for (int i = 1; i <= m - s; i++)
                {
                    int j = i + s;
                    var temp = MinAndMax(i, j, ops, minTable, maxTable);
                    minTable[i, j] = temp.Item1;
                    maxTable[i, j] = temp.Item2;
                }

            return maxTable[0, m - 1];
        }

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
    }
}
