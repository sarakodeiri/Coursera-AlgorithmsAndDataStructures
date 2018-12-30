using System;
using System.Diagnostics;

namespace A11
{
    public class SplayTree: BST
    {
        public SplayTree(Node r=null) 
            :base(r)
        //*****************//
        { }

        public void Splay(long key) //***************//
        {
            Node n = base.Find(key);
            Splay(n);
        }

        public Node SFind(long key) //********************//
        {
            Node n = base.Find(key);
            Splay(n);
            return n;
        }

        public override void Insert(long key) //*****************//
        {
            base.Insert(key);
            Splay(key);
        }

        public override void Delete(long key) //*****************//
        {
            Node n = Find(key);
            Delete(n);
        }

        public override void Delete(Node n) //*****************//
        {
            Splay(Next(n));
            Splay(n);
            var l = n.Left;
            var r = n.Right;
            r.Left = l;
            r.Parent = r;
            Root = r;
            r.Parent = null;
        }

        public void Splay(Node n)
        {
            while (n != null && n.Parent != null)
            {
                if (n.IsLeftChild)
                {
                    if (n.Parent.Parent == null)
                        Rotate(n.Parent, "right");
                    else if (n.Parent.IsLeftChild)
                        ApplyZigZigRight(n);
                    else if (n.Parent.IsRightChild)
                        ApplyZigZagRight(n);
                }
                else
                {
                    if (n.Parent.Parent == null)
                        Rotate(n.Parent, "left");
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

        private void ApplyZigZigLeft(Node q) //*****************//
        { }

        private void ApplyZigZagLeft(Node n) //*****************//
        { }

        private void ApplyZigZigRight(Node n) //*****************//
        { }
    }
}
