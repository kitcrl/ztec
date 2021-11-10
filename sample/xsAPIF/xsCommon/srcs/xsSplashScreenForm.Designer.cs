namespace kr.asef.net.apif.Common
{
  partial class CxsSplashScreenForm
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
      this.picBack = new System.Windows.Forms.PictureBox();
      this.lblMsg = new System.Windows.Forms.Label();
      this.lblMsg2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
      this.SuspendLayout();
      // 
      // picBack
      // 
      this.picBack.BackColor = System.Drawing.Color.White;
      this.picBack.BackgroundImage = global::kr.asef.net.apif.Common.Properties.Resources.Logo;
      this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.picBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picBack.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picBack.Location = new System.Drawing.Point(0, 0);
      this.picBack.Name = "picBack";
      this.picBack.Size = new System.Drawing.Size(670, 359);
      this.picBack.TabIndex = 0;
      this.picBack.TabStop = false;
      // 
      // lblMsg
      // 
      this.lblMsg.AutoSize = true;
      this.lblMsg.BackColor = System.Drawing.Color.White;
      this.lblMsg.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMsg.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.lblMsg.Location = new System.Drawing.Point(418, 257);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(187, 24);
      this.lblMsg.TabIndex = 1;
      this.lblMsg.Text = "Welcome To GOD";
      // 
      // lblMsg2
      // 
      this.lblMsg2.AutoSize = true;
      this.lblMsg2.BackColor = System.Drawing.Color.White;
      this.lblMsg2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMsg2.ForeColor = System.Drawing.Color.Black;
      this.lblMsg2.Location = new System.Drawing.Point(420, 283);
      this.lblMsg2.Name = "lblMsg2";
      this.lblMsg2.Size = new System.Drawing.Size(192, 17);
      this.lblMsg2.TabIndex = 2;
      this.lblMsg2.Text = "Initializing Gui Component ...";
      // 
      // CxsSplashScreenForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(670, 359);
      this.Controls.Add(this.lblMsg2);
      this.Controls.Add(this.lblMsg);
      this.Controls.Add(this.picBack);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "CxsSplashScreenForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "xsSplash";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xsSplashScreenForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.PictureBox picBack;
    public System.Windows.Forms.Label lblMsg;
    public System.Windows.Forms.Label lblMsg2;

  }
}