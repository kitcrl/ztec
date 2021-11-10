using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xsAppMonEx
{
  public partial class xsAppMonEx : Form
  {
    public xsAppMonEx()
    {
      InitializeComponent();
      LocalInit();
    }

    private void LocalInit()
    {
      LocalVar_Init();
      GUI_Init();
    }


    private void LocalVar_Init()
    {
      this._mainProc = new xsZApp.xsMainWndEventProc();

      //this._dlgtMainProc = new xsZApp.DlgtMainProc(_mainProc.MainProc);
    }

    private void GUI_Init()
    {
      btnPower.Text = "OFF";
      btnPower.BackColor = Color.FromArgb(0xAA, 0x00, 0x00);
      btnPower.ForeColor = Color.FromArgb(0xAA, 0xAA, 0xAA);
    }



    private void btnPower_Click(object sender, EventArgs e)
    {
      if ( btnPower.Text == "ON" )
      {
        btnPower.Text = "OFF";
        btnPower.BackColor = Color.FromArgb(0xAA, 0x00, 0x00);
        btnPower.ForeColor = Color.FromArgb(0xAA, 0xAA, 0xAA);
      }
      else
      {
        btnPower.Text = "ON";
        btnPower.BackColor = Color.FromArgb(0x00, 0xFF, 0x00);
        btnPower.ForeColor = Color.FromArgb(0xFF, 0xFF, 0xFF);
      }

      _mainProc.OnEvent(0,0,0,null);
    }
  }
}
