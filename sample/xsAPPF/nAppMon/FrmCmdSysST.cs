using System;

namespace nAppMon
{
  public partial class FrmCmdSysST : FrmCmd
  {

    public int MAX = 1;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "SYSST-CMD");
      lstvCmds.InsertText(0, 2, "9");
    }
  }
}
