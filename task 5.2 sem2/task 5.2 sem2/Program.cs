using System;
using System.Collections.Generic;

namespace task_5._2_sem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph d = new Graph("text.txt");
            d.SpanningTree();
            d.PrintToFileSpanningTree();
        }
    }
}
