using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using kr.asef.net.apif.xsAXIF;

namespace xsAppMon
{

  unsafe public partial class xsAppMon : Form
  {


    //string ip = "10.5.164.230";
    string ip = "127.0.0.1";
    string port = "2654";
    string systype = "CLIENT";
    string protocol = "TCP";
    string casttype = "UNICAST";

    byte[] _ip = new byte[32];
    byte[] _port = new byte[32];
    byte[] _systype = new byte[32];
    byte[] _protocol = new byte[32];
    byte[] _casttype = new byte[32];


    public xsAppMon()
    {
      InitializeComponent();
      LocalInit();
    }


    public void LocalInit()
    {
      cvt = new kr.asef.net.apif.Common.CxsConverter();
      sock = new kr.asef.net.apif.xsAXIF.socket.xsSocket();

      this.cbType.Items.Add("bit");
      this.cbType.Items.Add("Byte");
      this.cbType.Items.Add("Word");
      this.cbType.Items.Add("iNteger");
      this.cbType.SelectedIndex = 1;
      this.cbType.DropDownStyle = ComboBoxStyle.DropDown;

      //dlgtSerial = new DlgtCallbackProcSerial(OnRead);
      dlgtConnStatus = new kr.asef.net.apif.xsAXIF.socket.xsSocket.DlgtOnConnStatus(OnConnStatusCallbackProc);
      dlgtRecv       = new kr.asef.net.apif.xsAXIF.socket.xsSocket.DlgtOnRecv(OnRecvCallbackProc);
      dlgtCallbackProc = new DlgtCallbackProc(OnCallbackProc);
    }

    private void OnCallbackProc(byte[] packet, int len)
    {
      int e = 0;

      this.txtLog.AppendText(string.Format("{0:d} {1}\n", len, cvt.BytesToString(packet, packet.Length)));

      return;
      //dlgtSerial.BeginInvoke(packet, len, null, null);
    }

    private int OnRecvCallbackProc(int id, int sd, char * buf, int len, void * cbo)
    {
      int e = 0;

      string msg = new string(buf, 0, len);


      this.BeginInvoke(dlgtCallbackProc, cvt.StringToBytes(msg), len);
      //dlgtSerial.BeginInvoke(packet, len, null, null);
      return e;
    }

    private int OnConnStatusCallbackProc(int id, int sd, char * ip, int port, int ecode, void * cbo)
    {
      int e = 0;

      string msg;

      if ( ecode == 0 )
      {
        msg = "CONNECTED";
      }
      else
      {
        msg = "CONNFAIL";
      }

      msg = sock.ConnectionStatus(id, ecode);



      this.BeginInvoke(dlgtCallbackProc, cvt.StringToBytes(msg), ecode);
      //dlgtSerial.BeginInvoke(packet, len, null, null);
      return e;
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      string val = btnOpen.Text;
      if ( val == "Open" )
      {
        btnOpen.Text = "Close";
        int key = int.Parse(txtKey.Text);
        int size = int.Parse(txtSize.Text);
        string type = this.cbType.SelectedText;
        byte [] _type = new byte[16];
        _type = cvt.StringToBytes(type);
      }
      else
      {
        btnOpen.Text = "Open";
      }
    }

    private void btnWrite_Click(object sender, EventArgs e)
    {
      int offset = int.Parse(txtOffset.Text);
      int len = txtWrite.Text.Length;
      byte [] msg = new byte[len];
      msg = cvt.StringToBytes(txtWrite.Text);
      byte [] mode = new byte[16];
      string type = "";

      //if ( this.cbType.SelectedText == "" ) type = "Byte";
      //else type = this.cbType.SelectedText;

      type = this.cbType.Items[this.cbType.SelectedIndex].ToString();

      mode = cvt.StringToBytes(type);
      if (mode[0] == 'i') mode[0] = (byte)'N';
    }

    private void btnRead_Click(object sender, EventArgs e)
    {
      int offset = int.Parse(txtOffset.Text);
      int len = int.Parse(txtLen.Text);
      byte[] msg = new byte[len];
      byte[] mode = new byte[16];
      string type = "";

      if ( this.cbType.SelectedText == "" ) type = "Byte";
      else type = this.cbType.SelectedText;

      mode = cvt.StringToBytes(type);
      if ( mode[0] == 'i' ) mode[0] = (byte)'N';

      string ret = cvt.BytesToString(msg, len);
      txtMsg.Text = ret;
    }

    private void btnSerialOpen_Click(object sender, EventArgs e)
    {
    }

    public void OnRead(byte[] msg, int len)
    {
      this.txtSerialRead.Text = cvt.BytesToString(msg, len);
    }

