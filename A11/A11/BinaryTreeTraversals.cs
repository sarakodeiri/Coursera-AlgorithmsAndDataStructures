using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        List<long> InOrderResult;
        List<long> PreOrderResult;
        List<long> PostOrderResult;
        
        private void InOrder(Node root)
        {
            InOrderResult = new List<long>();
            Stack<Node> nodeStack = new Stack<Node>();
            Node currentNode = root;
            if (root == null)
                return;
            
            while (nodeStack.Count > 0 || currentNode != null)
            {
                while (currentNode != null)
                {
                    nodeStack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = nodeStack.Pop();
                InOrderResult.Add(currentNode.key);
                currentNode = currentNode.right;
            }
        }

        private void PreOrder(Node root)
        {
            PreOrderResult = new List<long>();
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(root);
            if (root == null)
                return;

            while (nodeStack.Count > 0)
            {

                Node peeked = nodeStack.Peek();
                PreOrderResult.Add(peeked.key);
                nodeStack.Pop();
                
                if (peeked.right != null)
                    nodeStack.Push(peeked.right);
                
                if (peeked.left != null)
                    nodeStack.Push(peeked.left);
            }
        }

        private void PostOrder(Node root)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            PostOrderResult = new List<long>();
            nodeStack.Push(root);
            if (root == null)
                return;
           
            while (nodeStack.Count > 0)
            {
                Node peeked = nodeStack.Peek();
                
                if (peeked.right == root || peeked.left == root || peeked.left == null && peeked.right == null)
                {
                    nodeStack.Pop();
                    PostOrderResult.Add(peeked.key);
                    root = peeked;
                }

                else
                {
                    if (peeked.right != null)
                        nodeStack.Push(peeked.right);

                    if (peeked.left != null)
                        nodeStack.Push(peeked.left);
                }
            }
        }

        public long[][] Solve(long[][] nodes)
        {
            Tree tree = new Tree(nodes);
            InOrder(tree.root);
            PreOrder(tree.root);
            PostOrder(tree.root);

            long[][] finalResult = new long[3][];
            finalResult[0] = InOrderResult.ToArray();
            finalResult[1] = PreOrderResult.ToArray();
            finalResult[2] = PostOrderResult.ToArray();

            return finalResult;
        }

    }
}
