// <copyright file="Operations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EventOrientation;

/// <summary>
/// List of operations.
/// </summary>
public class Operations
{
    /// <summary>
    /// Occurs when an element is mapped during Map operation.
    /// First (object?) - the input element before mapping.
    /// Second (object?) = the result after mapping.
    /// </summary>
    public event Action<object?, object?> OnMap = (_, _) => { };

    /// <summary>
    /// Occurs when an element is checked during Filter operation.
    /// First (object?) - the element that is being checked.
    /// Second (bool) - the result of whether an item has been filtered or not.
    /// </summary>
    public event Action<object?, bool> OnFilter = (_, _) => { };

    /// <summary>
    /// Occurs when an element is processed during Fold operation.
    /// First (object?) - the element that is being processed.
    /// Second (object?) - the accumulator value after processing this element.
    /// </summary>
    public event Action<object?, object?> OnFold = (_, _) => { };

    /// <summary>
    /// The function for mapping a number.
    /// </summary>
    /// <typeparam name="TInput">The type of input elements.</typeparam>
    /// <typeparam name="TOutput">The type of output elements.</typeparam>
    /// <param name="list">The list to process.</param>
    /// <param name="func">The conversion function.</param>
    /// <returns>New list with converted elements.</returns>
    /// <exception cref="ArgumentNullException">Thrown when list or converter is null.</exception>
    public List<TOutput> Map<TInput, TOutput>(List<TInput>? list, Func<TInput, TOutput>? func)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        var output = new List<TOutput>();
        foreach (var el in list)
        {
            var current = func(el);
            output.Add(current);
            this.OnMap?.Invoke(el, current);
        }

        return output;
    }

    /// <summary>
    /// The function for filter list.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to process.</param>
    /// <param name="func">Function that returns a boolean value for a list element.</param>
    /// <returns>Filtered list.</returns>
    /// <exception cref="ArgumentNullException">Thrown when list or predicate is null.</exception>
    public List<T> Filter<T>(List<T>? list, Func<T, bool>? func)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        var output = new List<T>();
        foreach (var el in list)
        {
            bool flag = func(el);
            if (flag)
            {
                output.Add(el);
            }

            this.OnFilter?.Invoke(el, flag);
        }

        return output;
    }

    /// <summary>
    /// Accumulates a value by the list.
    /// </summary>
    /// <typeparam name="T">The type of list elements.</typeparam>
    /// <typeparam name="TAcc">The type of accumulator.</typeparam>
    /// <param name="list">The list to process.</param>
    /// <param name="start">The start accumulator value.</param>
    /// <param name="func">The accumulation function.</param>
    /// <returns>The final accumulator value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when list or accumulator is null.</exception>
    public TAcc Fold<T, TAcc>(List<T>? list, TAcc start, Func<TAcc, T, TAcc>? func)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        TAcc current = start;
        foreach (var el in list)
        {
            current = func(current, el);
            this.OnFold?.Invoke(el, current);
        }

        return current;
    }
}