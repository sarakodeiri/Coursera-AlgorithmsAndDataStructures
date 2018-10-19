using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4
{
    public class Program
    {
        /// <summary>
        /// This method tells us how many 1, 2, 5 coins we need to change our money.
        /// </summary>
        /// <param name="money">The money we want to turn to change</param>
        /// <returns>Total amount of coins required</returns>

        public static long ChangingMoney1(long money)
        {
            long coins = 0;

            while (money - 10 >= 0)
            {
                coins++;
                money -= 10;
            }
            while (money - 5 >= 0)
            {
                coins++;
                money -= 5;
            }

            coins += money;

            return coins;
        }

        public static string ProcessChangingMoney1(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long>) ChangingMoney1);
        
        /// <summary>
        /// Maximum value a thief can steal using a bag that has a specific capacity.
        /// </summary>
        /// <param name="capacity">Const capacity of the bag</param>
        /// <param name="weights">The weight of each item ai</param>
        /// <param name="values">The value of each item ai</param>
        /// <returns>Most value the thief can steal with that bag</returns>

        public static long MaximizingLoot2(long capacity, long[] weights, long[] values)
        {
            List<Loot> allLoots = new List<Loot>();
            for (int i = 0; i < weights.Count(); i++)
                allLoots.Add(new Loot(weights[i], values[i]));

            List<Loot> sortedLoots = allLoots.OrderByDescending(u => u.UnitValue).ToList();

            double maximumValueFitted = 0;

            for (int i=0; capacity != 0; i++)
            {
                if (sortedLoots[i].Weight >= capacity)
                {
                    maximumValueFitted += capacity * sortedLoots[i].UnitValue;
                    capacity = 0;
                    
                }

                else
                {
                    maximumValueFitted += sortedLoots[i].Value;
                    capacity -= sortedLoots[i].Weight;
                }
            }

            return (long) maximumValueFitted;
        }

        public static string ProcessMaximizingLoot2(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);

        /// <summary>
        /// Making the most out of click-on ads
        /// </summary>
        /// <param name="slotCount">number of empty slots available</param>
        /// <param name="adRevenue">revenue of each ad ai</param>
        /// <param name="averageDailyClick">average clicks on each revenue bi</param>
        /// <returns>most money we can make out of putting the ads in the right places</returns>

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

        /// <summary>
        /// minimum amount of visits to appartments who are home at different times
        /// </summary>
        /// <param name="tenantCount">number of people we have to meet</param>
        /// <param name="startTimes">tenant i is home from starttimes[i]</param>
        /// <param name="endTimes">tenant i is home till endtimes[i]</param>
        /// <returns></returns>

        public static long CollectingSignatures4(long tenantCount, long[] startTimes, long[] endTimes)
        {
            var timePeriods = new List<(long startTime, long endTime)>();

            for (int i = 0; i < tenantCount; i++)
                timePeriods.Add((startTimes[i], endTimes[i]));

            var sortedTime = timePeriods.OrderBy(e => e.endTime).ToList();

            List<long> jointPoints = new List<long>();
            long jointPoint = sortedTime[0].endTime;
            jointPoints.Add(jointPoint);

            for (int i = 1; i < sortedTime.Count(); i++)
            {
                if (!(jointPoint <= sortedTime[i].endTime && jointPoint >= sortedTime[i].startTime))
                {
                    jointPoint = sortedTime[i].endTime; // update the point to the end point of the current segment
                    jointPoints.Add(jointPoint);
                }
                
            }

            return jointPoints.Count();
        }

        public static string ProcessCollectingSignatures4(string inStr) =>
            TestCommon.TestTools.Process(inStr, (Func<long, long[], long[], long>)CollectingSignatures4);

        /// <summary>
        /// Giving children different prizes. Maximising the number of children we can give prizes to.
        /// </summary>
        /// <param name="n">number of prizes we have</param>
        /// <returns>maximum number of childrem we can give different prizes to</returns>

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

        /// <summary>
        /// Making the biggest number possible using separate cards with numbers of different digits on them.
        /// </summary>
        /// <param name="n">number of cards we have</param>
        /// <param name="numbers">cards we have</param>
        /// <returns>highest number possible to make with these cads</returns>

        public static string MaximizeSalary6(long n, long[] numbers)
        {
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (sortedByMSD(numbers[i], numbers[j]))
                        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            
            return string.Join("", numbers);
        }

        //Using a comment in the forum linked in the assignment doc, saying the following:
        //In this problem 2 >= 21 because the statement (221 >= 212) is true but (212>=221) is false.

        public static bool sortedByMSD(long a, long b)
        {
            long digitsA = a.ToString().Length;
            long digitsB = b.ToString().Length;

            long ab = a * (long)Math.Pow(10, digitsB) + b;
            long ba = b * (long)Math.Pow(10, digitsA) + a;

            if (ab <= ba)
                return true;
            
            else
                return false;
        }

        public static string ProcessMaximizeSalary6(string inStr) =>
            TestCommon.TestTools.Process(inStr, MaximizeSalary6);

        static void Main(string[] args)
        {

        }
    }
}
