using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public interface IEdgeWeightedGraph
    {
        int VerticesCount { get; }
        int EdgeCount { get; }
        void AddEdge(Edge edge);
        Edge[] AdjacentsOf(int v);
        Edge[] Edges();
        int GetDegree(int v);
        int GetMaxDegree();
        int GetNumberOfSelfLoops();
    }
}
