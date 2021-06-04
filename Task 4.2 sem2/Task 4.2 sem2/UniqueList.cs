using System;

namespace Task_4._2_sem2
{
    public class UniqueList<T> : List<T>
    {
        public override void PushBack(T value)
        {
            if (ValueExists(value))
            {
                //
            }

            base.PushBack(value);
        }

        public override void PushFront(T value)
        {
            if (ValueExists(value))
            {
                //
            }

            base.PushFront(value);
        }

        public void PopByValue(T value)
        {
            if (!ValueExists(value))
            {
                //
            }

            Node temp = this.head;

            while (!temp.Value.Equals(value))
            {
                temp = temp.Next;
            }

            if (temp == this.tail)
            {
                this.tail = temp.Previous;
                temp = null;
                --this.size;

                return;
            }

            Node previousNode = temp.Previous;
            Node nextNode = temp.Next;
            temp = null;
            previousNode.Next = nextNode;
            this.tail = nextNode;
            --this.size;
        }
    }
}
