using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public static class SortHelper
    {
        public static void MergeSort(int[] a, SortDirection direction)
        {
            MergeSort<int> ms = new MergeSort<int>();
            ms.Sort(a, direction);
        }

        public static void QuickSort(int[] a, SortDirection direction)
        {
            QuickSort<int> qs = new QuickSort<int>();
            qs.Sort(a, direction);
        }

        public static void ThreeWayQuickSort(int[] a, SortDirection direction)
        {
            ThreeWayQuickSort<int> qs = new ThreeWayQuickSort<int>();
            qs.Sort(a, direction);
        }

        public static void HeapSort(int[] a, SortDirection direction)
        {
            HeapSort<int> hs = new HeapSort<int>();
            hs.Sort(a, direction);
        }
    }
}
