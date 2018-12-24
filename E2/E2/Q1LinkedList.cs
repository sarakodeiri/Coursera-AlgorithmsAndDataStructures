using System;
using System.Collections;
using System.Collections.Generic;

namespace E2
{

    public class Q1LinkedList
    {
        public class Node
        {
            public Node(int key) { this.Key = key;  }
            public int Key;
            public Node Next = null;
            public Node Prev = null;
            public override string ToString() => ToString(4);

            public string ToString(int maxDepth)
            {
                return maxDepth == 1 || Next == null ?
                    $"{Key.ToString()}" + (Next != null ? "..." : string.Empty) :
                    $"{Key.ToString()} {Next.ToString(maxDepth - 1)}";
            }
        }

        private Node Head = null;
        private Node Tail = null;

        public void Insert(int key)
        {
            if (Head == null)
            {
                Head = Tail = new Node(key);
            }

            else
            {
                var newNode = new Node(key);
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public override string ToString() => Head.ToString();

        public void Reverse() 
        {
            if (Head == null) //Base case
                return;
            Reverse(Head);
            (Head, Tail) = (Tail, Head);
        }

        private void Reverse(Node head) 
        {
            if (head.Next != null) //Base case
                Reverse(head.Next);

            Node next = head.Next;
            head.Next = head.Prev;
            head.Prev = next;
            return;
        }

        public void DeepReverse()
        {
            Node current = Head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = current.Prev;
                current.Prev = next;
                current = current.Prev;
            }

            (Head, Tail) = (Tail, Head);
        }

        public IEnumerable<int> GetForwardEnumerator()
        {
            var it = this.Head;
            while (it != null)
            {
                yield return it.Key;
                it = it.Next;
            }
        }

        public IEnumerable<int> GetReverseEnumerator()
        {
            var it = this.Tail;
            while (it != null)
            {
                yield return it.Key;
                it = it.Prev;
            }
        }
    }
}