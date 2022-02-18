using Vakor.ABCAlgorithm.Lib.Configurations;
using Vakor.ABCAlgorithm.Lib.Graphs;
using Vakor.ABCAlgorithm.Lib.SalesmanSolutions;

namespace Vakor.ABCAlgorithm.Lib.BeeColonies
{
    public interface IArtificialBeeColony
    {
        Configuration Configuration { get; set; }
        
        SalesmanSolution SolveSalesmanTask(IGraph graph);
    }
}