using System;

namespace nAppMon
{
  public partial class FrmASCTrnchAns : FrmCmd
  {
    public int MAX = 4;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRNCH-ANS");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Trans Cmd Data No.");
      lstvCmds.InsertText(2, 1, "00000001");
      lstvCmds.InsertText(2, 2, "8");

      lstvCmds.InsertText(3, 0, "Dest Change Result");
      lstvCmds.InsertText(3, 1, "OK");
      lstvCmds.InsertText(3, 2, "2");
    }
  }
}
