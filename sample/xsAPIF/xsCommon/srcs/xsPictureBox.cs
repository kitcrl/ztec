using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace kr.asef.net.apif.Common
{
  public class CxsPictureBox : PictureBox
  {
    public CxsPictureBox()
    {
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
      this.UpdateStyles();
    }


  }
}
