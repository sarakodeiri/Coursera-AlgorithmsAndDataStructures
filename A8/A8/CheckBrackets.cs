using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            char[] specials = new char[] { '(', ')', '{', '}', '[', ']' };
            var chars = str.ToCharArray();
            List<(char, int)> info = new List<(char, int)>();

            for (int i = 0; i < chars.Length; i++)
                if (specials.Contains(chars[i]))
                    info.Add((chars[i], i));

            var final = IsBalanced(info);
            
            if (!final.Item1)
                return final.Item2 + 1;

            else
                return -1;
        }

        private static (bool, int) IsBalanced(List<(char, int)> info)
        {
            Stack<(char, int)> stack = new Stack<(char, int)>();
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Item1 == '(' || info[i].Item1 == '[' || info[i].Item1 == '{')

                    stack.Push(info[i]);

                else
                {
                    if (stack.Count == 0)
                        return (false, info[i].Item2);

                    char top = stack.Pop().Item1;
                    if ((top == '(' && info[i].Item1 != ')') ||
                        (top == '[' && info[i].Item1 != ']') || (top == '{' && info[i].Item1 != '}'))
                        return (false, info[i].Item2);
                }

            }

            List<(char, int)> stackResults = new List<(char, int)>();
            int n = stack.Count();

            for (int i = 0; i < n; i++)
                stackResults.Add(stack.Pop());
            stackResults.Reverse();

            return n == 0 ? (true, 0) : (false, stackResults[0].Item2);
        }
    }
}
