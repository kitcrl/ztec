using System;

namespace nAppMon
{
  public partial class FrmASCTransRep : FrmCmd
  {
    public int MAX = 3;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRANS-REP");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Completion Type");
      lstvCmds.InsertText(1, 1, "1");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Equip Type.");
      lstvCmds.InsertText(2, 1, "P");
      lstvCmds.InsertText(2, 2, "1");

      lstvCmds.InsertText(3, 0, "Completion Pt Type.");
      lstvCmds.InsertText(3, 1, "STN");
      lstvCmds.InsertText(3, 2, "3");

      lstvCmds.InsertText(4, 0, "Completion Pt No.");
      lstvCmds.InsertText(4, 1, "00000001");
      lstvCmds.InsertText(4, 2, "8");

      lstvCmds.InsertText(5, 0, "Transport Command Data No.");
      lstvCmds.InsertText(5, 1, "00000001");
      lstvCmds.InsertText(5, 2, "8");

      lstvCmds.InsertText(6, 0, "Error Code");
      lstvCmds.InsertText(6, 1, "0000");
      lstvCmds.InsertText(6, 2, "4");

      lstvCmds.InsertText(7, 0, "AGV No.");
      lstvCmds.InsertText(7, 1, "01");
      lstvCmds.InsertText(7, 2, "2");
    }
  }
}
