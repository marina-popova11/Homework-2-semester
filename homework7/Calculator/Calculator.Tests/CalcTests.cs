namespace Calculator.Tests;

/// <summary>
/// Class for Tests.
/// </summary>
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
    public void Test_NumberEnter_WithoutOperator()
    {
        var calculator = new Calc();
        calculator.NumberEnter(1);
        calculator.NumberEnter(2);
        calculator.NumberEnter(3);
        Assert.That(calculator.GetCurrentValue(), Is.EqualTo(123));
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

    [Test]
    public void Test_SubtractionWithNormalData()
    {
        var calculator = new Calc();
        calculator.NumberEnter(1);
        calculator.OperatorEnter('-');
        calculator.NumberEnter(5);
        var result = calculator.OperatorEnter('=');
        Assert.That(result, Is.EqualTo(-4));
    }

    [Test]
    public void Test_Multiplication()
    {
        var calculator = new Calc();
        calculator.NumberEnter(3);
        calculator.OperatorEnter('*');
        calculator.NumberEnter(5);
        var result = calculator.OperatorEnter('=');
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Test_DivisionWithNormalData()
    {
        var calculator = new Calc();
        calculator.NumberEnter(1);
        calculator.NumberEnter(0);
        calculator.OperatorEnter('/');
        calculator.NumberEnter(2);
        var result = calculator.OperatorEnter('=');
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Test_Division_ThrowsException()
    {
        var calculator = new Calc();
        calculator.NumberEnter(10);
        calculator.OperatorEnter('/');
        calculator.NumberEnter(0);
        Assert.Throws<DivideByZeroException>(() => calculator.OperatorEnter('='));
    }
}