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

      private List<Edge> Vertexes { get; set; }

      /// <summary>
      /// Add edge between two vertexes.
      /// </summary>
      /// <param name="fv">First vertex.</param>
      /// <param name="sv">Second vertex.</param>
      /// <param name="bandwidth">The bandwidth of channel.</param>
      public void AddEdge(int fv, int sv, int bandwidth)
      {
            this.Vertexes.Add(new Edge(fv, sv, bandwidth));
      }

      /// <summary>
      /// An algorithm for finding a minimum spanning tree.
      /// </summary>
      /// <param name="network"></param>
      public void PrimAlgorithm(Network network)
      {

      }

      private class Edge
      {
            public Edge(int fv, int sv, int bandwidth)
            {
                  this.FirstVertex = fv;
                  this.SecondVertex = sv;
                  this.Bandwidth = bandwidth;
            }

            public int FirstVertex { get; set; }

            public int SecondVertex { get; set; }

            public int Bandwidth { get; set; }
      }
}