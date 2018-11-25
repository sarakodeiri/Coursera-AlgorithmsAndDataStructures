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
            //var chars = str.ToCharArray();
            List<(char, int)> info = new List<(char, int)>();

            for (int i = 0; i < str.Length; i++)
                if (specials.Contains(str[i]))
                    info.Add((str[i], i));

            return IsBalanced(info).Item1 ? -1 : IsBalanced(info).Item2 + 1;
        }

        private static (bool, int) IsBalanced(List<(char, int)> info)
        {
            Stack<(char, int)> stack = new Stack<(char, int)>();
            for (int i = 0; i < info.Count; i++)
            {
                char current = info[i].Item1;

                if (current == '(' || current == '[' || current == '{')
                    stack.Push(info[i]);

                else
                {
                    if (stack.Count == 0)
                        return (false, info[i].Item2);

                    char top = stack.Pop().Item1;
                    if ((top == '(' && current != ')') ||
                        (top == '[' && current != ']') || (top == '{' && current != '}'))
                        return (false, info[i].Item2);
                }

            }

            return stack.Count == 0 ? (true, 0) : (false, stack.Last().Item2);
        }
    }
}
