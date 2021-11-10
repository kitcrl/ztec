using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LineJJ
{
  public partial class nDebug : Form
  {
    AppMain gMain;
    public string[] cmdTR = new string[25];

    public nDebug()
    {
      InitializeComponent();
    }

    public void Open(AppMain m)
    {
      gMain = m;
      this.TopMost = true;
      //Show();
      ShowDialog();
    }

    public void InitCmd_TRANS_CMD()
    {
      int i = 0;

      /// 0
      cmdTR[i] = "TRANS-CMD";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "1";
      i++;
      cmdTR[i] = "N";
      i++;
      cmdTR[i] = "00000001";
      i++;

      /// 5
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "00";
      i++;

      /// 10
      cmdTR[i] = "000";
      i++;
      cmdTR[i] = "00000";
      i++;
      cmdTR[i] = "00";
      i++;
      cmdTR[i] = "00";
      i++;
      cmdTR[i] = "N";
      i++;

      /// 15
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "00";
      i++;

      /// 20
      cmdTR[i] = "000";
      i++;
      cmdTR[i] = "00000";
      i++;
      cmdTR[i] = "00";
      i++;
      cmdTR[i] = "00";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_TRNCN_CMD()
    {
      int i = 0;

      /// 0
      cmdTR[i] = "TRNCH-CMD";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "0";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "000000001";
      i++;
      cmdTR[i] = "1";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_TRNCH_CMD()
    {
      int i = 0;
      
      cmdTR[i] = "TRNCH-CMD";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "0";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "000000001";
      i++;
      cmdTR[i] = "1";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_SYSMD_CMD()
    {
      int i = 0;

      cmdTR[i] = "SYSMD-CMD";
      i++;
      cmdTR[i] = "";
      i++;
      cmdTR[i] = "";

      gMain.appcommMaster.app_datum = cmdTR;

    }


    public void InitCmd_SYSST_CMD()
    {
      int i = 0;
      cmdTR[i] = "SYSST-CMD";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_DATTM_CMD()
    {
      int i = 0;
      string today = System.DateTime.Now.ToString("yyyy.MM.dd");
      string now = System.DateTime.Now.ToString("HH:mm:ss");

      cmdTR[i] = "DATTM-CMD";
      i++;
      cmdTR[i] = today;
      i++;
      cmdTR[i] = now;

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_EQUS1_REP()
    {
      int i = 0;

      cmdTR[i] = "EQUS1-REP";
      i++;
      cmdTR[i] = "AGV";
      i++;
      cmdTR[i] = "01";
      i++;
      cmdTR[i] = "3001";
      i++;
      cmdTR[i] = "0";
      i++;
      cmdTR[i] = "0000";
      i++;
      cmdTR[i] = "0000";
      i++;
      cmdTR[i] = "0000";
      i++;
      cmdTR[i] = "0000";
      i++;
      cmdTR[i] = "0000";

      gMain.appcommMaster.app_datum = cmdTR;
    }


    public void InitCmd_EQUER_REP()
    {
      int i =0;

      cmdTR[i] = "EQUER-REP";
      i++;
      cmdTR[i] = "AGV";
      i++;
      cmdTR[i] = "013001";
      i++;
      cmdTR[i] = "0000";

      gMain.appcommMaster.app_datum = cmdTR;
    }


    public void InitCmd_SYSER_REP()
    {
      int i = 0;

      cmdTR[i] = "SYSER-REP";
      i++;
      cmdTR[i] = "00";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_THROU_REP()
    {
      int i = 0;

      cmdTR[i] = "THROU-REP";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "01";

      gMain.appcommMaster.app_datum = cmdTR;

    }

    public void InitCmd_TRANS_REP()
    {
      int i = 0;

      cmdTR[i] = "TRANS-REP";
      i++;
      cmdTR[i] = "1";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "0000";
      i++;
      cmdTR[i] = "01";

      gMain.appcommMaster.app_datum = cmdTR;
    }


    public void InitCmd_CANSL_ANS()
    {
      int i = 0;

      cmdTR[i] = "CANSL-ANS";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000000";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "OK";
      i++;
      cmdTR[i] = "1";
      i++;
      cmdTR[i] = "";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_TRNCH_REQ()
    {
      int i = 0;

      cmdTR[i] = "TRNCH-REQ";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "STN";
      i++;
      cmdTR[i] = "00000000";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "00";
      i++;
      cmdTR[i] = "1";
      i++;
      cmdTR[i] = "0";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_TRNCH_ANS()
    {
      int i = 0;

      cmdTR[i] = "TRNCH-ANS";
      i++;
      cmdTR[i] = "P";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "OK";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_SYSMD_ANS()
    {
      int i = 0;

      cmdTR[i] = "SYSMD-ANS";
      i++;
      cmdTR[i] = "ON";
      i++;
      cmdTR[i] = "";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_OPCAL_INF()
    {
      int i = 0;

      cmdTR[i] = "OPCAL-INF";
      i++;
      cmdTR[i] = "T";
      i++;
      cmdTR[i] = "";

      gMain.appcommMaster.app_datum = cmdTR;
    }

    public void InitCmd_TRNAN_REP()
    {
      int i = 0;

      cmdTR[i] = "TRNAN-REP";
      i++;
      cmdTR[i] = "00000001";
      i++;
      cmdTR[i] = "01";

      gMain.appcommMaster.app_datum = cmdTR;
    }


    private void btnATrans_Click(object sender, EventArgs e)
    {
      InitCmd_TRANS_CMD();

      cmdTR[6] = string.Format("{0:d08}", int.Parse(txtFromATrans.Text));
      cmdTR[8] = string.Format("{0:d08}", int.Parse(txtToATrans.Text));


      gMain.appcommMaster.app_append = true;
      gMain.appcommMaster.AGVSend(gMain.sdMaster, "TRANSFER");
    }



    private void btnBTrans_Click(object sender, EventArgs e)
    {
      InitCmd_TRANS_CMD();

      cmdTR[2] = "2";

      cmdTR[17] = string.Format("{0:d08}", int.Parse(txtFromATrans.Text));
      cmdTR[19] = string.Format("{0:d08}", int.Parse(txtToATrans.Text));


      gMain.appcommMaster.app_append = true;
      gMain.appcommMaster.AGVSend(gMain.sdMaster, "TRANSFER");

    }

  }
}
