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
        button4 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        panel2 = new System.Windows.Forms.Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
        panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        panel1.Controls.Add(button4);
        panel1.Controls.Add(button3);
        panel1.Controls.Add(button2);
        panel1.Controls.Add(button1);
        panel1.Location = new System.Drawing.Point(18, 195);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(393, 442);
        panel1.TabIndex = 0;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(320, 293);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(65, 137);
        button4.TabIndex = 3;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(249, 371);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(65, 59);
        button3.TabIndex = 2;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(176, 371);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(65, 59);
        button2.TabIndex = 1;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(12, 371);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(158, 59);
        button1.TabIndex = 0;
        button1.Text = "0";
        button1.UseVisualStyleBackColor = true;
        // 
        // panel2
        // 
        panel2.BackColor = System.Drawing.SystemColors.ControlLight;
        panel2.Location = new System.Drawing.Point(18, 28);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(392, 149);
        panel2.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(432, 653);
        Controls.Add(panel2);
        Controls.Add(panel1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        KeyPress += Form1_KeyPress;
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Panel panel2;

    private System.Windows.Forms.Panel panel1;

    #endregion
}