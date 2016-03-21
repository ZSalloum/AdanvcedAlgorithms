using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Toolkit.Graphs;

namespace Algorithms.Toolkit.UnitTest
{
    /// <summary>
    /// Summary description for GraphUnitTest
    /// </summary>
    [TestClass]
    public class GraphUnitTest
    {
        public GraphUnitTest()
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
        public void Should_Create_EdgeWeightedDirectedGraph()
        {
            //given
            EdgeWeightedDirectedGraph g = new EdgeWeightedDirectedGraph(8);
            DirectedEdge[] edges = { new DirectedEdge(0, 1, 10), new DirectedEdge(0, 7, 10), new DirectedEdge(0, 4, 10),
                                    new DirectedEdge(1, 2, 10), new DirectedEdge(1, 3, 10), new DirectedEdge(1, 7, 10),
                                    new DirectedEdge(2, 3, 10), new DirectedEdge(2, 6, 10),
                                    new DirectedEdge(3, 6, 10),
                                    new DirectedEdge(4, 5, 10), new DirectedEdge(4, 6, 10), new DirectedEdge(4, 7, 10),
                                    new DirectedEdge(5, 2, 10), new DirectedEdge(5, 6, 10),
                                    new DirectedEdge(7, 5, 10), new DirectedEdge(7, 2, 10) };
            foreach(DirectedEdge e in edges)
            {
                g.AddEdge(e);
            }
            //when

            //then
             DirectedEdge[] tmp = g.AdjacentsOf(0);
            Assert.IsTrue(MatchEdges(0, tmp, 1, 7, 4));

            tmp = g.AdjacentsOf(1);
            Assert.IsTrue(MatchEdges(1, tmp, 2, 3, 7));

            tmp = g.AdjacentsOf(2);
            Assert.IsTrue(MatchEdges(2, tmp, 3, 6));

            tmp = g.AdjacentsOf(3);
            Assert.IsTrue(MatchEdges(3, tmp, 6));

            tmp = g.AdjacentsOf(4);
            Assert.IsTrue(MatchEdges(4, tmp, 5, 6, 7));

            tmp = g.AdjacentsOf(5);
            Assert.IsTrue(MatchEdges(5, tmp, 2, 6));

            tmp = g.AdjacentsOf(6);
            Assert.IsTrue(MatchEdges(6, tmp));

            tmp = g.AdjacentsOf(7);
            Assert.IsTrue(MatchEdges(7, tmp, 5, 2));
        }


        private bool MatchEdges(int from, DirectedEdge[] edges, params int[] to)
        {
            int edgesCount = 0;
            Dictionary<int, bool> tmp = new Dictionary<int, bool>();
            if (to != null)
            {
                foreach (int t in to)
                {
                    tmp[t] = false;
                }
            }

            if (edges != null)
            {
                edgesCount = edges.Length;
                foreach (DirectedEdge e in edges)
                {
                    if (e.From != from) return false;
                    if (!tmp.ContainsKey(e.To)) return false;
                    if (tmp[e.To]) return false;
                    tmp[e.To] = true;
                }
            }

            if (tmp.Count != edgesCount) return false;

            return true;

        }
    }
}
