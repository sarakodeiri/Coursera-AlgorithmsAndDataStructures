using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBSTHard : Processor
    {
        public IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            if (nodes.Length == 0)
                return true;
            Tree tree = new Tree(nodes);
            BinaryTreeTraversals binaryTreeTraversals = new BinaryTreeTraversals("TD1");
            List<long> InOrderResult = new List<long>();
            InOrderResult = binaryTreeTraversals.InOrder(tree.root, InOrderResult);
            for (int i = 1; i < InOrderResult.Count; i++)
                if (InOrderResult[i] < InOrderResult[i - 1])
                    return false;

            foreach (Node n in tree.allNodes)
                if (n.left != null)
                    if (n.left.key >= n.key)
                      return false;
            return true;
        }
    }
}
