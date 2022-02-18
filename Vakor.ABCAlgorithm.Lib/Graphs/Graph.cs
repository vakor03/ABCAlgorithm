using System;

namespace Vakor.ABCAlgorithm.Lib.Graphs
{
    public class Graph : IGraph
    {
        public int this[int vert1, int vert2]
        {
            get => _adjacencyMatrix[vert1, vert2];
            set => _adjacencyMatrix[vert1, vert2] = value;
        }

        public int VerticesCount { get; set; }
        
        private int[,] _adjacencyMatrix;

        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            _adjacencyMatrix = new int[verticesCount,verticesCount];
        }

        public Graph(int[,] adjacencyMatrix)
        {
            _adjacencyMatrix = adjacencyMatrix;
            
            if (_adjacencyMatrix.GetLength(0)!= _adjacencyMatrix.GetLength(1))
            {
                throw new ArgumentException();
            }
            VerticesCount = _adjacencyMatrix.GetLength(0);
        }

        public void GenerateRandomFullGraph(int minValue, int maxValue)
        {
            Random random = new Random();
            int[,] matrix = new int[VerticesCount,VerticesCount];
            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (i!=j)
                    {
                        matrix[i, j] = random.Next(minValue, maxValue);
                    }
                }
            }

            _adjacencyMatrix = matrix;
        }
    }
}