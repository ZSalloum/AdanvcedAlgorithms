using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Toolkit.Sorting;

namespace Algorithms.Toolkit.UnitTest
{
    [TestClass]
    public class SortingUnitTest
    {

        [TestMethod]
        public void TestMergeSort()
        {
            // given
            int[] a = { 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sa = { 1, 2, 3, 4, 5, 6, 7, 8 , 9 , 10 };
            int[] b = { 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sb = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // when
            SortHelper.MergeSort(a, SortDirection.Ascending);
            SortHelper.MergeSort(b, SortDirection.Descending);

            // then
            Assert.IsTrue(EqualArrays(a, sa));
            Assert.IsTrue(EqualArrays(b, sb));
        }


        [TestMethod]
        public void TestQuickSort()
        {
            // given
            int[] a = { 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sa = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] b = { 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sb = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // when
            SortHelper.QuickSort(a, SortDirection.Ascending);
            SortHelper.QuickSort(b, SortDirection.Descending);

            // then
            Assert.IsTrue(EqualArrays(a, sa));
            Assert.IsTrue(EqualArrays(b, sb));
        }

        [TestMethod]
        public void Test3WayQuickSort()
        {
            // given
            int[] a = { 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sa = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] b = { 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sb = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // when
            SortHelper.ThreeWayQuickSort(a, SortDirection.Ascending);
            SortHelper.ThreeWayQuickSort(b, SortDirection.Descending);

            // then
            Assert.IsTrue(EqualArrays(a, sa));
            Assert.IsTrue(EqualArrays(b, sb));
        }

        [TestMethod]
        public void TestHeapSort()
        {
            // given
            int[] a = { 0, 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sa = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] b = { 0, 10, 1, 9, 3, 2, 6, 7, 4, 8, 5 };
            int[] sb = { 0, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // when
            SortHelper.HeapSort(a, SortDirection.Ascending);
            SortHelper.HeapSort(b, SortDirection.Descending);

            // then
            Assert.IsTrue(EqualArrays(a, sa));
            Assert.IsTrue(EqualArrays(b, sb));
        }

        private bool EqualArrays(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
    }
}
