using System;
using System.Collections.Generic;
using System.Text;

namespace Sem2Task1_2
{
    class TableOfCyclePermutation
    {
        private string[] data;
        public TableOfCyclePermutation(string s)
        {
            s += '}'.ToString();
            data = new string[s.Length];

            for (int i = 0; i < s.Length; ++i)
            {
                char[] temp = new char[s.Length];
                for (int j = 0; j < s.Length; ++j)
                {
                    temp[(j + i) % s.Length] = s[j];
                }
                data[i] = new string(temp);
            }
        }
        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < data.Length; ++i)
            {
                s += data[i] + "\n";
            }

            return s;
        }

        public static bool StringCompare(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return true;
            }

            if (b.Length > a.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] > b[i])
                {
                    return true;
                }

                if (a[i] < b[i])
                {
                    return false;
                }
            }

            return false;
        }

        public void Sort()
        {
            for (int i = 0; i < data.Length; ++i)
            {
                for (int j = 0; j < data.Length - 1; ++j)
                {
                    if (StringCompare(data[j], data[j + 1]))
                    {
                        string temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }

        public string BWT()
        {
            this.Sort();
            string outpString = "";

            for (int i = 0; i < data.Length; ++i)
            {
                outpString += data[i][data.Length - 1];
            }

            return outpString;
        }
    }
}
