
namespace ztecSerialApp
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
      this.m_txtPort = new System.Windows.Forms.TextBox();
      this.m_txtBaud = new System.Windows.Forms.TextBox();
      this.m_btnOpen = new System.Windows.Forms.Button();
      this.m_txtWrite = new System.Windows.Forms.TextBox();
      this.m_btnWrite = new System.Windows.Forms.Button();
      this.m_txtRead = new System.Windows.Forms.TextBox();
      this.m_btnClear = new System.Windows.Forms.Button();
      this.m_txtIP = new System.Windows.Forms.TextBox();
      this.m_txtSocketPort = new System.Windows.Forms.TextBox();
      this.m_txtSocketRead = new System.Windows.Forms.TextBox();
      this.m_lstSocketClient = new System.Windows.Forms.ListBox();
      this.m_btnSocketOpen = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_txtPort
      // 
      this.m_txtPort.Location = new System.Drawing.Point(12, 12);
      this.m_txtPort.Name = "m_txtPort";
      this.m_txtPort.Size = new System.Drawing.Size(100, 20);
      this.m_txtPort.TabIndex = 0;
      this.m_txtPort.Text = "COM3";
      this.m_txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_txtBaud
      // 
      this.m_txtBaud.Location = new System.Drawing.Point(118, 12);
      this.m_txtBaud.Name = "m_txtBaud";
      this.m_txtBaud.Size = new System.Drawing.Size(100, 20);
      this.m_txtBaud.TabIndex = 1;
      this.m_txtBaud.Text = "115200";
      this.m_txtBaud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_btnOpen
      // 
      this.m_btnOpen.Location = new System.Drawing.Point(404, 12);
      this.m_btnOpen.Name = "m_btnOpen";
      this.m_btnOpen.Size = new System.Drawing.Size(75, 23);
      this.m_btnOpen.TabIndex = 2;
      this.m_btnOpen.Text = "open";
      this.m_btnOpen.UseVisualStyleBackColor = true;
      this.m_btnOpen.Click += new System.EventHandler(this.m_btnOpen_Click);
      // 
      // m_txtWrite
      // 
      this.m_txtWrite.Location = new System.Drawing.Point(12, 38);
      this.m_txtWrite.Name = "m_txtWrite";
      this.m_txtWrite.Size = new System.Drawing.Size(390, 20);
      this.m_txtWrite.TabIndex = 1;
      // 
      // m_btnWrite
      // 
      this.m_btnWrite.Location = new System.Drawing.Point(404, 38);
      this.m_btnWrite.Name = "m_btnWrite";
      this.m_btnWrite.Size = new System.Drawing.Size(75, 23);
      this.m_btnWrite.TabIndex = 2;
      this.m_btnWrite.Text = "write";
      this.m_btnWrite.UseVisualStyleBackColor = true;
      this.m_btnWrite.Click += new System.EventHandler(this.m_btnWrite_Click);
      // 
      // m_txtRead
      // 
      this.m_txtRead.Location = new System.Drawing.Point(12, 64);
      this.m_txtRead.Multiline = true;
      this.m_txtRead.Name = "m_txtRead";
      this.m_txtRead.Size = new System.Drawing.Size(390, 73);
      this.m_txtRead.TabIndex = 1;
      // 
      // m_btnClear
      // 
      this.m_btnClear.Location = new System.Drawing.Point(404, 64);
      this.m_btnClear.Name = "m_btnClear";
      this.m_btnClear.Size = new System.Drawing.Size(75, 23);
      this.m_btnClear.TabIndex = 2;
      this.m_btnClear.Text = "clear";
      this.m_btnClear.UseVisualStyleBackColor = true;
      this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
      // 
      // m_txtIP
      // 
      this.m_txtIP.Location = new System.Drawing.Point(12, 144);
      this.m_txtIP.Name = "m_txtIP";
      this.m_txtIP.Size = new System.Drawing.Size(122, 20);
      this.m_txtIP.TabIndex = 3;
      this.m_txtIP.Text = "127.0.0.1";
      this.m_txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_txtSocketPort
      // 
      this.m_txtSocketPort.Location = new System.Drawing.Point(140, 144);
      this.m_txtSocketPort.Name = "m_txtSocketPort";
      this.m_txtSocketPort.Size = new System.Drawing.Size(78, 20);
      this.m_txtSocketPort.TabIndex = 4;
      this.m_txtSocketPort.Text = "7810";
      this.m_txtSocketPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_txtSocketRead
      // 
      this.m_txtSocketRead.Location = new System.Drawing.Point(12, 170);
      this.m_txtSocketRead.Multiline = true;
      this.m_txtSocketRead.Name = "m_txtSocketRead";
      this.m_txtSocketRead.Size = new System.Drawing.Size(390, 73);
      this.m_txtSocketRead.TabIndex = 1;
      // 
      // m_lstSocketClient
      // 
      this.m_lstSocketClient.FormattingEnabled = true;
      this.m_lstSocketClient.Location = new System.Drawing.Point(12, 249);
      this.m_lstSocketClient.MultiColumn = true;
      this.m_lstSocketClient.Name = "m_lstSocketClient";
      this.m_lstSocketClient.Size = new System.Drawing.Size(390, 108);
      this.m_lstSocketClient.TabIndex = 5;
      // 
      // m_btnSocketOpen
      // 
      this.m_btnSocketOpen.Location = new System.Drawing.Point(404, 144);
      this.m_btnSocketOpen.Name = "m_btnSocketOpen";
      this.m_btnSocketOpen.Size = new System.Drawing.Size(75, 23);
      this.m_btnSocketOpen.TabIndex = 6;
      this.m_btnSocketOpen.Text = "open";
      this.m_btnSocketOpen.UseVisualStyleBackColor = true;
      this.m_btnSocketOpen.Click += new System.EventHandler(this.btnSocketOpen_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(491, 367);
      this.Controls.Add(this.m_btnSocketOpen);
      this.Controls.Add(this.m_lstSocketClient);
      this.Controls.Add(this.m_txtSocketPort);
      this.Controls.Add(this.m_txtIP);
      this.Controls.Add(this.m_btnClear);
      this.Controls.Add(this.m_btnWrite);
      this.Controls.Add(this.m_btnOpen);
      this.Controls.Add(this.m_txtSocketRead);
      this.Controls.Add(this.m_txtRead);
      this.Controls.Add(this.m_txtWrite);
      this.Controls.Add(this.m_txtBaud);
      this.Controls.Add(this.m_txtPort);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox m_txtPort;
    private System.Windows.Forms.TextBox m_txtBaud;
    private System.Windows.Forms.Button m_btnOpen;
    private System.Windows.Forms.TextBox m_txtWrite;
    private System.Windows.Forms.Button m_btnWrite;
    private System.Windows.Forms.TextBox m_txtRead;
    private System.Windows.Forms.Button m_btnClear;
    private System.Windows.Forms.TextBox m_txtIP;
    private System.Windows.Forms.TextBox m_txtSocketPort;
    private System.Windows.Forms.TextBox m_txtSocketRead;
    private System.Windows.Forms.ListBox m_lstSocketClient;
    private System.Windows.Forms.Button m_btnSocketOpen;
  }
}

