using System;

namespace nAppMon
{
  public partial class FrmASCTrnanRep : FrmCmd
  {
    public int MAX = 3;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRNAN-REP");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Assigned Data No.");
      lstvCmds.InsertText(1, 1, "00000001");
      lstvCmds.InsertText(1, 2, "8");

      lstvCmds.InsertText(2, 0, "AGV No.");
      lstvCmds.InsertText(2, 1, "01");
      lstvCmds.InsertText(2, 2, "2");
    }
  }
}
