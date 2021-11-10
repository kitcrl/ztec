using System;

namespace nAppMon
{
  public partial class FrmASCEqus1Rep : FrmCmd
  {
    public int MAX = 10;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "EQUS1-REP");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "AGV");
      lstvCmds.InsertText(1, 2, "3");

      lstvCmds.InsertText(2, 0, "AGV No.");
      lstvCmds.InsertText(2, 1, "01");
      lstvCmds.InsertText(2, 2, "2");

      lstvCmds.InsertText(3, 0, "Curr Pt No.");
      lstvCmds.InsertText(3, 1, "3001");
      lstvCmds.InsertText(3, 2, "4");

      lstvCmds.InsertText(4, 0, "Op Mode");
      lstvCmds.InsertText(4, 1, "0");
      lstvCmds.InsertText(4, 2, "1");

      lstvCmds.InsertText(5, 0, "Error Code");
      lstvCmds.InsertText(5, 1, "0000");
      lstvCmds.InsertText(5, 2, "4");

      lstvCmds.InsertText(6, 0, "System Mode");
      lstvCmds.InsertText(6, 1, "0000");
      lstvCmds.InsertText(6, 2, "4");

      lstvCmds.InsertText(7, 0, "Loader Status");
      lstvCmds.InsertText(7, 1, "0000");
      lstvCmds.InsertText(7, 2, "4");

      lstvCmds.InsertText(8, 0, "Spare 1");
      lstvCmds.InsertText(8, 1, "0000");
      lstvCmds.InsertText(8, 2, "4");

      lstvCmds.InsertText(9, 0, "Spare 2");
      lstvCmds.InsertText(9, 1, "0000");
      lstvCmds.InsertText(9, 2, "4");
    }
  }
}
