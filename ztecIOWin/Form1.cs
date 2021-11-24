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
  public partial class Form1 : Form, INet
  {

    public delegate Int32 OnCallback(UInt32 type, string msg);

    zTCPd tcpd;
    OnCallback onCallback;
    public Form1()
    {
      InitializeComponent();
      InitComponent();
    }

    public void InitComponent()
    {

      onCallback = new OnCallback(_Callback);

      this.txtPort.Text = "9000";

      this.cbxCSType.Items.Add("SERVER");
      this.cbxCSType.Items.Add("CLIENT");
      this.cbxCSType.SelectedIndex = 0;
      this.btnOpen.Text = "Open";


      this.lvRead.CreateColumn(2);
      this.lvRead.ColumnHeaderText(0, "no", 30);
      this.lvRead.ColumnHeaderText(1, "log", 600);

      tcpd = new zTCPd(this);
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
      tcpd.Open(txtPort.Text, (string)cbxCSType.SelectedItem);
      if (tcpd.fd > 0)
      {
        this.btnOpen.Text = "Close";
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

  }
}
