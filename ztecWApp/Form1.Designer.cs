
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
      this._txtA = new System.Windows.Forms.TextBox();
      this._txtR = new System.Windows.Forms.TextBox();
      this._txtG = new System.Windows.Forms.TextBox();
      this._txtB = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // _pnlSample
      // 
      this._pnlSample.BackColor = System.Drawing.Color.Black;
      this._pnlSample.Location = new System.Drawing.Point(12, 12);
      this._pnlSample.Name = "_pnlSample";
      this._pnlSample.Size = new System.Drawing.Size(431, 164);
      this._pnlSample.TabIndex = 1;
      // 
      // hsbR
      // 
      this.hsbR.Location = new System.Drawing.Point(12, 224);
      this.hsbR.Maximum = 255;
      this.hsbR.Name = "hsbR";
      this.hsbR.Size = new System.Drawing.Size(328, 21);
      this.hsbR.TabIndex = 2;
      this.hsbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbR_Scroll);
      // 
      // hsbG
      // 
      this.hsbG.Location = new System.Drawing.Point(12, 260);
      this.hsbG.Maximum = 255;
      this.hsbG.Name = "hsbG";
      this.hsbG.Size = new System.Drawing.Size(328, 21);
      this.hsbG.TabIndex = 2;
      this.hsbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbG_Scroll);
      // 
      // hsbB
      // 
      this.hsbB.Location = new System.Drawing.Point(12, 293);
      this.hsbB.Maximum = 255;
      this.hsbB.Name = "hsbB";
      this.hsbB.Size = new System.Drawing.Size(328, 21);
      this.hsbB.TabIndex = 2;
      this.hsbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbB_Scroll);
      // 
      // hsbA
      // 
      this.hsbA.LargeChange = 1;
      this.hsbA.Location = new System.Drawing.Point(12, 191);
      this.hsbA.Maximum = 255;
      this.hsbA.Name = "hsbA";
      this.hsbA.Size = new System.Drawing.Size(328, 21);
      this.hsbA.SmallChange = 0;
      this.hsbA.TabIndex = 2;
      this.hsbA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbA_Scroll);
      // 
      // _txtA
      // 
      this._txtA.Location = new System.Drawing.Point(343, 192);
      this._txtA.Name = "_txtA";
      this._txtA.Size = new System.Drawing.Size(100, 20);
      this._txtA.TabIndex = 3;
      this._txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this._txtA.TextChanged += new System.EventHandler(this._txtA_TextChanged);
      // 
      // _txtR
      // 
      this._txtR.Location = new System.Drawing.Point(343, 224);
      this._txtR.Name = "_txtR";
      this._txtR.Size = new System.Drawing.Size(100, 20);
      this._txtR.TabIndex = 3;
      this._txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this._txtR.TextChanged += new System.EventHandler(this._txtR_TextChanged);
      // 
      // _txtG
      // 
      this._txtG.Location = new System.Drawing.Point(343, 260);
      this._txtG.Name = "_txtG";
      this._txtG.Size = new System.Drawing.Size(100, 20);
      this._txtG.TabIndex = 3;
      this._txtG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this._txtG.TextChanged += new System.EventHandler(this._txtG_TextChanged);
      // 
      // _txtB
      // 
      this._txtB.Location = new System.Drawing.Point(343, 293);
      this._txtB.Name = "_txtB";
      this._txtB.Size = new System.Drawing.Size(100, 20);
      this._txtB.TabIndex = 3;
      this._txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this._txtB.TextChanged += new System.EventHandler(this._txtB_TextChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(465, 326);
      this.Controls.Add(this._txtB);
      this.Controls.Add(this._txtG);
      this.Controls.Add(this._txtR);
      this.Controls.Add(this._txtA);
      this.Controls.Add(this.hsbB);
      this.Controls.Add(this.hsbG);
      this.Controls.Add(this.hsbA);
      this.Controls.Add(this.hsbR);
      this.Controls.Add(this._pnlSample);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel _pnlSample;
    private System.Windows.Forms.HScrollBar hsbR;
    private System.Windows.Forms.HScrollBar hsbG;
    private System.Windows.Forms.HScrollBar hsbB;
    private System.Windows.Forms.HScrollBar hsbA;
    private System.Windows.Forms.TextBox _txtA;
    private System.Windows.Forms.TextBox _txtR;
    private System.Windows.Forms.TextBox _txtG;
    private System.Windows.Forms.TextBox _txtB;
  }
}

