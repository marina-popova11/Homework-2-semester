// <copyright file="SkipListTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList.Tests;

public class SkipListTests
{
    [Test]
    public void Test_EmptyList()
    {
        var list = new SkipList.List<int>();
        Assert.That(list.Count(), Is.EqualTo(0));
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void Test_AddTheSimpleData()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(2);
        Assert.That(list.Count(), Is.EqualTo(2));
    }

    [Test]
    public void Test_AddAndExist_ReturnTrue()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(2);
        Assert.That(list.Contains(2), Is.True);
    }

    [Test]
    public void Test_AddAndExist_ReturnFalse()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(2);
        Assert.That(list.Contains(5), Is.False);
    }

    [Test]
    public void Test_AddTheStringValue()
    {
        var list = new SkipList.List<string>();
        list.Add("Yes");
        list.Add("No");
        list.Add("Maybe");
        Assert.That(list, Is.EqualTo(new[] { "Maybe", "No", "Yes" }));
    }

    [Test]
    public void Test_Add_ThrowsException_BiggerThanSize()
    {
        var list = new SkipList.List<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(2, 2));
    }

    [Test]
    public void Test_AddWithGetGetIndexByValue_ToDeterminePosition()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(3);
        Assert.That(list[1], Is.EqualTo(3));
        Assert.That(list[0], Is.EqualTo(1));
    }
}
