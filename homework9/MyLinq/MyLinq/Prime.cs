// <copyright file="Prime.cs" author="marina-popova11">
// under MIT License
// </copyright>

namespace MyLinq;

/// <summary>
/// The class for prime numbers.
/// </summary>
public static class Prime
{
    /// <summary>
    /// Gets infinite sequence of prime numbers.
    /// </summary>
    /// <returns>Infinite sequence of prime numbers.</returns>
    public static IEnumerable<int> GetPrime()
    {
        yield return 2;
        for (int i = 3; ; i += 2)
        {
            bool isPrime = true;
            int sqrt = (int)MathF.Sqrt(i);
            for (int j = 3; j <= sqrt; j += 2)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                yield return i;
            }
        }
    }
}