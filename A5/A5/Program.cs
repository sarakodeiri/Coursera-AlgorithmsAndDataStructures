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
            long[] a = new long[] { 2, 3, 10, 20, 9, 1, 1, 4, 2};
            MergeSort(a);

            for (int i=0; i<a.Length; i++)
                Console.WriteLine(a[i]);
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



        //private static (List<long>, long) MergeSort(List<long> unsorted)
        //{
        //    if (unsorted.Count <= 1)
        //        return (unsorted, 0);

        //    List<long> left = new List<long>();
        //    List<long> right = new List<long>();

        //    long mid = unsorted.Count() / 2;

        //    for (long i = 0; i < mid; i++)  //Dividing the unsorted list
        //        left.Add(unsorted[(int)i]);

        //    for (long i = mid; i < unsorted.Count; i++)
        //        right.Add(unsorted[(int)i]);

        //    var leftMerge = MergeSort(left);
        //    var rightMerge = MergeSort(right);
        //    var finalResult = Merge(leftMerge.Item1, rightMerge.Item1);

        //    long allInvs = leftMerge.Item2 + rightMerge.Item2 + finalResult.Item2;

        //    return (finalResult.Item1, allInvs);
        //}

        //private static (List<long>, long) Merge(List<long> left, List<long> right)
        //{
        //    List<long> result = new List<long>();
        //    long invCount = 0;
        //    int l = 0, r = 0;

        //    while (l < left.Count() && r < right.Count())
        //    {
        //        if (right[r] < left[l])
        //        {
        //            result.Add(right[r]);
        //            invCount += left.Count() - 1;
        //            r++;
        //        }
        //        else
        //        {
        //            result.Add(left[l]);
        //            l++;
        //        }
        //    }

        //    if (l < left.Count())
        //        for (int i = l; l < left.Count(); l++)
        //            result.Add(left[i]);

        //    else if (r < right.Count())
        //        for (int i = r; r < left.Count(); r++)
        //            result.Add(right[i]);

        //    return (result, invCount);

        //}

        public static long MajorityElement2(long n, long[] a)
        {
            MergeSort(a);
            for (int i = 0; i < n / 2; i++)
                    if (a[i] == a[n / 2 + i])
                        return 1;
            return 0;
        }

        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)MajorityElement2);

        
        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            //write your code here 
            
            return a;
        }

        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);

        public static long NumberofInversions4(long n, long[] a)
        {
            //write your code here
            List<long> aToList = new List<long>();
            aToList = a.ToList();
           // return MergeSort(aToList).Item2;
            return 0;
        }

        public static string ProcessNumberofInversions4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofInversions4);

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

        public static void MergeSort(long[] initArray, long low, long high)
        {
            if (low < high)
            {
                long middle = (low / 2) + (high / 2);
                MergeSort(initArray, low, middle);
                MergeSort(initArray, middle + 1, high);
                Merge(initArray, low, middle, high);
            }
        }

        public static void MergeSort(long[] initArray)
        {
            MergeSort(initArray, 0, initArray.Length - 1);
        }

        private static void Merge(long[] initArray, long low, long middle, long high)
        {

            long left = low;
            long right = middle + 1;
            long[] copyArray = new long[(high - low) + 1];

            int index = 0;
            long invCount = 0;

            while ((left <= middle) && (right <= high)) // while none of the arrays are fully iterated
            {
                if (initArray[left] < initArray[right])
                {
                    copyArray[index] = initArray[left];
                    left++;
                }

                else
                {
                    copyArray[index] = initArray[right];
                    invCount += index - 1;    // ???????
                    right++;
                }
                index++;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    copyArray[index] = initArray[left];
                    left++;
                    index++;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    copyArray[index] = initArray[right];
                    right++;
                    index++;
                }
            }

            for (int i = 0; i < copyArray.Length; i++)

                initArray[low + i] = copyArray[i];
            

        }

    }
}
