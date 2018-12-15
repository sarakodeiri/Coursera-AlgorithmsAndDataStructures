using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A10.Tests
{
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()/*, Timeout(5000)*/]
        [DeploymentItem("TestData", "A10_TestData")]
        public void SolveTest()
        {
            Processor[] problems = new Processor[] {
              new PhoneBook("TD1"),
                new HashingWithChain("TD2"),
                 new RabinKarp("TD3")
            };

            foreach (var p in problems)
            {
                TestTools.RunLocalTest("A10", p.Process, p.TestDataName);
            }
        }


        [TestMethod()]
        public void PolyHashTest()
        {
            long result1 = HashingWithChain.PolyHash("world", 5);
            long result2 = HashingWithChain.PolyHash("HellO", 5);
            long result3 = HashingWithChain.PolyHash("GooD", 5);

           Assert.AreEqual(4, result1);
           Assert.AreEqual(4, result2);
           Assert.AreEqual(2, result3);

        }


        /// <summary>
        /// This test is just to help you test your
        /// PreComputeHashes function. It is not graded
        /// </summary>
        [TestMethod()]
        public void PreComputeHashesTest()
        {
            string testStr = "aaaa";
            int patternLen = 2;
            long[] H = RabinKarp.PreComputeHashes(
                testStr, patternLen, 101, 3);

            for (int i = 0; i < testStr.Length - patternLen + 1; i++)
            {
                long expectedHash = RabinKarp.PolyHash(testStr, i, patternLen, 101, 3);
                Assert.AreEqual(expectedHash, H[i]);
            }
        }
    }
}