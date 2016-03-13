using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public class ThreeWayQuickSort<T> : BaseSort<T>
        where T : IComparable<T>
    {
        private SortDirection direction;

        public void Sort(T[] a, SortDirection direction)
        {
            ResetCounters();
            this.direction = direction;
            Shuffle.ShuffleArray<T>(a);
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSorted(a, 0, a.Length - 1, direction));
        }


        // quicksort the subarray a[lo .. hi] using 3-way partitioning
        private void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo, gt = hi;
            T v = a[lo];
            int i = lo;
            while (i <= gt)
            {
                if(a[i].CompareTo(v) == 0)
                {
                    i++;
                }
                else if(Compare(a[i], v))
                {
                    Swap(a, lt++, i++);
                }
                else
                {
                    Swap(a, i, gt--);
                }
            }

            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]. 
            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
            //assert isSorted(a, lo, hi);
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
