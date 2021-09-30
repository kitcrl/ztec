using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kr.co.ztec.wformA
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      m_txtBox.Text = "0";
    }

    private void m_btnOK_Click(object sender, EventArgs e)
    {
      System.Int32 n = System.Int32.Parse(m_txtBox.Text);
      n++;
      m_txtBox.Text = Convert.ToString(n);
    }

    private void m_btnOK_MouseDown(object sender, MouseEventArgs e)
    {

    }

    private void m_btnOK_MouseUp(object sender, MouseEventArgs e)
    {

    }
  }
}
