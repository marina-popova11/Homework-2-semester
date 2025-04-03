namespace ParsingTree.Tests;

public class ParsingTreeTests
{
    [Test]
    public void Test_EvaluateWithValidTree_ReturnsCorrectResult()
    {
        var tree = new Tree(new OperatorNode("*", new OperatorNode("+", new NumberNode(1), new NumberNode(2)), new NumberNode(3)));
        Assert.That(tree.Evaluate(), Is.EqualTo(9));
    }

    [Test]
    public void Test_EvaluateEmptyTree()
    {
        Node? root = null;
        var tree = new Tree(root);
        Assert.That(tree.Evaluate(), Is.EqualTo(-1));
    }
}
