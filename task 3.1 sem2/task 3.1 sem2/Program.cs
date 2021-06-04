using System;
using System.Collections.Generic;
using System.Text;

namespace task_3._1_sem2
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree xyi = new BTree(3);
            xyi.Insert("7", "a");
            xyi.Insert("5", "b");
            xyi.Insert("4", "c");
            xyi.Insert("1", "d");
            xyi.Insert("2", "e");
            xyi.Insert("9", "f");
            xyi.Insert("11", "g");


            bool s = xyi.KeyExists("7");
        }
    }
}
