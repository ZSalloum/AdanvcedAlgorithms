using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public class QuickSort<T> : BaseSort<T>
        where T : IComparable
    {
        private SortDirection direction;
        //public static void SortInt(int[] a)
        //{
        //    QuickSort<int> intQS = new QuickSort<int>();
        //    intQS.Sort(a);
        //}

        public void Sort(T[] a, SortDirection direction)
        {
            ResetCounters();
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSorted(a, 0, a.Length - 1, direction));
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if(hi <= lo)
            {
                return;
            }

            int m = Partition(a, lo, hi);
            Sort(a, lo, m - 1);
            Sort(a, m + 1, hi);
        }

        private int Partition(T[] a, int lo, int hi)
        {
            T pivot = a[lo];
            int i = lo;
            int j = hi + 1;

            while(true)
            {
                while (Compare(a[++i], pivot)) if (i == hi) break;
                while (Compare(pivot, a[--j])) if (j == lo) break;
                if (i >= j) break;
                Swap(a, i, j);

            }
            Swap(a, lo, j);

            
            return j;
        }

        private void Swap(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        private bool Compare(T a, T b)
        {
            if (direction == SortDirection.Ascending)
            {
                return Less(a, b);
            }

            return Greater(a, b);
        }

    }
}
