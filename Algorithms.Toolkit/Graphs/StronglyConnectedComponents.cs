using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Graphs
{
    public class StronglyConnectedComponents
    {
        private int[] components;
        private int componentId = 0;
        private DepthFirstSearch dfs;
        private IDirectedGraph graph;

        public StronglyConnectedComponents(IDirectedGraph g) {
            graph = g;
            dfs = new DepthFirstSearch(g);
            dfs.VisitingVertex += Dfs_VisitingVertex;
        }

        public void Run()
        {
            Reset();
            components = new int[graph.VerticesCount];
            TopologicalSort ts = new TopologicalSort(graph);
            ts.Run(0);

            for(int v = 0; v < ts.ReverseOrder().Length; v++)
            {
                if (!dfs.IsVisited(v))
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
