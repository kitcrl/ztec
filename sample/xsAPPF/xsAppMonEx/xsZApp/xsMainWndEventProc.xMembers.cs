using System;
using System.Collections.Generic;
using System.Text;

namespace xsAppMonEx.xsZApp
{
  public partial class xsMainWndEventProc
  {
    public delegate void DlgtMainProc(int evt, int wparam, int lparam, object arg);
    public event DlgtMainProc evt;
  }
}
