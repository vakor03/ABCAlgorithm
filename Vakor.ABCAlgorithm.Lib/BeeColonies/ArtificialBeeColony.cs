using System.Collections.Generic;
using System.Linq;
using Vakor.ABCAlgorithm.Lib.Bees;
using Vakor.ABCAlgorithm.Lib.Configurations;
using Vakor.ABCAlgorithm.Lib.Graphs;
using Vakor.ABCAlgorithm.Lib.ProbabilityTapes;
using Vakor.ABCAlgorithm.Lib.SalesmanSolutions;

namespace Vakor.ABCAlgorithm.Lib.BeeColonies
{
    public class ArtificialBeeColony : IArtificialBeeColony
    {
        public Configuration Configuration { get; set; }

        private SalesmanSolution[] _nectarSources;
        private SalesmanSolution[] _chosenNectarSources;
        private IGraph _graph;

        private ForageBee[] _forageBees;
        private ScoutBee[] _scoutBees;

        public ArtificialBeeColony(Configuration configuration)
        {
            Configuration = configuration;
        }

        public SalesmanSolution SolveSalesmanTask(IGraph graph)
        {
            GenerateInitialState(graph);

            for (int i = 0; i < Configuration.IterationCount; i++)
            {
                SendScoutBees();
                SendForageBees();
            }

            return GetBestSolution();
        }

        private void GenerateInitialState(IGraph graph)
        {
            _graph = graph;
            _nectarSources = Enumerable.Range(0, Configuration.NectarSourcesCount)
                .Select(x => SalesmanSolution.GenerateRandom(_graph.VerticesCount, FindSolutionValue)).ToArray();
            _forageBees = Enumerable.Range(0, Configuration.ForageBeeCount).Select(x => new ForageBee()).ToArray();
            _scoutBees = Enumerable.Range(0, Configuration.ScoutBeeCount).Select(x => new ScoutBee()).ToArray();
            _chosenNectarSources = new SalesmanSolution[Configuration.ScoutBeeCount];
        }

        private void SendScoutBees()
        {
            for (int i = 0; i < _scoutBees.Length; i++)
            {
                _chosenNectarSources[i] = _scoutBees[i].ChooseNectarSource(_nectarSources);
            }
        }

        private void SendForageBees()
        {
            ProbabilityTape probabilityTape = new ProbabilityTape();
            probabilityTape.InitTape(_chosenNectarSources.Select(s => s.Value).ToList());


            foreach (var forageBee in _forageBees)
            {
                SalesmanSolution nectarSource = forageBee.ChooseNectarSource(probabilityTape,
                    _chosenNectarSources);

                forageBee.TryFindBetterSource(nectarSource);
            }
        }

        private SalesmanSolution GetBestSolution()
        {
            return _nectarSources.Min();
        }

        private int FindSolutionValue(List<int> path)
        {
            int totalLength = 0;

            for (int i = 0; i < _graph.VerticesCount; i++)
            {
                totalLength += _graph[path[i], path[(i + 1) % _graph.VerticesCount]];
            }

            return totalLength;
        }
    }
}