using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class SetWithRageSums : Processor
    {
        public SetWithRageSums(string testDataName) : base(testDataName)
        {
            CommandDict =
                        new Dictionary<char, Func<string, SplayTree, string>>()
                        {
                            ['+'] = Add,
                            ['-'] = Del,
                            ['?'] = Find,
                            ['s'] = Sum
                        };
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public readonly Dictionary<char, Func<string, SplayTree, string>> CommandDict;

        protected const long M = 1_000_000_001;

        protected long X = 0;

        protected List<long> Data;

        SplayTree splayTree;

        public string[] Solve(string[] lines)
        {
            splayTree = new SplayTree();
            X = 0;
            Data = new List<long>();
            List<string> result = new List<string>();
            foreach(var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                var output = CommandDict[cmd](args, splayTree); //
                if (null != output)
                    result.Add(output);
            }
            return result.ToArray();
        }

        private long Convert(long i)
            => i = (i + X) % M;       

        private string Add(string arg, SplayTree splayTree)
        {
            long i = Convert(long.Parse(arg));
            splayTree.Insert(i);

            return null;
        }

        private string Del(string arg, SplayTree splayTree)
        {
            long i = Convert(long.Parse(arg));
            splayTree.Delete(i);


            return null;
        }

        private string Find(string arg, SplayTree splayTree)
        {
            long i = Convert(int.Parse(arg));
            var findResult = splayTree.Find(i);
            if (findResult != null)
            {
                if (findResult.Key == i)
                    return "Found";
                else
                    return "Not found";
            }
            return "Not found";
        }

        private string Sum(string arg, SplayTree splayTree)
        {
            var toks = arg.Split();
            long l = Convert(long.Parse(toks[0]));
            long r = Convert(long.Parse(toks[1]));

            long sum = 0;

            var lowerBound = splayTree.Find(l);
            while (!(lowerBound.Key > r))
            {
                sum += lowerBound.Key;
                lowerBound = splayTree.Next(lowerBound);
            }
            

            X = sum;

            return sum.ToString();
        }
    }
}
