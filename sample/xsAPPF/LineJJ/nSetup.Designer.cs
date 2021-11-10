namespace LineJJ
{
  partial class nSetup
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
      this.txtIP = new System.Windows.Forms.TextBox();
      this.txtPortMaster = new System.Windows.Forms.TextBox();
      this.txtPortSlave = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnPower
      // 
      this.btnPower.BackColor = System.Drawing.Color.Red;
      this.btnPower.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPower.ForeColor = System.Drawing.Color.White;
      this.btnPower.Location = new System.Drawing.Point(12, 205);
      this.btnPower.Name = "btnPower";
      this.btnPower.Size = new System.Drawing.Size(486, 131);
      this.btnPower.TabIndex = 0;
      this.btnPower.Text = "OFF";
      this.btnPower.UseVisualStyleBackColor = false;
      this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
      // 
      // txtIP
      // 
      this.txtIP.BackColor = System.Drawing.Color.White;
      this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtIP.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtIP.Location = new System.Drawing.Point(12, 60);
      this.txtIP.Name = "txtIP";
      this.txtIP.Size = new System.Drawing.Size(228, 37);
      this.txtIP.TabIndex = 1;
      this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
      // 
      // txtPortMaster
      // 
      this.txtPortMaster.BackColor = System.Drawing.Color.White;
      this.txtPortMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtPortMaster.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPortMaster.Location = new System.Drawing.Point(246, 60);
      this.txtPortMaster.Name = "txtPortMaster";
      this.txtPortMaster.Size = new System.Drawing.Size(123, 37);
      this.txtPortMaster.TabIndex = 2;
      this.txtPortMaster.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtPortMaster.TextChanged += new System.EventHandler(this.txtPortMaster_TextChanged);
      // 
      // txtPortSlave
      // 
      this.txtPortSlave.BackColor = System.Drawing.Color.White;
      this.txtPortSlave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtPortSlave.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPortSlave.Location = new System.Drawing.Point(375, 60);
      this.txtPortSlave.Name = "txtPortSlave";
      this.txtPortSlave.Size = new System.Drawing.Size(123, 37);
      this.txtPortSlave.TabIndex = 3;
      this.txtPortSlave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtPortSlave.TextChanged += new System.EventHandler(this.txtPortSlave_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
      this.label1.Location = new System.Drawing.Point(78, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 23);
      this.label1.TabIndex = 4;
      this.label1.Text = "IPAddress";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(255, 23);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(108, 23);
      this.label2.TabIndex = 4;
      this.label2.Text = "MasterPort";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
      this.label3.Location = new System.Drawing.Point(387, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(96, 23);
      this.label3.TabIndex = 4;
      this.label3.Text = "SlavePort";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // nSetup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(510, 348);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtPortSlave);
      this.Controls.Add(this.txtPortMaster);
      this.Controls.Add(this.txtIP);
      this.Controls.Add(this.btnPower);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "nSetup";
      this.Text = "nSetup";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnPower;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.TextBox txtIP;
    public System.Windows.Forms.TextBox txtPortMaster;
    public System.Windows.Forms.TextBox txtPortSlave;
  }
}