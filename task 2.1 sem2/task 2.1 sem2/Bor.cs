using System;
using System.Collections.Generic;
using System.Text;

namespace task_2._1_sem2
{
    class Bor
    {
        private class Node
        {
            public List<byte> key;
            public byte value;
            public List<Node> children;
            public Node parent;

            public Node(List<byte> key, byte value, Node parent = null)
            {
                this.key = Utilities.ListCopy(key);
                this.value = value;
                this.children = new List<Node>();
                this.parent = parent;
            }

            public Node GetNodeByChain(List<byte> chain)
            {
                if (chain.Count == 0)
                {
                    return this;
                }

                for (int i = 0; i < this.children.Count; ++i)
                {
                    if (this.children[i].value == chain[0])
                    {
                        List<byte> newChain = Utilities.ListCopy(chain);
                        newChain.RemoveAt(0);
                        return this.children[i].GetNodeByChain(newChain);
                    }
                }

                return null;
            }

            public Node GetNodeByKey(List<byte> key)
            {
                if (Utilities.ListByteEqual(this.key, key))
                {
                    return this;
                }

                for (int i = 0; i < this.children.Count; ++i)
                {
                    Node node = this.children[i].GetNodeByKey(key);
                    if (node != null)
                    {
                        return node.GetNodeByKey(key);
                    }
                }

                return null;
            }
        }

        private Node root;

        private int CodeSize;

        public List<byte> LastCode;

        private void IncreaseCode()
        {
            for (int i = 0; i < this.CodeSize; i++)
            {
                if (LastCode[i] < 255)
                {
                    ++LastCode[i];
                    return;
                }
            }
        }

        public Bor(int CodeSize)
        {
            this.LastCode = new List<byte>(CodeSize);
            for (int i = 0; i < LastCode.Capacity; i++)
            {
                this.LastCode.Add(0);
            }
            this.CodeSize = CodeSize;
            this.root = new Node(new List<byte>(0), 0);
            this.root.children = new List<Node>(256);

            for (int i = 0; i < 255; i++)
            {
                this.root.children.Add(new Node(LastCode, (byte)i));
                this.IncreaseCode();
            }

            this.root.children.Add(new Node(LastCode, (byte)255));
        }

        public bool ContainsValue(List<byte> value)
        {
            return this.GetNodeByChain(value) != null;
        }

        public bool ContainsKey(List<byte> key)
        {
            return this.GetValueByKey(key) != null;
        }

        public List<byte> GetKeyByValue(List<byte> value)
        {
            if (!this.ContainsValue(value))
            {
                return null;
            }

            return this.GetNodeByChain(value).key;
        }

        public List<byte> GetValueByKey(List<byte> key)
        {
            Node temp = this.GetNodeByKey(key);

            if (temp == null)
            {
                return null;
            }

            List<byte> chain = new List<byte>();

            while (temp != null)
            {
                chain.Add(temp.value);
                temp = temp.parent;
            }

            chain.Reverse();

            return chain;
        }

        public void Add(List<byte> chain)
        {
            if (this.GetNodeByChain(chain) != null)
            {
                return;
            }

            byte lastSymbol = chain[chain.Count - 1];
            chain.RemoveAt(chain.Count - 1);

            Node parent = GetNodeByChain(chain);

            chain.Add(lastSymbol);

            if (parent == null)
            {
                return;
            }

            IncreaseCode();

            Node nodeToAdd = new Node(LastCode, lastSymbol, parent);
            parent.children.Add(nodeToAdd);
        }
        private Node GetNodeByChain(List<byte> chain)
        {
            for (int i = 0; i < this.root.children.Count; ++i)
            {
                if (this.root.children[i].value == chain[0])
                {
                    List<byte> newChain = Utilities.ListCopy(chain);
                    newChain.RemoveAt(0);
                    return this.root.children[i].GetNodeByChain(newChain);
                }
            }

            return null;
        }

        private Node GetNodeByKey(List<byte> key)
        {
            for (int i = 0; i < this.root.children.Count; ++i)
            {
                Node node = this.root.children[i].GetNodeByKey(key);

                if (node != null)
                {
                    return node.GetNodeByKey(key);
                }
            }

            return null;
        }
    }
}
