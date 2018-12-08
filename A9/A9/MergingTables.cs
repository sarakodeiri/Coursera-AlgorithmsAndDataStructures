using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            DisjointSet disjointSet = new DisjointSet(tableSizes);
            List<long> result = new List<long>();

            for (int i = 0; i < sourceTables.Length; i++)
            {
                disjointSet.Union(sourceTables[i], targetTables[i]);
                result.Add(disjointSet.SetCount.Max());
            }

            return result.ToArray();
        }

        public class DisjointSet
        {
            public long[] Parent;
            public long[] SetCount;

            public DisjointSet(long[] tableSizes)
            {
                this.Parent = new long[tableSizes.Length];
                this.SetCount = new long[tableSizes.Length];

                for (int i = 0; i < Parent.Length; i++)
                {
                    Parent[i] = i;
                    SetCount[i] = tableSizes[i];
                }
            }

            public long Find(long i)
            {
                if (Parent[i] == i)
                    return i;
                else
                    return Find(Parent[i]);
            }

            public void Union(long source, long target)
            {
                long sParent = Find(--source);
                long tParent = Find(--target);

                if (sParent == tParent)
                    return;

                Parent[sParent] = tParent;
                SetCount[tParent] += SetCount[sParent];
                SetCount[source] = 0;
            }
        }
    }
}