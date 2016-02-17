using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Sorting
{
    public static class Shuffle
    {
        public static void ShuffleArray<T>(T[] a)
        {
            Random random = new Random();
            for(int i = 1; i < a.Length; i++)
            {
                int r = random.Next(0, i);
                Swap<T>(a, r, i);
            }
        }

        public static void ShuffleList<T>(List<T> l)
        {
            Random random = new Random();
            for (int i = 1; i < l.Count; i++)
            {
                int r = random.Next(0, i);
                Swap<T>(l, r, i);
            }
        }

        private static void Swap<T>(T[]a, int i, int j)
        {
            T tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        private static void Swap<T>(List<T> l, int i, int j)
        {
            T tmp = l[i];
            l[i] = l[j];
            l[j] = tmp;
        }
    }
}
