using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.Common
{
    public class BaseComparable<T> where T : IComparable<T>
    {
        private int comparisonCount = 0;

        public int ComparisonCount
        {
            get
            {
                return comparisonCount;
            }
        }

        public void ResetCounters()
        {
            comparisonCount = 0;
        }

        protected bool Less(T a, T b)
        {
            comparisonCount++;
            return a.CompareTo(b) <= 0;
        }

        protected bool Greater(T a, T b)
        {
            comparisonCount++;
            return a.CompareTo(b) >= 0;
        }
    }
}
