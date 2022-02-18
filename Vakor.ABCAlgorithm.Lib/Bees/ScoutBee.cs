using System;
using Vakor.ABCAlgorithm.Lib.SalesmanSolutions;

namespace Vakor.ABCAlgorithm.Lib.Bees
{
    public class ScoutBee
    {
        private readonly Random _random = new();
        public SalesmanSolution ChooseNectarSource(SalesmanSolution[] nectarSources)
        {
            return nectarSources[_random.Next(nectarSources.Length)];
        }
    }
}