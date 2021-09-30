
namespace wsSerialController
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
      this.m_txtComPort = new System.Windows.Forms.TextBox();
      this.m_txtBaudRate = new System.Windows.Forms.TextBox();
      this.m_txtDataBit = new System.Windows.Forms.TextBox();
      this.m_cbxStopBit = new System.Windows.Forms.ComboBox();
      this.m_cbxFlowControl = new System.Windows.Forms.ComboBox();
      this.m_btnOpenClose = new System.Windows.Forms.Button();
      this.m_txtWrite = new System.Windows.Forms.TextBox();
      this.m_txtRead = new System.Windows.Forms.TextBox();
      this.m_btnWrite = new System.Windows.Forms.Button();
      this.m_btnClear = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_txtComPort
      // 
      this.m_txtComPort.Location = new System.Drawing.Point(12, 11);
      this.m_txtComPort.Name = "m_txtComPort";
      this.m_txtComPort.Size = new System.Drawing.Size(100, 20);
      this.m_txtComPort.TabIndex = 0;
      this.m_txtComPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_txtBaudRate
      // 
      this.m_txtBaudRate.Location = new System.Drawing.Point(119, 11);
      this.m_txtBaudRate.Name = "m_txtBaudRate";
      this.m_txtBaudRate.Size = new System.Drawing.Size(100, 20);
      this.m_txtBaudRate.TabIndex = 1;
      this.m_txtBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_txtDataBit
      // 
      this.m_txtDataBit.Location = new System.Drawing.Point(226, 11);
      this.m_txtDataBit.Name = "m_txtDataBit";
      this.m_txtDataBit.Size = new System.Drawing.Size(54, 20);
      this.m_txtDataBit.TabIndex = 2;
      this.m_txtDataBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // m_cbxStopBit
      // 
      this.m_cbxStopBit.FormattingEnabled = true;
      this.m_cbxStopBit.Location = new System.Drawing.Point(286, 11);
      this.m_cbxStopBit.Name = "m_cbxStopBit";
      this.m_cbxStopBit.Size = new System.Drawing.Size(71, 21);
      this.m_cbxStopBit.TabIndex = 3;
      // 
      // m_cbxFlowControl
      // 
      this.m_cbxFlowControl.FormattingEnabled = true;
      this.m_cbxFlowControl.Location = new System.Drawing.Point(363, 11);
      this.m_cbxFlowControl.Name = "m_cbxFlowControl";
      this.m_cbxFlowControl.Size = new System.Drawing.Size(88, 21);
      this.m_cbxFlowControl.TabIndex = 4;
      // 
      // m_btnOpenClose
      // 
      this.m_btnOpenClose.Location = new System.Drawing.Point(457, 9);
      this.m_btnOpenClose.Name = "m_btnOpenClose";
      this.m_btnOpenClose.Size = new System.Drawing.Size(128, 23);
      this.m_btnOpenClose.TabIndex = 5;
      this.m_btnOpenClose.Text = "open";
      this.m_btnOpenClose.UseVisualStyleBackColor = true;
      this.m_btnOpenClose.Click += new System.EventHandler(this.m_btnOpenClose_Click);
      // 
      // m_txtWrite
      // 
      this.m_txtWrite.Location = new System.Drawing.Point(12, 37);
      this.m_txtWrite.Name = "m_txtWrite";
      this.m_txtWrite.Size = new System.Drawing.Size(439, 20);
      this.m_txtWrite.TabIndex = 6;
      // 
      // m_txtRead
      // 
      this.m_txtRead.Location = new System.Drawing.Point(12, 63);
      this.m_txtRead.Multiline = true;
      this.m_txtRead.Name = "m_txtRead";
      this.m_txtRead.Size = new System.Drawing.Size(439, 206);
      this.m_txtRead.TabIndex = 7;
      // 
      // m_btnWrite
      // 
      this.m_btnWrite.Location = new System.Drawing.Point(458, 35);
      this.m_btnWrite.Name = "m_btnWrite";
      this.m_btnWrite.Size = new System.Drawing.Size(127, 23);
      this.m_btnWrite.TabIndex = 8;
      this.m_btnWrite.Text = "write";
      this.m_btnWrite.UseVisualStyleBackColor = true;
      // 
      // m_btnClear
      // 
      this.m_btnClear.Location = new System.Drawing.Point(458, 63);
      this.m_btnClear.Name = "m_btnClear";
      this.m_btnClear.Size = new System.Drawing.Size(127, 23);
      this.m_btnClear.TabIndex = 9;
      this.m_btnClear.Text = "clear";
      this.m_btnClear.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(597, 281);
      this.Controls.Add(this.m_btnClear);
      this.Controls.Add(this.m_btnWrite);
      this.Controls.Add(this.m_txtRead);
      this.Controls.Add(this.m_txtWrite);
      this.Controls.Add(this.m_btnOpenClose);
      this.Controls.Add(this.m_cbxFlowControl);
      this.Controls.Add(this.m_cbxStopBit);
      this.Controls.Add(this.m_txtDataBit);
      this.Controls.Add(this.m_txtBaudRate);
      this.Controls.Add(this.m_txtComPort);
      this.Name = "Form1";
      this.Text = "Serial Communicator";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox m_txtComPort;
    private System.Windows.Forms.TextBox m_txtBaudRate;
    private System.Windows.Forms.TextBox m_txtDataBit;
    private System.Windows.Forms.ComboBox m_cbxStopBit;
    private System.Windows.Forms.ComboBox m_cbxFlowControl;
    private System.Windows.Forms.Button m_btnOpenClose;
    private System.Windows.Forms.TextBox m_txtWrite;
    private System.Windows.Forms.TextBox m_txtRead;
    private System.Windows.Forms.Button m_btnWrite;
    private System.Windows.Forms.Button m_btnClear;
  }
}

