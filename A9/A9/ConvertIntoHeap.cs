using TestCommon;
using System;
using System.Collections.Generic;

namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(
            long[] array)
        {
            List<Tuple<long, long>> swapsList = new List<Tuple<long, long>>();
            int n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int index;
                if (i % 2 == 0)
                    if (i - 1 < 0)
                        index = i;
                    else
                        index = array[i] > array[i - 1] ? i - 1 : i;

                else if (i + 1 <= n - 1)
                    index = array[i] > array[i + 1] ? i + 1 : i;

                else
                    index = i;

                int parentIndex = (i + 1) / 2 - 1;

                while (parentIndex < n && index < n)
                {
                    if (array[index] < array[parentIndex])
                    {
                        swapsList.Add(new Tuple<long, long>(parentIndex, index));
                        (array[index], array[parentIndex]) = (array[parentIndex], array[index]);
                        parentIndex = index;

                        
                        if (index * 2 + 2 < n  && array[index * 2 + 2] < array[index * 2 + 1])
                            index = index * 2 + 2;
                        else
                            index = index * 2 + 1;
                    }

                    else
                        break;
                }
            }

            return swapsList.ToArray();
        }

    }
}