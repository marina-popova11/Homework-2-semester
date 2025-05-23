// <copyright file="Tests.cs" company="marina-popova11">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest.Tests;

/// <summary>
/// Tests for.
/// </summary>
public class Tests
{
    [Test]
    public void Test_CountForInteger()
    {
        var list = new GenericList<int>();
        list.Add(13);
        list.Add(0);
        list.Add(0);
        var checker = new IntNullChecker();
        Assert.That(list.Count(checker), Is.EqualTo(2));
    }

    [Test]
    public void Test_CountForString()
    {
        var list = new GenericList<string>();
        list.Add("13");
        list.Add(string.Empty);
        list.Add(null);
        var checker = new StringNullChecker();
        Assert.That(list.Count(checker), Is.EqualTo(2));
    }

    [Test]
    public void Test_ReturnZero()
    {
        var list = new GenericList<string>();
        var checker = new StringNullChecker();
        Assert.That(list.Count(checker), Is.EqualTo(0));
    }
}
