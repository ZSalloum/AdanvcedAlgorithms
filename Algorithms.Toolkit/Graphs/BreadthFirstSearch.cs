using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class BreadthFirstSearch : BaseGraphSearch
    {


        public BreadthFirstSearch(IGraph g) : base(g)
        {
            
        }

        public override void Run(int start)
        {
            Reset();
            origin = start;
            BFS(start);
        }

        public override void Continue(int start)
        {
            BFS(start);
        }

        protected void BFS(int s)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            marked[s] = true;
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                count++;
                OnVisiting(v);

                foreach (int w in graph.AdjacentsOf(v))
                {
                    if (!marked[w])
                    {
                        q.Enqueue(w);
                        marked[w] = true;
                        edgeTo[w] = v;
                    }
                }
            }
        }
    }
}
