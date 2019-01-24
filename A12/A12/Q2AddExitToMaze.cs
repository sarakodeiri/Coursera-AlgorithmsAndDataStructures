using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            List<long>[] adjacencyList = new List<long>[nodeCount];
            for (int i = 0; i < adjacencyList.Length; i++)
                adjacencyList[i] = new List<long>();

            bool[] visited = new bool[nodeCount];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            int[] CCNum = new int[nodeCount];

            for (int i = 0; i < edges.Length; i++)
            {
                long first = edges[i][0] - 1;
                long second = edges[i][1] - 1;
                //Graph is undirected
                adjacencyList[first].Add(second);
                adjacencyList[second].Add(first);
            }
            
            int f = DFS(adjacencyList, visited, CCNum) - 1;
            return f;
        }

        private int DFS(List<long>[] adj, bool[] visited, int[] CCNum)
        {
            int componentCount = 1;
            Stack<long> myStack = new Stack<long>();

            for (long i=0; i<adj.Length; i++)
            {
                if (!visited[i])
                {
                    componentCount++;
                    myStack.Push(i);
                    while (myStack.Count > 0)
                    {
                        long current = myStack.Pop();
                        CCNum[current] = componentCount;
                        visited[current] = true;

                        foreach (var v in adj[current])
                            if (!visited[v])
                                myStack.Push(v);
                    }
                }
            }

            return componentCount;
        }

        private void Explore(List<long>[] adj, long i, bool[] visited, int[] CCNum, int componentCount)
        {
            visited[i] = true;
            CCNum[i] = componentCount;
            foreach (var v in adj[i])
                if (!visited[v])
                    Explore(adj, v, visited, CCNum, componentCount);
        }
    }
}
