namespace nAppMon
{
  partial class FrmCmd
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
      this.lstvCmds = new nAppComm.CListView();
      this.SuspendLayout();
      // 
      // lstvCmds
      // 
      this.lstvCmds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstvCmds.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstvCmds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstvCmds.FullRowSelect = true;
      this.lstvCmds.GridLines = true;
      this.lstvCmds.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstvCmds.Location = new System.Drawing.Point(0, 0);
      this.lstvCmds.Name = "lstvCmds";
      this.lstvCmds.Size = new System.Drawing.Size(274, 482);
      this.lstvCmds.TabIndex = 1;
      this.lstvCmds.UseCompatibleStateImageBehavior = false;
      this.lstvCmds.View = System.Windows.Forms.View.Details;
      // 
      // FrmCmd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(274, 482);
      this.Controls.Add(this.lstvCmds);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FrmCmd";
      this.Text = "FrmCmd";
      this.ResumeLayout(false);

    }

    #endregion

    public nAppComm.CListView lstvCmds;
  }
}