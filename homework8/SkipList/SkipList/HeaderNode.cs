// <copyright file="HeaderNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

/// <summary>
/// This node class.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public class HeaderNode<T> : Node<T>
    where T : IComparable<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderNode{T}"/> class.
    /// </summary>
    /// <param name="height">The height the header node.</param>
    public HeaderNode(int height)
        : base(default, int.MinValue, height)
        {
        }
}