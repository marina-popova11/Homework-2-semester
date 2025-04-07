namespace EventOrientation.Tests;

public class MapTests
{
    private Operations element = new();
    [SetUp]
    public void SetUp()
    {
        var element = new Operations();
    }

    [Test]
    public void TestMap_ThrowArgumentNullException_ListIsNull()
    {
        List<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => element.Map(list, x => x * 2));
    }

    [Test]
    public void TestMap_ThrowArgumentNullException_FuncIsNull()
    {
        var list = new List<int> {1, 2, 3};
        Assert.Throws<ArgumentNullException>(() => element.Map<int, int>(list, null));
    }

    [Test]
    public void TestMap_WithNormalData()
    {
        var list = new List<int> {1, 2, 3};
        Assert.That(element.Map(list, x => x * 2), Is.EqualTo(new List<int> {2, 4, 6}));
    }

    [Test]
    public void TestMap_FunctionOnMap()
    {
        var list = new List<int> {1, 2};
        var objects = new List<(object?, object?)>();
        element.OnMap += (input, output) => objects.Add((input, output));

        element.Map(list, x => x * 2);
        Assert.That(objects.Count, Is.EqualTo(2));
        Assert.That(objects[0], Is.EqualTo((1, 2)));
        Assert.That(objects[1], Is.EqualTo((2, 4)));
    }
}
