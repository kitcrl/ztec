namespace xsAppMon
{
  partial class xsAppMon
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
      this.cbProtocol = new System.Windows.Forms.ComboBox();
      this.cbSysType = new System.Windows.Forms.ComboBox();
      this.cbCast = new System.Windows.Forms.ComboBox();
      this.txtIP = new System.Windows.Forms.TextBox();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.btnSocketOpen = new System.Windows.Forms.Button();
      this.btnWrite = new System.Windows.Forms.Button();
      this.btnRead = new System.Windows.Forms.Button();
      this.btnOpen = new System.Windows.Forms.Button();
      this.btnSerialOpen = new System.Windows.Forms.Button();
      this.txtKey = new System.Windows.Forms.TextBox();
      this.txtWrite = new System.Windows.Forms.TextBox();
      this.txtMsg = new System.Windows.Forms.TextBox();
      this.txtSerialRead = new System.Windows.Forms.TextBox();
      this.txtSize = new System.Windows.Forms.TextBox();
      this.txtOffset = new System.Windows.Forms.TextBox();
      this.txtLen = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cbType = new System.Windows.Forms.ComboBox();
      this.btnTest01 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.txtLog = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // cbProtocol
      // 
      this.cbProtocol.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.cbProtocol.FormattingEnabled = true;
      this.cbProtocol.Location = new System.Drawing.Point(126, 11);
      this.cbProtocol.Name = "cbProtocol";
      this.cbProtocol.Size = new System.Drawing.Size(79, 31);
      this.cbProtocol.TabIndex = 4;
      // 
      // cbSysType
      // 
      this.cbSysType.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.cbSysType.FormattingEnabled = true;
      this.cbSysType.Items.AddRange(new object[] {
            "SERVER",
            "CLIENT"});
      this.cbSysType.Location = new System.Drawing.Point(14, 11);
      this.cbSysType.Name = "cbSysType";
      this.cbSysType.Size = new System.Drawing.Size(103, 31);
      this.cbSysType.TabIndex = 4;
      // 
      // cbCast
      // 
      this.cbCast.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.cbCast.FormattingEnabled = true;
      this.cbCast.Location = new System.Drawing.Point(212, 11);
      this.cbCast.Name = "cbCast";
      this.cbCast.Size = new System.Drawing.Size(83, 31);
      this.cbCast.TabIndex = 4;
      // 
      // txtIP
      // 
      this.txtIP.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtIP.Location = new System.Drawing.Point(301, 11);
      this.txtIP.Name = "txtIP";
      this.txtIP.Size = new System.Drawing.Size(177, 31);
      this.txtIP.TabIndex = 5;
      this.txtIP.Text = "127.0.0.1";
      this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtPort
      // 
      this.txtPort.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtPort.Location = new System.Drawing.Point(484, 11);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(80, 31);
      this.txtPort.TabIndex = 5;
      this.txtPort.Text = "2654";
      this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btnSocketOpen
      // 
      this.btnSocketOpen.BackColor = System.Drawing.Color.Gray;
      this.btnSocketOpen.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.btnSocketOpen.ForeColor = System.Drawing.Color.White;
      this.btnSocketOpen.Location = new System.Drawing.Point(570, 11);
      this.btnSocketOpen.Name = "btnSocketOpen";
      this.btnSocketOpen.Size = new System.Drawing.Size(87, 33);
      this.btnSocketOpen.TabIndex = 6;
      this.btnSocketOpen.Text = "Open";
      this.btnSocketOpen.UseVisualStyleBackColor = false;
      this.btnSocketOpen.Click += new System.EventHandler(this.btnSocketOpen_Click);
      // 
      // btnWrite
      // 
      this.btnWrite.BackColor = System.Drawing.Color.Gray;
      this.btnWrite.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.btnWrite.ForeColor = System.Drawing.Color.White;
      this.btnWrite.Location = new System.Drawing.Point(14, 330);
      this.btnWrite.Name = "btnWrite";
      this.btnWrite.Size = new System.Drawing.Size(253, 52);
      this.btnWrite.TabIndex = 0;
      this.btnWrite.Text = "Write";
      this.btnWrite.UseVisualStyleBackColor = false;
      this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
      // 
      // btnRead
      // 
      this.btnRead.BackColor = System.Drawing.Color.Gray;
      this.btnRead.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.btnRead.ForeColor = System.Drawing.Color.White;
      this.btnRead.Location = new System.Drawing.Point(274, 330);
      this.btnRead.Name = "btnRead";
      this.btnRead.Size = new System.Drawing.Size(243, 52);
      this.btnRead.TabIndex = 0;
      this.btnRead.Text = "Read";
      this.btnRead.UseVisualStyleBackColor = false;
      this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
      // 
      // btnOpen
      // 
      this.btnOpen.BackColor = System.Drawing.Color.Gray;
      this.btnOpen.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOpen.ForeColor = System.Drawing.Color.White;
      this.btnOpen.Location = new System.Drawing.Point(14, 228);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(118, 29);
      this.btnOpen.TabIndex = 0;
      this.btnOpen.Text = "Open";
      this.btnOpen.UseVisualStyleBackColor = false;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // btnSerialOpen
      // 
      this.btnSerialOpen.BackColor = System.Drawing.Color.Gray;
      this.btnSerialOpen.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSerialOpen.ForeColor = System.Drawing.Color.White;
      this.btnSerialOpen.Location = new System.Drawing.Point(14, 409);
      this.btnSerialOpen.Name = "btnSerialOpen";
      this.btnSerialOpen.Size = new System.Drawing.Size(118, 29);
      this.btnSerialOpen.TabIndex = 0;
      this.btnSerialOpen.Text = "Open";
      this.btnSerialOpen.UseVisualStyleBackColor = false;
      this.btnSerialOpen.Click += new System.EventHandler(this.btnSerialOpen_Click);
      // 
      // txtKey
      // 
      this.txtKey.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtKey.Location = new System.Drawing.Point(139, 228);
      this.txtKey.Name = "txtKey";
      this.txtKey.Size = new System.Drawing.Size(97, 31);
      this.txtKey.TabIndex = 1;
      this.txtKey.Text = "2654";
      this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtWrite
      // 
      this.txtWrite.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtWrite.Location = new System.Drawing.Point(139, 262);
      this.txtWrite.Name = "txtWrite";
      this.txtWrite.Size = new System.Drawing.Size(377, 31);
      this.txtWrite.TabIndex = 1;
      this.txtWrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtMsg
      // 
      this.txtMsg.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtMsg.Location = new System.Drawing.Point(139, 296);
      this.txtMsg.Name = "txtMsg";
      this.txtMsg.Size = new System.Drawing.Size(252, 31);
      this.txtMsg.TabIndex = 1;
      this.txtMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtSerialRead
      // 
      this.txtSerialRead.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtSerialRead.Location = new System.Drawing.Point(14, 444);
      this.txtSerialRead.Multiline = true;
      this.txtSerialRead.Name = "txtSerialRead";
      this.txtSerialRead.Size = new System.Drawing.Size(502, 129);
      this.txtSerialRead.TabIndex = 1;
      this.txtSerialRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtSize
      // 
      this.txtSize.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtSize.Location = new System.Drawing.Point(244, 228);
      this.txtSize.Name = "txtSize";
      this.txtSize.Size = new System.Drawing.Size(96, 31);
      this.txtSize.TabIndex = 1;
      this.txtSize.Text = "10240";
      this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtOffset
      // 
      this.txtOffset.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtOffset.Location = new System.Drawing.Point(348, 228);
      this.txtOffset.Name = "txtOffset";
      this.txtOffset.Size = new System.Drawing.Size(69, 31);
      this.txtOffset.TabIndex = 1;
      this.txtOffset.Text = "0";
      this.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtLen
      // 
      this.txtLen.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtLen.Location = new System.Drawing.Point(399, 296);
      this.txtLen.Name = "txtLen";
      this.txtLen.Size = new System.Drawing.Size(117, 31);
      this.txtLen.TabIndex = 1;
      this.txtLen.Text = "1";
      this.txtLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.label1.Location = new System.Drawing.Point(14, 264);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 23);
      this.label1.TabIndex = 2;
      this.label1.Text = "Write";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(14, 299);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 23);
      this.label2.TabIndex = 2;
      this.label2.Text = "Read";
      // 
      // cbType
      // 
      this.cbType.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.cbType.FormattingEnabled = true;
      this.cbType.Location = new System.Drawing.Point(425, 228);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(91, 31);
      this.cbType.TabIndex = 3;
      // 
      // btnTest01
      // 
      this.btnTest01.BackColor = System.Drawing.Color.Gray;
      this.btnTest01.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.btnTest01.ForeColor = System.Drawing.Color.White;
      this.btnTest01.Location = new System.Drawing.Point(14, 65);
      this.btnTest01.Name = "btnTest01";
      this.btnTest01.Size = new System.Drawing.Size(125, 33);
      this.btnTest01.TabIndex = 6;
      this.btnTest01.Text = "TEST 1";
      this.btnTest01.UseVisualStyleBackColor = false;
      this.btnTest01.Click += new System.EventHandler(this.btnTest01_Click);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.Gray;
      this.button2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.button2.ForeColor = System.Drawing.Color.White;
      this.button2.Location = new System.Drawing.Point(145, 65);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(125, 33);
      this.button2.TabIndex = 6;
      this.button2.Text = "TEST 2";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // txtLog
      // 
      this.txtLog.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
      this.txtLog.Location = new System.Drawing.Point(15, 104);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.Size = new System.Drawing.Size(502, 78);
      this.txtLog.TabIndex = 1;
      this.txtLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // xsAppMon
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(811, 585);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnTest01);
      this.Controls.Add(this.btnSocketOpen);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.txtIP);
      this.Controls.Add(this.cbSysType);
      this.Controls.Add(this.cbCast);
      this.Controls.Add(this.cbProtocol);
      this.Controls.Add(this.cbType);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtLen);
      this.Controls.Add(this.txtOffset);
      this.Controls.Add(this.txtSize);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.txtSerialRead);
      this.Controls.Add(this.txtMsg);
      this.Controls.Add(this.txtWrite);
      this.Controls.Add(this.txtKey);
      this.Controls.Add(this.btnSerialOpen);
      this.Controls.Add(this.btnOpen);
      this.Controls.Add(this.btnRead);
      this.Controls.Add(this.btnWrite);
      this.Name = "xsAppMon";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbProtocol;
    private System.Windows.Forms.ComboBox cbSysType;
    private System.Windows.Forms.ComboBox cbCast;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Button btnSocketOpen;
    private System.Windows.Forms.Button btnWrite;
    private System.Windows.Forms.Button btnRead;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnSerialOpen;
    private System.Windows.Forms.TextBox txtKey;
    private System.Windows.Forms.TextBox txtWrite;
    private System.Windows.Forms.TextBox txtMsg;
    private System.Windows.Forms.TextBox txtSerialRead;
    private System.Windows.Forms.TextBox txtSize;
    private System.Windows.Forms.TextBox txtOffset;
    private System.Windows.Forms.TextBox txtLen;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbType;
    private System.Windows.Forms.Button btnTest01;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox txtLog;
  }
}

