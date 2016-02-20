using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class ConnectedComponents
    {
        private int[] components;
        private int componentId = 0;
        private DepthFirstSearch dfs;
        private IGraph graph;

        public ConnectedComponents(IGraph g) {
            graph = g;
            dfs = new DepthFirstSearch(g);
            dfs.VisitingVertex += Dfs_VisitingVertex;
        }

        public void Run()
        {
            Reset();
            components = new int[graph.VerticesCount];
            for(int v = 0; v < graph.VerticesCount; v++)
            {
                if (!dfs.IsMarked(v))
                {
                    dfs.Continue(v);
                    componentId++;
                }
            }
        }

        public bool IsConnected(int v, int w)
        {
            return components[v] == components[w];
        }


        public int GetComponentId(int v)
        {
            return components[v];
        }


        public int Count
        {
            get
            {
                return componentId;
            }
        }


        private void Dfs_VisitingVertex(BaseGraphSearch sender, int v)
        {
            components[v] = componentId;
        }

        private void Reset()
        {
            dfs.Reset();
            componentId = 0;
        }
    }
}
