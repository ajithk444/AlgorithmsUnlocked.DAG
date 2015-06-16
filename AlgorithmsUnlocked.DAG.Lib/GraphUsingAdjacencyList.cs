using System;
using System.Collections.Generic;

namespace AlgorithmsUnlocked.DAG.Lib
{
    public class GraphUsingAdjacencyList<T>
    {
        public Dictionary<string, Node> Nodes { get; private set; }

        public GraphUsingAdjacencyList()
        {
            Nodes = new Dictionary<string, Node>();
        }

        public virtual void AddNode(string key, T data)
        {
            Nodes.Add(key, new Node(key, data));
        }

        public virtual void AddDirectedEdge(string uKey, string vKey)
        {
            AddDirectedEdge(uKey, vKey, 0);
        }

        public virtual void AddDirectedEdge(string uKey, string vKey, int cost)
        {
            // get references to uKey and vKey
            if (Nodes.ContainsKey(uKey) && Nodes.ContainsKey(vKey))
                AddDirectedEdge(Nodes[uKey], Nodes[vKey], cost);
            else
                throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
        }

        void AddDirectedEdge(Node u, Node v, int cost = 0)
        {
            // Make sure u and v are Nodes in this graph
            if (Nodes.ContainsKey(u.Key) && Nodes.ContainsKey(v.Key))
                // add an edge from u -> v
                u.AddDirected(v, cost);
            else
                // one or both of the nodes were not found in the graph
                throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
        }

        /// <summary>
        /// The Node class represents a single node in the graph. When working with graphs, 
        /// the nodes typically represent some entity. Therefore, our Node class contains a Data property 
        /// of type object that can be used to store any sort of data associated with the node. 
        /// Furthermore, we'll need some way to easily identify nodes, so let's add a string Key property, 
        /// which serves as a unique identifier for each Node
        /// </summary>
        public class Node
        {
            public T Data { get; private set; }
            public string Key { get; private set; }
            public List<EdgeToNeighbor> Neighbors { get; private set; }

            public Node(string key, T data)
            {
                Key = key;
                Data = data;
                Neighbors = new List<EdgeToNeighbor>();
            }

            protected internal void AddDirected(Node n)
            {
                AddDirected(new EdgeToNeighbor(n));
            }

            protected internal void AddDirected(Node n, int cost)
            {
                AddDirected(new EdgeToNeighbor(n, cost));
            }

            private void AddDirected(EdgeToNeighbor e)
            {
                Neighbors.Add(e);
            }

            public override string ToString()
            {
                return ($"{Key} -> {string.Join(", ", Neighbors)}");
            }
        }

        public class EdgeToNeighbor
        {
            public int Cost { get; private set; }
            public Node Neighbor { get; private set; }

            public EdgeToNeighbor(Node neighbor) : this(neighbor, 0) { }
            public EdgeToNeighbor(Node neighbor, int c) { Neighbor = neighbor; Cost = c; }

            public override string ToString()
            {
                return Neighbor.Key;
            }
        }

    }
}
