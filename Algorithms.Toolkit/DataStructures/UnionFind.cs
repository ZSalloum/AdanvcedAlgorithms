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

        public int Add(T data)
        {
            int newId = ids.Count;
            ids.Add(new UnionFindEntry() { Data = data, Parent = newId });
            return newId;
        }

        public void AddRange(T[] array)
        {
            foreach(T a in array)
            {
                Add(a);
            }
        }

        public int Count
        {
            get
            {
                return ids.Count;
            }
        }

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

        public void Clear()
        {
            ids.Clear();
        }

        private int GetRoot(int id)
        {
            while(ids[id].Parent != id)
            {
                int parent = ids[id].Parent;
                ids[id].Parent = ids[parent].Parent; // link to the grand parent on the go
                id = ids[id].Parent;
            }

            return id;
        }


    }
}
