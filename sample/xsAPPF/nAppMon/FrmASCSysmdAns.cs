using System;

namespace nAppMon
{
  public partial class FrmASCSysmdAns : FrmCmd
  {
    public int MAX = 3;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "SYSMD-ANS");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Mode");
      lstvCmds.InsertText(1, 1, "ON");
      lstvCmds.InsertText(1, 2, "2");

      lstvCmds.InsertText(2, 0, "Control Info");
      lstvCmds.InsertText(2, 1, "");
      lstvCmds.InsertText(2, 2, "20");
    }
  }
}
