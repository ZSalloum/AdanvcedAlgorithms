using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public interface IGraph
    {
        int VerticesCount { get; }
        int EdgeCount { get; }
        void AddEdge(int v, int w);
        int[] AdjacentsOf(int v);
        int GetDegree(int v);
        int GetMaxDegree();
        int GetNumberOfSelfLoops();
    }
}
