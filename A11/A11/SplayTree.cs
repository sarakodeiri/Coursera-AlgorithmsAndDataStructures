using System;
using System.Diagnostics;

namespace A11
{
    public class SplayTree: BST
    {
        public SplayTree(Node r=null)
            :base(r)
        { }

        public void Splay(long key) { }

        public override Node Find(long key) => null;

        public override void Insert(long key) { }

        public override void Delete(long key) { }
        public override void Delete(Node n) { }

        public void Splay(Node n)
        {
            while (n != null && n.Parent != null)
            {
                if (n.IsLeftChild)
                {
                    if (n.Parent.Parent == null)
                        RotateRight(n.Parent);
                    else if (n.Parent.IsLeftChild)
                        ApplyZigZigRight(n);
                    else if (n.Parent.IsRightChild)
                        ApplyZigZagRight(n);
                }
                else
                {
                    if (n.Parent.Parent == null)
                        RotateLeft(n.Parent);
                    else if (n.Parent.IsRightChild)
                        ApplyZigZigLeft(n);
                    else if (n.Parent.IsLeftChild)
                        ApplyZigZagLeft(n);
                }
            }

            if (DebugMode && !EnsureBSTConsistency(this.Root))
                Debugger.Break();
        }

        private void ApplyZigZagRight(Node n)
        {
            var green = n.Left;
            var blue = n.Right;
            var p = n.Parent;
            var red = p.Right;
            var q = p.Parent;
            var black = q.Left;

            var topParent = q.Parent;

            UpdateParentWithNewNode(topParent, q, n);

            q.Right = green;
            n.Left = q;
            p.Left = blue;
            n.Right = p;
        }

        private void ApplyZigZigLeft(Node q) { }
        private void ApplyZigZagLeft(Node n) { }
        private void ApplyZigZigRight(Node n) { }
    }
}
