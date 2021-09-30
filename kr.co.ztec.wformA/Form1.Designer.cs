
namespace kr.co.ztec.wformA
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
      this.m_btnOK = new System.Windows.Forms.Button();
      this.m_txtBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // m_btnOK
      // 
      this.m_btnOK.Location = new System.Drawing.Point(287, 40);
      this.m_btnOK.Name = "m_btnOK";
      this.m_btnOK.Size = new System.Drawing.Size(112, 79);
      this.m_btnOK.TabIndex = 0;
      this.m_btnOK.Text = "ok";
      this.m_btnOK.UseVisualStyleBackColor = true;
      this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
      this.m_btnOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_btnOK_MouseDown);
      this.m_btnOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnOK_MouseUp);
      // 
      // m_txtBox
      // 
      this.m_txtBox.Location = new System.Drawing.Point(30, 66);
      this.m_txtBox.Name = "m_txtBox";
      this.m_txtBox.Size = new System.Drawing.Size(197, 26);
      this.m_txtBox.TabIndex = 1;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(451, 302);
      this.Controls.Add(this.m_txtBox);
      this.Controls.Add(this.m_btnOK);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button m_btnOK;
    private System.Windows.Forms.TextBox m_txtBox;
  }
}

