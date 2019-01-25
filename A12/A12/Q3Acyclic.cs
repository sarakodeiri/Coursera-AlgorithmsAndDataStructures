using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        bool[] visited;
        bool[] keepTrack;

        public long Solve(long nodeCount, long[][] edges)
        {
            List<long>[] adjacencyList = new List<long>[nodeCount];
            for (int i = 0; i < adjacencyList.Length; i++)
                adjacencyList[i] = new List<long>();

            visited = new bool[nodeCount];
            keepTrack = new bool[nodeCount];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
                keepTrack[i] = false;
            }


            for (int i = 0; i < edges.Length; i++)
            {
                long first = edges[i][0] - 1;
                long second = edges[i][1] - 1;
                //Graph is directed:
                adjacencyList[first].Add(second);
            }

            for (int i = 0; i < adjacencyList.Length; i++)
                if (IsAcyclic(adjacencyList, i))
                    return 1;
            return 0;
        }
        
        private bool IsAcyclic(List<long>[] adj, long i)
        {
            if (!visited[i])
            {
                visited[i] = true;
                keepTrack[i] = true;

                for (int j = 0; j < adj[i].Count; j++)
                {
                    long current = adj[i][j];
                    if ((!visited[current] && IsAcyclic(adj, current)) || keepTrack[current])
                        return true;
                }
            }
            keepTrack[i] = false;
            return false;
        }
    }
}