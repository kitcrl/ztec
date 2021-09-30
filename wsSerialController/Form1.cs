using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsSerialController
{
  public partial class Form1 : Form
  {
    kr.co.ztec.Serial.ztecSerialPort m_serial;
    public Form1()
    {
      InitializeComponent();
      InitComponent();
    }

    public void InitComponent()
    {
      m_btnOpenClose.Text = "OPEN";
      m_btnWrite.Text = "WRITE";
      m_btnClear.Text = "CLEAR";

      m_txtComPort.Text = "COM3";
      m_txtBaudRate.Text = "115200";
      m_txtDataBit.Text = "8";

      m_cbxStopBit.Items.Add("0");
      m_cbxStopBit.Items.Add("1");
      m_cbxStopBit.SelectedIndex = 0;

      m_cbxFlowControl.Items.Add("NONE");
      m_cbxFlowControl.Items.Add("EVEN");
      m_cbxFlowControl.Items.Add("ODD");
      m_cbxFlowControl.SelectedIndex = 0;

      m_serial = new kr.co.ztec.Serial.ztecSerialPort();
    }

    private void m_btnOpenClose_Click(object sender, EventArgs e)
    {
      Int32 ecode = 0;
      if (m_btnOpenClose.Text == "OPEN")
      {
        ecode = m_serial.Open(m_txtComPort.Text,
                              m_txtBaudRate.Text,
                              m_txtDataBit.Text,
                              (string)m_cbxStopBit.SelectedItem,
                              (string)m_cbxFlowControl.SelectedItem);
        if (ecode > 0)
        {
          m_btnOpenClose.Text = "CLOSE";
        }
      }
      else
      {
        ecode = m_serial.Close();
        if (ecode > 0)
        {
          m_btnOpenClose.Text = "OPEN";
        }
      }
    }
  }
}
