namespace LineJJ
{
  partial class nDebug
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
      this.btnATrans = new System.Windows.Forms.Button();
      this.txtFromATrans = new System.Windows.Forms.TextBox();
      this.txtToATrans = new System.Windows.Forms.TextBox();
      this.btnBTrans = new System.Windows.Forms.Button();
      this.txtFromBTrans = new System.Windows.Forms.TextBox();
      this.txtToBTrans = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnATrans
      // 
      this.btnATrans.BackColor = System.Drawing.Color.Blue;
      this.btnATrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnATrans.ForeColor = System.Drawing.Color.White;
      this.btnATrans.Location = new System.Drawing.Point(12, 21);
      this.btnATrans.Name = "btnATrans";
      this.btnATrans.Size = new System.Drawing.Size(106, 22);
      this.btnATrans.TabIndex = 0;
      this.btnATrans.Text = "a Transfer";
      this.btnATrans.UseVisualStyleBackColor = false;
      this.btnATrans.Click += new System.EventHandler(this.btnATrans_Click);
      // 
      // txtFromATrans
      // 
      this.txtFromATrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtFromATrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtFromATrans.Location = new System.Drawing.Point(144, 21);
      this.txtFromATrans.Name = "txtFromATrans";
      this.txtFromATrans.Size = new System.Drawing.Size(100, 22);
      this.txtFromATrans.TabIndex = 1;
      this.txtFromATrans.Text = "414";
      this.txtFromATrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtToATrans
      // 
      this.txtToATrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtToATrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtToATrans.Location = new System.Drawing.Point(284, 21);
      this.txtToATrans.Name = "txtToATrans";
      this.txtToATrans.Size = new System.Drawing.Size(100, 22);
      this.txtToATrans.TabIndex = 2;
      this.txtToATrans.Text = "415";
      this.txtToATrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btnBTrans
      // 
      this.btnBTrans.BackColor = System.Drawing.Color.Blue;
      this.btnBTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnBTrans.ForeColor = System.Drawing.Color.White;
      this.btnBTrans.Location = new System.Drawing.Point(12, 61);
      this.btnBTrans.Name = "btnBTrans";
      this.btnBTrans.Size = new System.Drawing.Size(106, 22);
      this.btnBTrans.TabIndex = 0;
      this.btnBTrans.Text = "b Transfer";
      this.btnBTrans.UseVisualStyleBackColor = false;
      this.btnBTrans.Click += new System.EventHandler(this.btnBTrans_Click);
      // 
      // txtFromBTrans
      // 
      this.txtFromBTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtFromBTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtFromBTrans.Location = new System.Drawing.Point(144, 62);
      this.txtFromBTrans.Name = "txtFromBTrans";
      this.txtFromBTrans.Size = new System.Drawing.Size(100, 22);
      this.txtFromBTrans.TabIndex = 1;
      this.txtFromBTrans.Text = "413";
      this.txtFromBTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtToBTrans
      // 
      this.txtToBTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtToBTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtToBTrans.Location = new System.Drawing.Point(284, 61);
      this.txtToBTrans.Name = "txtToBTrans";
      this.txtToBTrans.Size = new System.Drawing.Size(100, 22);
      this.txtToBTrans.TabIndex = 2;
      this.txtToBTrans.Text = "418";
      this.txtToBTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // nDebug
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(441, 422);
      this.Controls.Add(this.txtToBTrans);
      this.Controls.Add(this.txtToATrans);
      this.Controls.Add(this.txtFromBTrans);
      this.Controls.Add(this.txtFromATrans);
      this.Controls.Add(this.btnBTrans);
      this.Controls.Add(this.btnATrans);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "nDebug";
      this.Text = "nDebug";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnATrans;
    private System.Windows.Forms.TextBox txtFromATrans;
    private System.Windows.Forms.TextBox txtToATrans;
    private System.Windows.Forms.Button btnBTrans;
    private System.Windows.Forms.TextBox txtFromBTrans;
    private System.Windows.Forms.TextBox txtToBTrans;
  }
}