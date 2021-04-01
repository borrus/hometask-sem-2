using System;
using System.Collections.Generic;
using System.Text;

namespace task_2._2
{
    class ArrayStack
    {
        private string[] array = new string[1000];
        int size = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void PushBack(string value)
        {
            this.array[this.size] = value;
            ++this.size;
        }

        public void PopBack()
        {
            if (this.size > 0)
            {
                --this.size;
            }
        }

        public override string ToString()
        {
            string temp = "";

            for (int i = 0; i < this.size; ++i)
            {
                temp += this.array[i];
                temp += " ";
            }

            return temp;
        }
    }
}
