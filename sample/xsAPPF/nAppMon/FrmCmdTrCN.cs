using System;

namespace nAppMon
{
  public partial class FrmCmdTrCN : FrmCmd
  {

    public int MAX = 6;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRNCN-CMD");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Cancel Point Type");
      lstvCmds.InsertText(2, 1, "STN");
      lstvCmds.InsertText(2, 2, "3");

      lstvCmds.InsertText(3, 0, "Cancel Point No");
      lstvCmds.InsertText(3, 1, "00000000");
      lstvCmds.InsertText(3, 2, "8");

      lstvCmds.InsertText(4, 0, "Cancel Transport Data No");
      lstvCmds.InsertText(4, 1, "00000000");
      lstvCmds.InsertText(4, 2, "8");

      lstvCmds.InsertText(5, 0, "Cancel Info");
      lstvCmds.InsertText(5, 1, "");
      lstvCmds.InsertText(5, 2, "20");


    }
  }
}
