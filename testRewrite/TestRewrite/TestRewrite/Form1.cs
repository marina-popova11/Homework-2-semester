// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestRewrite;

/// <summary>
/// The Form1.
/// </summary>
public partial class Form1 : Form
{
    private Random random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="Form1"/> class.
    /// </summary>
    public Form1()
    {
        this.InitializeComponent();
        this.CenterButton();
        this.Resize += this.Form1Resize;
        this.MouseMove += this.Form1MouseMove;
        this.buttonRun.MouseMove += this.ButtonRunMouseMove;
        this.buttonRun.Click += this.ButtonRun_Click;
    }

    private void Form1Resize(object? sender, EventArgs e)
    {
        this.CenterButton();
    }

    private void CenterButton()
    {
        if (this.buttonRun != null)
        {
            this.buttonRun.Left = (this.ClientSize.Width - this.buttonRun.Width) / 2;
            this.buttonRun.Top = (this.ClientSize.Height - this.buttonRun.Height) / 2;
        }
    }

    private void Form1MouseMove(object? sender, MouseEventArgs e)
    {
        this.CheckAndMoveButton(Cursor.Position);
    }

    private void ButtonRunMouseMove(object? sender, MouseEventArgs e)
    {
        this.CheckAndMoveButton(Cursor.Position);
    }

    private void CheckAndMoveButton(Point cursor)
    {
        Point cursorPosition = this.PointToClient(cursor);
        Point buttonCenter = new Point(
            this.buttonRun.Left + (this.buttonRun.Width / 2),
            this.buttonRun.Top + (this.buttonRun.Height / 2));

        double distance = Math.Sqrt(
            Math.Pow(cursorPosition.X - buttonCenter.X, 2) +
            Math.Pow(cursorPosition.Y - buttonCenter.Y, 2));

        if (distance < 50)
        {
            this.MoveButton();
        }
    }

    private void MoveButton()
    {
        int maxX = this.ClientSize.Width - this.buttonRun.Width;
        int maxY = this.ClientSize.Height - this.buttonRun.Height;

        if (maxX < 0)
        {
            maxX = 0;
        }

        if (maxY < 0)
        {
            maxY = 0;
        }

        int x = this.random.Next(0, maxX + 1);
        int y = this.random.Next(0, maxY + 1);
        this.buttonRun.Location = new Point(x, y);
    }

    private void ButtonRun_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
}