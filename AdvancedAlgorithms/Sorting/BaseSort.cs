using AdvancedAlgorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Sorting
{
    public class BaseSort<T> : BaseComparable<T> 
        where T : IComparable
    {



        protected bool IsSortedAsc(T[] a, int lo, int hi)
        {
            for (int i = lo; i < hi; i++)
            {
                if (!Less(a[i], a[i + 1]))
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
                if (!Greater(a[i], a[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
