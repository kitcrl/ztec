using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace kr.asef.net.apif.Common
{
  public class CxsPanel : Panel
  {
    public CxsPanel()
    {
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
      this.UpdateStyles();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
    }
  }
}
