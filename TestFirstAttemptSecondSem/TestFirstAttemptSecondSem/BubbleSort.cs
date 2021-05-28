using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestFirstAttemptSecondSem
{
    /// <summary>
    /// bubble sort
    /// accepts a list of objects of arbitary type and an object that allows them to be compared
    /// <typeparam name="T"></typeparam>
    class BubbleSort<T>
    {
        public void Sort(List<T> list, Comparer<T> comparsionObject)
        {
            if (list.Count == 0)
            {
                throw new Exception("List is empty");
            }

            int size = list.Capacity;

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (comparsionObject.Compare(list[j], list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }  
    }
}