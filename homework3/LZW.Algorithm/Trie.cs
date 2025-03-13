namespace LZW.Algorithm;

/// <summary>
/// This trie.
/// </summary>
public class Trie
{
      private readonly TrieNode root;
      private int nextCode;

      public Trie()
      {
            this.root = new TrieNode(-1);
            this.nextCode = 0;
      }

      /// <summary>
      /// Adds a string.
      /// </summary>
      /// <param name="text">The string to add.</param>
      public void AddElement(byte[] text)
      {
            var current = this.root;
            foreach (var el in text)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        current.Children[el] = new TrieNode(this.nextCode++);
                  }

                  current = current.Children[el];
            }
      }

      /// <summary>
      /// Checks whether the word is contained in the tree.
      /// </summary>
      /// <param name="text">The string to check.</param>
      /// <returns>Returns the code of the given string.</returns>
      public int Contains(byte[] text)
      {
            var current = this.root;
            foreach (var el in text)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        return -1;
                  }

                  current = current.Children[el];
            }

            return current.ElementCode;
      }

      // /// <summary>
      // /// Checks whether the word is contained in the tree.
      // /// </summary>
      // /// <param name="word">The string to check.</param>
      // /// <returns>Returns the code of the given string.</returns>
      // public int Contains(byte[] word)
      // {
      //       var current = this.root;
      //       foreach (var el in word)
      //       {
      //             if (!current.Children.ContainsKey(el))
      //             {
      //                   return -1;
      //             }

      //             current = current.Children[el];
      //       }

      //       return current.ElementCode;
      // }

      private class TrieNode
      {
            public TrieNode(int code)
            {
                  this.ElementCode = code;
                  this.Children = new Dictionary<byte, TrieNode>();
            }

            public int ElementCode { get; set; } = -1;

            public Dictionary<byte, TrieNode> Children { get; } = new Dictionary<byte, TrieNode>();
      }
}