using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public interface IEdgeWeightedDirectedGraph
    {
        int VerticesCount { get; }
        int EdgeCount { get; }
        void AddEdge(DirectedEdge edge);
        DirectedEdge[] AdjacentsOf(int v);
        DirectedEdge[] Edges();
        int GetDegree(int v);
        int GetMaxDegree();
        int GetNumberOfSelfLoops();
    }
}
