using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class DirectedEdge : IComparable<DirectedEdge>
    {
        private int from;
        private int to;
        private double weight;

        public DirectedEdge(int from, int to, double weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public int From
        {
            get
            {
                return from;
            }
        }

        public int To
        {
            get
            {
                return to;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
        }

        public int CompareTo(DirectedEdge other)
        {
            if (this.weight > other.weight) return +1;
            if (this.weight < other.weight) return -1;
            return 0;
        }


    }
}
