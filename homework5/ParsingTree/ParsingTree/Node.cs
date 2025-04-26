// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// This node of parsing tree.
/// </summary>
public abstract class Node
{
      /// <summary>
      /// The function for calculating the value.
      /// </summary>
      /// <returns>The result of evaluate.</returns>
      public abstract int Evaluate();

      /// <summary>
      /// The function for output to the console.
      /// </summary>
      /// <returns>String.</returns>
      public abstract string Print();
}