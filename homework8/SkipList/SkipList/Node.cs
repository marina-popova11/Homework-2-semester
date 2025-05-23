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
    /// <param name="height">The height.</param>
    public Node(T value, int height)
    {
        this.Value = value;
        this.Next = new Node<T>[height];
    }

    /// <summary>
    /// Gets or sets the node`s value.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets or sets the node`next elements.
    /// </summary>
    public Node<T>[] Next { get; set; }

    /// <summary>
    /// Gets the height of node in skipList.
    /// </summary>
    public int Height => this.Next.Length;

    /// <summary>
    /// Returns next node at the specified level.
    /// </summary>
    /// <param name="level">Level.</param>
    /// <returns>Next node.</returns>
    public virtual Node<T> GetNext(int level)
    {
        if (level < 0 || level >= this.Next.Length)
        {
            return null;
        }

        return this.Next[level];
    }

    /// <summary>
    /// Sets the node`s value.
    /// </summary>
    /// <param name="value">the value.</param>
    public void SetValue(T value)
        => this.Value = value;
}