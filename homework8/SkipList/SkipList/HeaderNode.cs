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
        : base(default, height)
        {
        }

    /// <summary>
    /// Returns next node at the specified level.
    /// </summary>
    /// <param name="level">level.</param>
    /// <returns>Next node.</returns>
    public override Node<T> GetNext(int level)
    {
        if (level < 0 || level >= this.Next.Length)
        {
            return null;
        }

        return this.Next[level];
    }
}