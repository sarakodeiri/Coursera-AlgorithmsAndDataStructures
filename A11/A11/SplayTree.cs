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
            Splay(base.Next(n));
            Splay(n);
            var l = n.Left;
            var r = n.Right;

            if (r != null)
            {
                UpdateParentWithNewNode(r, r.Left, l);
                Root = r;
            }

            else if (l != null)
                Root = l;
            else
                Root = l;
            if (Root != null)
                Root.Parent = null;
            //r.Left = l;
            //r.Parent = r;
            //Root = r;
            //r.Parent = null;
        }

        public void Splay(Node n)
        {
            while (n != null && n.Parent != null)
            {
                if (n.IsLeftChild)
                {
                    if (n.Parent.Parent == null)
                        Rotate(n.Parent, "right"); //why parent?
                    else if (n.Parent.IsLeftChild)
                        ApplyZigZigRight(n);
                    else if (n.Parent.IsRightChild)
                        ApplyZigZagRight(n);
                }
                else
                {
                    if (n.Parent.Parent == null)
                        Rotate(n.Parent, "left"); //why parent?
                    else if (n.Parent.IsRightChild)
                        ApplyZigZigLeft(n);
                    else if (n.Parent.IsLeftChild)
                        ApplyZigZagLeft(n);
                }
            }

            if (DebugMode && !EnsureBSTConsistency(this.Root))
                Debugger.Break();
        }

        private void ApplyZigZigRight(Node n) // N IS RIGHT CHILD AND PARENT IS LEFT CHILD.
        {
            var p = n.Parent;
            var q = p.Parent;
            var green = n.Right;
            var blue = p.Right;
            var red = n.Left;
            var black = q.Right;

            var topParent = q.Parent;

            UpdateParentWithNewNode(topParent, q, n);

            n.Left = red;
            n.Right = p;
            p.Left = green;
            p.Right = q;
            q.Left = blue;
            q.Right = black;
        }

        private void ApplyZigZagRight(Node n) // N IS LEFT CHILD AND PARENT IS RIGHT CHILD.
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

        private void ApplyZigZigLeft(Node n) // N IS RIGHT CHILD AND PARENT IS RIGHT CHILD.
        {
            var p = n.Parent;
            var q = p.Parent;
            var green = p.Left;
            var blue = n.Left;
            var red = n.Right;
            var black = q.Left;

            var topParent = q.Parent;

            UpdateParentWithNewNode(topParent, q, n);

            q.Left = black;
            q.Right = green;
            p.Left = q;
            p.Right = blue;
            n.Left = p;
            n.Right = red;

        }

        private void ApplyZigZagLeft(Node n) // N IS RIGHT CHILD AND PARENT IS LEFT CHILD.
        {
            var green = n.Left;
            var blue = n.Right;
            var p = n.Parent;
            var red = p.Left;
            var q = p.Parent;
            var black = q.Right;

            var topParent = q.Parent;

            UpdateParentWithNewNode(topParent, q, n);

            n.Left = p;
            n.Right = q;
            q.Left = blue;
            p.Right = green;
        }

       
    }
}
