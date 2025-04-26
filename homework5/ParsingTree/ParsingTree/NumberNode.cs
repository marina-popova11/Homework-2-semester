// <copyright file="NumberNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// The node with integer value.
/// </summary>
public class NumberNode : Node
{
      private readonly int value;

      /// <summary>
      /// Initializes a new instance of the <see cref="NumberNode"/> class.
      /// </summary>
      /// <param name="value">Node`s value.</param>
      public NumberNode(int value)
      {
            this.value = value;
      }

      /// <summary>
      /// The function for calculating the value.
      /// </summary>
      /// <returns>Node`s value.</returns>
      public override int Evaluate()
      {
            return this.value;
      }

      /// <summary>
      /// The function for output to the console.
      /// </summary>
      /// <returns>String.</returns>
      public override string Print()
      {
            return this.value.ToString();
      }
}