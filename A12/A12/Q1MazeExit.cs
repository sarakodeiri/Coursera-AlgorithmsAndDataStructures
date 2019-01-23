using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            // Your code here
            List<long>[] adjacencyList = new List<long>[nodeCount];
            for (int i = 0; i < adjacencyList.Length; i++)
                adjacencyList[i] = new List<long>();

            bool[] visited = new bool[nodeCount];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;


            for (int i=0; i<edges.Length; i++)
            {
                long first = edges[i][0] - 1;
                long second = edges[i][1] - 1;
                adjacencyList[first].Add(second);
                adjacencyList[second].Add(first);
            }

            Explore(adjacencyList, StartNode - 1, visited);

            if (visited[EndNode - 1])
                return 1;
            return 0;
        }
        
        private void Explore(List<long>[] adj, long Start, bool[] visited)
        {
            visited[Start] = true;
            foreach (var v in adj[Start])
                if (!visited[v])
                    Explore(adj, v, visited);
        }
     }
}
