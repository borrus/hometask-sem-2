using System;
using System.Collections.Generic;
using System.Text;

namespace Sem2Task1_2
{
    class ReverseConversion
    {
        string initialString;
        string[] arrayOfStrings;
        int position;
        public ReverseConversion(string initialString, int position)
        {
            this.initialString = initialString;
            arrayOfStrings = new string[initialString.Length];
            this.position = position;

            for (int i = 0; i < initialString.Length; ++i)
            {
                arrayOfStrings[i] = "";
            }
        }

        public void Sort()
        {
            for (int i = 0; i < this.arrayOfStrings.Length; ++i)
            {
                for (int j = 0; j < arrayOfStrings.Length - 1; ++j)
                {
                    if (TableOfCyclePermutation.StringCompare(arrayOfStrings[j], arrayOfStrings[j + 1]))
                    {
                        string temp = arrayOfStrings[j];
                        arrayOfStrings[j] = arrayOfStrings[j + 1];
                        arrayOfStrings[j + 1] = temp;
                    }
                }
            }
        }
        public string AlgorythmReBWT()
        {
            for (int i = 0; i < this.initialString.Length; ++i)
            {
                for (int j = 0; j < this.initialString.Length; ++j)
                {
                    this.arrayOfStrings[j] = this.initialString[j].ToString() + this.arrayOfStrings[j];
                }

                this.Sort();
            }

            return arrayOfStrings[position - 1];
        }
    }
}
