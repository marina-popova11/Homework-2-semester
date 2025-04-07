namespace EventOrientation.Tests;

public class FilterTests
{
    [Test]
    public void TestFilter_ThrowArgumentNullException_ListIsNull()
    {
        List<int>? list = null;
        var element = new Operations();
        Assert.Throws<ArgumentNullException>(() => element.Filter(list, x => x % 2 == 0));
    }

    [Test]
    public void TestFilter_ThrowArgumentNullException_FuncIsNull()
    {
        var list = new List<int> {1, 2, 3};
        var element = new Operations();
        Assert.Throws<ArgumentNullException>(() => element.Filter(list, null));
    }

    [Test]
    public void TestFilter_WithNormalData()
    {
        var list = new List<int> {2, 4, 8};
        var element = new Operations();
        Assert.That(element.Filter(list, x => x % 2 == 0), Is.EqualTo(list));
    }

    [Test]
    public void TestFilter_FunctionOnFilter()
    {
        var list = new List<int> {2, 5, 8};
        var element = new Operations();
        var objects = new List<(object?, bool)>();
        element.OnFilter += (input, isFiltered) => objects.Add((input, isFiltered));

        element.Filter(list, x => x % 2 == 0);
        Assert.That(objects.Count, Is.EqualTo(3));
        Assert.That(objects[0], Is.EqualTo((2, true)));
        Assert.That(objects[1], Is.EqualTo((5, false)));
        Assert.That(objects[2], Is.EqualTo((8, true)));
    }
}