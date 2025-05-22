// <copyright file="Methods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// The class for methods.
/// </summary>
public static class Methods
{
    /// <summary>
    /// Returns a sequence of the first n elements of the sequence seq.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="seq">The sequence.</param>
    /// <param name="n">The number of elements.</param>
    /// <returns>A sequence of the first n elements of the sequence seq.</returns>
    /// <exception cref="ArgumentNullException">If sequence is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If n numbers less than zero.</exception>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        if (seq == null)
        {
            throw new ArgumentNullException(nameof(seq));
        }

        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return TakeIterator(seq, n);
    }

    /// <summary>
    /// Returns a sequence of the second n elements of the sequence seq.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="seq">The sequence.</param>
    /// <param name="n">The number of elements.</param>
    /// <returns>A sequence of the second n elements of the sequence seq.</returns>
    /// <exception cref="ArgumentNullException">If sequence is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If n less than zero.</exception>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        if (seq == null)
        {
            throw new ArgumentNullException(nameof(seq));
        }

        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return SkipIterator(seq, n);
    }

    private static IEnumerable<T> TakeIterator<T>(this IEnumerable<T> seq, int n)
    {
        var count = 0;
        foreach (var i in seq)
        {
            if (count >= n)
            {
                yield break;
            }

            yield return i;
            ++count;
        }
    }

    private static IEnumerable<T> SkipIterator<T>(this IEnumerable<T> seq, int n)
    {
        int count = 0;
        foreach (var i in seq)
        {
            if (count >= n)
            {
                yield return i;
            }

            ++count;
        }
    }
}
