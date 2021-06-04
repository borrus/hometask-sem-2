using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace task_5._2_sem2
{
    class Graph
    {
        enum ParseLine
        {
            waitingForMainVertex,
            waitingForVertex,
            waitingForweight
        }

        private class Element
        {
            public  int Vertex
            {
                get; private set;
            }

            public int Weight
            {
                get; private set;
            }

            public Element(int vertex, int weight)
            {
                this.Vertex = vertex;
                this.Weight = weight;
            }

            public override string ToString()
            {
                return String.Format("{0} ({1}); ", Vertex, Weight);
            }
        }

        private int amountOfVertex = 0;
        private int[][] adjacencyMatrix;
        public HashSet<int> Vertexes
        {
            get;
            set;
        }
        
        private void Parser(string line, Dictionary<int, List<Element>> adjancencyDict)
        {
            var state = ParseLine.waitingForMainVertex;
            string temp = "";
            int vertex = 0;
            int mainVertex = 0;
            int weight = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsDigit(line[i]) && state == ParseLine.waitingForMainVertex)
                {
                    temp += line[i].ToString();
                }
                else if (!Char.IsDigit(line[i]) && state == ParseLine.waitingForMainVertex && temp != "")
                {
                    mainVertex = int.Parse(temp);
                    adjancencyDict.Add(mainVertex, new List<Element>());

                    if (this.amountOfVertex < mainVertex)
                    {
                        this.amountOfVertex = mainVertex;
                    }

                    temp = "";
                    state = ParseLine.waitingForVertex;
                }
                else if (Char.IsDigit(line[i]) && state == ParseLine.waitingForVertex)
                {
                    temp += line[i].ToString();
                }
                else if (!Char.IsDigit(line[i]) && state == ParseLine.waitingForVertex && temp != "")
                {
                    vertex = int.Parse(temp);
                    temp = "";
                    state = ParseLine.waitingForweight;
                }
                else if (Char.IsDigit(line[i]) && state == ParseLine.waitingForweight)
                {
                    temp += line[i].ToString();
                }
                else if (!Char.IsDigit(line[i]) && state == ParseLine.waitingForweight && temp != "")
                {
                    weight = int.Parse(temp);
                    adjancencyDict[mainVertex].Add(new Element(vertex, weight));

                    if (this.amountOfVertex < vertex)
                    {
                        this.amountOfVertex = vertex;
                    }

                    temp = "";
                    state = ParseLine.waitingForVertex;
                }
            }
        }

        public Graph(string filePath)
        {
            var adjancencyDict = new Dictionary<int, List<Element>>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string currentString = reader.ReadLine();
                    this.Parser(currentString, adjancencyDict);
                }

                this.adjacencyMatrix = new int[amountOfVertex + 1][];

                for (int i = 0; i < amountOfVertex + 1; ++i)
                {
                    this.adjacencyMatrix[i] = new int[amountOfVertex + 1];
                }

                for (int i = 0; i <= this.amountOfVertex; ++i)
                {
                    for (int j = 0; j <= this.amountOfVertex; ++j)
                    {
                        this.adjacencyMatrix[i][j] = 0;
                    }
                }

                foreach (var dicEl in adjancencyDict)
                {
                    foreach (var el in dicEl.Value)
                    {
                        this.adjacencyMatrix[dicEl.Key][el.Vertex] = el.Weight;
                        this.adjacencyMatrix[el.Vertex][dicEl.Key] = el.Weight;
                    }
                }
            }

            Vertexes = new HashSet<int>();
            for (int i = 1; i <= amountOfVertex; i++)
            {
                Vertexes.Add(i);
            }
        }

        public Graph(int amountOfVertex)
        {
            this.amountOfVertex = amountOfVertex;
            Vertexes = new HashSet<int>();
            adjacencyMatrix = new int[amountOfVertex + 1][];
            for (int i = 0; i <= amountOfVertex; i++)
            {
                adjacencyMatrix[i] = new int[amountOfVertex + 1];
            }
            for (int i = 0; i <= amountOfVertex; i++)
            {
                for (int j = 0; j <= amountOfVertex; j++)
                {
                    adjacencyMatrix[i][j] = 0;
                }
            }
        }

        public Graph SpanningTree()
        {
            var span = new Graph(amountOfVertex);
            span.Vertexes.Add(1);
            var unvisited = new HashSet<int>();

            for (int i = 2; i <= this.amountOfVertex; i++)
            {
                unvisited.Add(i);
            }

            while (unvisited.Count != 0)
            {
                var maxWeight = 0;
                var newVertex = 0;
                int previousVertex = 0;
                
                foreach (var unvisitedVertex in unvisited)
                {
                    foreach (var visitedVertex in span.Vertexes)
                    {
                        int a = this.adjacencyMatrix[visitedVertex][unvisitedVertex];

                        if (this.adjacencyMatrix[visitedVertex][unvisitedVertex] > maxWeight)
                        {
                            maxWeight = this.adjacencyMatrix[unvisitedVertex][visitedVertex];
                            previousVertex = visitedVertex;
                            newVertex = unvisitedVertex;
                        }
                    }
                }

                span.adjacencyMatrix[newVertex][previousVertex] = maxWeight;
                span.adjacencyMatrix[previousVertex][newVertex] = maxWeight;

                span.Vertexes.Add(newVertex);
                unvisited.Remove(newVertex);
            }

            return span;
        }

        public string PrintToFileSpanningTree()
        {
            Graph graphToFile = this.SpanningTree();
            string result = new string("");
            List<int> values = new List<int>(this.amountOfVertex);

            foreach (var vertex in graphToFile.Vertexes)
            {
                for (int i = 0; i < this.amountOfVertex; ++i)
                {
                    if (graphToFile.adjacencyMatrix[i][vertex] != 0 && !values.Contains(graphToFile.adjacencyMatrix[i][vertex]))
                    {
                        values.Add(graphToFile.adjacencyMatrix[i][vertex]);

                        result += i.ToString();
                        result += ": ";
                        result += vertex.ToString();
                        result += "(";
                        result += graphToFile.adjacencyMatrix[i][vertex].ToString();
                        result += ")";
                        result += "\n";
                    }
                }
            }

            return "";
        }
    } 
}
