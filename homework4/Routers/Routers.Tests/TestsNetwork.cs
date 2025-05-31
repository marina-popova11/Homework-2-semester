using Routers;

namespace Routers.Tests;

public class TestsNetwork
{
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
    public void Test_PrimAlgorithmWithEmptyNet()
    {
        var net = new Network();
        var newNet = net.PrimAlgorithm();
        Assert.That(newNet.Count, Is.EqualTo(0));
        Assert.That(newNet, Is.Not.Null);
    }

    [Test]
    public void Test_PrimAlgorithmWithNotEmptyNet()
    {
        var net = new Network();
        net.AddEdge(1, 2, 8);
        net.AddEdge(1, 4, 5);
        net.AddEdge(2, 3, 5);
        net.AddEdge(2, 4, 2);
        net.AddEdge(3, 4, 3);
        var newNet = net.PrimAlgorithm();
        Assert.That(newNet.Count, Is.EqualTo(3));
        Assert.That(newNet.Exists(e => (e.FirstVertex == 1 && e.SecondVertex == 2)));
        Assert.That(newNet.Exists(e => (e.FirstVertex == 2 && e.SecondVertex == 3)));
        Assert.That(newNet.Exists(e => (e.FirstVertex == 1 && e.SecondVertex == 4)));
    }

    [Test]
    public void Test_PrimAlgorithmWithIdenticalEdges()
    {
        var net = new Network();
        net.AddEdge(1, 2, 4);
        net.AddEdge(2, 1, 5);
        net.AddEdge(2, 3, 6);
        var newNet = net.PrimAlgorithm();
        Assert.That(newNet.Count, Is.EqualTo(2));
        Assert.That(newNet[0].Bandwidth, Is.EqualTo(5));
    }

    [Test]
    public void Test_DisconnectedGraph()
    {
        var net = new Network();
        net.AddEdge(1, 2, 8);
        net.AddEdge(1, 3, 5);
        net.AddEdge(2, 3, 5);
        net.AddEdge(5, 4, 2);
        Assert.That(net.IsNetworkConnected(), Is.False);
    }
}
