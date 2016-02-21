using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class DirectedGraph : Graph, IDirectedGraph
    {
        public DirectedGraph(int count):base(count)
        {
        }

        public override void AddEdge(int v, int w)
        {
            edgeCount++;
            if (adjacents[v] == null)
            {
                adjacents[v] = new List<int>();
            }
            adjacents[v].Add(w);
        }
    }
}
