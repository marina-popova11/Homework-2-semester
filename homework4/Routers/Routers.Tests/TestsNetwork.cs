using Routers;

namespace Routers.Tests;

public class TestsNetwork
{
    // private Network net = new();
    // [SetUp]
    // public void Setup()
    // {
    //     var net = new Network();
    // }

    [Test]
    public void Test_AddEdgeWithNormalData()
    {
        var net = new Network();
        net.AddEdge(1, 2, 10);
        List<Edge> vertexes = net.GetVertexes();
        Assert.That(vertexes.Count, Is.EqualTo(1));
        Assert.That(vertexes[0].FirstVertex, Is.EqualTo(1));
        Assert.That(vertexes[0].SecondVertex, Is.EqualTo(2));
        Assert.That(vertexes[0].Bandwidth, Is.EqualTo(10));
    }

    [Test]
    public void Test_AddEdgeWithZeroWeight()
    {
        var net = new Network();
        net.AddEdge(1, 2, 0);
        List<Edge> vertexes = net.GetVertexes();
        Assert.That(vertexes[0].Bandwidth, Is.EqualTo(0));
    }

    [Test]
    public void Test_AddEdgeWithManyData()
    {
        var net = new Network();
        net.AddEdge(1, 2, 8);
        net.AddEdge(1, 4, 5);
        net.AddEdge(2, 4, 2);
        net.AddEdge(2, 3, 5);
        net.AddEdge(3, 4, 3);
        List<Edge> vertexes = net.GetVertexes();
        Assert.That(vertexes.Count, Is.EqualTo(5));
        Assert.That(vertexes[0].FirstVertex, Is.EqualTo(1));
        Assert.That(vertexes[0].SecondVertex, Is.EqualTo(2));
        Assert.That(vertexes[0].Bandwidth, Is.EqualTo(8));

        Assert.That(vertexes[1].FirstVertex, Is.EqualTo(1));
        Assert.That(vertexes[1].SecondVertex, Is.EqualTo(4));
        Assert.That(vertexes[1].Bandwidth, Is.EqualTo(5));

        Assert.That(vertexes[2].FirstVertex, Is.EqualTo(2));
        Assert.That(vertexes[2].SecondVertex, Is.EqualTo(4));
        Assert.That(vertexes[2].Bandwidth, Is.EqualTo(2));

        Assert.That(vertexes[3].FirstVertex, Is.EqualTo(2));
        Assert.That(vertexes[3].SecondVertex, Is.EqualTo(3));
        Assert.That(vertexes[3].Bandwidth, Is.EqualTo(5));

        Assert.That(vertexes[4].FirstVertex, Is.EqualTo(3));
        Assert.That(vertexes[4].SecondVertex, Is.EqualTo(4));
        Assert.That(vertexes[4].Bandwidth, Is.EqualTo(3));
    }

    [Test]
    public void Test_GetBandwidthWithNormalData()
    {

    }

    [Test]
    public void Test_PrimAlgorithm()
    {
        
    }
}
