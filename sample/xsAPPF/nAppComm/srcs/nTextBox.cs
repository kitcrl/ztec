using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace nAppComm
{
  public class CTextBox : TextBox
  {
    public CTextBox()
    {
    }

    public void Append(string msg)
    {
      this.AppendText(msg + "\r\n");
      this.SelectionStart = this.Text.Length;
      this.ScrollToCaret();
      if ( this.Text.Length > 30000 )
      {
        this.Clear();
      }
    }

  }
}
