using Microsoft.VisualStudio.TestTools.UnitTesting;
using A11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11.Tests
{
    [TestClass()]
    public class BSTTests
    {
        [TestMethod()]
        public void ParseBSTTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                { 7, 4, 1, -1, -1, 6, -1, -1, 13, 10, -1, -1, 15, -1, -1 };

            var bst = BST.ParseBST(preOrderList);

            Assert.IsTrue(BST.EnsureBSTConsistency(bst.Root));

            Assert.AreEqual("7(4(1,6),13(10,15))", bst.ToString());
            var n = bst.Find(4);
            Assert.AreEqual(4, n.Key);

            n = bst.Find(5);
            Assert.AreEqual(6, n.Key);
            var nn = bst.Next(n);
            Assert.AreEqual(7, nn.Key);

            n = bst.Find(4);
            Assert.AreEqual(4, n.Key);
            nn = bst.Next(n);
            Assert.AreEqual(6, nn.Key);

            n = bst.Find(15);
            Assert.AreEqual(15, n.Key);
            nn = bst.Next(n);
            Assert.AreEqual(null, nn);

            var range = bst.RangeSearch(1, 6);
            Assert.AreEqual("1 4 6",
                string.Join(" ", range.Select(x => x.Key)));
        }

        [TestMethod]
        public void AddTest()
        {
            var bst = new BST();
            bst.Insert(5);
            Assert.AreEqual("5", bst.ToString());

            bst.Insert(4);
            Assert.AreEqual("5(4,-)", bst.ToString());

            bst.Insert(2);
            Assert.AreEqual("5(4(2,-),-)", bst.ToString());

            bst.Insert(3);
            Assert.AreEqual("5(4(2(-,3),-),-)", bst.ToString());

            bst.Insert(8);
            Assert.AreEqual("5(4(2(-,3),-),8)", bst.ToString());
        }

        [TestMethod]
        public void DeleteTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                { 7, 4, 1, -1, -1, 6, -1, -1, 13, 10, -1, -1, 15, -1, -1 };

            var bst = BST.ParseBST(preOrderList);

            var n = bst.Find(4);
            bst.Delete(n);
            Assert.IsTrue(BST.EnsureBSTConsistency(bst.Root));
            Assert.AreEqual("7(6(1,-),13(10,15))", bst.ToString());

            n = bst.Find(6);
            bst.Delete(n);
            Assert.IsTrue(BST.EnsureBSTConsistency(bst.Root));
            Assert.AreEqual("7(1,13(10,15))", bst.ToString());

            n = bst.Find(7);
            bst.Delete(n);
            Assert.IsTrue(BST.EnsureBSTConsistency(bst.Root));
            Assert.AreEqual("10(1,13(-,15))", bst.ToString());
        }
    }
}