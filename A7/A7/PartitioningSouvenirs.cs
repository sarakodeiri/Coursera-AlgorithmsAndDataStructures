using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum = souvenirs.Sum();
            int n = souvenirs.Length;

            if (sum%3 != 0 || n < 3 || sum / 3 < souvenirs.Max())
                return 0;

            long partialSum = sum / 3; //g is short for goal, meaning the sum we want each of our partitions to have.

            bool[,,] allData = new bool[(int)partialSum + 1, (int)partialSum + 1, n];

            //initializing our 3d array of data
            for (int i = 0; i < partialSum + 1; i++)
                for (int j = 0; j < partialSum + 1; j++)
                    for (int k = 0; k < n; k++)
                    {
                        allData[i, 0, k] = ((i == 0) || (souvenirs[k] == i));
                        allData[0, j, k] = ((j == 0) || (souvenirs[k] == j));
                    }
            

            for (int i = 1; i < partialSum + 1; i++)
                for (int j = 1; j < partialSum + 1; j++)
                    for (int k = 0; k < n; k++)
                    {
                        int currentSouvenir = (int)souvenirs[k];

                        bool canBeFilled = false;

                        //get new value based on the previous one.
                        if (k > 0)
                        {
                            canBeFilled = allData[i, j, k - 1];

                            if ((currentSouvenir <= i && allData[i - currentSouvenir, j, k - 1])
                                || (currentSouvenir <= j && allData[i, j - currentSouvenir, k - 1]))

                                canBeFilled = true;
                        }
                        
                        allData[i, j, k] = canBeFilled;
                    }

            if (allData[partialSum, partialSum, n - 1])
                return 1;

            return 0;
        }
    }
}
