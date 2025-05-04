// <copyright file="List.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

using System.Collections;

/// <summary>
/// This skipList.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public class List<T> : IList<T>
    where T : IComparable<T>
{
    private const double Probability = 0.5;

    private readonly Random rand = new Random();

    private HeaderNode<T> header;

    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="List{T}"/> class.
    /// </summary>
    public List()
    {
        this.header = new HeaderNode<T>(1);
        this.header.Next = new Node<T>[1];
        this.size = 0;
    }

    /// <summary>
    /// Gets the number of element in skipList.
    /// </summary>
    public int Count => this.size;

    /// <summary>
    /// Gets a value indicating whether the skipList is readonly.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Allows you to access the list items by index.
    /// </summary>
    /// <param name="index">The current index.</param>
    /// <returns>the value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If index goes beyond the boundaries.</exception>
    /// <exception cref="NotSupportedException">Not supported exception.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException();
            }

            var node = this.header.GetNext(0);
            for (int i = 0; i < index; ++i)
            {
                node = node.GetNext(0);
            }

            return node.Value;
        }

        set => throw new NotSupportedException("Set by index is not supported in SkipList.");
    }

    /// <summary>
    /// Adds an item to the skipList.
    /// </summary>
    /// <param name="item">The object to add.</param>
    public void Add(T item)
    {
        var index = this.GetIndexByValue(item);
        this.Insert(index, item);
    }

    /// <summary>
    /// The function to clear the skip list.
    /// </summary>
    public void Clear()
    {
        this.header = new HeaderNode<T>(this.header.Height);
        this.size = 0;
    }

    /// <summary>
    /// Determines whether the skipList contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in skipList.</param>
    /// <returns>True or false depending on whether the node has been found or not.</returns>
    public bool Contains(T item)
    {
        return this.IndexOf(item) >= 0;
    }

    /// <summary>
    /// Copies the elements of the SkipList to an Array, starting at a particular Array index.
    /// </summary>
    /// <param name="array">The array to which the elements from the skipList are copied.</param>
    /// <param name="arrayIndex">Initial index.</param>
    /// <exception cref="ArgumentNullException">If array is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If index goes beyond the boundaries.</exception>
    /// <exception cref="ArgumentException">If array is not large enough.</exception>
    public void CopyTo(T[]? array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException();
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (array.Length - arrayIndex < this.size)
        {
            throw new ArgumentException();
        }

        var current = this.header.GetNext(0);
        int index = arrayIndex;
        while (current != null)
        {
            array[index] = current.Value;
            ++index;
            current = current.GetNext(0);
        }
    }

    /// <summary>
    /// Determines the index of a specific item in the skipList.
    /// </summary>
    /// <param name="item">The object to locate in skipList.</param>
    /// <returns>The index of item if found in the list or -1.</returns>
    public int IndexOf(T item)
    {
        int index = 0;
        var current = this.header.GetNext(0);
        while (current != null)
        {
            if (current.Value.CompareTo(item) == 0)
            {
                return index;
            }
            else if (current.Value.CompareTo(item) > 0)
            {
                break;
            }

            current = current.GetNext(0);
            ++index;
        }

        return -1;
    }

    /// <summary>
    /// Insert an item to skipList at the specified index.
    /// </summary>
    /// <param name="index">Initial index.</param>
    /// <param name="item">The object to insert into skipList.</param>
    /// <exception cref="ArgumentOutOfRangeException">If index goes beyond the boundaries.</exception>
    public void Insert(int index, T item)
    {
        if (index < 0 || index > this.size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int newHeight = this.GetRandomHeight();
        var newNode = new Node<T>(item, newHeight);
        var update = new Node<T>[newHeight];
        var current = (Node<T>)this.header;
        for (int i = Math.Min(this.header.Height - 1, newHeight - 1); i >= 0; --i)
        {
            while (current.GetNext(i) != null && index > 0)
            {
                if (current.GetNext(i) != null)
                {
                    --index;
                    current = current.GetNext(i);
                }
            }

            update[i] = current;
        }

        for (int i = this.header.Height; i < newHeight; ++i)
        {
            update[i] = this.header;
        }

        for (int i = 0; i < newHeight; ++i)
        {
            if (i < update.Length && update[i] != null)
            {
                if (i >= update[i].Next.Length)
                {
                    var newNext = new Node<T>[i + 1];
                    Array.Copy(update[i].Next, newNext, update[i].Next.Length);
                    update[i].Next = newNext;
                }

                newNode.Next[i] = update[i].GetNext(i);
                update[i].Next[i] = newNode;
            }
        }

        if (newHeight > this.header.Next.Length)
        {
            var newNext = new Node<T>[newHeight];
            Array.Copy(this.header.Next, newNext, this.header.Next.Length);
            for (int i = this.header.Height; i < newHeight; ++i)
            {
                newNext[i] = newNode;
            }

            this.header.Next = newNext;
        }

        ++this.size;
    }

    /// <summary>
    /// The function to remove the node.
    /// </summary>
    /// <param name="node">The found node.</param>
    /// <returns>Returns true or false depending on whether the node has been deleted or not.</returns>
    public bool Remove(Node<T> node)
    {
        if (node == null)
        {
            return false;
        }

        var update = new Node<T>[this.header.Height];
        var current = (Node<T>)this.header;
        for (int i = this.header.Height - 1; i >= 0; --i)
        {
            while (current.GetNext(i) != null && current.GetNext(i).Value.CompareTo(node.Value) < 0)
            {
                current = current.GetNext(i);
            }

            update[i] = current;
        }

        var found = false;
        for (int i = 0; i < this.header.Height; ++i)
        {
            if (update[i].GetNext(i) == node)
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            return false;
        }

        for (int i = 0; i < this.header.Height; ++i)
        {
            if (update[i].GetNext(i) == node)
            {
                update[i].Next[i] = node.GetNext(i);
            }
        }

        while (this.header.Height > 1 && this.header.GetNext(this.header.Height - 1) == null)
        {
            var newNext = new Node<T>[this.header.Height - 1];
            Array.Copy(this.header.Next, newNext, newNext.Length);
            this.header.Next = newNext;
        }

        --this.size;
        return true;
    }

    /// <summary>
    /// Finds a node by index (works only at the lower level).
    /// Calls Remove(Node) for the found node.
    /// </summary>
    /// <param name="index">the index.</param>
    /// <exception cref="ArgumentOutOfRangeException">If index goes beyond the boundaries.</exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentOutOfRangeException();
        }

        var node = this.header.GetNext(0);
        for (int i = 0; i < index; ++i)
        {
            node = node.GetNext(0);
        }

        this.Remove(node);
    }

    /// <summary>
    /// The function to remove the item.
    /// </summary>
    /// <param name="item">The object to removing.</param>
    /// <returns>Returns true or false depending on whether the node has been deleted or not.</returns>
    public bool Remove(T item)
    {
        var node = this.FindNode(item);
        return node != null ? this.Remove(node) : false;
    }

    /// <summary>
    /// The function to find node by it`s key.
    /// </summary>
    /// <param name="value">The node`s value.</param>
    /// <returns>The found node.</returns>
    public Node<T>? FindNode(T value)
    {
        var node = (Node<T>)this.header;
        for (int i = this.header.Height - 1; i >= 0; --i)
        {
            while (node.GetNext(i) != null && node.GetNext(i).Value.CompareTo(value) < 0)
            {
                node = node.GetNext(i);
            }
        }

        var current = node.GetNext(0);
        return current != null && current.Value.CompareTo(value) == 0 ? current : null;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the skipList.
    /// </summary>
    /// <returns>An Enumerator{T} that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = this.header.GetNext(0);
        while (current != null)
        {
            yield return current.Value;
            current = current.GetNext(0);
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the skipList.
    /// </summary>
    /// <returns>Returns GetEnumerator{T}.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    private int GetRandomHeight()
    {
        int height = 1;
        while (this.rand.NextDouble() < Probability && height < 16)
        {
            ++height;
        }

        return height;
    }

    private int GetIndexByValue(T value)
    {
        var current = this.header.GetNext(0);
        int index = 0;
        while (current != null && current.Value.CompareTo(value) < 0)
        {
            current = current.GetNext(0);
            ++index;
        }

        return index;
    }
}