using System;

namespace nAppMon
{
  public partial class FrmASCSyserRep : FrmCmd
  {
    public int MAX = 10;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "SYSER-REP");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Error Code");
      lstvCmds.InsertText(1, 1, "00");
      lstvCmds.InsertText(1, 2, "2");
    }
  }
}
