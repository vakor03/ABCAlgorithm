using System;
using System.Threading.Channels;
using Vakor.ABCAlgorithm.Lib.BeeColonies;
using Vakor.ABCAlgorithm.Lib.Configurations;
using Vakor.ABCAlgorithm.Lib.Graphs;
using Vakor.ABCAlgorithm.Lib.SalesmanSolutions;

namespace Vakor.ABCAlgorithm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration
            {
                ForageBeeCount = 90,
                ScoutBeeCount = 10,
                NectarSourcesCount = 50,
                IterationCount = 10000
            };
            IGraph graph = new Graph(300);
            graph.GenerateRandomFullGraph(5,150);

            for (int i = 0; i < 5; i++)
            {
                PrintABCAlgorithmResult(graph, configuration);
                configuration.ForageBeeCount += 5;
                Console.WriteLine();
            }
            
        }

        private static void PrintABCAlgorithmResult(IGraph graph, Configuration configuration)
        {
            Console.WriteLine("Configuration: \n" +
                              $"Forage bees: {configuration.ForageBeeCount}\n" +
                              $"Scout bees: {configuration.ScoutBeeCount}\n" +
                              $"Nectar sources count: {configuration.NectarSourcesCount}\n" +
                              $"Iteration count: {configuration.IterationCount}\n" +
                              $"Vertices count: {graph.VerticesCount}");
            //Console.WriteLine(configuration.ScoutBeeCount);
            IArtificialBeeColony artificialBeeColony = new ArtificialBeeColony(configuration);
            SalesmanSolution solution = artificialBeeColony.SolveSalesmanTask(graph);
            Console.WriteLine($"Solution value: {solution.Value}");
            Console.WriteLine($"Path :  {String.Join("=>", solution.Path)}");
        }

        
    }
}