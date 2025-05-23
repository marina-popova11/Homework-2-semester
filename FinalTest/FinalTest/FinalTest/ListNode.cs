// <copyright file="ListNode.cs" company="marina-popova11">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// the listNode`s class.
/// </summary>
/// <typeparam name="T">The type of value.</typeparam>
public class ListNode<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ListNode(T? value)
    {
        this.Value = value!;
        this.Next = null!;
    }

    /// <summary>
    /// Gets or sets the node`s value.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets or sets the node`s next element.
    /// </summary>
    public ListNode<T> Next { get; set; }
}