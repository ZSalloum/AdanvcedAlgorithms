using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public delegate void VisitingVertexHandler(BaseGraphSearch sender, int v);

    public abstract class BaseGraphSearch
    {
        protected bool[] marked;
        protected int[] edgeTo;
        protected IGraph graph;
        protected int count;
        protected int origin;

        public event VisitingVertexHandler VisitingVertex;

        public BaseGraphSearch(IGraph g)
        {
            graph = g;
            marked = new bool[g.VerticesCount];
        }

        // run the search algorithm
        public abstract void Run(int start);

        // continue the search algorithm without reseting 
        public abstract void Continue(int start);


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
            for (int x = v; x != origin; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(origin);
            return path.ToArray();
        }

        public void Reset()
        {
            count = 0;
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                marked[i] = false;
                edgeTo[i] = -1;
            }
        }

        protected virtual void OnVisiting(int v)
        {
            if(VisitingVertex != null)
            {
                VisitingVertex(this, v);
            }
        }
    }
}
