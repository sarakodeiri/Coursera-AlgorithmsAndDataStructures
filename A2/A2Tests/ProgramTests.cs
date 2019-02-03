using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Correctness() //Grade:A2:100
        {
            TestCommon.TestTools.RunLocalTest("A2", Program.Process);
        }

        [TestMethod(), Timeout(500)]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Performance()
        {
            TestCommon.TestTools.RunLocalTest("A2", Program.Process);
        }

        [TestMethod]
        public void GradedTest_Stress()
        {
            var now = DateTime.Now;
            while (DateTime.Now.Subtract(now).Seconds < 5)
            {
                Random rnd = new Random();
                int n = rnd.Next(2, 100);
                List<int> A = new List<int>();
                for (int i = 0; i < n; i++)
                    A.Add(rnd.Next(0, 1000));
                int result1 = Program.NaiveMaxPairwiseProduct(A);
                int result2 = Program.FastMaxPairwiseProduct(A);
                Assert.IsTrue(result1 == result2);
            }       

        }
        
    }
}
 