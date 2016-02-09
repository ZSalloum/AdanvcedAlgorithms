using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Sorting
{
    public class HeapSort<T> : BaseSort<T>
        where T : IComparable
    {
        private T[] data;

        public void Sort(T[] a)
        {
            data = a;
            Sort();
        }

        private void Sort()
        {
            int l = data.Length / 2;
            for(int i = l; i >= 1; i--)
            {
                Demote(i, l);
            }

            l = data.Length - 1;
            while (l > 1)
            {
                Swap(1, l--);
                Demote(1, l);
            }
        }

        private void Demote(int index, int length)
        {
            while (index * 2 <= length)
            {
                int j = index * 2;

                if (j < length && Less(data[j], data[j + 1]))
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
