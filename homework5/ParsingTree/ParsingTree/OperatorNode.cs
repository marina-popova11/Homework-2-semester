// <copyright file="OperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// The node with operator.
/// </summary>
public class OperatorNode : Node
{
      private string operation;

      private Node leftChild;

      private Node rightChild;

      /// <summary>
      /// Initializes a new instance of the <see cref="OperatorNode"/> class.
      /// </summary>
      /// <param name="operation">The operation.</param>
      /// <param name="leftChild">The leftChild of node.</param>
      /// <param name="rightChild">The rightChild of node.</param>
      public OperatorNode(string operation, Node leftChild, Node rightChild)
      {
            this.leftChild = leftChild;
            this.rightChild = rightChild;
            this.operation = operation;
      }

      /// <summary>
      /// The function for calculating the value with current operation.
      /// </summary>
      /// <returns>The result of calculating.</returns>
      /// <exception cref="DivideByZeroException">The exception is for division by zero.</exception>
      /// <exception cref="InvalidOperationException">The exception is for the invalid operation.</exception>
      public override int Evaluate()
      {
            switch (this.operation)
            {
                  case "+":
                        return this.leftChild.Evaluate() + this.rightChild.Evaluate();
                  case "-":
                        return this.leftChild.Evaluate() - this.rightChild.Evaluate();
                  case "*":
                        return this.leftChild.Evaluate() * this.rightChild.Evaluate();
                  case "/":
                        if (this.rightChild.Evaluate() == 0)
                        {
                              throw new DivideByZeroException("Division by zero is not allowed!");
                        }

                        return this.leftChild.Evaluate() / this.rightChild.Evaluate();
                  default:
                        throw new InvalidOperationException("Unknown operation!");
            }
      }

      /// <summary>
      /// The function for output to the console operator and two numberNode`s.
      /// </summary>
      /// <returns>String.</returns>
      public override string Print()
      {
            return $"{this.operation} {this.leftChild.Print()} {this.rightChild.Print()}";
      }
}