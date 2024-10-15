using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList
    {
        private class Node
        {
            // Essendo "private" l'intera class, posso usare "public" per i campi
            public int value;
            public Node next;
        }

        private Node head;
        public LinkedList()
        {
            this.head = null;
        }

        public int Count { 
            get 
            { 
                int count = 0;
                for (Node n = head; n != null; n = n.next)
                    ++count;
                return count;
            } 
        }
        public int this[int idx] { get { return Get(idx); } set { Set(idx, value); } }

        public int Get(int idx)
        {
            if (idx < 0)
                throw new ArgumentOutOfRangeException("idx is below 0.");

            if (head == null)
                throw new NullReferenceException("List is empty.");

            Node n = head;
            for (int i = 0; i < idx; ++i)
            {
                if (n == null)
                    throw new ArgumentOutOfRangeException("idx");
                n = n.next;
            }

            return n.value; 
        }

        public void Set(int idx, int val)
        {
            if (idx < 0)
                throw new IndexOutOfRangeException();

            if (head == null)
                throw new NullReferenceException("List is empty.");

            Node n = head;
            for (int i = 0; i < idx; ++i)
            {
                if (n == null)
                    throw new IndexOutOfRangeException();
                n = n.next;
            }

            n.value = val;
        }

        public void Add(int value)
        {
            // Crea il nuovo nodo
            Node n = new Node();
            n.value = value;
            n.next = null;

            if (head == null)  // lista vuota?
            {
                head = n;
            }
            else
            {
                Node prev = head;
                while (prev.next != null)
                    prev = prev.next;

                prev.next = n;
            }
        }
        public void RemoveAt(int idx)
        {
            if (head == null) return; 

            if (idx < 0)
                throw new ArgumentOutOfRangeException("idx is below 0.");

            if (idx == 0)
            {
                head = head?.next;
                return;
            }

            Node prev = head;
            for (int i = 0; i < idx - 1; ++i)
            {
                if (prev == null)
                    throw new ArgumentOutOfRangeException("idx");
                prev = prev.next;
            }
        }
        public void RemoveValue(int value)
        {
            if (head == null)
                return;

            Node n = head;
            if (n.value == value)
            {
                head = head.next;
                return;
            }

            while (n.next != null)
            {
                if (n.next.value == value)
                {
                    n.next = n.next.next;
                    return;
                }
                n = n.next;
            }
        }

        public int Search(int value)
        {
            int i = 0;
            for (Node curr = head; curr != null; curr = curr.next, ++i)
            {
                if (curr.value == value)
                    return i;
            }

            return -1;
        }
    }
}
