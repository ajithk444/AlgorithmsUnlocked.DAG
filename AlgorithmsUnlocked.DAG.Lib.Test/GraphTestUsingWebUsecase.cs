using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnlocked.DAG.Lib.Test
{
    [TestClass]
    public class GraphTestUsingWebUsecase
    {
        private GraphUsingAdjacencyList<string> _webGraph = new GraphUsingAdjacencyList<string>();

        [TestInitialize]
        public void Setup()
        {
            _webGraph.AddNode("Start.htm", "start");
            _webGraph.AddNode("Privacy.htm", "privacy");
            _webGraph.AddNode("People.htm", "people");
            _webGraph.AddNode("About.htm", "about");
            _webGraph.AddNode("Index.htm", "index");
            _webGraph.AddNode("Products.htm", "products");
            _webGraph.AddNode("Contact.htm", "contact");
            _webGraph.AddNode("End.htm", "end");

            _webGraph.AddDirectedEdge("Start.htm", "Privacy.htm");  // Start -> Privacy

            _webGraph.AddDirectedEdge("Privacy.htm", "Index.htm");    // Privacy -> Index
            _webGraph.AddDirectedEdge("Privacy.htm", "About.htm");    // Privacy -> About

            //web.AddDirectedEdge("About.htm", "Privacy.htm");    // About -> Privacy
            _webGraph.AddDirectedEdge("About.htm", "People.htm");    // About -> People
            _webGraph.AddDirectedEdge("About.htm", "Contact.htm");   // About -> Contact

            _webGraph.AddDirectedEdge("Index.htm", "About.htm");      // Index -> About
            _webGraph.AddDirectedEdge("Index.htm", "Contact.htm");   // Index -> Contacts
            _webGraph.AddDirectedEdge("Index.htm", "Products.htm");  // Index -> Products

            _webGraph.AddDirectedEdge("Products.htm", "Index.htm");  // Products -> Index
            _webGraph.AddDirectedEdge("Products.htm", "End.htm");// Products -> End
        }

        [TestMethod]
        public void SortTest()
        {
            var list = TopologicalSort<string>.Sort(_webGraph);
            Assert.AreEqual(list.ElementAt(0), "start");
        }
    }
}
