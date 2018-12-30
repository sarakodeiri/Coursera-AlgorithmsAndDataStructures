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
            InOrderResult = binaryTreeTraversals.InOrder(tree.root);
            for (int i = 1; i < InOrderResult.Count; i++)
                if (InOrderResult[i] < InOrderResult[i - 1])
                    return false;
            
            return RecursiveCheck(tree.root, int.MinValue, int.MaxValue);
        }

        private bool RecursiveCheck(Node root, long min, long max)
        {
            if (root != null)
            {
                if (root.key >= max || root.key < min)
                    return false;
                
                return RecursiveCheck(root.left, min, root.key) && RecursiveCheck(root.right, root.key, max);
            }

            return true;
        }
    }
}
