using System;
using Vakor.ABCAlgorithm.Lib.ProbabilityTapes;
using Vakor.ABCAlgorithm.Lib.SalesmanSolutions;

namespace Vakor.ABCAlgorithm.Lib.Bees
{
    public class ForageBee
    {
        private readonly Random _random = new();
        public SalesmanSolution ChooseNectarSource(ProbabilityTape probabilityTape, SalesmanSolution[] nectarSources)
        {
            double randomValue = _random.NextDouble();
            int index = probabilityTape.FindValue(randomValue);
            return nectarSources[index];
        }

        public void TryFindBetterSource(SalesmanSolution nectarSource)
        {
            int vertex1 = _random.Next(nectarSource.Path.Count);
            int vertex2 = _random.Next(nectarSource.Path.Count);

            int previousValue = nectarSource.Value;
            
            nectarSource.SwapVertices(vertex1, vertex2);
            if (nectarSource.Value > previousValue)
            {
                nectarSource.SwapVertices(vertex2, vertex1);
            }
        }
    }
}