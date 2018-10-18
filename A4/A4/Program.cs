﻿using System;
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
            int tenCoins = 0;
            int fiveCoins = 0;
            //int oneCoins = 0;
            while(money - 10 >= 0)
            {
                tenCoins++;
                money -= 10;
            }
            while (money - 5 >= 0)
            {
                fiveCoins++;
                money -= 5;
            }
            return tenCoins+fiveCoins+money;
        }

        public static string ProcessChangingMoney1(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long>) ChangingMoney1);
        
        //Second Question

        public static long MaximizingLoot2(long capacity, long[] weights, long[] values)
        {
            List<Loot> allLoots = new List<Loot>();
            for (int i = 0; i < weights.Count(); i++)
                allLoots.Add(new Loot(weights[i], values[i]));

            List<Loot> sortedLoots = allLoots.OrderByDescending(l => l.UnitValue).ToList();

            double maximumValueFitted = 0;

            for (int i=0; capacity != 0; i++)
            {
                if (sortedLoots[i].Weight < capacity)
                {
                    maximumValueFitted += sortedLoots[i].Value;
                    capacity -= sortedLoots[i].Weight;
                }

                else
                {
                    maximumValueFitted += capacity*sortedLoots[i].UnitValue;
                    capacity = 0;
                }
            }

            return (long) maximumValueFitted;
        }

        public static string ProcessMaximizingLoot2(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);

        //Third Question

        public static long MaximizingOnlineRevenue3(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            long maxRevenue = 0;

            Array.Sort(adRevenue);
            Array.Sort(averageDailyClick);

            for (int i = 0; i < adRevenue.Count(); i++)
                maxRevenue += adRevenue[i] * averageDailyClick[i];

            return maxRevenue;
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
            List<long> numbers = new List<long>();

            for (int i=1; i <= n; i++)
            {

                if (n-i >= i+1)
                {
                    numbers.Add(i);
                    n -= i;
                }

                else
                {
                    numbers.Add(n);
                    break;
                }
            }

            return numbers.ToArray();
        }

        public static string ProcessMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[]>)MaximizeNumberOfPrizePlaces5);

        //Sixth Question

        public static string MaximizeSalary6(long n, long[] numbers)
        {
            string answer = string.Empty;
            List<long> allNumbers = new List<long>();
            allNumbers = numbers.ToList();

            return "0";
        }

        public static string ProcessMaximizeSalary6(string inStr) =>
            TestCommon.TestTools.Process(inStr, MaximizeSalary6);

        static void Main(string[] args)
        {
            MaximizeNumberOfPrizePlaces5(6);
        }
    }
}