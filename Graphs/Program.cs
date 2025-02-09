
using Graphs;

var graph = new Graph();
graph.AddNode(label: "A");
graph.AddNode(label: "B");
graph.AddNode(label: "C");
graph.AddEdge("A", "B");
graph.AddEdge("C", "B");
graph.AddEdge("A", "C");
graph.Print();

graph.RemoveEdge("A", "B");
graph.Print();

graph.RemoveEdge("C", "D");

graph.RemoveNode(label: "A");
graph.Print();

graph.TranverseDepthFirst(root: "A");
