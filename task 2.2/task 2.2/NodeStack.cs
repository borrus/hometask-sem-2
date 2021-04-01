using System;
using System.Collections.Generic;
using System.Text;

namespace task_2._2
{
    class NodeStack
    {
        private class Node
        {
            public string value;
            public Node next;

            public Node(string value)
            {
                this.value = value;
                this.next = null;
            }
        }

        private Node root;
        private int size;

        public NodeStack()
        {
            this.root = null;
            this.size = 0;
        }

        public void PushBack(string value)
        {
            if (this.root == null)
            {
                this.root = new Node(value);
                ++this.size;

                return;
            }

            Node temp = this.root;

            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = new Node(value);
            ++this.size;
        }

        public string PopBack()
        {
            if (root == null)
            {
                return "";
            }

            --this.size;

            if (root.next == null)
            {
                string returnValue = root.value;
                root = null;

                return returnValue;
            }

            Node temp = this.root;

            while (temp.next.next != null)
            {
                temp = temp.next;
            }

            string popValue = temp.next.value;
            temp.next = null;

            return popValue;
        }

        public string Peek()
        {
            return this.root.value;
        }

        public override string ToString()
        {
            string outputString = "";
            Node temp = this.root;

            while (temp != null)
            {
                outputString += temp.value;
                outputString += " ";
                temp = temp.next;
            }

            return outputString;
        }
    }
}
