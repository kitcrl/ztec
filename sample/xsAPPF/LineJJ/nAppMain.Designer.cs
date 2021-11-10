namespace LineJJ
{
  partial class AppMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMain));
      this.pnlLineMain = new System.Windows.Forms.Panel();
      this.picAGV = new System.Windows.Forms.PictureBox();
      this.btnDebug = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.txtLog = new nAppComm.CTextBox();
      this.lstProtocolView = new nAppComm.CListView();
      this.pnlMainLeft = new System.Windows.Forms.Panel();
      this.pnlMainRight = new System.Windows.Forms.Panel();
      this.pnlMainBottom = new System.Windows.Forms.Panel();
      this.btnSetup = new System.Windows.Forms.Button();
      this.pnlLineMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picAGV)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlLineMain
      // 
      this.pnlLineMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLineMain.BackgroundImage")));
      this.pnlLineMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.pnlLineMain.Controls.Add(this.picAGV);
      this.pnlLineMain.Location = new System.Drawing.Point(12, 38);
      this.pnlLineMain.Name = "pnlLineMain";
      this.pnlLineMain.Size = new System.Drawing.Size(1022, 599);
      this.pnlLineMain.TabIndex = 1;
      // 
      // picAGV
      // 
      this.picAGV.BackColor = System.Drawing.Color.Transparent;
      this.picAGV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.picAGV.Image = ((System.Drawing.Image)(resources.GetObject("picAGV.Image")));
      this.picAGV.InitialImage = ((System.Drawing.Image)(resources.GetObject("picAGV.InitialImage")));
      this.picAGV.Location = new System.Drawing.Point(228, 3);
      this.picAGV.Name = "picAGV";
      this.picAGV.Size = new System.Drawing.Size(39, 71);
      this.picAGV.TabIndex = 0;
      this.picAGV.TabStop = false;
      // 
      // btnDebug
      // 
      this.btnDebug.BackColor = System.Drawing.Color.Black;
      this.btnDebug.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDebug.ForeColor = System.Drawing.Color.White;
      this.btnDebug.Location = new System.Drawing.Point(858, 2);
      this.btnDebug.Name = "btnDebug";
      this.btnDebug.Size = new System.Drawing.Size(75, 34);
      this.btnDebug.TabIndex = 6;
      this.btnDebug.Text = "DEBUG";
      this.btnDebug.UseVisualStyleBackColor = false;
      this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
      // 
      // btnClear
      // 
      this.btnClear.BackColor = System.Drawing.Color.Red;
      this.btnClear.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
      this.btnClear.ForeColor = System.Drawing.Color.White;
      this.btnClear.Location = new System.Drawing.Point(939, 2);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(95, 34);
      this.btnClear.TabIndex = 7;
      this.btnClear.Text = "Clear Log";
      this.btnClear.UseVisualStyleBackColor = false;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // txtLog
      // 
      this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtLog.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtLog.Location = new System.Drawing.Point(12, 643);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtLog.Size = new System.Drawing.Size(469, 344);
      this.txtLog.TabIndex = 5;
      this.txtLog.WordWrap = false;
      // 
      // lstProtocolView
      // 
      this.lstProtocolView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstProtocolView.FullRowSelect = true;
      this.lstProtocolView.GridLines = true;
      this.lstProtocolView.Location = new System.Drawing.Point(487, 643);
      this.lstProtocolView.MultiSelect = false;
      this.lstProtocolView.Name = "lstProtocolView";
      this.lstProtocolView.Size = new System.Drawing.Size(547, 344);
      this.lstProtocolView.TabIndex = 2;
      this.lstProtocolView.UseCompatibleStateImageBehavior = false;
      this.lstProtocolView.View = System.Windows.Forms.View.Details;
      // 
      // pnlMainLeft
      // 
      this.pnlMainLeft.BackColor = System.Drawing.Color.Black;
      this.pnlMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlMainLeft.Location = new System.Drawing.Point(0, 0);
      this.pnlMainLeft.Name = "pnlMainLeft";
      this.pnlMainLeft.Size = new System.Drawing.Size(1, 999);
      this.pnlMainLeft.TabIndex = 8;
      // 
      // pnlMainRight
      // 
      this.pnlMainRight.BackColor = System.Drawing.Color.Black;
      this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.pnlMainRight.Location = new System.Drawing.Point(1273, 0);
      this.pnlMainRight.Name = "pnlMainRight";
      this.pnlMainRight.Size = new System.Drawing.Size(1, 999);
      this.pnlMainRight.TabIndex = 9;
      // 
      // pnlMainBottom
      // 
      this.pnlMainBottom.BackColor = System.Drawing.Color.Black;
      this.pnlMainBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlMainBottom.Location = new System.Drawing.Point(1, 998);
      this.pnlMainBottom.Name = "pnlMainBottom";
      this.pnlMainBottom.Size = new System.Drawing.Size(1272, 1);
      this.pnlMainBottom.TabIndex = 10;
      // 
      // btnSetup
      // 
      this.btnSetup.BackColor = System.Drawing.Color.Blue;
      this.btnSetup.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
      this.btnSetup.ForeColor = System.Drawing.Color.White;
      this.btnSetup.Location = new System.Drawing.Point(777, 2);
      this.btnSetup.Name = "btnSetup";
      this.btnSetup.Size = new System.Drawing.Size(75, 34);
      this.btnSetup.TabIndex = 11;
      this.btnSetup.Text = "SETUP";
      this.btnSetup.UseVisualStyleBackColor = false;
      this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
      // 
      // AppMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(1274, 999);
      this.Controls.Add(this.btnSetup);
      this.Controls.Add(this.pnlMainBottom);
      this.Controls.Add(this.pnlMainRight);
      this.Controls.Add(this.pnlMainLeft);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnDebug);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.lstProtocolView);
      this.Controls.Add(this.pnlLineMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AppMain";
      this.Text = "AppMain";
      this.pnlLineMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picAGV)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlLineMain;
    private System.Windows.Forms.PictureBox picAGV;
    private nAppComm.CListView lstProtocolView;
    private nAppComm.CTextBox txtLog;
    private System.Windows.Forms.Button btnDebug;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Panel pnlMainLeft;
    private System.Windows.Forms.Panel pnlMainRight;
    private System.Windows.Forms.Panel pnlMainBottom;
    private System.Windows.Forms.Button btnSetup;
  }
}

