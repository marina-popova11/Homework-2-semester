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
    public HeaderNode(int height)
        : base(default, height) { }
}