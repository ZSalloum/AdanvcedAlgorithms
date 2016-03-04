using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Toolkit.DataStructures;

namespace Algorithms.Toolkit.UnitTest
{
    [TestClass]
    public class UnionFindUnitTest
    {
        [TestMethod]
        public void Should_Connect_Two_By_Two()
        {
            //given
            UnionFind<String> uf = new UnionFind<String>();
            String[] cc = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            //when
            uf.AddRange(cc);
            for(int i = 0; i < cc.Length; i += 2)
            {
                uf.Merge(i, i + 1);
            }

            //Then
            uf.AddRange(cc);
            for (int i = 0; i < cc.Length; i += 2)
            {
                bool connected = uf.IsConnected(i, i + 1);
                Assert.IsTrue(connected);
                if(i+2 < cc.Length)
                {
                    connected = uf.IsConnected(i + 1, i + 2);
                    Assert.IsFalse(connected);
                }
            }

        }
    }
}
