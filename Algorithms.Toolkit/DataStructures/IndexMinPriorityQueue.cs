using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Toolkit.Common;

namespace Algorithms.Toolkit.DataStructures
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class IndexMinPriorityQueue<Key> : BaseComparable<Key>
        where Key : IComparable<Key>
    {

        /**
         *  The <tt>IndexMinPQ</tt> class represents an indexed priority queue of generic keys.
         *  It supports the usual <em>insert</em> and <em>delete-the-minimum</em>
         *  operations, along with <em>delete</em> and <em>change-the-key</em> 
         *  methods. In order to let the client refer to keys on the priority queue,
         *  an integer between 0 and maxN-1 is associated with each key&mdash;the client
         *  uses this integer to specify which key to delete or change.
         *  It also supports methods for peeking at the minimum key,
         *  testing if the priority queue is empty, and iterating through
         *  the keys.
         *  <p>
         *  This implementation uses a binary heap along with an array to associate
         *  keys with integers in the given range.
         *  The <em>insert</em>, <em>delete-the-minimum</em>, <em>delete</em>,
         *  <em>change-key</em>, <em>decrease-key</em>, and <em>increase-key</em>
         *  operations take logarithmic time.
         *  The <em>is-empty</em>, <em>size</em>, <em>min-index</em>, <em>min-key</em>, and <em>key-of</em>
         *  operations take constant time.
         *  Construction takes time proportional to the specified capacity.
         *  <p>
         *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> of
         *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
         *
         *  @author Robert Sedgewick
         *  @author Kevin Wayne
         *
         *  @param <Key> the generic type of key on this priority queue
         */

        private int maxCount;        // maximum number of elements on PQ
        private int count;           // number of elements on PQ
        private int[] pq;        // binary heap using 1-based indexing
        private int[] qp;        // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        private Key[] keys;      // keys[i] = priority of i

        /**
         * Initializes an empty indexed priority queue with indices between <tt>0</tt>
         * and <tt>maxN - 1</tt>.
         * @param  maxN the keys on this priority queue are index from <tt>0</tt>
         *         <tt>maxN - 1</tt>
         * @throws IllegalArgumentException if <tt>maxN</tt> &lt; <tt>0</tt>
         */
        public IndexMinPriorityQueue(int maxCount)
        {
            if (maxCount < 0) throw new ArgumentOutOfRangeException();
            this.maxCount = maxCount;
            keys = new Key[maxCount + 1];
            pq = new int[maxCount + 1];
            qp = new int[maxCount + 1];             
            for (int i = 0; i <= maxCount; i++)
                qp[i] = -1;
        }

        /**
         * Returns true if this priority queue is empty.
         *
         * @return <tt>true</tt> if this priority queue is empty;
         *         <tt>false</tt> otherwise
         */
        public bool IsEmpty
        {
            get { return count == 0; }
        }

        /**
         * Is <tt>i</tt> an index on this priority queue?
         *
         * @param  i an index
         * @return <tt>true</tt> if <tt>i</tt> is an index on this priority queue;
         *         <tt>false</tt> otherwise
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         */
        public bool Contains(int i)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            return qp[i] != -1;
        }

        /**
         * Returns the number of keys on this priority queue.
         *
         * @return the number of keys on this priority queue
         */
        public int Count
        {
            get { return count; }
        }

        public int MaxCount
        {
            get { return maxCount; }
        }


        /// <summary>
        /// Associates key with index <tt>i</tt>
        /// </summary>
        /// <param name="i"> an index</param>
        /// <param name="key">the key to associate with index <tt>i</tt></param>
        /// <exception cref="IndexOutOfRangeException">unless 0 &le; <tt>i</tt> &lt; <tt>MaxCount</tt></exception>
        /// <exception cref="ArgumentException">if there already is an item associated with index <tt>i</tt></exception>
        public void Insert(int i, Key key)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            if (Contains(i)) throw new ArgumentException("index is already in the priority queue");
            count++;
            qp[i] = count;
            pq[count] = i;
            keys[i] = key;
            Promote(count);
        }

        /**
         * Returns an index associated with a minimum key.
         *
         * @return an index associated with a minimum key
         * @throws NoSuchElementException if this priority queue is empty
         */
        public int MinIndex
        {
            get
            {
                if (count == 0) throw new ArgumentException("Priority queue underflow");
                return pq[1];
            }
        }

        /**
         * Returns a minimum key.
         *
         * @return a minimum key
         * @throws NoSuchElementException if this priority queue is empty
         */
        public Key MinKey
        {
            get
            {
                if (count == 0) throw new ArgumentException("Priority queue underflow");
                return keys[pq[1]];
            }
        }

        /**
         * Removes a minimum key and returns its associated index.
         * @return an index associated with a minimum key
         * @throws NoSuchElementException if this priority queue is empty
         */
        public int DeleteMin()
        {
            if (count == 0) throw new ArgumentException("Priority queue underflow");
            int min = pq[1];
            Swap(1, count--);
            Demote(1);
            Debug.Assert(min == pq[count + 1]);
            qp[min] = -1;        // delete
            keys[min] = default(Key);    // to help with garbage collection
            pq[count + 1] = -1;        // not needed
            return min;
        }

        /**
         * Returns the key associated with index <tt>i</tt>.
         *
         * @param  i the index of the key to return
         * @return the key associated with index <tt>i</tt>
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         * @throws NoSuchElementException no key is associated with index <tt>i</tt>
         */
        public Key KeyOf(int i)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            else return keys[i];
        }

        /**
         * Change the key associated with index <tt>i</tt> to the specified value.
         *
         * @param  i the index of the key to change
         * @param  key change the key associated with index <tt>i</tt> to this key
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         * @throws NoSuchElementException no key is associated with index <tt>i</tt>
         */
        public void ChangeKey(int i, Key key)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            keys[i] = key;
            Promote(qp[i]);
            Demote(qp[i]);
        }

        /**
         * Change the key associated with index <tt>i</tt> to the specified value.
         *
         * @param  i the index of the key to change
         * @param  key change the key associated with index <tt>i</tt> to this key
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         * @deprecated Replaced by {@link #changeKey(int, Key)}.
         */
        public void Change(int i, Key key)
        {
            ChangeKey(i, key);
        }

        /**
         * Decrease the key associated with index <tt>i</tt> to the specified value.
         *
         * @param  i the index of the key to decrease
         * @param  key decrease the key associated with index <tt>i</tt> to this key
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         * @throws IllegalArgumentException if key &ge; key associated with index <tt>i</tt>
         * @throws NoSuchElementException no key is associated with index <tt>i</tt>
         */
        public void DecreaseKey(int i, Key key)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            if (keys[i].CompareTo(key) <= 0)
                throw new ArgumentException("Calling decreaseKey() with given argument would not strictly decrease the key");
            keys[i] = key;
            Promote(qp[i]);
        }

        /**
         * Increase the key associated with index <tt>i</tt> to the specified value.
         *
         * @param  i the index of the key to increase
         * @param  key increase the key associated with index <tt>i</tt> to this key
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         * @throws IllegalArgumentException if key &le; key associated with index <tt>i</tt>
         * @throws NoSuchElementException no key is associated with index <tt>i</tt>
         */
        public void IncreaseKey(int i, Key key)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            if (keys[i].CompareTo(key) >= 0)
                throw new ArgumentException("Calling increaseKey() with given argument would not strictly increase the key");
            keys[i] = key;
            Demote(qp[i]);
        }

        /**
         * Remove the key associated with index <tt>i</tt>.
         *
         * @param  i the index of the key to remove
         * @throws IndexOutOfBoundsException unless 0 &le; <tt>i</tt> &lt; <tt>maxN</tt>
         * @throws NoSuchElementException no key is associated with index <t>i</tt>
         */
        public void Delete(int i)
        {
            if (i < 0 || i >= maxCount) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            int index = qp[i];
            Swap(index, count--);
            Promote(index);
            Demote(index);
            keys[i] = default(Key);
            qp[i] = -1;
        }


        /***************************************************************************
         * General helper functions.
         ***************************************************************************/
        private bool Greater(int i, int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        private void Swap(int i, int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }


        /***************************************************************************
         * Heap helper functions.
         ***************************************************************************/
        private void Promote(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void Demote(int k)
        {
            while (2 * k <= count)
            {
                int j = 2 * k;
                if (j < count && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }
    }
}
