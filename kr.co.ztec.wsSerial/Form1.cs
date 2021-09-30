using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kr.co.ztec.wsSerial
{
  public delegate void dlgtOnRead(string str);
  public partial class Form1 : Form
  {

    System.Timers.Timer sysTimer = new System.Timers.Timer();
    dlgtOnRead _dlgtOnRead;
    public Form1()
    {
      InitializeComponent();
      _dlgtOnRead = new dlgtOnRead(OnReadCallback);

      serialPort1.Open();
      serialPort1.ReadTimeout =0;
      timer1.Start();

      sysTimer.Interval = 10;
      sysTimer.Elapsed += sysTimer_Elapsed;
      sysTimer.Start();

    }

    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
      serialPort1.Write("Hello World");
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
    }

    private void sysTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs evt)
    {
      int r = 0;
      byte[] rcv = new byte[32];
      string str = null;

      try
      {
        r = serialPort1.Read(rcv, 0, 32);
        str = r + System.Char.ToString(',') + Encoding.Default.GetString(rcv) + "    \r\n";
        System.Diagnostics.Debug.Write(str);
        this.Invoke(_dlgtOnRead, str);
      }
      catch (TimeoutException exp)
      {
      }

    }

    public void OnReadCallback(string str)
    {
      textBox1.Text = str;
    }




  }
}
