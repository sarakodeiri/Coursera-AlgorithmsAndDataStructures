using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class ParallelProcessing : Processor
    {
        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        private class Thread
        {
            public int Index;
            public long StartTime;

            public Thread(int index, long startTime)
            {
                Index = index;
                StartTime = startTime;
            }
        }

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            var threadList = new List<Thread>((int)threadCount);
            var result = new List<Tuple<long, long>>();

            for (int i = 0; i < threadCount; i++)
                threadList.Add(new Thread(i, 0));

            for (int i = 0; i < jobDuration.Length; i++)
            {
                var optimalThread = threadList.First();
                result.Add(new Tuple<long, long>(optimalThread.Index, optimalThread.StartTime));
                threadList.RemoveAt(0);
                optimalThread.StartTime += jobDuration[i];
                threadList.Add(optimalThread);
                threadList = threadList.OrderBy(x => x.StartTime).ThenBy(x => x.Index).ToList();
            }


            return result.ToArray();
        }
    }
}
