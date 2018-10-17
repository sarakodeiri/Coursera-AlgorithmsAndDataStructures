using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4
{
    public class Program
    {
        //First Question

        public static long ChangingMoney1(long money)
        {
            return 0;
        }

        public static string ProcessChangingMoney1(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long>) ChangingMoney1);
        
        //Second Question

        public static long MaximizingLoot2(long capacity, long[] weights, long[] values)
        {
            return 0;
        }

        public static string ProcessMaximizingLoot2(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);

        //Third Question

        public static long MaximizingOnlineRevenue3(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            return 0;
        }

        public static string ProcessMaximizingOnlineRevenue3(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingOnlineRevenue3);

        //Forth Question

        public static long CollectingSignatures4(long tenantCount, long[] startTimes, long[] endTimes)
        {
            return 0;
        }

        public static string ProcessCollectingSignatures4(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[], long[], long>)CollectingSignatures4);

        //Fifth Question

        public static long[] MaximizeNumberOfPrizePlaces5(long n)
        {
            return new long[] { 0 };
        }

        public static string ProcessMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[]>)MaximizeNumberOfPrizePlaces5);

        //Sixth Question

        public static string MaximizeSalary6(long n, long[] numbers)
        {
            return "0";
        }

        public static string ProcessMaximizeSalary6(string inStr) =>
            TestCommon.TestTools.Process(inStr, MaximizeSalary6);

        static void Main(string[] args)
        {
        }
    }
}
