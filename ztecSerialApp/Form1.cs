using kr.co.ztec.io;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ztecSerialApp
{
  public partial class Form1 : Form, kr.co.ztec.io.ISerial, kr.co.ztec.io.ISocket
  {

    kr.co.ztec.io.Serial _serial;
    kr.co.ztec.io.Socket _socket;

    public Form1()
    {
      InitializeComponent();
      InitComponent();
    }

    public void InitComponent()
    {
      this.m_btnOpen.Text = "OPEN";
      this.m_btnWrite.Text = "WRITE";
      this.m_btnClear.Text = "CLEAR";

      _serial = new kr.co.ztec.io.Serial(this);


      this.m_btnSocketOpen.Text = "OPEN";
      _socket = new kr.co.ztec.io.Socket(this);
    }
    private void m_btnOpen_Click(object sender, EventArgs e)
    {
      if (this.m_btnOpen.Text == "OPEN")
      {
        if (this._serial.Open(this.m_txtPort.Text, this.m_txtBaud.Text, "8", "1", "0") > 0)
        {
          this.m_btnOpen.Text = "CLOSE";
        }
      }
      else
      {
        if (this._serial.Close() > 0)
        {
          this.m_btnOpen.Text = "OPEN";
        }
      }
    }

    private void m_btnWrite_Click(object sender, EventArgs e)
    {

    }

    private void m_btnClear_Click(object sender, EventArgs e)
    {

    }

    int ISerial.Read(byte[] b, int sz)
    {
      int e = 0;


      return e;
    }

    private void btnSocketOpen_Click(object sender, EventArgs e)
    {
      if (this.m_btnSocketOpen.Text == "OPEN")
      {
        if (this._socket.Open(
                  this.m_txtIP.Text,
                  this.m_txtSocketPort.Text,
                  "SERVER",
                  "TCP",
                  "UNICAST") > 0)
        {
          this.m_btnSocketOpen.Text = "CLOSE";
        }

      }
      else
      {
        this.m_btnSocketOpen.Text = "OPEN";
      }
    }

    public int Read(int fd, byte[] b, int sz, int err)
    {
      throw new NotImplementedException();
    }

    public int Status(int fd, byte[] b, int sz, int err)
    {
      throw new NotImplementedException();
    }
  }
}
