using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public class HeapSort<T> : BaseSort<T>
        where T : IComparable<T>
    {
        private T[] data;
        private SortDirection direction;

        public void Sort(T[] a, SortDirection direction)
        {
            data = a;
            this.direction = direction;
            Sort();
        }

        private void Sort()
        {
            int l = data.Length / 2;
            for(int i = l; i >= 1; i--)
            {
                Demote(i, l);
            }

            // now the head contains the biggest or smallest number (deending on sort order/direction)
            // in order to sort we pull that number from the head and put it aside, then recompute the heap
            // to find a new biggest or smallest number then pull it and put it next to the previously pulled number,
            // etc....
            // However putting those numbers pulled from the head in an another array will consume more space than we want to.
            // That's why we put them at the end of the same array, while taking care of telling the algorithm that the
            // part of the array representing the heap is getting shorter in theory (its length is decreasing)
            l = data.Length - 1;
            while (l > 1)
            {
                SwapPositions(1, l--);
                Demote(1, l);
            }
        }

        private void Demote(int index, int length)
        {
            while (index * 2 <= length)
            {
                int j = index * 2;

                if (j < length && Compare(data[j], data[j + 1]))
                {
                    j++;
                }
                if (!Compare(data[index], data[j])) break;
                SwapPositions(index, j);
                index = j;
            }
        }

        private void SwapPositions(int i, int j)
        {
            T t = data[i];
            data[i] = data[j];
            data[j] = t;
        }

        private bool Compare(T a, T b)
        {
            if(direction == SortDirection.Ascending)
            {
                return Less(a, b);
            }
            else // (direction == SortDirection.Descending)
            {
                return Greater(a, b);
            }

            
        }

    }
}
