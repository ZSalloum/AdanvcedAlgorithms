using Algorithms.Toolkit.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class ShortestPathTree
    {
        private double[] distTo;
        private DirectedEdge[] edgeTo;

        public ShortestPathTree(EdgeWeightedDirectedGraph G, int s)
        {
            foreach (DirectedEdge e in G.Edges())
            {
                if (e.Weight < 0)
                    throw new ArgumentException("edge " + e + " has negative weight");
            }

            distTo = new double[G.VerticesCount];
            edgeTo = new DirectedEdge[G.VerticesCount];
            for (int v = 0; v < G.VerticesCount; v++)
                distTo[v] = Double.PositiveInfinity;
            distTo[s] = 0.0;

            // relax vertices in order of distance from s
            IndexMinPriorityQueue<Double> pq = new IndexMinPriorityQueue<Double>(G.VerticesCount);
            pq.Insert(s, distTo[s]);
            while (!pq.IsEmpty)
            {
                int v = pq.DeleteMin();
                foreach (DirectedEdge e in G.AdjacentsOf(v))
                    Relax(e);
            }

        }

        public double DistanceTo(int v)
        {
            return distTo[v];
        }

        public DirectedEdge[] PathTo(int v)
        {
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for(DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From])
            {
                path.Push(e);
            }
            return path.ToArray();
        }

        private void Relax(DirectedEdge edge)
        {
            int v = edge.From;
            int w = edge.To;
            if (distTo[w] > distTo[v] + edge.Weight)
            {
                edgeTo[w] = edge;
                distTo[w] = distTo[v] + edge.Weight;
            }
        }
    }
}
