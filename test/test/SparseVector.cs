using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class SparseVector
    {
        private class Node
        {
            public int position;
            public int value;

            public Node next;
            public Node previous;
            
            public Node(int position, int value, Node next = null, Node previous = null)
            {
                this.position = position;
                this.value = value;

                this.next = next;
                this.previous = previous;
            }
        }

        private Node head;
        private Node tail;

        /// <summary>
        /// constructor
        /// </summary>
        public SparseVector()
        {
            this.head = null;
            this.tail = null;
        }

        private void pushBack(int position, int value)
        {
            if (this.head == null)
            {
                this.head = new Node(position: position, value: value);
                this.tail = this.head;

                return;
            }

            this.tail.next = new Node(position: position, value: value, previous: this.tail);
            this.tail = this.tail.next;
        }

        private void pushFront(int position, int value)
        {
            if (this.head == null)
            {
                this.head = new Node(position: position, value: value);
                this.tail = this.head;

                return;
            }

            this.head.previous = new Node(position: position, value: value, next: this.head);
            this.head = this.head.previous;
        }

        public static bool operator ==(SparseVector v1, SparseVector v2)
        {
            return (v1 - v2).IsZero();
        }

        public static bool operator !=(SparseVector v1, SparseVector v2)
        {
            return !(v1 == v2);
        }

        private Node GetPosition(int position)
        {
            if (this.head == null)
            {
                return null;
            }

            Node temp = this.head;

            while (temp != null)
            {
                if (temp.position == position)
                {
                    return temp;
                }

                temp = temp.next;
            }

            return null;
        }

        /// <summary>
        /// push element 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="value"></param>
        public void Add(int position, int value)
        {
            if (position < 0)
            {
                Console.WriteLine("Illegal position!");

                return;
            }

            if (value == 0)
            {
                return;
            }

            if (this.head == null)
            {
                this.pushBack(position: position, value: value);

                return;
            }

            Node toReplace = this.GetPosition(position);
            if (toReplace != null)
            {
                toReplace.value = value;

                return;
            }

            this.pushBack(position: position, value: value);
        }

        /// <summary>
        /// checks if vector is zero 
        /// </summary>
        /// <returns></returns>
        public bool IsZero()
        {
            return this.head == null;
        }

        /// <summary>
        /// summ of 2 vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static SparseVector operator +(SparseVector v1, SparseVector v2)
        {
            SparseVector sum = new SparseVector();

            Node temp1 = v1.head;
            while (temp1 != null)
            {
                Node temp = v2.GetPosition(temp1.position);
                if (temp != null)
                {
                    sum.Add(temp1.position, temp1.value + temp.value);
                }
                else
                {
                    sum.Add(temp1.position, temp1.value);
                }

                temp1 = temp1.next;
            }

            Node temp2 = v2.head;
            while (temp2 != null)
            {
                Node temp = v1.GetPosition(temp2.position);
                if (temp == null)
                {
                    sum.Add(temp2.position, temp2.value);
                }

                temp2 = temp2.next;
            }

            return sum;
        }

        /// <summary>
        /// diff of 2 vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static SparseVector operator -(SparseVector v1, SparseVector v2)
        {
            SparseVector sum = new SparseVector();

            Node temp1 = v1.head;
            while (temp1 != null)
            {
                Node temp = v2.GetPosition(temp1.position);
                if (temp != null)
                {
                    sum.Add(temp1.position, temp1.value - temp.value);
                }
                else
                {
                    sum.Add(temp1.position, temp1.value);
                }

                temp1 = temp1.next;
            }

            Node temp2 = v2.head;
            while (temp2 != null)
            {
                Node temp = v1.GetPosition(temp2.position);
                if (temp == null)
                {
                    sum.Add(temp2.position, -temp2.value);
                }

                temp2 = temp2.next;
            }

            return sum;
        }

        /// <summary>
        /// multip of 2 vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static int operator *(SparseVector v1, SparseVector v2)
        {
            int sum = 0;

            Node temp1 = v1.head;
            while (temp1 != null)
            {
                Node temp = v2.GetPosition(temp1.position);
                if (temp != null)
                {
                    sum += temp1.value * temp.value;
                }

                temp1 = temp1.next;
            }

            return sum;
        }

        /// <summary>
        /// override string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Node temp = this.head;
            if (temp == null)
            {
                return "zero vector";
            }

            string s = "";

            while (temp != null)
            {
                s += "postiion: " + temp.position.ToString() + "; value: " + temp.value.ToString() + ";\n";

                temp = temp.next;
            }

            return s;
        }
    }
}
