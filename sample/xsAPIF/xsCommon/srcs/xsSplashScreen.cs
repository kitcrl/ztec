using System;
using System.Collections.Generic;
using System.Text;

namespace kr.asef.net.apif.Common
{
  public static class CxsSplashScreen
  {
    static CxsSplashScreenForm sf = null;
    static string _simg = null;
    static string _smsg = null;
    /// <summary>
    /// Displays the splashscreen
    /// </summary>
    public static void ShowSplashScreen()
    {
      if (sf == null)
      {
        sf = new CxsSplashScreenForm();
        if ( _simg != null )
        {
          sf.picBack.BackgroundImage = null;
          sf.picBack.Load(_simg);
          sf.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        }
        if ( _smsg != null )
        {
          sf.lblMsg.Text = _smsg;        
        }
        sf.ShowSplashScreen();
      }
    }

    /// <summary>
    /// Closes the SplashScreen
    /// </summary>
    public static void CloseSplashScreen()
    {
      if (sf != null)
      {
        sf.CloseSplashScreen();
        sf = null;
      }
    }

    public static void StartSplash(System.Windows.Forms.Form prnt, string splash_image, string splash_msg)
    {
      prnt.Hide();
      if ( splash_image != null ) _simg = splash_image;
      if ( splash_msg   != null ) _smsg = splash_msg;

      System.Threading.Thread splashthread = new System.Threading.Thread(new System.Threading.ThreadStart(ShowSplashScreen));
      splashthread.IsBackground = true;
      splashthread.Start();
    }


  }
}
