using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public class MergeSort<T> : BaseSort<T>
        where T : IComparable
    {
        private T[] tmp;
        private SortDirection direction;

        public void Sort(T[] a, SortDirection direction)
        {
            tmp = new T[a.Length];
            this.direction = direction;
            Sort(a, 0, a.Length - 1);
            tmp = null;
            Debug.Assert(IsSorted(a, 0, a.Length - 1, direction));
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if(hi <= lo)
            {
                return;
            }

            int mid = (lo + hi) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);
            Merge(a, lo, mid, hi);
        }

        private void Merge(T[] a, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
            {
                tmp[k] = a[k];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)                a[k] = tmp[j++];
                else if (j > hi)            a[k] = tmp[i++];
                else if (Compare(tmp[i], tmp[j]))  a[k] = tmp[i++];
                else                        a[k] = tmp[j++];
            }

            Debug.Assert(IsSorted(a, lo, hi, direction));
        }

        private bool Compare(T a, T b)
        {
            if(direction == SortDirection.Ascending)
            {
                return Less(a, b);
            }

            return Greater(a, b);
        }

    }
}
