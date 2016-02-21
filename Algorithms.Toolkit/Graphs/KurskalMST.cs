using Algorithms.Toolkit.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class KurskalMST
    {
        private IEdgeWeightedGraph graph;
        private Queue<Edge> mst = new Queue<Edge>();

        public KurskalMST(IEdgeWeightedGraph graph)
        {
            this.graph = graph;
        }

        public void Run()
        {
            MinHeap<Edge> minHeap = new MinHeap<Edge>();
            foreach(Edge e in graph.Edges())
            {
                minHeap.Push(e);
            }

            UnionFind<int> uf = new UnionFind<int>();
            while(minHeap.Count > 0 && mst.Count < graph.VerticesCount - 1)
            {
                Edge e = minHeap.Pop();
                int v = e.GetEither();
                int w = e.GetOther(v);
                if(!uf.IsConnected(v, w))
                {
                    uf.Merge(v, w);
                    mst.Enqueue(e);
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
