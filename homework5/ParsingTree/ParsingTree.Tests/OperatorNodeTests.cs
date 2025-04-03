namespace ParsingTree.Tests;

public class OperatorNodeTests
{
      [Test]
      public void Test_EvaluateDivisionByZero_ThrowsException()
      {
            var left = new NumberNode(1);
            var right = new NumberNode(0);
            var operation = new OperatorNode("/", left, right);
            Assert.Throws<DivideByZeroException>(() => operation.Evaluate());
      }

      [Test]
      public void Test_EvaluateInvalidOperation_ThrowsException()
      {
            var left = new NumberNode(1);
            var right = new NumberNode(0);
            var operation = new OperatorNode("%", left, right);
            Assert.Throws<InvalidOperationException>(() => operation.Evaluate());
      }
}