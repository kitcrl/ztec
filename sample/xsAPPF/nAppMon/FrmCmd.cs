using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nAppMon
{
  public partial class FrmCmd : Form
  {
    Panel parent;

    public FrmCmd()
    {
      InitializeComponent();
    }

    public void Init(Panel p)
    {
      parent = p;
      this.TopLevel = false;
      this.TopMost = true;
      this.Dock = DockStyle.Fill;
      parent.Controls.Add(this);

      lstvCmds.CreateColumn(3);
      lstvCmds.AddColumnHeader(0, "ITEM", 100);
      lstvCmds.AddColumnHeader(1, "CMD", 100);
      lstvCmds.AddColumnHeader(2, "BYTE", 50);
      lstvCmds.SetEditableRows(1);

      InitVals();
    }

    public virtual void InitVals()
    {
    }

  }
}
