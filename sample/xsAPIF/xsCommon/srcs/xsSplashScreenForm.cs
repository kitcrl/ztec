using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kr.asef.net.apif.Common
{
  public partial class CxsSplashScreenForm : Form
  {
    delegate void SplashShowCloseDelegate();

    //  static xsSplashScreenForm sf = null;
    bool CloseSplashScreenFlag = false;

    public CxsSplashScreenForm()
    {
      InitializeComponent();
    }

    public void ShowSplashScreen()
    {
      if (InvokeRequired)
      {
        // We're not in the UI thread, so we need to call BeginInvoke
        BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
        return;
      }
      this.Show();
      Application.Run(this);
    }


    public void CloseSplashScreen()
    {
      if (InvokeRequired)
      {
        // We're not in the UI thread, so we need to call BeginInvoke
        BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
        return;
      }
      CloseSplashScreenFlag = true;
      this.Close();
    }

    private void xsSplashScreenForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (CloseSplashScreenFlag == false)
        e.Cancel = true;
    }
  }
}
