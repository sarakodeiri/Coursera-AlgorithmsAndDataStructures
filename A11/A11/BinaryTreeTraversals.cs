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

        
        
        public List<long> InOrder(Node root, List<long> result)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            Node currentNode = root;
            if (root == null)
                return null;
            
            while (nodeStack.Count > 0 || currentNode != null)
            {
                while (currentNode != null)
                {
                    nodeStack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = nodeStack.Pop();
                result.Add(currentNode.key);
                currentNode = currentNode.right;
            }

            return result;
        }

        private List<long> PreOrder(Node root, List<long> result)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(root);
            if (root == null)
                return null;

            while (nodeStack.Count > 0)
            {

                Node peeked = nodeStack.Peek();
                result.Add(peeked.key);
                nodeStack.Pop();
                
                if (peeked.right != null)
                    nodeStack.Push(peeked.right);
                
                if (peeked.left != null)
                    nodeStack.Push(peeked.left);
            }

            return result;
        }

        private List<long> PostOrder(Node root, List<long> result)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(root);
            if (root == null)
                return null;
           
            while (nodeStack.Count > 0)
            {
                Node peeked = nodeStack.Peek();
                
                if (peeked.right == root || peeked.left == root || peeked.left == null && peeked.right == null)
                {
                    nodeStack.Pop();
                    result.Add(peeked.key);
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
            return result;
        }

        public long[][] Solve(long[][] nodes)
        {
            Tree tree = new Tree(nodes);
            
            List<long> InOrderResult = new List<long>();
            List<long> PreOrderResult = new List<long>();
            List<long> PostOrderResult = new List<long>();

            long[][] finalResult = new long[3][];
            finalResult[0] = InOrder(tree.root, InOrderResult).ToArray();
            finalResult[1] = PreOrder(tree.root, PreOrderResult).ToArray();
            finalResult[2] = PostOrder(tree.root, PostOrderResult).ToArray();

            return finalResult;
        }

    }
}
