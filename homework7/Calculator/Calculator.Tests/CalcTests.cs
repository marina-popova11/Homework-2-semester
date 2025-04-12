namespace Calculator.Tests;

public class CalcTests
{
    [Test]
    public void Test_InitialState()
    {
        var calculator = new Calc();
        Assert.That(calculator.GetCurrentValue(), Is.EqualTo(0));
    }

    [Test]
    public void Test_NumberEnter()
    {
        var calculator = new Calc();
        calculator.NumberEnter(10);
        Assert.That(calculator.GetCurrentValue(), Is.EqualTo(10));
    }

    [Test]
    public void Test_OperatorEnter()
    {
        var calculator = new Calc();
        calculator.NumberEnter(2);
        calculator.OperatorEnter('+');
        calculator.NumberEnter(3);
        var result = calculator.OperatorEnter('=');
        Assert.That(result, Is.EqualTo(5));
    }
}