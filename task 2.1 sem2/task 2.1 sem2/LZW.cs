using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace task_2._1_sem2
{
    class LZW
    {
        private Bor codeTable;

        private int codeSize;

        private List<byte> maxCode;

        private List<byte> clearCode;

        public LZW(int CodeSize)
        {
            this.codeSize = CodeSize;

            this.maxCode = new List<byte>(this.codeSize);
            for (int i = 0; i < this.codeSize; ++i)
            {
                this.maxCode.Add((byte)255);
            }
            this.maxCode[this.codeSize - 1] = (byte)254;

            this.clearCode = Utilities.ListCopy(this.maxCode);
            this.clearCode[this.codeSize - 1] = (byte)255;

            this.codeTable = new Bor(this.codeSize);
        }

        public void LZWEncoding(string inputFilePath)
        {
            FileStream input = File.OpenRead(inputFilePath);
            BinaryReader reader = new BinaryReader(input);
            string output = "encoded.txt";
            File.Delete(output);

            List<byte> chain = new List<byte>();

            while (input.Position != input.Length)
            {
                byte symbol = reader.ReadByte();

                if (codeTable.ContainsValue(Utilities.ListPlusSymbol(chain, symbol)))
                {
                    chain.Add(symbol);
                }
                else
                {
                    Utilities.WriteByteListToFile(codeTable.GetKeyByValue(chain), output);

                    codeTable.Add(Utilities.ListPlusSymbol(chain, symbol));

                    chain.Clear();

                    chain.Add(symbol);

                    if (Utilities.ListByteEqual(this.codeTable.LastCode, this.maxCode))
                    {
                        Utilities.WriteByteListToFile(codeTable.GetKeyByValue(chain), output);
                        Utilities.WriteByteListToFile(this.clearCode, output);
                        this.codeTable = new Bor(this.codeSize);

                        chain.Clear();
                    }
                }
            }

            Utilities.WriteByteListToFile(codeTable.GetKeyByValue(chain), output);

            reader.Close();
            input.Close();
        }

        public void LZWDecoding(string inputFilePath)
        {
            FileStream input = File.OpenRead(inputFilePath);
            BinaryReader reader = new BinaryReader(input);
            string output = "decoded.txt";
            File.Delete(output);

            List<byte> previous = new List<byte>();

            while (input.Position != input.Length)
            {
                List<byte> next = Utilities.ReadLisOfByteFromFile(reader, this.codeSize);

                if (Utilities.ListByteEqual(this.clearCode, next))
                {
                    this.codeTable = new Bor(this.codeSize);

                    if (input.Position == input.Length)
                    {
                        break;
                    }

                    next = Utilities.ReadLisOfByteFromFile(reader, this.codeSize);
                    Utilities.WriteByteListToFile(codeTable.GetValueByKey(next), output);
                    previous = Utilities.ListCopy(next);
                }
                else
                {
                    if (codeTable.ContainsKey(next))
                    {
                        Utilities.WriteByteListToFile(codeTable.GetValueByKey(next), output);

                        List<byte> chain1 = codeTable.GetValueByKey(previous);
                        List<byte> chain2 = codeTable.GetValueByKey(next);
                        codeTable.Add(Utilities.ListPlusSymbol(chain1, chain2[0]));
                    }
                    else
                    {
                        List<byte> chain = Utilities.ListPlusSymbol(previous, previous[0]);
                        Utilities.WriteByteListToFile(chain, output);
                        codeTable.Add(chain);
                    }

                    previous = Utilities.ListCopy(next);
                }
            }

            reader.Close();
            input.Close();
        }
    }
}

