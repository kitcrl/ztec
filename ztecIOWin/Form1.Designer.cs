
namespace ztecIOWin
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
      this.lvRead = new ztecIOWin.csListView();
      this.txtIP = new System.Windows.Forms.TextBox();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.cbxCSType = new System.Windows.Forms.ComboBox();
      this.btnOpen = new System.Windows.Forms.Button();
      this.txtWrite = new System.Windows.Forms.TextBox();
      this.btnWrite = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lvRead
      // 
      this.lvRead.HideSelection = false;
      this.lvRead.Location = new System.Drawing.Point(12, 64);
      this.lvRead.Name = "lvRead";
      this.lvRead.Size = new System.Drawing.Size(534, 285);
      this.lvRead.TabIndex = 0;
      this.lvRead.UseCompatibleStateImageBehavior = false;
      // 
      // txtIP
      // 
      this.txtIP.Location = new System.Drawing.Point(12, 12);
      this.txtIP.Name = "txtIP";
      this.txtIP.Size = new System.Drawing.Size(141, 20);
      this.txtIP.TabIndex = 1;
      this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(159, 12);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(60, 20);
      this.txtPort.TabIndex = 2;
      this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // cbxCSType
      // 
      this.cbxCSType.FormattingEnabled = true;
      this.cbxCSType.Location = new System.Drawing.Point(225, 12);
      this.cbxCSType.Name = "cbxCSType";
      this.cbxCSType.Size = new System.Drawing.Size(121, 21);
      this.cbxCSType.TabIndex = 3;
      // 
      // btnOpen
      // 
      this.btnOpen.Location = new System.Drawing.Point(552, 12);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 4;
      this.btnOpen.Text = "button1";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // txtWrite
      // 
      this.txtWrite.Location = new System.Drawing.Point(12, 38);
      this.txtWrite.Name = "txtWrite";
      this.txtWrite.Size = new System.Drawing.Size(534, 20);
      this.txtWrite.TabIndex = 5;
      // 
      // btnWrite
      // 
      this.btnWrite.Location = new System.Drawing.Point(552, 36);
      this.btnWrite.Name = "btnWrite";
      this.btnWrite.Size = new System.Drawing.Size(75, 23);
      this.btnWrite.TabIndex = 6;
      this.btnWrite.Text = "button2";
      this.btnWrite.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(633, 361);
      this.Controls.Add(this.btnWrite);
      this.Controls.Add(this.txtWrite);
      this.Controls.Add(this.btnOpen);
      this.Controls.Add(this.cbxCSType);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.txtIP);
      this.Controls.Add(this.lvRead);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private csListView lvRead;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.ComboBox cbxCSType;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.TextBox txtWrite;
    private System.Windows.Forms.Button btnWrite;
  }
}

