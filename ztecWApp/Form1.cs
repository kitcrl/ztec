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
    ztSample sample = new ztSample();

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
      this.sample.Value = 100;
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


    //  "AF"   ->   'A' 'F'  ->    0xA<<4  |  0xF
    private bool converToHex(string s, out byte r)
    {
      int i = 0;
      byte[] a = new byte[2];
      byte[] arr = new byte[s.Length];

      r = 0;
      if (s.Length <= 1) return false;

      arr = Encoding.ASCII.GetBytes(s);

      for (i = 0; i < 2; i++)
      {
        if (arr[i] >= '0' && arr[i] <= '9')
        {
          a[i] = (byte)(arr[i] - '0');
        }
        else if (arr[i] >= 'A' && arr[i] <= 'Z')
        {
          a[i] = (byte)(arr[i] - 'A' + 10);
        }
        else if (arr[0] >= 'a' && arr[0] <= 'z')
        {
          a[i] = (byte)(arr[i] - 'a' + 10);
        }
      }

      r = (byte)(a[0] << 4 | a[1]);
      return true;
    }

    private void _txtA_TextChanged(object sender, EventArgs e)
    {
      byte a;
      if (converToHex(_txtA.Text, out a))
      {
        this.hsbA.Value = a;
        this.hsbA.Update();
        ARGB[0] = (byte)hsbA.Value;
        onChangeColor();
      }
    }

    private void _txtR_TextChanged(object sender, EventArgs e)
    {
      byte a;
      if (converToHex(_txtR.Text, out a))
      {
        this.hsbR.Value = a;
        this.hsbR.Update();
        ARGB[1] = (byte)hsbR.Value;
        onChangeColor();
      }
    }

    private void _txtG_TextChanged(object sender, EventArgs e)
    {
      byte a;
      if (converToHex(_txtG.Text, out a))
      {
        this.hsbG.Value = a;
        this.hsbG.Update();
        ARGB[2] = (byte)hsbG.Value;
        onChangeColor();
      }
    }

    private void _txtB_TextChanged(object sender, EventArgs e)
    {
      byte a;
      if (converToHex(_txtB.Text, out a))
      {
        this.hsbB.Value = a;
        this.hsbB.Update();
        ARGB[3] = (byte)hsbB.Value;
        onChangeColor();
      }
    }


  }
}
