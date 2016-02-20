using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class BipartiteDetection 
    {

        protected bool[] marked;
        protected bool[] colored;
        protected IGraph graph;
        protected int count;
        private Boolean isBipartite;

        public BipartiteDetection(IGraph g)
        {
            graph = g;
            marked = new bool[graph.VerticesCount];
            colored = new bool[graph.VerticesCount];
        }

        public void Run()
        {
            Reset();
            for (int v = 0; v < graph.VerticesCount; v++)
            {
                DFS(v);
            }
        }

        private void DFS(int v)
        {
            if (!isBipartite) return;

            count++;
            marked[v] = true;
            
            foreach (int w in graph.AdjacentsOf(v))
            {
                if (!marked[w])
                {
                    colored[w] = !colored[v];
                    DFS(w);
                }
                else if (colored[w] == colored[v])
                {
                    isBipartite = false; // if two adjacent nodes have the same color then this is not a bipartite graph.
                    return;
                }
            }
        }

        public bool HasCycle
        {
            get
            {
                return isBipartite;
            }
        }

        public void Reset()
        {
            count = 0;
            isBipartite = true;
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                marked[i] = false;
            }
        }
    }
}
