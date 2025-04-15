namespace Calculator;

/// <summary>
/// This class to calculate.
/// </summary>
public class Calc
{
    private double currentValue;
    private double accumulator;
    private char charOperator;
    private bool isNewOperation;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calc"/> class.
    /// </summary>
    public Calc()
    {
        this.Reset();
    }

    /// <summary>
    /// The function to reset at start state.
    /// </summary>
    public void Reset()
    {
        this.currentValue = 0;
        this.accumulator = 0;
        this.charOperator = '\0';
        this.isNewOperation = true;
    }

    /// <summary>
    /// For number enter.
    /// </summary>
    /// <param name="number">entering value.</param>
    /// <returns>current number value.</returns>
    public double NumberEnter(int number)
    {
        if (this.isNewOperation)
        {
            this.currentValue = number;
            this.isNewOperation = false;
        }
        else
        {
            this.currentValue = (this.currentValue * 10) + number;
        }

        return this.currentValue;
    }

    /// <summary>
    /// For character enter.
    /// </summary>
    /// <param name="character">entering character.</param>
    /// <returns>current number vakue.</returns>
    public double OperatorEnter(char character)
    {
        if (character == '=')
        {
            if (this.charOperator != '\0')
            {
                this.Calculating();
            }

            return this.currentValue;
        }

        if (this.charOperator != '\0' && !this.isNewOperation)
        {
            this.Calculating();
        }

        this.charOperator = character;
        this.accumulator = this.currentValue;
        this.isNewOperation = true;
        return this.currentValue;
    }

    /// <summary>
    /// The function to calculating value.
    /// </summary>
    /// <returns>The result.</returns>
    /// <exception cref="DivideByZeroException">If current value is equal zero.</exception>
    public double Calculating()
    {
        switch (this.charOperator)
        {
            case '+':
                this.currentValue = this.accumulator + this.currentValue;
                break;
            case '-':
                this.currentValue = this.accumulator - this.currentValue;
                break;
            case '*':
                this.currentValue = this.accumulator * this.currentValue;
                break;
            case '/':
                if (this.currentValue != 0)
                {
                    this.currentValue = this.accumulator / this.currentValue;
                }
                else
                {
                    throw new DivideByZeroException();
                }

                break;
        }

        this.charOperator = '\0';
        this.isNewOperation = true;
        return this.currentValue;
    }

    /// <summary>
    /// Gets the current value.
    /// </summary>
    /// <returns>Current value.</returns>
    public double GetCurrentValue()
    {
        return this.currentValue;
    }
}