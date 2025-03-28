namespace Routers;

/// <summary>
/// This network.
/// </summary>
public class Network
{
      /// <summary>
      /// Initializes a new instance of the <see cref="Network"/> class.
      /// </summary>
      public Network()
      {
            this.Vertexes = new List<Edge>();
            this.RouterNumber = 0;
      }

      /// <summary>
      /// Gets or sets the number of routers.
      /// </summary>
      public int RouterNumber { get; set; }

      /// <summary>
      /// Gets or sets list of edges.
      /// </summary>
      public List<Edge> Vertexes { get; set; }

      /// <summary>
      /// Get list of edges.
      /// </summary>
      /// <returns>list of edges.</returns>
      public List<Edge> GetVertexes()
      {
            return new List<Edge>(this.Vertexes);
      }

      /// <summary>
      /// Add edge between two vertexes.
      /// </summary>
      /// <param name="fv">First vertex.</param>
      /// <param name="sv">Second vertex.</param>
      /// <param name="bandwidth">The bandwidth of channel.</param>
      public void AddEdge(int fv, int sv, int bandwidth)
      {
            this.Vertexes.Add(new Edge(fv, sv, bandwidth));
            this.RouterNumber = Math.Max(this.RouterNumber, Math.Max(fv, sv) + 1);
      }

      /// <summary>
      /// Get bandwidth of edge.
      /// </summary>
      /// <param name="fv">first vertex.</param>
      /// <param name="sv">second vertex.</param>
      /// <returns>bandwidth.</returns>
      public int GetBandwidth(int fv, int sv)
      {
            var edge = this.Vertexes.FirstOrDefault(e => (e.FirstVertex == fv && e.SecondVertex == sv) ||
            (e.FirstVertex == sv && e.SecondVertex == fv));
            if (edge == null)
            {
                  return 0;
            }

            return edge.Bandwidth;
      }

      /// <summary>
      /// Checking the graph for connectivity.
      /// </summary>
      /// <returns>True or false.</returns>
      public bool IsNetworkConnected()
      {
            if (this.RouterNumber == 0 || this.Vertexes.Count == 0)
            {
                  return false;
            }

            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            int startVertex = this.Vertexes[0].FirstVertex;
            visited.Add(startVertex);
            queue.Enqueue(startVertex);
            var adjacencyList = new Dictionary<int, List<int>>();
            foreach (var el in this.Vertexes)
            {
                  if (!adjacencyList.ContainsKey(el.FirstVertex))
                  {
                        adjacencyList[el.FirstVertex] = new List<int>();
                  }

                  if (!adjacencyList.ContainsKey(el.SecondVertex))
                  {
                        adjacencyList[el.SecondVertex] = new List<int>();
                  }

                  adjacencyList[el.FirstVertex].Add(el.FirstVertex);
                  adjacencyList[el.SecondVertex].Add(el.SecondVertex);
            }

            while (queue.Count > 0)
            {
                  var current = queue.Dequeue();
                  if (adjacencyList.ContainsKey(current))
                  {
                        foreach (var neighbor in adjacencyList[current])
                        {
                              if (!visited.Contains(neighbor))
                              {
                                    visited.Add(neighbor);
                                    queue.Enqueue(neighbor);
                              }
                        }
                  }
            }

            for (int i = 0; i < this.RouterNumber; ++i)
            {
                  if (!visited.Contains(i))
                  {
                        return false;
                  }
            }

            return true;
      }

      /// <summary>
      /// An algorithm for finding a minimum spanning tree.
      /// </summary>
      /// <returns>A minimal list with maximum bandwidth.</returns>
      public List<Edge> PrimAlgorithm()
      {
            if (this.RouterNumber == 0 || this.Vertexes.Count == 0)
            {
                  return new List<Edge>();
            }

            var newNet = new List<Edge>();
            var visited = new HashSet<int>();
            var priorityQueue = new PriorityQueue<Edge, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            var adjacencyList = new Dictionary<int, List<Edge>>();
            foreach (var el in this.Vertexes)
            {
                  if (!adjacencyList.ContainsKey(el.FirstVertex))
                  {
                        adjacencyList[el.FirstVertex] = new List<Edge>();
                  }

                  if (!adjacencyList.ContainsKey(el.SecondVertex))
                  {
                        adjacencyList[el.SecondVertex] = new List<Edge>();
                  }

                  adjacencyList[el.FirstVertex].Add(el);
                  adjacencyList[el.SecondVertex].Add(new Edge(el.SecondVertex, el.FirstVertex, el.Bandwidth));
            }

            int startVertex = this.Vertexes[0].FirstVertex;
            visited.Add(startVertex);
            foreach (var el in adjacencyList[startVertex])
            {
                  priorityQueue.Enqueue(el, el.Bandwidth);
            }

            while (priorityQueue.Count > 0 && visited.Count < this.RouterNumber)
            {
                  var currentEdge = priorityQueue.Dequeue();
                  if (visited.Contains(currentEdge.SecondVertex))
                  {
                        continue;
                  }

                  newNet.Add(currentEdge);
                  visited.Add(currentEdge.SecondVertex);

                  foreach (var el in adjacencyList[currentEdge.SecondVertex])
                  {
                        if (!visited.Contains(el.SecondVertex))
                        {
                              priorityQueue.Enqueue(el, el.Bandwidth);
                        }
                  }
            }

            return newNet;
      }
}