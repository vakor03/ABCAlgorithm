using System;
using System.Collections.Generic;
using System.Linq;

namespace Vakor.ABCAlgorithm.Lib.SalesmanSolutions
{
    public class SalesmanSolution : IComparable<SalesmanSolution>
    {
        public delegate int FindValueFunc(List<int> path);

        public List<int> Path { get; }

        public int Value => _findValueFunc(Path);
        
        private readonly FindValueFunc _findValueFunc;

        private SalesmanSolution(FindValueFunc findValueFunc, List<int> path)
        {
            _findValueFunc = findValueFunc;
            Path = path;
        }

        public static SalesmanSolution GenerateRandom(int vertexCount, FindValueFunc findValueFunc)
        {
            Random random = new Random();
            return
                new SalesmanSolution(
                    findValueFunc,
                    Enumerable.Range(0, vertexCount).OrderBy(x=> random.Next(vertexCount)).ToList()
                );
        }

        public void SwapVertices(int firstVertex, int secondVertex)
        {
            (Path[firstVertex], Path[secondVertex]) = (Path[secondVertex], Path[firstVertex]);
        }

        public int CompareTo(SalesmanSolution other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}