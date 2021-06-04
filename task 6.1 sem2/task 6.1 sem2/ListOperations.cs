using System;
using System.Collections.Generic;

namespace task_6._1_sem2
{
    public static class ListOperations
    {
        public static List<T2> Map<T1, T2>(List<T1> list, Func<T1, T2> function)
        {
            List<T2> newList = new List<T2>(); 

            for (int i = 0; i < list.Count; ++i)
            {
                newList.Add(function(list[i]));
            }

            return newList;
        }

        public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
        {
            List<T> newList = new List<T>();

            for (int i = 0; i < list.Count; ++i)
            {
                if (function(list[i]))
                {
                    newList.Add(list[i]);
                }
            }

            return newList;
        }

        public static T2 Fold<T1, T2>(List<T1> list, T2 initialValue, Func<T2, T1, T2> function)
        {
            T2 result = initialValue;

            for (int i = 0; i < list.Count; ++i)
            {
                result = function(result, list[i]);
            }

            return result;
        }
    }
}
