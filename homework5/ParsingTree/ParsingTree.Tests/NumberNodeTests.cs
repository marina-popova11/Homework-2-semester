namespace ParsingTree.Tests;

public class NumberNodeTests
{
      [Test]
      public void Test_Evaluate()
      {
            var node = new NumberNode(10);
            Assert.That(node.Evaluate(), Is.EqualTo(10));
      }

      [Test]
      public void Test_Print()
      {
            var node = new NumberNode(10);
            Assert.That(node.Print(), Is.EqualTo("10"));
      }
}