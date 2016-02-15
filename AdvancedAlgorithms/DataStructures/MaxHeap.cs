using Algorithms.Toolkit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.DataStructures
{
    public class MaxHeap<T> : BaseComparable<T> 
        where T : IComparable
    {
        private List<T> data = new List<T>();

        public MaxHeap()
        {
            data.Add(default(T));
        }

        public void Push(T v)
        {
            data.Add(v);
            Promote(data.Count - 1);
        }

        public T Pop()
        {
            int last = data.Count - 1;
            if (last >= 1)
            {
                T v = data[1];
                data[1] = data[last];
                Demote(1);
                data.RemoveAt(last);
                return v;
            }
            throw new ApplicationException("Empty heap");
        }

        public T[] ToArray()
        {
            return data.ToArray();
        }

        private void Promote(int index)
        {
            while(index > 1 && Less(data[index / 2], data[index]))
            {
                Swap(index, index / 2);
                index = index / 2;
            }
        }

        private void Demote(int index)
        {
            while (index * 2 < data.Count)
            {
                int j = index * 2;

                if(j < data.Count - 1 && Less(data[j], data[j+1]))
                {
                    j++;
                }
                if (!Less(data[index], data[j])) break;
                Swap(index, j);
                index = j;
            }
        }

        private void Swap(int i, int j)
        {
            T t = data[i];
            data[i] = data[j];
            data[j] = t;
        }


    }
}
