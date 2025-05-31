namespace ParsingTree.Tests;

public class ParsingTreeTests
{
    [Test]
    public void Test_EvaluateWithValidTree_ReturnsCorrectResult()
    {
        var tree = new Tree("(* ( + 1 2 ) 3)");
        Assert.That(tree.Evaluate(), Is.EqualTo(9));
    }

    [Test]
    public void Test_EvaluateEmptyTree()
    {
        Node? root = null;
        var tree = new Tree(root!);
        Assert.That(tree.Evaluate(), Is.EqualTo(-1));
    }

    [Test]
    public void Test_EvaluateDivisionByZero_ThrowsDivideByZeroException()
    {
        var tree = new Tree("( / 8 ( - 3 3 ) )");
        Assert.Throws<DivideByZeroException>(() => tree.Evaluate());
    }

    [Test]
    public void Test_EvaluateWithInvalidTree_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(() => new Tree("/ 8 ( - 3 3 )"));
    }

    [Test]
    public void Test_EvaluateWithInvalidTree_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => new Tree("( / 8 ( % 3 3 ) )"));
    }

    [Test]
    public void Test_PrintEmptyTree()
    {
        Node? root = null;
        var tree = new Tree(root!);
        Assert.Throws<ArgumentNullException>(() => tree.Print());
    }
}
