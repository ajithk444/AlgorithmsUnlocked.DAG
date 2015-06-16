using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsUnlocked.DAG.Lib
{
    public class TopologicalSort<T>
    {
        /*
        Definitions:

        in-degree:  number of edges entering a vertex
        out-degree: number of edges exiting a vertex
        dag:        directed acyclic graph which has at least 1 node with in-degree = 0

        Algo: 

        Find vertices with in-degree = 0, add them to linearList and remove them from dag. 
        Repeat until dag is empty.

        Steps:

        Step 1: Create in-degree list with vertices as indexes, create an empty linearList
        Step 2: Set all values of in-degree to 0
        Step 3: For each vertex u in G:
                    A. For each vertex v adjacent to u:
                        i. Increment in-degree[v]
        Step 4: Make a list next consisting of all vertices u such that in-degree[u] = 0
        Step 5: while next is not empty:
                    A. Delete a vertex from next and call it u
                    B. Add u to the end of linearList
                        i. Decrement in-degree[v]
                        ii. If in-degree[v]=0, add it to next.
        */
        public static List<T> Sort(GraphUsingAdjacencyList<T> graph)
        {
            // step 1
            var linearList = new List<T>();
            var next = new Stack<GraphUsingAdjacencyList<T>.Node>();
            var inDegree = new Dictionary<string, int>();

            // step 2
            foreach (var node in graph.Nodes)
            {
                inDegree[node.Key] = 0;
            }

            // step 3
            foreach (var edgeToNeighbor in graph.Nodes.SelectMany(graphNode => graphNode.Value.Neighbors))
            {
                inDegree[edgeToNeighbor.Neighbor.Key]++;
            }

            // step 4
            foreach (var node in inDegree.Where(node => node.Value == 0))
            {
                next.Push(graph.Nodes[node.Key]);
            }

            // step 5
            while (next.Count > 0)
            {
                var nodeWithZeroInDegree = next.Pop();
                linearList.Add(nodeWithZeroInDegree.Data);

                foreach (var node in graph.Nodes)
                {
                    foreach (var edgeToNeighbor in node.Value.Neighbors)
                    {
                        if (!node.Key.Equals(nodeWithZeroInDegree.Key)) continue;

                        inDegree[edgeToNeighbor.Neighbor.Key]--;
                        if (inDegree[edgeToNeighbor.Neighbor.Key] == 0)
                        {
                            next.Push(edgeToNeighbor.Neighbor);
                        }
                    }
                }
            }

            return linearList;
        }
    }
}