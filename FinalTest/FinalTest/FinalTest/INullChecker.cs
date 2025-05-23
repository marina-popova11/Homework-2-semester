// <copyright file="INullChecker.cs" company="marina-popova11">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest;

/// <summary>
/// The interface.
/// </summary>
/// <typeparam name="T">The type of value.</typeparam>
public interface INullChecker<T>
{
    /// <summary>
    /// Checks whether the number is null.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>Is null.</returns>
    bool IsNull(T value);
}

/// <summary>
/// For int.
/// </summary>
public class IntNullChecker : INullChecker<int>
{
    /// <summary>
    /// Checks whether the number is null.
    /// </summary>
    /// <param name="item">The value.</param>
    /// <returns>Is null.</returns>
    public bool IsNull(int item) => item == 0;
}

/// <summary>
/// For string.
/// </summary>
public class StringNullChecker : INullChecker<string>
{
    /// <summary>
    /// Checks whether the number is null.
    /// </summary>
    /// <param name="item">The value.</param>
    /// <returns>Is null.</returns>
    public bool IsNull(string item) => string.IsNullOrEmpty(item);
}
