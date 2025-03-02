namespace PrefixTrie;

/// <summary>
/// this prefixTree.
/// </summary>
public class Trie
{
      private readonly TrieNode root = new TrieNode(' ');

      /// <summary>
      /// Gets the number of words in the tree.
      /// </summary>
      public int Size { get; private set; } = 0;

      /// <summary>
      /// Adds a string.
      /// </summary>
      /// <param name="word">The string to add.</param>
      /// <returns>If the string did not exist, then returns true.</returns>
      public bool AddElement(string word)
      {
            if (string.IsNullOrEmpty(word))
            {
                  throw new ArgumentException();
            }

            var current = this.root;
            foreach (var el in word)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        current.Children[el] = new TrieNode(el);
                  }

                  current = current.Children[el];
                  ++current.CountOfChildren;
            }

            if (!current.IsWord)
            {
                  current.IsWord = true;
                  ++this.Size;
                  return true;
            }

            return false;
      }

      /// <summary>
      /// Checks whether the word is contained in the tree.
      /// </summary>
      /// <param name="word">The string to check.</param>
      /// <returns>If there is a word in the tree, then the IsWord pointer will be true.</returns>
      public bool Contains(string word)
      {
            if (string.IsNullOrEmpty(word))
            {
                  throw new ArgumentException();
            }

            var current = this.root;
            foreach (var el in word)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        return false;
                  }

                  current = current.Children[el];
            }

            return current.IsWord;
      }

      /// <summary>
      /// Auxiliary function for removing.
      /// </summary>
      /// <param name="word">The string to remove.</param>
      /// <returns>If the word is successfully deleted, it returns the true.</returns>
      public bool Remove(string word)
      {
            if (string.IsNullOrEmpty(word))
            {
                  throw new ArgumentException();
            }

            if (!this.Contains(word))
            {
                  return false;
            }

            var current = this.root;
            foreach (var el in word)
            {
                  var nextNode = current.Children[el];
                  --nextNode.CountOfChildren;
                  if (nextNode.CountOfChildren == 0)
                  {
                        current.Children.Remove(el);
                        --this.Size;
                        return true;
                  }

                  current = nextNode;
            }

            current.IsWord = false;
            --this.Size;
            return true;
      }

      /// <summary>
      /// Gets the number of words starting with a prefix
      /// </summary>
      /// <param name="prefix">Prefix to get a count of words.</param>
      /// <returns>Returns the number of words starting with the given prefix.</returns>
      public int HowManyStartsWithPrefix(string prefix)
      {
            if (string.IsNullOrEmpty(prefix))
            {
                  throw new ArgumentException();
            }

            var current = this.root;
            foreach (var el in prefix)
            {
                  if (!current.Children.ContainsKey(el))
                  {
                        return 0;
                  }

                  current = current.Children[el];
            }

            return current.CountOfChildren;
      }

      private class TrieNode
      {
            public TrieNode(char key)
            {
                  this.Symbol = key;
                  this.IsWord = false;
                  this.Children = new Dictionary<char, TrieNode>();
            }

            public char Symbol { get; set; }

            public bool IsWord { get; set; }

            public int CountOfChildren { get; set; } = 0;

            public Dictionary<char, TrieNode> Children { get; }
      }
}