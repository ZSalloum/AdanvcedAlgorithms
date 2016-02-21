using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class Edge : IComparable<Edge>
    {
        private int v;
        private int w;
        private double weight;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public int GetEither()
        {
            return v;
        }

        public int GetOther(int vertex)
        {
            if (v == vertex) return w;
            else if (w == vertex) return v;
            throw new ArgumentException(String.Format("Vertex '{0}' does not belong to this edge", vertex));
        }

        public double Weight
        {
            get
            {
                return weight;
            }
        }

        public int CompareTo(Edge other)
        {
            if (this.weight > other.weight) return +1;
            if (this.weight < other.weight) return -1;
            return 0;
        }


    }
}
