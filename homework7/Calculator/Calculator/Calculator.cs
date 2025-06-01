// <copyright file="Calculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator;

/// <summary>
/// This Form1.
/// </summary>
public partial class Calculator : Form
{
    private readonly Calc calculator = new Calc();

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    public Calculator()
    {
        this.InitializeComponent();
        this.UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        this.label1.Text = this.calculator.GetCurrentValue().ToString();
    }

    private void DigitButtonClick(object sender, EventArgs e)
    {
        if (sender is Button button && int.TryParse(button.Tag?.ToString(), out int digit))
        {
            this.calculator.NumberEnter(digit);
            this.UpdateDisplay();
        }
    }

    private void Button11_Click(object sender, EventArgs e)
    {
        this.calculator.Reset();
        this.UpdateDisplay();
    }

    private void Button12_Click(object sender, EventArgs e)
    {
        this.calculator.OperatorEnter('=');
        this.UpdateDisplay();
    }

    private void Button13_Click(object sender, EventArgs e)
    {
        this.calculator.OperatorEnter('+');
        this.UpdateDisplay();
    }

    private void Button14_Click(object sender, EventArgs e)
    {
        this.calculator.OperatorEnter('*');
        this.UpdateDisplay();
    }

    private void Button15_Click(object sender, EventArgs e)
    {
        this.calculator.OperatorEnter('-');
        this.UpdateDisplay();
    }

    private void Button16_Click(object sender, EventArgs e)
    {
        this.calculator.OperatorEnter('/');
        this.UpdateDisplay();
    }
}