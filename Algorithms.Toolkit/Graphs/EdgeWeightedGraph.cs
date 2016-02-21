using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class EdgeWeightedGraph : IEdgeWeightedGraph
    {
        protected List<Edge>[] adjacents;
        protected int edgeCount;

        public EdgeWeightedGraph(int count)
        {
            edgeCount = 0;
            var adjacents = new List<int>[count];
            for (int i = 0; i < count; i++)
            {
                adjacents[i] = null;
            }
        }

        public Edge[] AdjacentsOf(int v)
        {
            return adjacents[v].ToArray();
        }

        public int EdgeCount
        {
            get
            {
                return edgeCount;
            }
        }

        public int VerticesCount
        {
            get
            {
                return adjacents.Length;
            }
        }

        public virtual void AddEdge(Edge edge)
        {
            edgeCount++;
            int v = edge.GetEither();
            int w = edge.GetOther(v);
            if (adjacents[v] == null)
            {
                adjacents[v] = new List<Edge>();
            }
            if (adjacents[w] == null)
            {
                adjacents[w] = new List<Edge>();
            }
            adjacents[v].Add(edge);
            adjacents[w].Add(edge);
        }

        /// <summary>
        /// Returns array of all edges in this edge-weighted graph.
        /// </summary>
        /// <returns></returns>
        public Edge[] Edges()
        {
            List<Edge> list = new List<Edge>();
            for (int v = 0; v < VerticesCount; v++)
            {
                int selfLoops = 0;
                foreach (Edge e in AdjacentsOf(v))
                {
                    if (e.GetOther(v) > v)
                    {
                        list.Add(e);
                    }
                    // only add one copy of each self loop (self loops will be consecutive)
                    else if (e.GetOther(v) == v)
                    {
                        if (selfLoops % 2 == 0) list.Add(e);
                        selfLoops++;
                    }
                }
            }
            return list.ToArray();
        }

        public int GetDegree(int v)
        {
            if (adjacents[v] == null)
            {
                return 0;
            }
            return adjacents[v].Count;
        }

        public int GetMaxDegree()
        {
            int max = 0;
            for (int i = 0; i < VerticesCount; i++)
            {
                max = Math.Max(max, GetDegree(i));
            }
            return max;
        }

        public int GetNumberOfSelfLoops()
        {
            int count = 0;
            for (int v = 0; v < VerticesCount; v++)
                foreach (Edge edge in AdjacentsOf(v))
                {
                    if (v == edge.GetOther(v)) count++;
                }
            return count / 2;   // self loop appears in adjacency list twice
        }
    }
}
