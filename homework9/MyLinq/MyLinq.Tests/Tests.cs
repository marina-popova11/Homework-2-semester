// <copyright file="Tests.cs" author="marina-popova11">
// under MIT License
// </copyright>

namespace MyLinq;

public class Tests
{
    [Test]
    public void Test_GetPrimeSequenceWithTake()
    {
        var seq = Prime.GetPrime();
        var expected = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        Assert.That(seq.Take(10).ToList(), Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFirstNElements()
    {
        var seq = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19 };
        var expected = new List<int> { 2, 3, 5, 7 };
        Assert.That(seq.Take(4).ToList(), Is.EqualTo(expected));
    }

    [Test]
    public void Test_Take_ThrowsArgumentNullException()
    {
        List<int>? seq = null;
        Assert.Throws<ArgumentNullException>(() => seq.Take(10));
    }

    [Test]
    public void Test_Take_ThrowsArgumentOutOfRangeException()
    {
        var seq = new List<int> { 2, 3, 5, 7 };
        Assert.Throws<ArgumentOutOfRangeException>(() => seq.Take(-1));
    }

    [Test]
    public void Test_GetPrimeSequenceWithSkip()
    {
        var seq = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        var expected = new List<int> { 17, 19, 23, 29 };
        Assert.That(seq.Skip(6).ToList(), Is.EqualTo(expected));
    }

    [Test]
    public void Test_Skip_ThrowsArgumentNullException()
    {
        List<int>? seq = null;
        Assert.Throws<ArgumentNullException>(() => seq.Skip(10));
    }

    [Test]
    public void Test_Skip_ThrowsArgumentOutOfRangeException()
    {
        var seq = new List<int> { 2, 3, 5, 7 };
        Assert.Throws<ArgumentOutOfRangeException>(() => seq.Skip(-1));
    }

    [Test]
    public void Test_SkipAndTake()
    {
        var seq = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        var expected = new List<int> { 5, 7, 11, 13, 17 };
        Assert.That(seq.Skip(2).Take(5), Is.EqualTo(expected));
    }
}
