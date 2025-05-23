// <copyright file="NullCounter.cs" company="marina-popova11">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest;

/// <summary>
/// The null counter class.
/// </summary>
public static class NullCounter
{
    /// <summary>
    /// Count nullable elements.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="list">The list with data.</param>
    /// <param name="checker">An object that understands what a null element is.</param>
    /// <returns>The number of nullable element.</returns>
    public static int Count<T>(this GenericList<T> list, INullChecker<T> checker)
    {
        int count = 0;
        foreach (T el in list)
        {
            if (checker.IsNull(el))
            {
                ++count;
            }
        }

        return count;
    }
}