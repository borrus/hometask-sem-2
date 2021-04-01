using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace task_2._1_sem2
{
    interface Utilities
    {
        public static bool ListByteEqual(List<byte> list1, List<byte> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; ++i)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static List<byte> ListCopy(List<byte> source)
        {
            List<byte> destination = new List<byte>();
            for (int i = 0; i < source.Count; i++)
            {
                destination.Add(source[i]);
            }

            return destination;
        }

        public static List<byte> ListSumm(List<byte> l1, List<byte> l2)
        {
            List<byte> summ = new List<byte>(l1.Count + l2.Count);

            for (int i = 0; i < l1.Count; i++)
            {
                summ.Add(l1[i]);
            }

            for (int i = 0; i < l2.Count; i++)
            {
                summ.Add(l2[i]);
            }

            return summ;
        }

        public static List<byte> ListPlusSymbol(List<byte> l, byte symbol)
        {
            List<byte> summ = new List<byte>();

            if (l == null)
            {
                summ.Add(symbol);

                return summ;
            }

            for (int i = 0; i < l.Count; i++)
            {
                summ.Add(l[i]);
            }

            summ.Add(symbol);

            return summ;
        }

        public static void WriteByteListToFile(List<byte> list, string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);

            for (int i = 0; i < list.Count; ++i)
            {
                writer.Write(list[i]);
            }

            writer.Close();
            stream.Close();
        }

        public static List<byte> ReadLisOfByteFromFile(BinaryReader reader, int listSize)
        {
            List<byte> code = new List<byte>(listSize);

            for (int i = 0; i < listSize; ++i)
            {
                code.Add(reader.ReadByte());
            }

            return code;
        }
    }
}
