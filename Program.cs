using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeDaily {
    internal class Program {
        static void Main(string[] args) {
            Graph graph = new(4, [[0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3]]);
            Console.WriteLine();
        }
        public class Graph {
            public int NodesCount { get; private set; }
            private Dictionary<int, IList<(int node, int weight)>> _adjacencyGraph;
            private PriorityQueue<int, int> _pq;

            public Graph(int n, int[][] edges) {
                NodesCount = n;
                _pq = new PriorityQueue<int, int>();
                _adjacencyGraph = [];
                for (int i = 0; i < n; i++) {
                    _adjacencyGraph.Add(i, []);
                }

                foreach (var edge in edges) {
                    AddEdge(edge);
                }
            }

            public void AddEdge(int[] edge) => _adjacencyGraph[edge[0]].Add((edge[1], edge[2]));


            public int ShortestPath(int node1, int node2) {
                HashSet<int> visited = [];
                int[] distances = Enumerable.Repeat(int.MaxValue, NodesCount).ToArray();
                distances[node1] = 0;
                _pq.Enqueue(node1, 0);

                while (_pq.Count > 0) {
                    var cur = _pq.Dequeue();
                    if (visited.Contains(cur)) continue;
                    visited.Add(cur);

                    foreach ((int neighbor, int weight) in _adjacencyGraph[cur]) {
                        int distance = distances[cur] + weight;
                        _pq.Enqueue(neighbor, distance);
                        distances[neighbor] = Math.Min(distances[neighbor], distance);
                    }
                }

                _pq.Clear();
                return distances[node2] == int.MaxValue ? -1 : distances[node2];
            }
        }
    }
}
