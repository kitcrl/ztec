using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ztecIOWin
{
  public partial class Form1 : Form, INet, IUart
  {

    public delegate Int32 OnCallback(UInt32 type, string msg);

    zTCPd tcpd;
    zSerial serial;
    kr.co.ztec.io.Common common = new kr.co.ztec.io.Common();

    OnCallback onCallback;
    OnCallback onSCallback;
    public Form1()
    {
      InitializeComponent();
      InitComponent();
    }

    public void InitComponent()
    {

      onCallback = new OnCallback(_Callback);
      onSCallback = new OnCallback(_SCallback);

      this.txtIP.Text = "127.0.0.1";      
      this.txtPort.Text = "9000";

      this.cbxCSType.Items.Add("SERVER");
      this.cbxCSType.Items.Add("CLIENT");
      this.cbxCSType.SelectedIndex = 0;
      this.btnOpen.Text = "Open";
      this.btnWrite.Text = "Write";

      this.lvRead.CreateColumn(2);
      this.lvRead.ColumnHeaderText(0, "no", 30);
      this.lvRead.ColumnHeaderText(1, "log", 600);

      this.txtSPort.Text = "COM3";
      this.txtSBaudrate.Text = "115200";
      this.btnSOpen.Text = "Open";
      this.btnSWrite.Text = "Write";

      this.lvSRead.CreateColumn(2);
      this.lvSRead.ColumnHeaderText(0, "no", 30);
      this.lvSRead.ColumnHeaderText(1, "log", 600);


      tcpd = new zTCPd(this);
      serial = new zSerial(this);
    }

    public int OnRead(int fd, byte[] b, int sz, UInt32 err)
    {
      return 0;
    }

    public int OnStatus(int fd, byte[] b, int sz, UInt32 err)
    {
      string item = string.Format("Status {0:d04} {1:d4} {2:X08}\r\n", fd, sz, err);

      if (err != 0xE000FDAB && err != 0xE000FDAA)
      {
        this.Invoke(onCallback, (UInt32)0, item);
      }
      return 0;
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      if (this.btnOpen.Text == "Open")
      {
        tcpd.Open(txtPort.Text, (string)cbxCSType.SelectedItem);
        if (tcpd.fd > 0)
        {
          this.btnOpen.Text = "Close";
        }
      }
      else
      {
        tcpd.Close();
        this.btnOpen.Text = "Open";
      }
    }
    public Int32 _Callback(UInt32 type, string msg)
    {
      if (type == 0)
      {
        this.lvRead.InsertText(msg);
      }
      return 0;
    }

    public int OnRead(byte[] b, int sz)
    {
      
      this.Invoke(onSCallback, (UInt32)0, ByteString(b, sz));

      return 0;
    }

    public Int32 _SCallback(UInt32 type, string msg)
    {
      this.lvSRead.InsertText(msg);
      return 0;
    }



    public string ByteString(byte[] b, int sz)
    {
      string item = "";
      int i = 0;

      for (i = 0; i < sz; i++)
      {
        item += string.Format("{0:02X} ", b[i]);
      }
      return item;
    }

    private void btnSOpen_Click(object sender, EventArgs e)
    {
      if (this.btnSOpen.Text == "Open")
      {
        if (serial.Open(this.txtSPort.Text, this.txtSBaudrate.Text) > 0)
        {
          this.btnSOpen.Text = "Close";
        }
      }
      else
      {
        serial.Close();
        this.btnSOpen.Text = "Open";
      }
    }

    private void btnSWrite_Click(object sender, EventArgs e)
    {
      string sim = this.txtSWrite.Text;
      byte[] _sim = new byte[sim.Length];
      byte[] _out = new byte[sim.Length];
      string __out = "";
      _sim = System.Text.Encoding.UTF8.GetBytes(sim);

      common.HexSim(_sim, _out);

      __out = System.Text.Encoding.UTF8.GetString(_out);

      this.Invoke(onSCallback, (UInt32)0, __out);


    }
  }
}
