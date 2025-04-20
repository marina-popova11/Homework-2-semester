namespace Calculator;

/// <summary>
/// This Form1.
/// </summary>
public partial class Form1 : Form
{
    private readonly Calc calculator = new Calc();

    public Form1()
    {
        this.InitializeComponent();
        this.UpdateDisplay();
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