using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);


        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            LinkedList<string>[] data = new LinkedList<string>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                data[i] = new LinkedList<string>();

            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg, data, bucketCount);
                        break;
                    case "del":
                        Delete(arg, data, bucketCount);
                        break;
                    case "find":
                        result.Add(Find(arg, data, bucketCount));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg), data));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str,  int bucket,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
                hash = (hash * x + str[i]) % p;

            return (hash + 3 * bucket) % bucket;
        }
        /// ??????
        public static long AdvPolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
                  hash = (hash * x + str[i]) % p;

            return (hash + 3*count) % count;
        }
        /// ?????????
        public void Add(string str, LinkedList<string>[] data, long bucketCount)
        {
            long hashed = PolyHash(str, (int)bucketCount);
            if (!data[hashed].Contains(str))
                data[hashed].AddFirst(str);
        }

        public string Find(string str, LinkedList<string>[] data, long bucketCount)
        {
            long hashed = PolyHash(str, (int)bucketCount);
            if (data[hashed].Contains(str))
                return "yes";
            return "no";
        }

        public void Delete(string str, LinkedList<string>[] data, long bucketCount)
        {
            long hashed = PolyHash(str, (int)bucketCount);
            if (data[hashed].Contains(str))
                data[hashed].Remove(str);
        }

        public string Check(int i, LinkedList<string>[] data)
        {
            if (data[i].Count == 0)
                return "-";

            string result = string.Empty;
            foreach (string c in data[i])
                result += (c + " ");

            return result.Trim();
        }
    }
}
