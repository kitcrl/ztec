
namespace ztecWApp
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
      this._pnlSample = new System.Windows.Forms.Panel();
      this.hsbR = new System.Windows.Forms.HScrollBar();
      this.hsbG = new System.Windows.Forms.HScrollBar();
      this.hsbB = new System.Windows.Forms.HScrollBar();
      this.hsbA = new System.Windows.Forms.HScrollBar();
      this.SuspendLayout();
      // 
      // _pnlSample
      // 
      this._pnlSample.BackColor = System.Drawing.Color.Black;
      this._pnlSample.Location = new System.Drawing.Point(135, 12);
      this._pnlSample.Name = "_pnlSample";
      this._pnlSample.Size = new System.Drawing.Size(240, 139);
      this._pnlSample.TabIndex = 1;
      // 
      // hsbR
      // 
      this.hsbR.Location = new System.Drawing.Point(135, 214);
      this.hsbR.Maximum = 255;
      this.hsbR.Name = "hsbR";
      this.hsbR.Size = new System.Drawing.Size(240, 21);
      this.hsbR.TabIndex = 2;
      this.hsbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbR_Scroll);
      // 
      // hsbG
      // 
      this.hsbG.Location = new System.Drawing.Point(135, 250);
      this.hsbG.Maximum = 255;
      this.hsbG.Name = "hsbG";
      this.hsbG.Size = new System.Drawing.Size(240, 21);
      this.hsbG.TabIndex = 2;
      this.hsbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbG_Scroll);
      // 
      // hsbB
      // 
      this.hsbB.Location = new System.Drawing.Point(135, 283);
      this.hsbB.Maximum = 255;
      this.hsbB.Name = "hsbB";
      this.hsbB.Size = new System.Drawing.Size(240, 21);
      this.hsbB.TabIndex = 2;
      this.hsbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbB_Scroll);
      // 
      // hsbA
      // 
      this.hsbA.Location = new System.Drawing.Point(135, 179);
      this.hsbA.Maximum = 255;
      this.hsbA.Name = "hsbA";
      this.hsbA.Size = new System.Drawing.Size(240, 21);
      this.hsbA.TabIndex = 2;
      this.hsbA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbA_Scroll);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(455, 329);
      this.Controls.Add(this.hsbB);
      this.Controls.Add(this.hsbG);
      this.Controls.Add(this.hsbA);
      this.Controls.Add(this.hsbR);
      this.Controls.Add(this._pnlSample);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel _pnlSample;
    private System.Windows.Forms.HScrollBar hsbR;
    private System.Windows.Forms.HScrollBar hsbG;
    private System.Windows.Forms.HScrollBar hsbB;
    private System.Windows.Forms.HScrollBar hsbA;
  }
}

