using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public static class SortHelper
    {
        public static void MergeSort(int[] a)
        {
            MergeSort<int> ms = new MergeSort<int>();
            ms.Sort(a);
        }
    }
}
