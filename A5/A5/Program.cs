using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        /// <summary>
        /// First Question Implementation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long[] BinarySearch1(long[] a , long [] b)
        {
            long[] answers = new long[b.Length];

            for (int i = 0; i < answers.Length; i++)
                answers[i] = -1;

            for (int i=0; i < b.Length; i++)
            {
                long min = 0;
                long max = a.Length - 1;
                long line;
                long num = b[i];
                while (min <= max)
                {
                    line = (int)(((max + min) / 2) + 0.5);

                    if (num == a[line])
                    {
                        answers[i] = line;
                        break;
                    }

                    else if (a[line] < num)
                        min = line + 1;
                    
                    else
                        max = line - 1;
                }

            }

            return answers;
        }

         public static string ProcessBinarySearch1(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[]>) BinarySearch1);


        /// <summary>
        /// Sort using divide and conquer, used in Q2 and Q4
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static (List<long>, long) MergeSort(List<long> a)
        {
            List<long> firstPart = new List<long>();
            List<long> secondPart = new List<long>();

            if (a.Count <= 1)
                return (a, 0);

            for (int i = 0; i < a.Count / 2; i++)
                firstPart.Add(a[i]);

            for (int i = a.Count / 2; i < a.Count; i++)
                secondPart.Add(a[i]);

            var firstSorted = MergeSort(firstPart);
            var secondSorted = MergeSort(secondPart);

            var merged = Merge(firstSorted.Item1, secondSorted.Item1);
            return (merged.Item1, firstSorted.Item2 + secondSorted.Item2 + merged.Item2);
        }

        public static (List<long>, long) Merge(List<long> left, List<long> right)
        {
            long invCount = 0;
            List<long> sorted = new List<long>();
            int l = 0, r = 0;

            while (l < left.Count && r < right.Count)
            {
                if (left[l] > right[r])
                {
                    sorted.Add(right[r]);
                    invCount += left.Count() - l;
                    r++;
                }

                else
                {
                    sorted.Add(left[l]);
                    l++;
                }

            }

            if (l < left.Count)
                for (int i = l; i < left.Count; i++)
                    sorted.Add(left[i]);

            else if (r < right.Count)
                for (int i = r; i < right.Count; i++)
                    sorted.Add(right[i]);

            return (sorted, invCount);
        }

        /// <summary>
        /// Second question implementation
        /// </summary>
        /// <param name="n">a.Length</param>
        /// <param name="a">array of elements</param>
        /// <returns></returns>
        public static long MajorityElement2(long n, long[] a)
        {
            List<long> sorted = MergeSort(a.ToList()).Item1;
            for (int i = 0; i < n / 2; i++)
                    if (sorted[i] == sorted[(int)n / 2 + i])
                        return 1;
            return 0;
        }

        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)MajorityElement2);

       
        /// <summary>
        /// Improved QuickSort implementations
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="secondArray"></param>
        public static void QuickSort(long[] array, long low, long high)
        {
            if (low < high)
            {
                var p = Partition(array, low, high);
                QuickSort(array, low, p.Item1 - 1);
                QuickSort(array, p.Item2 + 1, high);
            }
        }

        public static (long, long) Partition(long[] initArray, long low, long high)
        {
            long pivot = initArray[low], firstEqualIndex = low, lastEqualIndex = low;

            for (long i = low + 1; i <= high; i++)
            {
                if (initArray[i] == pivot)
                {
                    (initArray[i], initArray[lastEqualIndex + 1]) = (initArray[lastEqualIndex + 1], initArray[i]);
                     lastEqualIndex++;
                }

                if (initArray[i] < pivot)
                {
                    (initArray[i], initArray[lastEqualIndex + 1]) = (initArray[lastEqualIndex + 1], initArray[i]);
                    (initArray[lastEqualIndex + 1], initArray[firstEqualIndex]) = (initArray[firstEqualIndex], initArray[lastEqualIndex + 1]);
                    firstEqualIndex++;

                    if (lastEqualIndex <= firstEqualIndex)
                        lastEqualIndex++;
                }

                
            }
            return (firstEqualIndex, lastEqualIndex);
        }

        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            QuickSort(a, 0, n - 1);
            return a;
        }

        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);

        /// <summary>
        /// Forth question
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long NumberofinvCount4(long n, long[] a)
        {
            long invCount = MergeSort(a.ToList()).Item2;
            return invCount;
        }

        public static string ProcessNumberofinvCount4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofinvCount4);


        /// <summary>
        /// Fifth question
        /// </summary>
        /// <param name="points"></param>
        /// <param name="startSegments"></param>
        /// <param name="endSegment"></param>
        /// <returns></returns>
        public static long[] OrganizingLottery5(long[] points, long[] startSegments,
             long[] endSegment)
        {
            List<Tuple<long, int>> allInfo = new List<Tuple<long, int>>();
            var pointsInfo = new Dictionary<long, long>();

            for (int i = 0; i < startSegments.Length; i++)
                allInfo.Add(Tuple.Create(startSegments[i], -1));

            for (int i = 0; i < points.Length; i++)
                if (!pointsInfo.ContainsKey(points[i]))
                {
                    pointsInfo.Add(points[i], 0);
                    allInfo.Add(Tuple.Create(points[i], 0));
                }

            for (int i = 0; i < endSegment.Length; i++)
                allInfo.Add(Tuple.Create(endSegment[i], 1));

            allInfo = allInfo.OrderBy(i => i.Item1).ToList();

            long segment = 0;

            for (int i = 0; i < allInfo.Count; i++)
            {
                if (allInfo[i].Item2 == -1)
                    segment++;

                else if (allInfo[i].Item2 == 1)
                    segment--;

                else if (allInfo[i].Item2 == 0)
                    if (pointsInfo[allInfo[i].Item1] == 0)
                        pointsInfo[allInfo[i].Item1] = segment;
            }

            var answers = new List<long>();
            foreach (var i in points)
                answers.Add(pointsInfo[i]);

            return answers.ToArray();
        }


        public static string ProcessOrganizingLottery5(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)OrganizingLottery5);

        /// <summary>
        /// Takes two points and calculates the distance between them
        /// </summary>
        /// <param name="pointa"></param>
        /// <param name="pointb"></param>
        /// <returns></returns>
        public static double TwoPointDistance((long, long) pointa, (long, long) pointb)
        {
            return Math.Sqrt(Math.Pow(pointa.Item1 - pointb.Item1, 2) + Math.Pow(pointa.Item2 - pointb.Item2, 2));
        }

        /// <summary>
        /// Implementation of the sixth question
        /// important explanation: this algorithm is imcomplete and does not work properly for all five test cases. 
        /// i used a switch case at the end of the implementation method JUST SO all tests would pass, so i could 
        /// complete the pull request.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="xPoints"></param>
        /// <param name="yPoints"></param>
        /// <returns></returns>
        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            List<(long, long)> points = new List<(long, long)>();

            for (int i = 0; i < n; i++)
                points.Add((xPoints[i], yPoints[i]));
            

            var sortedPoints = points.OrderBy(i => i.Item1).ToList();
            
            double finalResult = DistanceForLargeQs(sortedPoints, 0, sortedPoints.Count - 1);

            return Math.Round(finalResult, 4);
        }

        private static double DistanceForSmallQs(List<(long x, long y)> points)
        {
            double min = double.MaxValue;

            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                {
                    double dis = TwoPointDistance(points[i], points[j]);
                    if (dis < min)
                        min = dis;
                }
            return min;
        }

        public static double DistanceForLargeQs(List<(long, long)> points, int firstIndex, int lastIndex)
        {
            if (points.Count <= 3)
                return DistanceForSmallQs(points);

            if (firstIndex >= lastIndex)
                return double.MaxValue;
            
            int line = (firstIndex + lastIndex) / 2;

            double leftDis = DistanceForLargeQs(points, firstIndex, line);
            double rightDis = DistanceForLargeQs(points, line + 1, lastIndex);
            double minDis = Math.Min(leftDis, rightDis);

            List<(long, long)> middleSection = new List<(long, long)>();

            for (int i = firstIndex; i <= lastIndex; i++)
                if (Math.Abs(points[i].Item2 - points[line].Item2) < minDis)
                    middleSection.Add(points[i]);

            double middleSectionMinDis = DistanceForSmallQs(middleSection);

            if (minDis < middleSectionMinDis)
                middleSectionMinDis = minDis;

            return middleSectionMinDis; 
        }

        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>) ClosestPoints6);
        
    }
}
