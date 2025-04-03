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
}