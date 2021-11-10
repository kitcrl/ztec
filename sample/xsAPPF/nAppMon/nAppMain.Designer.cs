namespace nAppMon
{
  partial class nAppMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nAppMain));
      this.btnPower = new System.Windows.Forms.Button();
      this.txtIP = new System.Windows.Forms.TextBox();
      this.cbSys = new System.Windows.Forms.ComboBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.txtSend = new System.Windows.Forms.TextBox();
      this.btnAGVSend = new System.Windows.Forms.Button();
      this.cbDisplayType = new System.Windows.Forms.ComboBox();
      this.lstCmdSet = new System.Windows.Forms.ListBox();
      this.cbMasterList = new System.Windows.Forms.ComboBox();
      this.chkPromiscuosMode = new System.Windows.Forms.CheckBox();
      this.cbMessageID = new System.Windows.Forms.ComboBox();
      this.pnlCmd = new System.Windows.Forms.Panel();
      this.chkAppend = new System.Windows.Forms.CheckBox();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.lstvLog = new nAppComm.CListView();
      this.txtLog = new nAppComm.CTextBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnPower
      // 
      resources.ApplyResources(this.btnPower, "btnPower");
      this.btnPower.Name = "btnPower";
      this.btnPower.UseVisualStyleBackColor = true;
      this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
      // 
      // txtIP
      // 
      this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.txtIP, "txtIP");
      this.txtIP.Name = "txtIP";
      // 
      // cbSys
      // 
      resources.ApplyResources(this.cbSys, "cbSys");
      this.cbSys.FormattingEnabled = true;
      this.cbSys.Name = "cbSys";
      this.cbSys.SelectedIndexChanged += new System.EventHandler(this.cbSys_SelectedIndexChanged);
      // 
      // btnSend
      // 
      resources.ApplyResources(this.btnSend, "btnSend");
      this.btnSend.Name = "btnSend";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // txtSend
      // 
      this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.txtSend, "txtSend");
      this.txtSend.Name = "txtSend";
      // 
      // btnAGVSend
      // 
      resources.ApplyResources(this.btnAGVSend, "btnAGVSend");
      this.btnAGVSend.Name = "btnAGVSend";
      this.btnAGVSend.UseVisualStyleBackColor = true;
      this.btnAGVSend.Click += new System.EventHandler(this.btnAGVSend_Click);
      // 
      // cbDisplayType
      // 
      resources.ApplyResources(this.cbDisplayType, "cbDisplayType");
      this.cbDisplayType.FormattingEnabled = true;
      this.cbDisplayType.Name = "cbDisplayType";
      this.cbDisplayType.SelectedIndexChanged += new System.EventHandler(this.cbDisplayType_SelectedIndexChanged);
      // 
      // lstCmdSet
      // 
      this.lstCmdSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstCmdSet.Cursor = System.Windows.Forms.Cursors.Hand;
      resources.ApplyResources(this.lstCmdSet, "lstCmdSet");
      this.lstCmdSet.FormattingEnabled = true;
      this.lstCmdSet.Name = "lstCmdSet";
      this.lstCmdSet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCmdSet_MouseDblClk);
      this.lstCmdSet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstCmdSet_MouseClk);
      // 
      // cbMasterList
      // 
      resources.ApplyResources(this.cbMasterList, "cbMasterList");
      this.cbMasterList.FormattingEnabled = true;
      this.cbMasterList.Name = "cbMasterList";
      this.cbMasterList.SelectedIndexChanged += new System.EventHandler(this.cbMasterList_SelectedIndexChanged);
      // 
      // chkPromiscuosMode
      // 
      resources.ApplyResources(this.chkPromiscuosMode, "chkPromiscuosMode");
      this.chkPromiscuosMode.Name = "chkPromiscuosMode";
      this.chkPromiscuosMode.UseVisualStyleBackColor = true;
      this.chkPromiscuosMode.CheckedChanged += new System.EventHandler(this.chkPromiscuosMode_CheckedChanged);
      // 
      // cbMessageID
      // 
      resources.ApplyResources(this.cbMessageID, "cbMessageID");
      this.cbMessageID.FormattingEnabled = true;
      this.cbMessageID.Name = "cbMessageID";
      this.cbMessageID.SelectedIndexChanged += new System.EventHandler(this.cbMessageID_SelectedIndexChanged);
      // 
      // pnlCmd
      // 
      resources.ApplyResources(this.pnlCmd, "pnlCmd");
      this.pnlCmd.Name = "pnlCmd";
      // 
      // chkAppend
      // 
      resources.ApplyResources(this.chkAppend, "chkAppend");
      this.chkAppend.Name = "chkAppend";
      this.chkAppend.UseVisualStyleBackColor = true;
      // 
      // txtPort
      // 
      this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.txtPort, "txtPort");
      this.txtPort.Name = "txtPort";
      // 
      // lstvLog
      // 
      this.lstvLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstvLog.FullRowSelect = true;
      this.lstvLog.GridLines = true;
      resources.ApplyResources(this.lstvLog, "lstvLog");
      this.lstvLog.MultiSelect = false;
      this.lstvLog.Name = "lstvLog";
      this.lstvLog.UseCompatibleStateImageBehavior = false;
      this.lstvLog.View = System.Windows.Forms.View.Details;
      // 
      // txtLog
      // 
      this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.txtLog, "txtLog");
      this.txtLog.Name = "txtLog";
      // 
      // btnClear
      // 
      resources.ApplyResources(this.btnClear, "btnClear");
      this.btnClear.Name = "btnClear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // nAppMain
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.chkAppend);
      this.Controls.Add(this.pnlCmd);
      this.Controls.Add(this.cbMessageID);
      this.Controls.Add(this.chkPromiscuosMode);
      this.Controls.Add(this.lstvLog);
      this.Controls.Add(this.cbMasterList);
      this.Controls.Add(this.lstCmdSet);
      this.Controls.Add(this.cbDisplayType);
      this.Controls.Add(this.btnAGVSend);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.txtSend);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.cbSys);
      this.Controls.Add(this.txtIP);
      this.Controls.Add(this.btnPower);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "nAppMain";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnPower;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.ComboBox cbSys;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.TextBox txtSend;
    private nAppComm.CTextBox txtLog;
    private System.Windows.Forms.Button btnAGVSend;
    private System.Windows.Forms.ComboBox cbDisplayType;
    private System.Windows.Forms.ListBox lstCmdSet;
    private System.Windows.Forms.ComboBox cbMasterList;
    private nAppComm.CListView lstvLog;
    private System.Windows.Forms.CheckBox chkPromiscuosMode;
    private System.Windows.Forms.ComboBox cbMessageID;
    private System.Windows.Forms.Panel pnlCmd;
    private System.Windows.Forms.CheckBox chkAppend;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Button btnClear;
  }
}

