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
