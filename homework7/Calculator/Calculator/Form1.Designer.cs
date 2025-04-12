namespace Calculator;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new System.Windows.Forms.Panel();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
        panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        panel1.Location = new System.Drawing.Point(444, 29);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(364, 518);
        panel1.TabIndex = 0;
        panel1.Paint += panel1_Paint;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 593);
        Controls.Add(panel1);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel1;

    #endregion
}