using System;

namespace nAppMon
{
  public partial class FrmCmdDatTM : FrmCmd
  {

    public int MAX = 3;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "DATTM-CMD");
      lstvCmds.InsertText(0, 2, "9");

      string today = System.DateTime.Now.ToString("yyyy.MM.dd");

      lstvCmds.InsertText(1, 0, "Date");
      lstvCmds.InsertText(1, 1, today);
      lstvCmds.InsertText(1, 2, "10");

      string now = System.DateTime.Now.ToString("HH:mm:ss");
      lstvCmds.InsertText(2, 0, "Control Info");
      lstvCmds.InsertText(2, 1, now);
      lstvCmds.InsertText(2, 2, "8");
    }
  }
}
