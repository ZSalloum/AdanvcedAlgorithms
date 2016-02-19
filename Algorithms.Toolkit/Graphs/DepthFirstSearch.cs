using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class DepthFirstSearch
    {
        private bool[] marked;
        private int[] edgeTo;
        private IGraph graph;
        private int count;
        private int origin;

        public DepthFirstSearch(IGraph g)
        {
            graph = g;
            marked = new bool[g.VerticesCount];
        }

        public void Start(int v)
        {
            Reset();
            origin = v;
            DFS(v);
        }

        public int Origin
        {
            get
            {
                return origin;
            }
        }

        public bool IsMarked(int v)
        {
            return marked[v];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool HasPathTo(int v)
        {
            return IsMarked(v);
        }

        public int[] GetPathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for(int x = v; x != origin; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(origin);
            return path.ToArray();
        }

        private void DFS(int v)
        {
            count++;
            marked[v] = true;
            foreach (int w in graph.AdjacentsOf(v))
            {
                if (!marked[w])
                {
                    DFS(w);
                    edgeTo[w] = v;
                }
            }
        }

        private void Reset()
        {
            count = 0;
            for(int i = 0; i < graph.VerticesCount; i++)
            {
                marked[i] = false;
                edgeTo[i] = -1;
            }
        }
    }
}
