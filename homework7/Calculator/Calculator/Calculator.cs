// <copyright file="Form1.cs" company="PlaceholderCompany">
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
        this.KeyPreview = true;
        this.UpdateDisplay();
        this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.D0:
            case Keys.NumPad0:
                this.Button1_Click(sender, EventArgs.Empty);
                break;

            case Keys.D1:
            case Keys.NumPad1:
                this.Button2_Click(sender, EventArgs.Empty);
                break;

            case Keys.D2:
            case Keys.NumPad2:
                this.Button3_Click(sender, EventArgs.Empty);
                break;

            case Keys.D3:
            case Keys.NumPad3:
                this.Button4_Click(sender, EventArgs.Empty);
                break;

            case Keys.D4:
            case Keys.NumPad4:
                this.Button5_Click(sender, EventArgs.Empty);
                break;

            case Keys.D5:
            case Keys.NumPad5:
                this.Button6_Click(sender, EventArgs.Empty);
                break;

            case Keys.D6:
            case Keys.NumPad6:
                this.Button7_Click(sender, EventArgs.Empty);
                break;

            case Keys.D7:
            case Keys.NumPad7:
                this.Button8_Click(sender, EventArgs.Empty);
                break;

            case Keys.D8:
            case Keys.NumPad8:
                this.Button9_Click(sender, EventArgs.Empty);
                break;

            case Keys.D9:
            case Keys.NumPad9:
                this.Button10_Click(sender, EventArgs.Empty);
                break;

            case Keys.Add:
                this.Button13_Click(sender, EventArgs.Empty);
                break;

            case Keys.Subtract:
                this.Button15_Click(sender, EventArgs.Empty);
                break;

            case Keys.Multiply:
                this.Button14_Click(sender, EventArgs.Empty);
                break;

            case Keys.Divide:
                this.Button16_Click(sender, EventArgs.Empty);
                break;

            case Keys.Enter:
                this.Button12_Click(sender, EventArgs.Empty);
                break;

            case Keys.Back:
            case Keys.Delete:
                this.Button11_Click(sender, EventArgs.Empty);
                break;
        }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(0);
        this.UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        this.label1.Text = this.calculator.GetCurrentValue().ToString();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(1);
        this.UpdateDisplay();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(2);
        this.UpdateDisplay();
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(3);
        this.UpdateDisplay();
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(4);
        this.UpdateDisplay();
    }

    private void Button6_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(5);
        this.UpdateDisplay();
    }

    private void Button7_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(6);
        this.UpdateDisplay();
    }

    private void Button8_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(7);
        this.UpdateDisplay();
    }

    private void Button9_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(8);
        this.UpdateDisplay();
    }

    private void Button10_Click(object sender, EventArgs e)
    {
        this.calculator.NumberEnter(9);
        this.UpdateDisplay();
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