// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Algorithm;

/// <summary>
/// This trie.
/// </summary>
public class Trie
{
      private readonly TrieNode root;
      private int nextCode = 0;

      /// <summary>
      /// Initializes a new instance of the <see cref="Trie"/> class.
      /// </summary>
      public Trie()
      {
            this.root = new TrieNode(this.nextCode++);
      }

      /// <summary>
      /// Adds a string.
      /// </summary>
      /// <param name="text">The string to add.</param>
      public void AddElement(byte[] text)
      {
            if (text.Length > 100)
            {
                  return;
            }

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