using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ztecWApp
{
  public partial class Form1 : Form
  {
    byte[] ARGB = new byte[4];
    public Form1()
    {
      InitializeComponent();
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
      this.UpdateStyles();

      ARGB[0] = 0;
      ARGB[1] = 0;
      ARGB[2] = 0;
      ARGB[3] = 0;

      onChangeColor();
    }

    private void onChangeColor()
    {
      this._pnlSample.BackColor = System.Drawing.Color.FromArgb(ARGB[0], ARGB[1], ARGB[2], ARGB[3]);
    }

    private void hsbR_Scroll(object sender, ScrollEventArgs e)
    {
      ARGB[1] = (byte)hsbR.Value;
      _txtR.Text = String.Format("{0:X02}", ARGB[1]);
      onChangeColor();
    }

    private void hsbG_Scroll(object sender, ScrollEventArgs e)
    {
      ARGB[2] = (byte)hsbG.Value;
      _txtG.Text = String.Format("{0:X02}", ARGB[2]);
      onChangeColor();
    }

    private void hsbB_Scroll(object sender, ScrollEventArgs e)
    {
      ARGB[3] = (byte)hsbB.Value;
      _txtB.Text = String.Format("{0:X02}", ARGB[3]);
      onChangeColor();
    }

    private void hsbA_Scroll(object sender, ScrollEventArgs e)
    {
      ARGB[0] = (byte)hsbA.Value;
      _txtA.Text = String.Format("{0:X02}", ARGB[0]);
      onChangeColor();
    }

    private void _txtA_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
