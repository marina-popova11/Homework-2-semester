namespace ParsingTree;

/// <summary>
/// This parsing tree.
/// </summary>
public class Tree
{
      private Node root;

      /// <summary>
      /// Initializes a new instance of the <see cref="Tree"/> class.
      /// </summary>
      /// <param name="root">The root node.</param>
      public Tree(Node root)
      {
            this.root = root;
      }

      /// <summary>
      /// The function for calculating the value.
      /// </summary>
      /// <returns>The result of calculating.</returns>
      public int Evaluate()
      {
            if (this.root == null)
            {
                  System.Console.WriteLine("The tree must not be empty.");
                  return -1;
            }

            return this.root.Evaluate();
      }

      /// <summary>
      /// The function for output to the console.
      /// </summary>
      /// <returns>String.</returns>
      public string Print()
      {
            return this.root.Print();
      }

      /// <summary>
      /// The node with integer value.
      /// </summary>
      public abstract class NumberNode : Node
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

      /// <summary>
      /// The node with operator.
      /// </summary>
      public abstract class OperatorNode : Node
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

            /// <summary>
            /// Get operator.
            /// </summary>
            /// <returns>Operator.</returns>
            protected abstract char GetOperatorSymbol();
      }
}