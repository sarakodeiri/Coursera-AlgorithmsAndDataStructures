using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBST : Processor
    {
        public IsItBST(string testkeyName) : base(testkeyName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            Tree tree = new Tree(nodes);

            BinaryTreeTraversals binaryTreeTraversals = new BinaryTreeTraversals("TD1");
            List<long> InOrderResult = new List<long>();
            InOrderResult = binaryTreeTraversals.InOrder(tree.root, InOrderResult);
            for (int i=1; i<InOrderResult.Count; i++)
                if (InOrderResult[i] < InOrderResult[i - 1])
                    return false;
            return true;
        }

    }    
}
