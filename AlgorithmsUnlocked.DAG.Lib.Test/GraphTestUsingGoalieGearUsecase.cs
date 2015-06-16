using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnlocked.DAG.Lib.Test
{
    [TestClass]
    public class GraphTestUsingGoalieGearUsecase
    {

        private GraphUsingAdjacencyList<string> _gearGraph = new GraphUsingAdjacencyList<string>();

        [TestInitialize]
        public void Setup()
        {
            _gearGraph.AddNode("undershorts", "undershorts");
            _gearGraph.AddNode("compression shorts", "compression shorts");
            _gearGraph.AddNode("socks", "socks");
            _gearGraph.AddNode("hose", "hose");
            _gearGraph.AddNode("cup", "cup");
            _gearGraph.AddNode("pants", "pants");
            _gearGraph.AddNode("skates", "skates");
            _gearGraph.AddNode("leg pads", "leg pads");
            _gearGraph.AddNode("T-shirts", "T-shirts");
            _gearGraph.AddNode("chest pad", "chest pad");
            _gearGraph.AddNode("sweater", "sweater");
            _gearGraph.AddNode("mask", "mask");
            _gearGraph.AddNode("catch glove", "catch glove");
            _gearGraph.AddNode("blocker", "blocker");

            _gearGraph.AddDirectedEdge("undershorts", "compression shorts"); 
            _gearGraph.AddDirectedEdge("compression shorts", "hose");
            _gearGraph.AddDirectedEdge("compression shorts", "cup");
            _gearGraph.AddDirectedEdge("socks", "hose");
            _gearGraph.AddDirectedEdge("hose", "pants");
            _gearGraph.AddDirectedEdge("cup", "pants");
            _gearGraph.AddDirectedEdge("pants", "skates");
            _gearGraph.AddDirectedEdge("skates", "leg pads");
            _gearGraph.AddDirectedEdge("T-shirts", "chest pad");
            _gearGraph.AddDirectedEdge("chest pad", "sweater");
            _gearGraph.AddDirectedEdge("sweater", "mask");
            _gearGraph.AddDirectedEdge("mask", "catch glove");
            _gearGraph.AddDirectedEdge("catch glove", "blocker");
            _gearGraph.AddDirectedEdge("pants", "sweater");
            _gearGraph.AddDirectedEdge("leg pads", "catch glove");
        }

        [TestMethod]
        public void SortTest()
        {
            var actual = TopologicalSort<string>.Sort(_gearGraph);

            var expected = new List<string>
            {
                "T-shirts",
                "chest pad",
                "socks",
                "undershorts",
                "compression shorts",
                "cup",
                "hose",
                "pants",
                "sweater",
                "mask",
                "skates",
                "leg pads",
                "catch glove",
                "blocker",
            };

            Assert.IsTrue(expected.SequenceEqual(actual), "Returned list is not expected");
        }
    }
}
