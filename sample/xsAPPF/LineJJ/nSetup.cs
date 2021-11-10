using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LineJJ
{

  public delegate void DlgtWindowEvent(int msec);


  public partial class nSetup : Form
  {
    AppMain gMain;

    DlgtWindowEvent dwe;

    class PowerButton
    {
      public Color backColor = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
      public string text = "OFF";
    }

    class NetInfo
    {
      public string ip = "127.0.0.1";
      public string portMaster = "3000";
      public string portSlvae = "3001";
    }

    PowerButton pwrButton = new PowerButton();
    NetInfo netInfo = new NetInfo();

    public nSetup()
    {
      dwe = new DlgtWindowEvent(LocalWindowEvent);
      InitializeComponent();
    }

    public void Open(AppMain m)
    {
      btnPower.Text = pwrButton.text;
      btnPower.BackColor = pwrButton.backColor;
      txtIP.Text = netInfo.ip;
      txtPortMaster.Text = netInfo.portMaster;
      txtPortSlave.Text = netInfo.portSlvae;


      gMain = m;
      //Show();
      try
      {
        ShowDialog();
      }
      catch(Exception exp)
      {

      }
    }

    public void LocalWindowEvent(int msec)
    {
      System.Threading.Thread.Sleep(msec);
      Close();
    }


    private void btnPower_Click(object sender, EventArgs e)
    {
      if ( btnPower.Text == "OFF" )
      {
        pwrButton.text = btnPower.Text = "ON";
        pwrButton.backColor = btnPower.BackColor = Color.FromArgb(0xFF, 0x00, 0xFF, 0x00);
        gMain.DoOpen();
      }
      else
      {
        pwrButton.text = btnPower.Text = "OFF";
        pwrButton.backColor = btnPower.BackColor = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
        gMain.DoClose();
      }
    }

    private void txtIP_TextChanged(object sender, EventArgs e)
    {
      netInfo.ip = txtIP.Text;
    }

    private void txtPortMaster_TextChanged(object sender, EventArgs e)
    {
      netInfo.portMaster = txtPortMaster.Text;
    }

    private void txtPortSlave_TextChanged(object sender, EventArgs e)
    {
      netInfo.portSlvae = txtPortSlave.Text;
    }


  }
}


