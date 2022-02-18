namespace Vakor.ABCAlgorithm.Lib.Graphs
{
    public interface IGraph
    {
        int this[int vert1, int vert2] { get; set; }
        int VerticesCount { get; set; }
        
        void GenerateRandomFullGraph(int minValue, int maxValue);
    }
}