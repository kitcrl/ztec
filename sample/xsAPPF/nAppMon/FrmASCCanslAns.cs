using System;

namespace nAppMon
{
  public partial class FrmASCCanslAns : FrmCmd
  {
    public int MAX = 8;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "CANSL-ANS");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");


      lstvCmds.InsertText(2, 0, "Cancel Pt Type");
      lstvCmds.InsertText(2, 1, "STN");
      lstvCmds.InsertText(2, 2, "3");

      lstvCmds.InsertText(3, 0, "Cancel Pt No.");
      lstvCmds.InsertText(3, 1, "00000000");
      lstvCmds.InsertText(3, 2, "8");

      lstvCmds.InsertText(4, 0, "Trans Pt No.");
      lstvCmds.InsertText(4, 1, "00000001");
      lstvCmds.InsertText(4, 2, "8");

      lstvCmds.InsertText(5, 0, "Cancel Result");
      lstvCmds.InsertText(5, 1, "OK");
      lstvCmds.InsertText(5, 2, "2");

      lstvCmds.InsertText(6, 0, "Cancel Type");
      lstvCmds.InsertText(6, 1, "1");
      lstvCmds.InsertText(6, 2, "1");

      lstvCmds.InsertText(7, 0, "Control Info");
      lstvCmds.InsertText(7, 1, "");
      lstvCmds.InsertText(7, 2, "20");
    }
  }
}
