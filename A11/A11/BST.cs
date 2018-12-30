using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    public class BST
    {
        public class Node
        {
            public long Key { get; set; }
            protected Node _LeftChild;

            public Node Left
            {
                get => _LeftChild;
                set
                {
                    _LeftChild = value;
                    if (value != null)
                        _LeftChild.Parent = this;
                }
            }
            protected Node _RightChild;
            public Node Right
            {
                get => _RightChild;
                set
                {
                    _RightChild = value;
                    if (value != null)
                        _RightChild.Parent = this;
                }
            }
            public const string NullChar = "-";

            public Node Parent { get; set; }
            public bool IsLeftChild => Parent != null && ReferenceEquals(Parent.Left, this);
            public bool IsRightChild => Parent != null && ReferenceEquals(Parent.Right, this);

            public override string ToString()
            {
                try
                {
                    return ($"{Key}({(Left != null ? Left.ToString() : NullChar)}," +
                           $"{(Right != null ? Right.ToString() : NullChar)})")
                        .Replace("(-,-)", "")
                        .Replace("(-,-)", "")
                        .Trim();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            public Node(long key,
                Node leftChild = null,
                Node rightChild = null,
                Node parent = null)
            {
                Key = key;
                Left = leftChild;
                Right = rightChild;
                Parent = parent;
            }
            
        } //end of node class

        public void Clear() => Root = null;

        public Node Root { get; protected set; }

        /// <summary>
        /// If DebugMode is on, the entire tree will be checked
        /// for parent-child consistence and making sure there are 
        /// no loops. It adds a huge performance cost, so only turn
        /// it on when you are trying to find a bug.
        /// You can add more calls to EnsureBSTConsistency where needed.
        /// </summary>
        public static bool DebugMode { get; set; } = false;

        

        public static BST ParseBST(IEnumerable<long> preOrderList)
        {
            var root = ParseBST(ref preOrderList);
            return new BST(root);
        }

        public static Node ParseBST(ref IEnumerable<long> preOrderList)
        {
            if (!preOrderList.Any())
                return null;

            long nextNode = preOrderList.First();
            preOrderList = preOrderList.Skip(1);

            if (nextNode == -1)
                return null;
            
            Node n = new Node(nextNode);

            n.Left = ParseBST(ref preOrderList);
            n.Right = ParseBST(ref preOrderList);

            return n;
            
        }

        public BST(Node root = null)
        {
            this.Root = root;
        }

        public override string ToString()
            => Root?.ToString();

        public virtual Node Find(long key)
        {
            Node current = Root;

            if (current == null)
                return current;

            while (current != null)
            {
                if (current.Key == key)
                    return current;

                if (current.Key < key)

                {
                    if (current.Right != null)
                        current = current.Right;
                    else
                        return current;
                }

                else
                {
                    if (current.Left != null)
                        current = current.Left;
                    else
                        return current;
                }
            }
            return current;
        }

        public virtual void Insert(long key)
        {
            if (Root == null)
            {
                Root = new Node(key);
                return;
            }

            Node n = Find(key);
            
            if (n.Key < key)
            {
                Node m = new Node(key);
                m.Parent = n;
                n.Right = m;
            }

            if (n.Key > key)
            {
                Node m = new Node(key);
                m.Parent = n;
                n.Left = m;
            }

            if (n.Key == key)
                return;
        }

        public virtual void Delete(Node wantToDelete)
        {
            if (wantToDelete.Right == null) // remove n, promote wantToDelete.left
            {
                if (wantToDelete.Left != null)
                    wantToDelete.Left.Parent = wantToDelete.Parent;
                
                if (wantToDelete != Root)
                {
                    if (wantToDelete.IsLeftChild)
                        wantToDelete.Parent.Left = wantToDelete.Left;

                    else
                        wantToDelete.Parent.Right = wantToDelete.Left;
                }

                else
                {
                    Clear();
                    return;
                }
            }

            else //wantToDelete.Left == null
            {
                Node x = Next(wantToDelete);

                if (wantToDelete.Key != Root.Key)
                {
                    if (wantToDelete.IsLeftChild)
                        wantToDelete.Parent.Left = x;
                    else
                        wantToDelete.Parent.Right = x;
                }

                else
                    Root = x;

                // from now on: replace n by x, promote x.right

                if (wantToDelete.Right != x)
                {
                    x.Parent.Left = null;
                    x.Left = wantToDelete.Left;
                    x.Right = wantToDelete.Right;
                    x.Parent = wantToDelete.Parent;
                }

                else
                {
                    x.Parent = wantToDelete.Parent;
                    x.Left = wantToDelete.Left;
                    x.Right = null;
                }

            }
            wantToDelete = null; //remove n
        }


        public virtual void Delete(long key)
        {
            Node node = Find(key);

            if (node.Key == key)
                Delete(node);
        }

        public Node Next(long key)
        {
            Node n = this.Find(key);
            return Next(n);
        }

        public Node Next(Node n)
        {
            if (n.Right != null)
                return LeftDescendant(n.Right);

            return RightAncestor(n);
        }

        private Node LeftDescendant(Node n)
        {
            if (n.Left == null)
                return n;
            return LeftDescendant(n.Left);
        }

        private Node RightAncestor(Node n)
        {
            if (n.Parent == null)
                return null;
            
            if (n.Key < n.Parent.Key)
                return n.Parent;
            else
                return RightAncestor(n.Parent);
        }

        public IEnumerable<Node> RangeSearch(long x, long y)
        {
            Node n = Find(x);
            while (n != null && n.Key <= y)
            {
                if (n.Key >= x)
                    yield return n;
                n = Next(n);
            }
        }

        public static bool EnsureBSTConsistency(BST.Node r)
        {
            if (r == null)
                return true;

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(r);

            while (nodes.Count > 0)
            {

                var n = nodes.Dequeue();

                // Make sure left child points back to parent
                if (n.Left != null && !ReferenceEquals(n.Left.Parent, n))
                    return false;

                // Make sure right child points back to parent
                if (n.Right != null && !ReferenceEquals(n.Right.Parent, n))
                    return false;

                // Make sure no node is its own parent
                if (n.Parent != null && ReferenceEquals(n, n.Parent))
                    return false;

                if (n.Left != null)
                    nodes.Enqueue(n.Left);

                if (n.Right != null)
                    nodes.Enqueue(n.Right);

            }
            return true;
        }

        protected void UpdateParentWithNewNode(Node parent, Node n, Node newNode)
        {
            if (parent == null)
            {
                Root = newNode;
                if (Root != null)
                    Root.Parent = null;

                return;
            }

            if (ReferenceEquals(parent.Left,n))
                parent.Left = newNode;
            else
                parent.Right = newNode;
        }

        

        protected void Rotate(Node n, string rightOrLeft)
        {
            Node green = n.Left;
            Node blue = n.Right;
            Node p = n.Parent;
            Node red = p.Left;

            Node topParent = p.Parent;

            UpdateParentWithNewNode(topParent, p, n);

            if (rightOrLeft == "right")
            {
                n.Right = p;
                p.Left = blue;
            }

            if (rightOrLeft == "left")
            {
                n.Left = p;
                p.Right = green;
            }

        }

    }
}
