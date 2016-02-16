using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.DataStructures
{
    public class UnionFind<T>
    {
        private class UnionFindEntry
        {
            public int Parent;
            public T Data;
        }

        private List<UnionFindEntry> ids = new List<UnionFindEntry>();

        public void Merge(int id1, int id2)
        {
            int root1 = GetRoot(id1);
            int root2 = GetRoot(id2);

            ids[root2].Parent = root1;
        }

        public bool IsConnected(int id1, int id2)
        {
            int root1 = GetRoot(id1);
            int root2 = GetRoot(id2);
            return root1 == root2;
        }

        private int GetRoot(int id)
        {
            while(ids[id].Parent != id)
            {
                int parent = ids[id].Parent;
                ids[id].Parent = ids[parent].Parent; // paint to the grand parent on the go
                id = ids[id].Parent;
            }

            return id;
        }


    }
}
