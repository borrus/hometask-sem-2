using System;
using System.Collections.Generic;
using System.Text;

namespace task_3._1_sem2
{
    class BTree
    {
        private class Node
        {
            private List<KeyValuePair<string, string>> elements = new List<KeyValuePair<string, string>>();
            private List<Node> children = new List<Node>();
            private Node parent = null;
            private int mantiss;

            public Node(int mantiss)
            {
                this.mantiss = mantiss;
            }

            public Node Parent
            {
                set
                {
                    this.parent = value;
                }

                get
                {
                    return this.parent;
                }
            }

            public void ChangeValueByKey(string key, string value)
            {
                if (this == null)
                {
                    return;
                }

                for (int i = 0; i < this.Element.Count; ++i)
                {
                    if (this.Element[i].Key == key)
                    {
                        this.Element[i].Value = value;
                    }
                }
            }

            public string GetValueByKey(string key)
            {
                if (this == null)
                {
                    return null;
                }

                for (int i = 0; i < this.Element.Count; ++i)
                {
                    if (this.Element[i].Key == key)
                    {
                        return this.Element[i].Value;
                    }

                    if (key.CompareTo(this.Element[i].Key) < 0)
                    {
                        if (i <= 0)
                        {
                            if (this.children.Count == 0)
                            {
                                return null;
                            }
                            return this.children[0].GetValueByKey(key);
                        }
                        
                        if (this.Element[i - 1].Key == key)
                        {
                            return this.Element[i - 1].Value;
                        }

                        if (this.children.Count == 0)
                        {
                            return null;
                        }

                        return this.children[i].GetValueByKey(key);
                    }
                }

                return this.children[this.children.Count - 1].GetValueByKey(key);
            }

            public Node(string key, int mantiss, string value)
            {
                this.elements.Add(new KeyValuePair<string, string>(key, value));
                this.mantiss = mantiss;
            }

            public void Insert(string key, string value)
            {
                this.elements.Add(new KeyValuePair<string, string>(key, value));
                this.elements.Sort((x, y) => x.Key.CompareTo(y.Key));
            }

            public void Restruct()
            {
                if (this.Element.Count < mantiss)
                {
                    return;
                }

                int middleIndex = this.mantiss / 2;

                Node leftChild = new Node(this.mantiss);

                for (int i = 0; i < middleIndex; ++i)
                {
                    leftChild.Element.Add(this.elements[i]);
                }

                Node rightChild = new Node(this.mantiss);

                for (int i = middleIndex + 1; i <= this.mantiss; ++i)
                {
                    rightChild.Element.Add(this.elements[i]);
                }

                if (this.children.Count != 0)
                {
                    for (int i = 0; i < middleIndex; ++i)
                    {
                        leftChild.children.Add(this.children[i]);
                        leftChild.children[i].parent = leftChild;
                    }

                    for (int i = middleIndex + 1; i <= mantiss; ++i)
                    {
                        rightChild.children.Add(this.children[i]);
                        rightChild.children[i - middleIndex - 1] = rightChild;
                    }

                }

                if (this.parent == null)
                {
                    this.parent = new Node(this.elements[middleIndex].Key, this.mantiss, this.elements[middleIndex].Value);

                    this.parent.children.Add(leftChild);
                    this.parent.children.Add(rightChild);
                }
                else
                {
                    this.parent.Insert(this.elements[middleIndex].Key, this.elements[middleIndex].Value);
                    int insertIndex = this.parent.elements.IndexOf(this.elements[middleIndex]);

                    this.parent.children[insertIndex] = leftChild;
                    this.parent.children.Insert(insertIndex + 1, rightChild);
                }

                leftChild.parent = this.parent;
                rightChild.parent = this.parent;
            }

            public Node Spusk(string key)
            {
                if (this.children.Capacity == 0)
                {
                    return this;
                }

                for (int i = 0; i < this.Element.Count; ++i)
                {
                    if (key.CompareTo(this.Element[i].Key) < 0)
                    {
                        return this.children[i].Spusk(key);
                    }
                }

                return this.children[this.elements.Count];
            }

            public List<KeyValuePair<string, string>> Element
            {
                get
                {
                    return this.elements;
                }
            }
        }

        private Node root = null;

        private int mantiss;

        public BTree(int mantiss)
        {
            this.mantiss = mantiss;
        }

        private Node Spusk(string key)
        {
            if (this.root != null)
            {
                return this.root.Spusk(key);
            }

            return null;
        }

        public void Insert(string key, string value)
        {
            if (this.root == null)
            {
                this.root = new Node(key, this.mantiss, value);

                return;
            }

            Node nodeToAdd = Spusk(key);
            nodeToAdd.Insert(key, value);

            while (nodeToAdd.Element.Count == this.mantiss + 1)
            {
                if (nodeToAdd == this.root)
                {
                    nodeToAdd.Restruct();
                    this.root = this.root.Parent;

                    return;
                }

                nodeToAdd.Restruct();

                nodeToAdd = nodeToAdd.Parent;
            }
        }

        public string GetValueByKey(string key)
        {
            if (this.root == null)
            {
                return null;
            }

            return this.root.GetValueByKey(key);
        }

        public bool KeyExists(string key)
        {
            return this.GetValueByKey(key) != null;
        }

        public void ChangeValueByKey(string key, string value)
        {
            if (!KeyExists(key))
            {
                return;
            }


        }
    }
}