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


    zTClient tclient;
    zTCPd tcpd;
    zSerial serial;
    kr.co.ztec.io.Common common = new kr.co.ztec.io.Common();

    OnCallback onCallback;
    OnCallback onSCallback;
    public Form1()
    {
      InitInstance();
      InitializeComponent();
      InitComponent();
    }

    public void InitInstance()
    {
      onCallback = new OnCallback(_Callback);
      onSCallback = new OnCallback(_SCallback);
      tcpd = new zTCPd(this);
      serial = new zSerial(this);
      tclient = new zTClient();
    }

    public void InitComponent()
    {
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


      this.panels = new System.Windows.Forms.Panel[this.tclient.MAX_CLIENT];
      // 
      // panels
      // 
      int i = 0;
      int pX = 12, pY = 170;
      int pofst = 1;
      int w = 10, h = 10;
      for (i = 0; i < tclient.MAX_CLIENT; i++)
      {
        pX = 12 + (pofst + w) * (i);
        this.panels[i] = new System.Windows.Forms.Panel();
        this.panels[i].Location = new System.Drawing.Point(pX, pY);
        //this.panels[i].Name = string.Format("panel{d:03}", i);
        this.panels[i].Size = new System.Drawing.Size(w, h);
        this.panels[i].BackColor = Color.FromArgb(0xFF, 0xFF, 0, 0);
        this.panels[i].MouseHover += new System.EventHandler(this.panels_MouseHover);
      }
      for (i = 0; i < 48; i++)
      {
        this.Controls.Add(this.panels[i]);
      }

    }


    public int DoBroadcasting(byte[] b, int sz)
    {
      int e = 0;
      int i = 0;

      for (i = 0; i < tclient.MAX_CLIENT; i++)
      {
        if (tclient.cinfo[i].fd > 0)
        {
          panels[i].BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF, 0);
          tcpd.Write(tclient.cinfo[i].fd, b, sz);
          panels[i].BackColor = Color.FromArgb(0xFF, 0xFF, 0, 0);
        }
      }
      return e;
    }



    public int OnRead(int fd, byte[] b, int sz, UInt32 err)
    {
      string _b = "";
      if (sz > 0)
      {
        _b = System.Text.Encoding.UTF8.GetString(b);
      }
      string item = "OnRead " + _b;

      //// echo
      //tcpd.Write(fd, b, sz);
      DoBroadcasting(b, sz);
      this.Invoke(onCallback, (UInt32)0, item);
      //onCallback.BeginInvoke((UInt32)0, item, null, null);
      return 0;
    }

    public int OnStatus(int fd, byte[] b, int sz, UInt32 err)
    {
      Int32 idx = 0;
      string _b = "";
      /////   1460:127.0.0.1:11520
      if (sz > 0)
      {
        _b = System.Text.Encoding.UTF8.GetString(b);
      }
      string item = string.Format("Status {0:d04} {1:d4} {2:X08} ", fd, sz, err) + _b;

      if (err != 0xE000FDAB && err != 0xE000FDAA && err != 0xE000101B && err != 0xE000101A)
      {
        if (err == 0xE000FDA0)
        {
          idx = tclient.Set(fd, null, 0);
          if (idx >= 0)
          {
            this.panels[idx].BackColor = Color.FromArgb(0xFF, 0, 0xFF, 0);
          }
        }
        if (err == 0xE000101F)
        {
          idx = tclient.GetIndex(fd);
          if (idx >= 0)
          {
            this.panels[idx].BackColor = Color.FromArgb(0xFF, 0xFF, 0, 0);
            tclient.Reset(fd);
          }
        }
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

    private void panels_MouseHover(object sender, EventArgs e)
    {
      int i = 0;

      for (i = 0; i < tclient.MAX_CLIENT; i++)
      {
        if (this.panels[i] == sender)
        {

        }
      }
    }
  }
}
