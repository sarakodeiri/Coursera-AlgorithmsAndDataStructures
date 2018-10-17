using Microsoft.VisualStudio.TestTools.UnitTesting;
using A4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void ChangingMoney1Test()
        {
            TestCommon.TestTools.RunLocalTest("A4", Program.ProcessChangingMoney1, "TD1");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void MaximizingLoot2Test()
        {
            TestCommon.TestTools.RunLocalTest("A4", Program.ProcessMaximizingLoot2, "TD2");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void MaximizingOnlineRevenue3Test()
        {
            TestCommon.TestTools.RunLocalTest("A4", Program.ProcessMaximizingOnlineRevenue3, "TD3");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void CollectingSignatures4Test()
        {
            TestCommon.TestTools.RunLocalTest("A4", Program.ProcessCollectingSignatures4, "TD4");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void MaximizeNumberOfPrizePlaces5Test()
        {
            TestCommon.TestTools.RunLocalTest("A4", Program.ProcessMaximizeNumberOfPrizePlaces5, "TD5");
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void MaximizeSalary6Test()
        {
            TestCommon.TestTools.RunLocalTest("A4", Program.ProcessMaximizeSalary6, "TD6");
        }
    }
}