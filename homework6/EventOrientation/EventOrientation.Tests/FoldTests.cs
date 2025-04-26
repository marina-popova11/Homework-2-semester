// <copyright file="FoldTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EventOrientation.Tests;

public class FoldTests
{
    private Operations element = new();

    [Test]
    public void TestFold_ThrowArgumentNullException_ListIsNull()
    {
        List<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => this.element.Fold(list, 0, (acc, x) => acc * x));
    }

    [Test]
    public void TestFold_ThrowArgumentNullException_FuncIsNull()
    {
        List<int>? list = new List<int> { 1, 2, 3 };
        Assert.Throws<ArgumentNullException>(() => this.element.Fold(list, 0, null));
    }

    [Test]
    public void TestFold_WithNormalData()
    {
        List<int>? list = new List<int> { 2, 4, 6 };
        Assert.That(this.element.Fold(list, 1, (acc, x) => acc * x), Is.EqualTo(48));
    }

    [Test]
    public void TestFold_FunctionOnFold()
    {
        List<int>? list = new List<int> { 2, 4, 6 };
        var objects = new List<(object?, object?)>();
        this.element.OnFold += (input, output) => objects.Add((input, output));

        this.element.Fold(list, 1, (acc, x) => acc * x);
        Assert.That(objects.Count, Is.EqualTo(3));
        Assert.That(objects[0], Is.EqualTo((2, 2)));
        Assert.That(objects[1], Is.EqualTo((4, 8)));
        Assert.That(objects[2], Is.EqualTo((6, 48)));
    }

    [Test]
    public void TestFold_DifferentTypes()
    {
        List<string>? list = new List<string> { "a", "b", "c" };
        Assert.That(this.element.Fold(list, " ", (acc, x) => acc + x), Is.EqualTo(" abc"));
    }
}