using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class Tests
    {
        public static void RunAllTests()
        {
            TestSumm();
        }

        private static void TestSumm()
        {
            SparseVector vector1 = new SparseVector();
            vector1.Add(1, 10);
            vector1.Add(3, 12);
            vector1.Add(12, 40);
            SparseVector vector2 = new SparseVector();
            vector2.Add(2, 10);
            vector2.Add(3, 12);
            vector2.Add(12, 40);

            SparseVector sum = new SparseVector();
            sum.Add(1, 10);
            sum.Add(2, 10);
            sum.Add(3, 24);
            sum.Add(12, 80);

            if (sum == vector1 + vector2)
            {
                Console.WriteLine("testSum passed");
            }
            else
            {
                Console.WriteLine("testSum failed");
            }
        }
    }
}
