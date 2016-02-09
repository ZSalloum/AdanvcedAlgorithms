using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Sorting
{
    public class QuickSort<T> : BaseSort<T>
        where T : IComparable
    {

        public static void SortInt(int[] a)
        {
            QuickSort<int> intQS = new QuickSort<int>();
            intQS.Sort(a);
        }

        public void Sort(T[] a)
        {
            ResetCounters();
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSortedAsc(a, 0, a.Length - 1));
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
                while (Less(a[++i], pivot)) if (i == hi) break;
                while (Less(pivot, a[--j])) if (j == lo) break;
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

    }
}
