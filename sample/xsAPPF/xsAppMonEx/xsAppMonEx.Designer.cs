namespace xsAppMonEx
{
  partial class xsAppMonEx
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
      this.btnPower = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnPower
      // 
      this.btnPower.BackColor = System.Drawing.Color.DarkGray;
      this.btnPower.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.btnPower.ForeColor = System.Drawing.Color.White;
      this.btnPower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.btnPower.Location = new System.Drawing.Point(500, 12);
      this.btnPower.Name = "btnPower";
      this.btnPower.Size = new System.Drawing.Size(200, 66);
      this.btnPower.TabIndex = 11;
      this.btnPower.Text = "POWER";
      this.btnPower.UseVisualStyleBackColor = false;
      this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
      // 
      // xsAppMonEx
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(712, 494);
      this.Controls.Add(this.btnPower);
      this.Name = "xsAppMonEx";
      this.Text = "AppMonEx";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnPower;
  }
}

