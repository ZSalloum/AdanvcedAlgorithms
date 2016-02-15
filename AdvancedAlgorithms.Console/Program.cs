using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Toolkit.Sorting;
using Algorithms.Toolkit.DataStructures;

namespace AdvancedAlgorithms.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 10, 4, 6, 8, 2, 5, 3, 0, 7 };

            //TestQuickSort(a);
            //TestMergeSort(a);
            //TestMaxHeap();
            //TestHeapSort();

            System.Console.WriteLine("\n\nPress ENTER to quit");
            System.Console.ReadLine();
        }


        private static void TestQuickSort(int[] a)
        {
            Random r = new Random(10000);
            a = new int[1000];
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = i;// a.Length - i;
            }
            QuickSort<int> qs = new QuickSort<int>();
            qs.Sort(a);
            //DisplayArray(a);
            System.Console.WriteLine("Comparison in sorted array : {0}", qs.ComparisonCount);
            

            
            for (int i = 0; i < a.Length; i++)
            {
                int j = r.Next(i);
                int tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
            }
            //DisplayArray(a);
            qs.Sort(a);

            //DisplayArray(a);
            System.Console.WriteLine("Comparison in random array : {0}", qs.ComparisonCount);
            DisplaySeparator();
        }


        private static void TestMergeSort(int[] a)
        {
            SortHelper.MergeSort(a);
            DisplayArray(a);
            DisplaySeparator();
        }

        private static void TestHeapSort()
        {
            int[] a = {0, 1, 4, 6, 8, 10, 2, 5, 3, 0, 7 };
            HeapSort<int> mh = new HeapSort<int>();

            mh.Sort(a);
            DisplayArray(a);
            DisplaySeparator();
        }

        private static void TestMaxHeap()
        {
            int[] a = { 1, 4, 6, 8, 10, 2, 5, 3, 0, 7 };
            MaxHeap<int> mh = new MaxHeap<int>();

            for (int i = 0; i < a.Length; i++)
            {
                mh.Push(a[i]);
            }

            DisplayArray(mh.ToArray());
            DisplaySeparator();

            for (int i = 0; i < a.Length; i++)
            {
                int v = mh.Pop();
                System.Console.Write("Pop {0}  :  ", v);
                DisplayArray(mh.ToArray());
                System.Console.WriteLine("");
            }

            DisplayArray(mh.ToArray());
            DisplaySeparator();
        }

        private static void DisplayArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                System.Console.Write(a[i]);
                System.Console.Write(", ");
            }
            System.Console.WriteLine();
        }



        private static void DisplaySeparator()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=============================\n");
        }
    }
}
