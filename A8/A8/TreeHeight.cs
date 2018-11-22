using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public class Node
        {
            public List<Node> children = new List<Node>();
            public int depth;
            public Node() { }
        }

        public class Tree
        {
            public Node root;
            public List<Node> nodes = new List<Node>();
            public Tree (long[] tree)
            {
                for (int i = 0; i < tree.Length; i++)
                    nodes.Add(new Node());

                for (int i = 0; i < tree.Length; i++)
                    if (tree[i] != -1)
                        nodes[(int)tree[i]].children.Add(nodes[i]);
            
                    else
                        root = nodes[i];
            }
        
        }
        
        public long Solve(long nodeCount, long[] treeList)
        {
            Tree tree = new Tree(treeList);
            int height = 1;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(tree.root);

            do
            {
                Node currentNode = queue.Dequeue(); 
                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    queue.Enqueue(currentNode.children[i]);
                    currentNode.children[i].depth = currentNode.depth + 1;
                    height = Math.Max(height, currentNode.depth + 1);
                }
            } while (queue.Count != 0);

            return height + 1;
        }

    }
}
