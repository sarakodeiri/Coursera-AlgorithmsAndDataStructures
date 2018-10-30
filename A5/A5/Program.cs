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

        public static void QuickSort(long[] input, int lowIndex, int highIndex)
        {

            if (highIndex <= lowIndex)
                return;

            int low = lowIndex;
            int high = highIndex;
            int i = lowIndex + 1;
            int pivotIndex = lowIndex;
            long pivotValue = input[pivotIndex];
            
            while (i <= high)
            {
                if (input[i] < pivotValue)
                    (input[i++], input[low++]) = (input[low++], input[i++]);
                
                else if (pivotValue < input[i])
                    (input[i], input[high--]) = (input[high--], input[i]);
      
                else
                    i++;
            }
            
            QuickSort(input, lowIndex, low - 1);
            QuickSort(input, high + 1, highIndex);
        }



        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            QuickSort(a, 0, a.Length - 1);
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
            //write your code here
            return new long[] { 0 };
        }

        public static string ProcessOrganizingLottery5(string inStr) =>
            TestTools.Process(inStr,OrganizingLottery5);

        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            //write your code here
            return 0;
        }

        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);

        


       

    }
}
