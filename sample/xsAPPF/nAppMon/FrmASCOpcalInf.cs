using System;

namespace nAppMon
{
  public partial class FrmASCOpcalInf : FrmCmd
  {
    public int MAX = 3;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "OPCAL-INF");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Msg Level");
      lstvCmds.InsertText(1, 1, "T");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Msg Contents");
      lstvCmds.InsertText(2, 1, "");
      lstvCmds.InsertText(2, 2, "100");
    }
  }
}
