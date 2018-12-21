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
    public class SplayTreeTests
    {
        [TestMethod()]
        public void InsertDuplicateTest()
        {
            var st = new SplayTree();
            for (int i = 1; i < 100; i++)
                st.Insert(1);

            Assert.AreEqual("1", st.ToString());
        }

        [TestMethod()]
        public void InsertDeepTest()
        {
            BST.DebugMode = false;

            var st = new SplayTree();
            for (int i = 1; i < 100000; i++)
                st.Insert(i);

            for (int i = 100001; i < 200000; i++)
            {
                st.Insert(i);
                st.Find(0);
            }
        }

        [TestMethod()]
        public void InsertTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                { 30, 20, 10, -1, -1, -1, -1 };

            var root = BST.ParseBST(ref preOrderList);
            var st = new SplayTree(root);
            Assert.AreEqual("30(20(10,-),-)", st.ToString());

            st.Insert(15);
            Assert.AreEqual("15(10,30(20,-))", st.ToString());

            st.Insert(25);
            Assert.AreEqual("25(15(10,20),30)", st.ToString());

            st.Insert(23);
            Assert.AreEqual("23(20(15(10,-),-),25(-,30))", st.ToString());

            st.Insert(17);
            Assert.AreEqual("17(15(10,-),23(20,25(-,30)))", st.ToString());

            st.Insert(21);
            Assert.AreEqual("21(17(15(10,-),20),23(-,25(-,30)))", st.ToString());

            st.Insert(35);
            Assert.AreEqual("35(23(21(17(15(10,-),20),-),30(25,-)),-)", st.ToString());

            st.Insert(5);
            Assert.AreEqual("5(-,23(17(10(-,15),21(20,-)),35(30(25,-),-)))", st.ToString());

        }

        [TestMethod]
        public void DeleteTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                {5, -1, 23, 17, 10, -1, 15, -1, -1, 21, 20,
                 -1, -1, -1, 35, 30, 25, -1, -1, -1, -1 };

            var root = BST.ParseBST(ref preOrderList);
            var st = new SplayTree(root);
            Assert.AreEqual("5(-,23(17(10(-,15),21(20,-)),35(30(25,-),-)))", st.ToString());

            st.Delete(25);
            Assert.AreEqual("30(23(5(-,17(10(-,15),21(20,-))),-),35)", st.ToString());

            st.Delete(15);
            Assert.AreEqual("17(10(5,-),30(23(21(20,-),-),35))", st.ToString());

            st.Delete(12);
            Assert.AreEqual("17(10(5,-),30(23(21(20,-),-),35))", st.ToString());

        }

        [TestMethod()]
        public void ThreeNodeSplayTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                { 3, 2, 1, -1, -1, -1, -1 };

            var root = BST.ParseBST(ref preOrderList);
            var st = new SplayTree(root);
            Assert.AreEqual("3(2(1,-),-)", st.ToString());

            st.Splay(1);
            Assert.AreEqual("1(-,2(-,3))", st.ToString());

            st.Splay(3);
            Assert.AreEqual("3(2(1,-),-)", st.ToString());

            st.Splay(2);
            Assert.AreEqual("2(1,3)", st.ToString());

            st.Splay(3);
            Assert.AreEqual("3(2(1,-),-)", st.ToString());

            st.Splay(3);
            Assert.AreEqual("3(2(1,-),-)", st.ToString());

        }

        [TestMethod()]
        public void FiveNodeSplayTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                { 5, 4, 3, 2, 1, -1, -1, -1, -1, -1, -1 };

            var root = BST.ParseBST(ref preOrderList);
            var st = new SplayTree(root);
            Assert.AreEqual("5(4(3(2(1,-),-),-),-)", st.ToString());

            st.Splay(1);
            Assert.AreEqual("1(-,4(2(-,3),5))", st.ToString());

            st.Splay(3);
            Assert.AreEqual("3(1(-,2),4(-,5))", st.ToString());

            st.Splay(2);
            Assert.AreEqual("2(1,3(-,4(-,5)))", st.ToString());

            st.Splay(4);
            Assert.AreEqual("4(3(2(1,-),-),5)", st.ToString());

            st.Splay(4);
            Assert.AreEqual("4(3(2(1,-),-),5)", st.ToString());

            st.Splay(2);
            st.Splay(4);
            Assert.AreEqual("4(3(2(1,-),-),5)", st.ToString());

        }

        [TestMethod()]
        public void EightNodeSplayTest()
        {
            IEnumerable<long> preOrderList = new List<long>()
                { 8, 7, 6, 1, -1, 4, -1, -1, -1, -1, 13, 10, -1, -1, 15, -1, -1 };

            var root = BST.ParseBST(ref preOrderList);
            var st = new SplayTree(root);
            Assert.AreEqual("8(7(6(1(-,4),-),-),13(10,15))", st.ToString());

            st.Splay(4);
            Assert.AreEqual("4(1,7(6,8(-,13(10,15))))", st.ToString());

            st.Splay(6);
            st.Splay(13);
            Assert.AreEqual("13(6(4(1,-),8(7,10)),15)", st.ToString());

        }
    }
}