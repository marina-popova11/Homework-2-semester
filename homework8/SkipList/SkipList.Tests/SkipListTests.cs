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

    [Test]
    public void Test_FindNode_ReturnCorrect()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        Assert.That(list.FindNode(5), Is.Not.Null);
    }

    [Test]
    public void Test_FindNode_ReturnInCorrect()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        Assert.That(list.FindNode(2), Is.Null);
    }

    [Test]
    public void Test_IndexOf_ReturnCorrect()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        Assert.That(list.IndexOf(3), Is.EqualTo(1));
    }

    [Test]
    public void Test_IndexOf_ReturnWithNonexistentElement()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        Assert.That(list.IndexOf(10), Is.EqualTo(-1));
    }

    [Test]
    public void Test_CopyTo()
    {
        var list = new SkipList.List<string>();
        list.Add("No");
        list.Add("Yes");
        list.Add("Maybe");
        var array = new string[3];
        list.CopyTo(array, 0);
        Assert.That(array[0], Is.EqualTo("Maybe"));
        Assert.That(array[2], Is.EqualTo("Yes"));
        Assert.That(array[1], Is.EqualTo("No"));
    }

    [Test]
    public void CopyTo_ThrowsArgumentNullException()
    {
        var list = new SkipList.List<int>();
        Assert.Throws<ArgumentNullException>(() => list.CopyTo(null, 0));
    }

    [Test]
    public void CopyTo_ThrowsArgumentOutOfRangeException()
    {
        var list = new SkipList.List<int>();
        var array = new int[1];
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));
    }

    [Test]
    public void CopyTo_ThrowsArgumentException()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(2);
        var array = new int[1];
        Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0));
    }

    [Test]
    public void Test_Clear()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        Assert.That(list.Count(), Is.EqualTo(1));
        list.Clear();
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void Test_RemoveAt()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(5);
        list.Add(3);
        list.RemoveAt(1);
        Assert.That(list.Count(), Is.EqualTo(2));
    }

    [Test]
    public void Test_Remove_ReturnTrue()
    {
        var list = new SkipList.List<string>();
        list.Add("No");
        list.Add("Yes");
        list.Add("Maybe");
        Assert.That(list.Remove("Yes"), Is.True);
    }

    [Test]
    public void Test_Remove_ReturnFalse()
    {
        var list = new SkipList.List<string>();
        list.Add("No");
        list.Add("Yes");
        list.Add("Maybe");
        Assert.That(list.Remove("Sorry"), Is.False);
    }

    [Test]
    public void Test_Remove()
    {
        var list = new SkipList.List<string>();
        list.Add("No");
        list.Add("Yes");
        list.Add("Maybe");
        list.Remove("No");
        Assert.That(list.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetEnumerator_ReturnsAllItems()
    {
        var list = new SkipList.List<int>();
        list.Add(1);
        list.Add(6);
        list.Add(3);

        var enumerator = list.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.True);
        Assert.That(enumerator.Current, Is.EqualTo(1));
        Assert.That(enumerator.MoveNext(), Is.True);
        Assert.That(enumerator.Current, Is.EqualTo(3));
        Assert.That(enumerator.MoveNext(), Is.True);
        Assert.That(enumerator.Current, Is.EqualTo(6));
        Assert.That(enumerator.MoveNext(), Is.False);
    }
}
