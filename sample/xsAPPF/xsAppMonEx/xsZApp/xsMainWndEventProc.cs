using System;
using System.Collections.Generic;
using System.Text;

namespace xsAppMonEx.xsZApp
{
  public partial class xsMainWndEventProc
  {
    public xsMainWndEventProc()
    {
      evt += new DlgtMainProc(MainProc);
    }


    public void OnEvent(int evt, int wparam, int lparam, object arg)
    {
      MainProc(evt, wparam, lparam, arg);
      System.Diagnostics.Debug.Print("OnEvent\r\n");
    }

    private void MainProc(int evt, int wparam, int lparam, object arg)
    {

    }
  }
}
