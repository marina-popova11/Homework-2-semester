namespace LZW.Algorithm;

/// <summary>
/// This trie.
/// </summary>
public class Trie
{
      private readonly TrieNode root = new TrieNode();

      // /// <summary>
      // /// Initializes a new instance of the <see cref="Trie"/> class.
      // /// </summary>
      // public Trie()
      // {
      //       this.root.ElementCode = this.NextCode++;
      // }

      /// <summary>
      /// Gets the number of unique symbols in the trie.
      /// </summary>
      public int Size { get; private set; } = 0;

      /// <summary>
      /// Adds a string.
      /// </summary>
      /// <param name="word">The string to add.</param>
      /// <param name="code">The following free code.</param>
      public void AddElement(byte[] word, int code)
      {
            var current = this.root;
            foreach (var el in word)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        current.Children[el] = new TrieNode();
                  }

                  current = current.Children[el];
            }

            current.ElementCode = code;
      }

      /// <summary>
      /// Checks whether the word is contained in the tree.
      /// </summary>
      /// <param name="word">The string to check.</param>
      /// <returns>Returns the code of the given string.</returns>
      public int Contains(byte[] word)
      {
            var current = this.root;
            foreach (var el in word)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        return -1;
                  }

                  current = current.Children[el];
            }

            return current.ElementCode;
      }

      private class TrieNode
      {
            public char Symbol { get; set; }

            public int ElementCode { get; set; } = -1;

            public Dictionary<byte, TrieNode> Children { get; } = new Dictionary<byte, TrieNode>();
      }
}