using Algorithms.Toolkit.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class LazyPrimMST
    {
        private IEdgeWeightedGraph graph;
        private bool[] marked;
        private Queue<Edge> mst = new Queue<Edge>();
        private MinHeap<Edge> minHeap = new MinHeap<Edge>();

        public LazyPrimMST(IEdgeWeightedGraph graph)
        {
            this.graph = graph;
            this.marked = new bool[graph.VerticesCount];
        }

        public void Run()
        {
            Reset();
            Visit(0);

            
            while (!minHeap.IsEmpty)
            {
                Edge e = minHeap.Pop();
                int v = e.GetEither();
                int w = e.GetOther(v);
                if (marked[v] && marked[w]) continue;
                mst.Enqueue(e);
                if (!marked[v]) Visit(v);
                if (!marked[w]) Visit(w);
            }
        }

        private void Reset()
        {
            mst.Clear();
            minHeap.Clear();
        }

        private void Visit(int v)
        {
            marked[v] = true;
            foreach(Edge e in graph.AdjacentsOf(v))
            {
                if (!marked[e.GetOther(v)])
                {
                    minHeap.Push(e);
                }
            }
        }

        public Edge[] Edges
        {
            get
            {
                return mst.ToArray();
            }
        }
    }
}
