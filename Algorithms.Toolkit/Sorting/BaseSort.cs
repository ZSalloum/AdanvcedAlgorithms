using Algorithms.Toolkit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public class BaseSort<T> : BaseComparable<T> 
        where T : IComparable<T>
    {

        protected bool IsSorted(T[] a, int lo, int hi, SortDirection direction)
        {
            if(direction == SortDirection.Ascending)
            {
                return IsSortedAsc(a, lo, hi);
            }
            return IsSortedDesc(a, lo, hi);
        }

        protected bool IsSortedAsc(T[] a, int lo, int hi)
        {
            for (int i = lo; i < hi; i++)
            {
                if (!LessOrEqual(a[i], a[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        protected bool IsSortedDesc(T[] a, int lo, int hi)
        {
            for (int i = lo; i < hi; i++)
            {
                if (!GreaterOrEqual(a[i], a[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
