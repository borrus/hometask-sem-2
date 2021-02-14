using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2___task_1._1
{
    class Program
    {
        static void BubbleSort(int[] array)
        {
            int size = array.Length;

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 3, 1, 4};
            BubbleSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
