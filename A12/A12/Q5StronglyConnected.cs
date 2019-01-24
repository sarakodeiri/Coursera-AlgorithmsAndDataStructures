using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q5StronglyConnected: Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        bool[] visited;
        List<long> order;


        public long Solve(long nodeCount, long[][] edges)
        {
            List<long>[] adjacencyList = new List<long>[nodeCount];
            List<long>[] reverseAdjacencyList = new List<long>[nodeCount];

            for (int i = 0; i < adjacencyList.Length; i++)
            {
                adjacencyList[i] = new List<long>();
                reverseAdjacencyList[i] = new List<long>();
            }


            visited = new bool[nodeCount];
            order = new List<long>();

            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            for (int i = 0; i < edges.Length; i++)
            {
                long first = edges[i][0] - 1;
                long second = edges[i][1] - 1;
                adjacencyList[first].Add(second);
                reverseAdjacencyList[second].Add(first);
            }

            return SCCCount(adjacencyList, reverseAdjacencyList);
        }

        private long SCCCount(List<long>[] adjacencyList, List<long>[] reverseAdjacencyList)
        {
            long finalResult = 0;
            for (int i = 0; i < reverseAdjacencyList.Length; i++)
                if (!visited[i])
                    DFS(i, reverseAdjacencyList);
            order.Reverse();
            //fill(visited.begin(), visited.end(), 0);
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            for (int i=0; i<order.Count; i++)
                if (!visited[order[i]])
                {
                    Explore(order[i], adjacencyList);
                    finalResult++;
                }
            return finalResult;
        }

        private void DFS(long start, List<long>[] reverseAdjacencyList)
        {
            visited[start] = true;
            for (int i = 0; i < reverseAdjacencyList.Length; i++)
                if (!visited[reverseAdjacencyList[start][i]])
                    DFS(reverseAdjacencyList[start][i], reverseAdjacencyList);
            order.Add(start);
        }

        private void Explore(long start, List<long>[] adjacencyList)
        {
            visited[start] = true;
            for (int i = 0; i < adjacencyList[start].Count; i++)
                if (!visited[adjacencyList[start][i]])
                    Explore(adjacencyList[start][i], adjacencyList);
        }
    }
}
