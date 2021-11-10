using System;

namespace nAppMon
{
  public partial class FrmCmdTrCH : FrmCmd
  {

    public int MAX = 7;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRNCH-CMD");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Tr Cmd Dat No.");
      lstvCmds.InsertText(2, 1, "00000001");
      lstvCmds.InsertText(2, 2, "8");

      lstvCmds.InsertText(3, 0, "Error Type");
      lstvCmds.InsertText(3, 1, "0");
      lstvCmds.InsertText(3, 2, "1");

      lstvCmds.InsertText(4, 0, "TO Point Type");
      lstvCmds.InsertText(4, 1, "STN");
      lstvCmds.InsertText(4, 2, "3");

      lstvCmds.InsertText(5, 0, "TO Point No.");
      lstvCmds.InsertText(5, 1, "000000001");
      lstvCmds.InsertText(5, 2, "8");

      lstvCmds.InsertText(6, 0, "Pallet Size");
      lstvCmds.InsertText(6, 1, "1");
      lstvCmds.InsertText(6, 2, "1");

    }
  }
}
