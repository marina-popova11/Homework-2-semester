// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

/// <summary>
/// This node class.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public class Node<T>
    where T : IComparable<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="key">The key.</param>
    /// <param name="height">The height.</param>
    public Node(T value, int key, int height)
    {
        this.Value = value;
        this.Key = key;
        this.Next = new Node<T>[height];
    }

    /// <summary>
    /// Gets or sets the node`s value.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets the node`s key.
    /// </summary>
    public int Key { get; }

    /// <summary>
    /// Gets or sets the node`next elements.
    /// </summary>
    public Node<T>[] Next { get; set; }

    /// <summary>
    /// Gets the height of node in skipList.
    /// </summary>
    public int Height => this.Next.Length;

    /// <summary>
    /// Returns next node at the lowest level.
    /// </summary>
    /// <returns>Next node.</returns>
    public Node<T> GetNext()
        => this.Next[0];

    /// <summary>
    /// Returns next node at the specified level.
    /// </summary>
    /// <param name="level">Level.</param>
    /// <returns>Next node.</returns>
    public Node<T> GetNext(int level)
        => this.Next[level];

    /// <summary>
    /// Sets the node`s value.
    /// </summary>
    /// <param name="value">the value.</param>
    public void SetValue(T value)
        => this.Value = value;
}