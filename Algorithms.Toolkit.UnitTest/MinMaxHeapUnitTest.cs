using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Toolkit.DataStructures;

namespace Algorithms.Toolkit.UnitTest
{
    /// <summary>
    /// Summary description for MinMaxHeapUnitTest
    /// </summary>
    [TestClass]
    public class MinMaxHeapUnitTest
    {
        public MinMaxHeapUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMinMaxHeap()
        {

            // given
            int[] a = { 1, 4, 6, 8, 10, 2, 5, 3, 0, 7 };
            int[] sortedArray = { 0, 1, 2, 3, 4, 5 , 6 , 7, 8, 10 };

            MaxHeap<int> maxh = new MaxHeap<int>();
            MinHeap<int> minh = new MinHeap<int>();

            // when
            for (int i = 0; i < a.Length; i++)
            {
                maxh.Push(a[i]);
                minh.Push(a[i]);
            }


            // then
            for (int i = 0; i < a.Length; i++)
            {
                int v = minh.Pop();
                Assert.AreEqual(v, sortedArray[i]);
            }
            
            for (int i = a.Length - 1; i >= 0 ; i--)
            {
                int v = maxh.Pop();
                Assert.AreEqual(v, sortedArray[i]);
            }


        }
    }
}
