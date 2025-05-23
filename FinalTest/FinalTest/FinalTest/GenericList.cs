// <copyright file="GenericList.cs" company="marina-popova11">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections;

namespace FinalTest;

/// <summary>
/// The List`s class.
/// </summary>
/// <typeparam name="T">The type of data.</typeparam>
public class GenericList<T> : IEnumerable<T>
{
    private ListNode<T>? head;
    private ListNode<T>? tail;

    /// <summary>
    /// Add element to end.
    /// </summary>
    /// <param name="value">The value to add.</param>
    public void Add(T? value)
    {
        var node = new ListNode<T>(value);
        if (this.head == null)
        {
            this.head = node;
            this.tail = node;
        }

        if (this.tail != null)
        {
            this.tail.Next = node;
            this.tail = node;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the List.
    /// </summary>
    /// <returns>An Enumerator{T} that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the List.
    /// </summary>
    /// <returns>Returns GetEnumerator{T}.</returns>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}