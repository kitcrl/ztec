using System;

namespace nAppMon
{
  public partial class FrmASCThrouRep : FrmCmd
  {
    public int MAX = 8;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "THROU-REP");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Pass Pt Type");
      lstvCmds.InsertText(2, 1, "STN");
      lstvCmds.InsertText(2, 2, "3");

      lstvCmds.InsertText(3, 0, "Pass Pt No.");
      lstvCmds.InsertText(3, 1, "00000001");
      lstvCmds.InsertText(3, 2, "8");

      lstvCmds.InsertText(4, 0, "Final Dest Pt Type");
      lstvCmds.InsertText(4, 1, "STN");
      lstvCmds.InsertText(4, 2, "3");

      lstvCmds.InsertText(5, 0, "Final Dest Pt No.");
      lstvCmds.InsertText(5, 1, "00000001");
      lstvCmds.InsertText(5, 2, "8");

      lstvCmds.InsertText(6, 0, "Pass Transport Data No.");
      lstvCmds.InsertText(6, 1, "00000001");
      lstvCmds.InsertText(6, 2, "8");

      lstvCmds.InsertText(7, 0, "AGV No.");
      lstvCmds.InsertText(7, 1, "01");
      lstvCmds.InsertText(7, 2, "2");
    }
  }
}
