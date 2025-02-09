using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph
    {
        private class Node
        {
            public string label;
            public Node(string label)
            {
                this.label = label;
            }
            public override string ToString()
            {
                return label;
            }
        }

        private Dictionary<string, Node> nodes = new();
        private Dictionary<Node, List<Node>> adjencyList = new();

        public void AddNode(string label)
        {
            var node = new Node(label);

            nodes.TryAdd(label, node);
            adjencyList.TryAdd(node, new List<Node>());

        }

        public void AddEdge(string from, string to)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];

            if (fromNode is null || toNode is null)
                throw new Exception();

            adjencyList[fromNode].Add(toNode);
        }

        public void Print()
        {
            foreach (var key in adjencyList.Keys)
            {
                var targets = adjencyList[key];

                if (!targets.Any())
                    Console.WriteLine(key + "is connected to " + targets);
            }
        }

        public void RemoveNode(string label)
        {
            var node = nodes[label];
            if (node is null)
                return;

            foreach (var key in adjencyList.Keys)
                adjencyList[key].Remove(node);

            adjencyList.Remove(node);
            nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];

            if (fromNode is null || toNode is null)
                return;

            adjencyList[fromNode].Remove(toNode);
        }

        public void TranverseDepthFirstRec(string root)
        {
            var node = nodes[root];
            if (root is null)
                return;
            TranverseDepthFirstRec(node, new HashSet<Node>());
        }

        private void TranverseDepthFirstRec(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root);
            visited.Add(root);

            foreach (var node in adjencyList[root])
                if (!visited.Contains(node))
                    TranverseDepthFirstRec(node, visited);
        }

        public void TranverseDepthFirst(string root)
        {
            var node = nodes[root];
            if (root is null) return;

            HashSet<Node> visited = new();
            Stack<Node> stack = new();

            stack.Push(node);

            while (!stack.Any())
            {
                var current = stack.Pop();

                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbor in adjencyList[current])
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }
        }
        public void TranverseBreadthFirst(string root)
        {
            var node = nodes[root];
            if (root is null) return;

            HashSet<Node> visited = new();

            Queue<Node> queue = new();

            queue.Enqueue(node);

            while (queue.Any())
            {
                var current = queue.Dequeue();

                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbor in adjencyList[current])
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
        }
    }
}