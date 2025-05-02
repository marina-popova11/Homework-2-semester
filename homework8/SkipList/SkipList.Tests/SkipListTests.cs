// <copyright file="SkipListTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList.Tests;

public class SkipListTests
{
    [Test]
    public void Test_EmptyList()
    {
        var list = new List<int>();
        Assert.That(list.Count(), Is.EqualTo(0));
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void Test_AddTheSimpleData()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        Assert.That(list.Count(), Is.EqualTo(2));
    }

    [Test]
    public void Test_AddAndExist_ReturnTrue()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        Assert.That(list.Contains(2), Is.True);
    }

    [Test]
    public void Test_AddAndExist_ReturnFalse()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        Assert.That(list.Contains(5), Is.False);
        list.Clear();
    }
}
