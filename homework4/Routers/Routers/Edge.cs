// <copyright file="Edge.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// this edge.
/// </summary>
public class Edge
{
      /// <summary>
      /// Initializes a new instance of the <see cref="Edge"/> class.
      /// </summary>
      /// <param name="fv">first vertex.</param>
      /// <param name="sv">second vertex.</param>
      /// <param name="bandwidth">bandwidth.</param>
      public Edge(int fv, int sv, int bandwidth)
      {
            this.FirstVertex = fv;
            this.SecondVertex = sv;
            this.Bandwidth = bandwidth;
      }

      /// <summary>
      /// Gets or sets first vertex.
      /// </summary>
      public int FirstVertex { get; set; }

      /// <summary>
      /// Gets or sets second vertex.
      /// </summary>
      public int SecondVertex { get; set; }

      /// <summary>
      /// Gets or sets bandwidth.
      /// </summary>
      public int Bandwidth { get; set; }
}