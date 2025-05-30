// <copyright file="Vector.cs" author="Popova Marina">
// under MIT License.
// </copyright>

namespace TestReRewrite;

/// <summary>
/// .
/// </summary>
public class Vector
{
    private readonly Dictionary<int, double> vector = new Dictionary<int, double>();
    private int dim;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class.
    /// </summary>
    /// <param name="dim">The dimension.</param>
    /// <exception cref="InvalidDataException">If dimension les or equal to zero.</exception>
    public Vector(int dim)
    {
        if (dim <= 0)
        {
            throw new InvalidDataException();
        }

        this.dim = dim;
    }

    /// <summary>
    /// Gets or sets the element by the specified index.
    /// </summary>
    /// <param name="index">Index of element.</param>
    /// <returns>The value of element.</returns>
    /// <exception cref="IndexOutOfRangeException">If index goes out of range.</exception>
    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= this.dim)
            {
                throw new IndexOutOfRangeException();
            }

            return this.vector.TryGetValue(index, out var value) ? value : 0.0;
        }

        set
        {
            if (index < 0 || index >= this.dim)
            {
                throw new IndexOutOfRangeException();
            }

            if (value == 0.0)
            {
                this.vector.Remove(index);
            }
            else
            {
                this.vector[index] = value;
            }
        }
    }

    /// <summary>
    /// Get vector`s dimension.
    /// </summary>
    /// <returns>dimension.</returns>
    public int GetDim() => this.dim;

    /// <summary>
    /// Check on zero vector.
    /// </summary>
    /// <returns>If vector is zero.</returns>
    public bool IsZero() => this.vector.Count == 0;

    /// <summary>
    /// Adding two vectors.
    /// </summary>
    /// <param name="vector">The vector to add to current.</param>
    /// <returns>The result vector.</returns>
    public Vector Add(Vector vector)
    {
        this.CheckDim(vector);
        var result = new Vector(this.dim);
        foreach (var element in this.vector)
        {
            result[element.Key] += element.Value;
        }

        foreach (var element in vector.vector)
        {
            result[element.Key] += element.Value;
        }

        return result;
    }

    /// <summary>
    /// Subtracting two vectors.
    /// </summary>
    /// <param name="vector">The vector to subtract from current.</param>
    /// <returns>The result vector.</returns>
    public Vector Subtract(Vector vector)
    {
        this.CheckDim(vector);
        var result = new Vector(this.dim);
        foreach (var element in this.vector)
        {
            result[element.Key] += element.Value;
        }

        foreach (var element in vector.vector)
        {
            result[element.Key] -= element.Value;
        }

        return result;
    }

    /// <summary>
    /// The scalar product of two vectors.
    /// </summary>
    /// <param name="vector">Еhe vector with which the scalar product will be.</param>
    /// <returns>The number.</returns>
    public double Product(Vector vector)
    {
        this.CheckDim(vector);
        var result = 0.0;
        var smaller = this.vector.Count <= vector.vector.Count ? this.vector : vector.vector;
        var larger = this.vector.Count > vector.vector.Count ? this.vector : vector.vector;
        foreach (var element in smaller)
        {
            if (larger.TryGetValue(element.Key, out var value))
            {
                result += element.Value * value;
            }
        }

        return result;
    }

    /// <summary>
    /// To print vector as a string.
    /// </summary>
    /// <returns>vector as a string.</returns>
    public string Print()
    {
        var result = new List<string>();
        for (int i = 0; i < this.dim; ++i)
        {
            result.Add(this[i].ToString());
        }

        return $"[{string.Join(",", result)}]";
    }

    private void CheckDim(Vector vector)
    {
        if (vector == null)
        {
            throw new ArgumentNullException();
        }

        if (this.dim != vector.GetDim())
        {
            throw new Exception();
        }
    }
}