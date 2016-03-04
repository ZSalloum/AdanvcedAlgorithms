using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class CycleDetection 
    {

        protected bool[] marked;
        protected IGraph graph;
        protected int count;
        private Boolean hasCycle;

        public CycleDetection(IGraph g)
        {
            graph = g;
            marked = new bool[graph.VerticesCount];
        }

        public void Run()
        {
            Reset();
            for (int v = 0; v < graph.VerticesCount; v++)
            {
                DFS(v, v);
            }
        }

        private void DFS(int v, int source)
        {
            if (hasCycle) return;

            count++;
            marked[v] = true;
            
            foreach (int w in graph.AdjacentsOf(v))
            {
                if (!marked[w])
                {
                    DFS(w, v);
                }
                else if (w != source) // if the marked node is not the one we are coming
                {                     //  from (source) then this is a cycle.
                    hasCycle = true; 
                    return;
                }
            }
        }

        public bool HasCycle
        {
            get
            {
                return hasCycle;
            }
        }

        public void Reset()
        {
            count = 0;
            hasCycle = false;
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                marked[i] = false;
            }
        }
    }
}
