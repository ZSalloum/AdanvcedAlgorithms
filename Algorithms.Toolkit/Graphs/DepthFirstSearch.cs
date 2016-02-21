using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class DepthFirstSearch : BaseGraphSearch
    {

        public DepthFirstSearch(IGraph g) : base(g)
        {
        }

        public override void Run(int start)
        {
            Reset();
            origin = start;
            DFS(start);
        }

        public override void Continue(int start)
        {
            DFS(start);
        }

        protected virtual void DFS(int v)
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
            }

            OnVisited(v);
        }

    }
}
