using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class Graph : IGraph
    {
         private List<int>[] adjacents;
        private int edgeCount;

        public Graph(int count)
        {
            edgeCount = 0;
            var adjacents = new List<int>[count];
            for(int i = 0; i < count; i++)
            {
                adjacents[i] = null;
            }
        }

        public int[] AdjacentsOf(int v)
        {
            return adjacents[v].ToArray();
        }

        public int EdgeCount
        {
            get
            {
                return edgeCount;
            }
        }

        public int VerticesCount
        {
            get
            {
                return adjacents.Length;
            }
        }

        public void AddEdge(int v, int  w )
        {
            edgeCount++;
            if(adjacents[v] == null)
            {
                adjacents[v] = new List<int>();
            }
            if (adjacents[w] == null)
            {
                adjacents[w] = new List<int>();
            }
            adjacents[v].Add(w);
            adjacents[w].Add(v);
        }

        public int GetDegree(int v)
        {
            if (adjacents[v] == null)
            {
                return 0;
            }
            return adjacents[v].Count;
        }

        public int GetMaxDegree()
        {
            int max = 0;
            for (int i = 0; i < VerticesCount; i++)
            {
                max = Math.Max(max, GetDegree(i));
            }
            return max;
        }

        public int GetNumberOfSelfLoops()
        {
            int count = 0;
            for (int v = 0; v < VerticesCount; v++)
                foreach (int w in AdjacentsOf(v))
                {
                    if (v == w) count++;
                }
            return count / 2;   // self loop appears in adjacency list twice
        }

    }
}
