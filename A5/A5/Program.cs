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

        public static long[] BinarySearch1(long[] a , long [] b)
        {
            long[] answers = new long[b.Length];

            for (int i = 0; i < answers.Length; i++)
                answers[i] = -1;

            for (int i=0; i < b.Length; i++)
            {
                long min = 0;
                long max = a.Length - 1;
                long mid;
                long num = b[i];
                while (min <= max)
                {
                    mid = (int)(((max + min) / 2) + 0.5);

                    if (num == a[mid])
                    {
                        answers[i] = mid;
                        break;
                    }

                    else if (a[mid] < num)
                        min = mid + 1;
                    
                    else
                        max = mid - 1;
                }

            }

            return answers;
        }

         public static string ProcessBinarySearch1(string inStr) =>
            TestTools.Process(inStr, BinarySearch1);


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

       

        public static void QuickSort(long[] array, long low, long high, long[] secondArray = null)
        {
            if (low < high)
            {
                var p = Partition(array, low, high, secondArray);
                QuickSort(array, low, p.Item1 - 1, secondArray);
                QuickSort(array, p.Item2 + 1, high, secondArray);
            }
        }

        public static (long, long) Partition(long[] initArray, long low, long high, long[] equalToPivot = null)
        {
            long pivot = initArray[low], firstEqualIndex = low, lastEqualIndex = low;

            for (long i = low + 1; i <= high; i++)
            {
                if (initArray[i] == pivot)
                {
                    (initArray[i], initArray[lastEqualIndex + 1]) = (initArray[lastEqualIndex + 1], initArray[i]);
                    if (equalToPivot != null)
                        (equalToPivot[i], equalToPivot[lastEqualIndex + 1]) = (equalToPivot[lastEqualIndex + 1], equalToPivot[i]);
                    lastEqualIndex++;
                }

                if (initArray[i] < pivot)
                {
                    (initArray[i], initArray[lastEqualIndex + 1]) = (initArray[lastEqualIndex + 1], initArray[i]);
                    (initArray[lastEqualIndex + 1], initArray[firstEqualIndex]) = (initArray[firstEqualIndex], initArray[lastEqualIndex + 1]);

                    if (equalToPivot != null)
                    {
                        (equalToPivot[i], equalToPivot[lastEqualIndex + 1]) = (equalToPivot[lastEqualIndex + 1], equalToPivot[i]);
                        (equalToPivot[lastEqualIndex + 1], equalToPivot[firstEqualIndex]) = (equalToPivot[firstEqualIndex], equalToPivot[lastEqualIndex + 1]);
                    }
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

        public static long NumberofinvCount4(long n, long[] a)
        {
            long invCount = MergeSort(a.ToList()).Item2;
            return invCount;
        }

        public static string ProcessNumberofinvCount4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofinvCount4);

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
            TestTools.Process(inStr,OrganizingLottery5);

        public static double TwoPointDistance( (long, long) pointa, (long, long)pointb)
        {
            return Math.Sqrt(Math.Pow(pointa.Item1 - pointb.Item1, 2) + Math.Pow(pointa.Item2 - pointb.Item2, 2));
        }

        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            double Dis = double.MaxValue;

            List<(long, long)> points = new List<(long, long)>();
            for (int i = 0; i < n; i++)
            {
                var temp = (xPoints[i], yPoints[i]);
                points.Add(temp);
            }

            points.OrderBy(i => i.Item1);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n && points[j].Item1 - points[i].Item1 < Dis; j++)
                {
                    double temp = TwoPointDistance(points[i], points[j]);
                    if (temp < Dis)
                        Dis = temp;
                }
            }
            
            return Math.Round(Dis, 4);
        }

        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);
    }
}
