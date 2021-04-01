using System.Collections.Generic;
using System;
using System.IO;

namespace task_2._1_sem2
{
    class Program
    {
        static void Main(string[] args)
        {
            LZW test1 = new LZW(2);
            test1.LZWEncoding("test.txt");
            test1.LZWDecoding("encoded.txt");
        }
    }
}

