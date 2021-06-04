using System;

namespace Task_4._2_sem2
{
    public class List<T>
    {
        protected class Node
        {
            public T Value
            {
                get; set;
            }

            public Node Next
            {
                get; set;
            }

            public Node Previous
            {
                get; set;
            }

            public Node(T value, Node next = null, Node previous = null)
            {
                this.Value = value;
                this.Previous = previous;
                this.Next = next;
            }
        }

        protected Node head = null;
        protected Node tail = null;
        protected int size = 0;

        public T Head
        {
            get
            {
                return this.head.Value;
            }
        }

        public T Tail
        {
            get
            {
                return this.tail.Value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public virtual void PushBack(T value)
        {
            if (this.head == null)
            {
                this.head = new Node(value: value);
                this.tail = this.head;
                ++this.size;

                return;
            }

            this.tail.Next = new Node(value: value, next: null, previous: this.tail);
            this.tail = this.tail.Next;
            ++this.size;
        }

        public virtual void PushFront(T value)
        {
            if (this.head == null)
            {
                this.head = new Node(value: value);
                this.tail = this.head;
                ++this.size;

                return;
            }

            this.head.Previous = new Node(value: value, next: this.head, previous: null);
            this.head = this.head.Previous;
            ++this.size;
        }

        public void PopBack()
        {
            if (this.size == 0)
            {
                return;
            }

            if (this.size == 1)
            {
                this.tail = null;
                this.head = null;
                this.size = 0;

                return;
            }

            this.tail = this.tail.Previous;
            this.tail.Next = null;
            --this.size;
        }

        public void PopFront()
        {
            if (this.size == 0)
            {
                return;
            }

            if (this.size == 1)
            {
                this.tail = null;
                this.head = null;
                this.size = 0;

                return;
            }

            this.head = this.head.Next;
            this.head.Previous = null;
            --this.size;
        }

        public void ChangeValueByPosition(T value, int position)
        {
            if (this.size < position)
            {
                return;
            }

            Node temp = this.head;

            for (int i = 1; i < position; ++i)
            {
                temp = temp.Next;
            }

            temp.Value = value;
        }

        public bool ValueExists(T value)
        {
            Node temp = this.head;

            for (int i = 0; i < this.size; ++i)
            {
                if (temp.Value.Equals(value))
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }

        public override string ToString()
        {
            string result = "";
            Node temp = this.head;

            for (int i = 0; i < this.size - 1; ++i)
            {
                result += temp.Value.ToString();
                temp = temp.Next;
            }

            return result;
        }
    }
}
