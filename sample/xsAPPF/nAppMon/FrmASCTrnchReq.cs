using System;

namespace nAppMon
{
  public partial class FrmASCTrnchReq : FrmCmd
  {
    public int MAX = 9;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRNCH-REQ");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Req Pt Type");
      lstvCmds.InsertText(2, 1, "STN");
      lstvCmds.InsertText(2, 2, "3");

      lstvCmds.InsertText(3, 0, "Req Pt No.");
      lstvCmds.InsertText(3, 1, "00000000");
      lstvCmds.InsertText(3, 2, "8");

      lstvCmds.InsertText(4, 0, "Trans Cmd Data No.");
      lstvCmds.InsertText(4, 1, "00000001");
      lstvCmds.InsertText(4, 2, "8");

      lstvCmds.InsertText(5, 0, "AGV No.");
      lstvCmds.InsertText(5, 1, "00");
      lstvCmds.InsertText(5, 2, "2");

      lstvCmds.InsertText(6, 0, "Req Rsn");
      lstvCmds.InsertText(6, 1, "1");
      lstvCmds.InsertText(6, 2, "1");

      lstvCmds.InsertText(7, 0, "Pallet Size");
      lstvCmds.InsertText(7, 1, "0");
      lstvCmds.InsertText(7, 2, "1");
    }
  }
}
