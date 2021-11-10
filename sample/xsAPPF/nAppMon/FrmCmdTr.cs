using System;

namespace nAppMon
{
  public partial class FrmCmdTr : FrmCmd
  {
    public int MAX = 25;

    public override void InitVals()
    {
      lstvCmds.InsertText(0, 0, "MessageID");
      lstvCmds.InsertText(0, 1, "TRANS-CMD");
      lstvCmds.InsertText(0, 2, "9");
      
      lstvCmds.InsertText(1, 0, "Equip Type");
      lstvCmds.InsertText(1, 1, "P");
      lstvCmds.InsertText(1, 2, "1");

      lstvCmds.InsertText(2, 0, "Tr Cmd Dat Item");
      lstvCmds.InsertText(2, 1, "1");
      lstvCmds.InsertText(2, 2, "1");

      lstvCmds.InsertText(3, 0, "Tr Cmd Type");
      lstvCmds.InsertText(3, 1, "N");
      lstvCmds.InsertText(3, 2, "1");

      lstvCmds.InsertText(4, 0, "Tr Cmd Dat No.");
      lstvCmds.InsertText(4, 1, "00000001");
      lstvCmds.InsertText(4, 2, "8");

      lstvCmds.InsertText(5, 0, "From Pt Type");
      lstvCmds.InsertText(5, 1, "STN");
      lstvCmds.InsertText(5, 2, "3");

      lstvCmds.InsertText(6, 0, "From Pt No.");
      lstvCmds.InsertText(6, 1, "00000001");
      lstvCmds.InsertText(6, 2, "8");

      lstvCmds.InsertText(7, 0, "To Pt Type");
      lstvCmds.InsertText(7, 1, "STN");
      lstvCmds.InsertText(7, 2, "3");

      lstvCmds.InsertText(8, 0, "To Pt No.");
      lstvCmds.InsertText(8, 1, "00000001");
      lstvCmds.InsertText(8, 2, "8");

      lstvCmds.InsertText(9, 0, "Tr Mode");
      lstvCmds.InsertText(9, 1, "00");
      lstvCmds.InsertText(9, 2, "2");

      lstvCmds.InsertText(10, 0, "Tr Grp No.");
      lstvCmds.InsertText(10, 1, "000");
      lstvCmds.InsertText(10, 2, "3");

      lstvCmds.InsertText(11, 0, "Tr Seq No.");
      lstvCmds.InsertText(11, 1, "00000");
      lstvCmds.InsertText(11, 2, "5");

      lstvCmds.InsertText(12, 0, "No of Unit");
      lstvCmds.InsertText(12, 1, "00");
      lstvCmds.InsertText(12, 2, "2");

      lstvCmds.InsertText(13, 0, "AGV No. Set");
      lstvCmds.InsertText(13, 1, "00");
      lstvCmds.InsertText(13, 2, "2");

      ////  RED SECTION
      lstvCmds.InsertText(14, 0, "Tr Cmd Type");
      lstvCmds.InsertText(14, 1, "N");
      lstvCmds.InsertText(14, 2, "1");

      lstvCmds.InsertText(15, 0, "Tr Cmd Dat No.");
      lstvCmds.InsertText(15, 1, "00000001");
      lstvCmds.InsertText(15, 2, "8");

      lstvCmds.InsertText(16, 0, "From Pt Type");
      lstvCmds.InsertText(16, 1, "STN");
      lstvCmds.InsertText(16, 2, "3");

      lstvCmds.InsertText(17, 0, "From Pt No.");
      lstvCmds.InsertText(17, 1, "00000001");
      lstvCmds.InsertText(17, 2, "8");

      lstvCmds.InsertText(18, 0, "To Pt Type");
      lstvCmds.InsertText(18, 1, "STN");
      lstvCmds.InsertText(18, 2, "3");

      lstvCmds.InsertText(19, 0, "To Pt No.");
      lstvCmds.InsertText(19, 1, "00000001");
      lstvCmds.InsertText(19, 2, "8");

      lstvCmds.InsertText(20, 0, "Tr Mode");
      lstvCmds.InsertText(20, 1, "00");
      lstvCmds.InsertText(20, 2, "2");

      lstvCmds.InsertText(21, 0, "Tr Grp No.");
      lstvCmds.InsertText(21, 1, "000");
      lstvCmds.InsertText(21, 2, "3");

      lstvCmds.InsertText(22, 0, "Tr Seq No.");
      lstvCmds.InsertText(22, 1, "00000");
      lstvCmds.InsertText(22, 2, "5");

      lstvCmds.InsertText(23, 0, "No. of Unit");
      lstvCmds.InsertText(23, 1, "00");
      lstvCmds.InsertText(23, 2, "2");

      lstvCmds.InsertText(24, 0, "AGV No. Set");
      lstvCmds.InsertText(24, 1, "00");
      lstvCmds.InsertText(24, 2, "2");
    }
  }
}
