using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    public class Node
    {
        public long key;
        public Node left;
        public Node right;
    }

    public class Tree
    {
        public Node root;
        public List<Node> allNodes = new List<Node>();

        public Tree(long[][] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
                allNodes.Add(new Node());

            for (int i = 0; i < nodes.Length; i++)
            {
                allNodes[i].key = nodes[i][0];
                if (nodes[i][1] != -1)
                    allNodes[i].left = allNodes[(int)nodes[i][1]];

                if (nodes[i][2] != -1)
                    allNodes[i].right = allNodes[(int)nodes[i][2]];
            }
            this.root = allNodes[0];
        }
    }
}