    private void btnSocketOpen_Click(object sender, EventArgs e)
    {
      _ip = cvt.StringToBytes(ip);
      _port = cvt.StringToBytes(port);
      _systype = cvt.StringToBytes(systype);
      _protocol = cvt.StringToBytes(protocol);
      _casttype = cvt.StringToBytes(casttype);

      sock.Create(0,1);
      sock.SetCBConnStatus(0, dlgtConnStatus, (IntPtr)null);
      sock.SetCBRecv(0, dlgtRecv, (IntPtr)null);
      sock.Open(0, _ip, _port, _systype, _protocol, _casttype, null);
    }


    
    private void DoConnTest()
    {
      //// OPEN & CLOSE TEST
      int i = 0;
      for (; ; )
      {
        if (i % 2 == 0)
        {
          i = 1;
          sock.Close(0);
        }
        else
        {
          i = 0;
          sock.Open(0, _ip, _port, _systype, _protocol, _casttype, null);
        }
        System.Threading.Thread.Sleep(300);
      }
    }

    private void btnTest01_Click(object sender, EventArgs e)
    {
      System.Threading.Thread thr = null;

      thr = new System.Threading.Thread(DoConnTest);
      thr.Start();

    }


    private void DoSendTest()
    {
      int e = 0;
      int i = 0;
      byte[] buf = new byte[39];
      byte[] buf2 = new byte[46];

      buf[i] = 0x02; i++;
      buf[i] = 0x20; i++;
      buf[i] = 0x20; i++;
      buf[i] = 0x20; i++;
      buf[i] = 0x20; i++;
      buf[i] = 0x20; i++;
      buf[i] = 0x32; i++;
      buf[i] = 0x30; i++;
      buf[i] = 0x31; i++;
      buf[i] = 0x32; i++;

      buf[i] = 0x30; i++;
      buf[i] = 0x39; i++;
      buf[i] = 0x31; i++;
      buf[i] = 0x33; i++;
      buf[i] = 0x31; i++;
      buf[i] = 0x35; i++;
      buf[i] = 0x34; i++;
      buf[i] = 0x35; i++;
      buf[i] = 0x34; i++;
      buf[i] = 0x38; i++;

      buf[i] = 0x52; i++;
      buf[i] = 0x44; i++;
      buf[i] = 0x31; i++;
      buf[i] = 0x53; i++;
      buf[i] = 0x55; i++;
      buf[i] = 0x32; i++;
      buf[i] = 0x35; i++;
      buf[i] = 0x35; i++;
      buf[i] = 0x32; i++;
      buf[i] = 0x35; i++;

      buf[i] = 0x35; i++;
      buf[i] = 0x43; i++;
      buf[i] = 0x30; i++;
      buf[i] = 0x30; i++;
      buf[i] = 0x30; i++;
      buf[i] = 0x32; i++;
      buf[i] = 0x38; i++;
      buf[i] = 0x32; i++;
      buf[i] = 0x03; i++;

      i = 0;
      buf2[i] = 0x02; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x32; i++;
      buf2[i] = 0x30; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x32; i++;
      buf2[i] = 0x30; i++;
      buf2[i] = 0x39; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x33; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x35; i++;
      buf2[i] = 0x34; i++;
      buf2[i] = 0x35; i++;
      buf2[i] = 0x34; i++;
      buf2[i] = 0x39; i++;
      buf2[i] = 0x54; i++;
      buf2[i] = 0x4A; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x20; i++;
      buf2[i] = 0x32; i++;
      buf2[i] = 0x30; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x32; i++;
      buf2[i] = 0x30; i++;
      buf2[i] = 0x39; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x33; i++;
      buf2[i] = 0x31; i++;
      buf2[i] = 0x35; i++;
      buf2[i] = 0x34; i++;
      buf2[i] = 0x35; i++;
      buf2[i] = 0x34; i++;
      buf2[i] = 0x39; i++;
      buf2[i] = 0x52; i++;
      buf2[i] = 0x44; i++;
      buf2[i] = 0x39; i++;
      buf2[i] = 0x03; i++;

      i = 0;
      for (; ; )
      {
        if (i % 2 == 0)
        {
          i = 1;
          e = sock.Send(0, 0, buf, 39, 4000);
        }
        else
        {
          i = 0;
          e = sock.Send(0, 0, buf2, 46, 4000);
          System.Threading.Thread.Sleep(1);
        }
      }

    }

    private void button2_Click(object sender, EventArgs e)
    {
      //// SEND
      System.Threading.Thread thr = null;

      thr = new System.Threading.Thread(DoSendTest);
      thr.Start();


    }
  }
}
