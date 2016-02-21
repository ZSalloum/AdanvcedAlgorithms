using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class TopologicalSort : DepthFirstSearch
    {
        protected IDirectedGraph digraph;
        protected Stack<int> postOrder;

        public TopologicalSort(IDirectedGraph g) : base(g)
        {
            digraph = g;
        }

        public override void Run(int start)
        {
            Reset();
            CycleDetection cycleDetection = new CycleDetection(digraph);
            cycleDetection.Run();

            if (cycleDetection.HasCycle)
            {
                throw new InvalidOperationException("Graph contains a cycle. It must be Acyclic.");
            }

            for(int v = 0; v < graph.VerticesCount; v++)
            {
                if (!IsVisited(v))
                {
                    DFS(v);
                }
            }
        }

        public override void Reset()
        {
            base.Reset();
            postOrder.Clear();
        }

        public int[] ReverseOrder()
        {
            return postOrder.ToArray();
        }

        protected override void DFS(int v)
        {
            count++;
            marked[v] = true;
            OnVisiting(v);

            foreach (int w in graph.AdjacentsOf(v))
            {
                if (!marked[w])
                {
                    DFS(w);
                    edgeTo[w] = v;
                }
                postOrder.Push(w);
            }
        }
    }
}
