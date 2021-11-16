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
    zTCPd tcpd;
    public Form1()
    {
      InitializeComponent();
      InitComponent();
    }

    public void InitComponent()
    {
      this.txtPort.Text = "9000";

      this.cbxCSType.Items.Add("SERVER");
      this.cbxCSType.Items.Add("CLIENT");
      this.cbxCSType.SelectedIndex = 0;

      this.btnOpen.Text = "Open";
      tcpd = new zTCPd(this);
    }

    public int OnRead(int fd, byte[] b, int sz, int err)
    {
      return 0;
    }

    public int OnStatus(int fd, byte[] b, int sz, int err)
    {
      string item = string.Format("Status {0:d04} {1:d4} {2:X08}\r\n", fd, sz, err);
      //this.lvRead.Items.Add(item);
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
  }
}
