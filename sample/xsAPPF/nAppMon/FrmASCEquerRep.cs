using System;

namespace nAppMon
{
  public partial class FrmASCEquerRep : FrmCmd
  {
    public int MAX = 4;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "EQUER-REP");
      lstvCmds.InsertText(0, 2, "9");

      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "AGV");
      lstvCmds.InsertText(1, 2, "3");

      lstvCmds.InsertText(2, 0, "Equip Info");
      lstvCmds.InsertText(2, 1, "013001");
      lstvCmds.InsertText(2, 2, "6");

      lstvCmds.InsertText(3, 0, "Error Code");
      lstvCmds.InsertText(3, 1, "0000");
      lstvCmds.InsertText(3, 2, "4");
    }
  }
}
