using System;
using System.Collections.Generic;
using System.Text;

namespace Sem2Task1_2
{
    class Tests
    {
        static bool EqualStrings(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            for (int i = 0; i < s1.Length; ++i)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }

            return true;
        }
        public bool Test1()
        {
            ReverseConversion test1 = new ReverseConversion("BCABAAA", 3);

            if (EqualStrings(test1.AlgorythmReBWT(), "ABACABA"))
            {
                return true;
            }

            return false;
        }

        public bool Test2()
        {
            ReverseConversion test2 = new ReverseConversion("QWEREEQ", 2);

            if (EqualStrings(test2.AlgorythmReBWT(), "EQWEQWE"))
            {
                return true;
            }

            return false;
        }

        public bool RunTests()
        {
            if (!Test1() || !Test2())
            {
                Console.WriteLine("Fail");
                return false;
            }

            Console.WriteLine("true");
            return true;
        }
    }
}
