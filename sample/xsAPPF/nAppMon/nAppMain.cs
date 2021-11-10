using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using nAPIF;

// Master == Client
// Slave  == Server


namespace nAppMon
{
  public delegate void DlgtLog(int sts, int sd, byte [] msg, int len);
  public delegate void DlgtDoClose();
  public delegate void DlgtWriteLog(string msg);

  public partial class nAppMain : Form
  {
    nAppComm.nAppComm  appcomm = null;
    DlgtLog   dlgtLog = null;
    DlgtDoClose dlgtDoClose = null;
    DlgtWriteLog dlgtWriteLog = null;


    byte [] trxid = new byte[6];

    int       csd = 0;
    int       ssd = 0;

    Timer     tmr;

    FrmCmdTr     frmCmdTr;
    FrmCmdTrCN   frmCmdTrCN;
    FrmCmdTrCH   frmCmdTrCH;
    FrmCmdSysMD  frmCmdSysMD;
    FrmCmdSysST  frmCmdSysST;
    FrmCmdDatTM  frmCmdDatTM;


    FrmASCEqus1Rep frmASCEqus1Rep;
    FrmASCEquerRep frmASCEquerRep;
    FrmASCSyserRep frmASCSyserRep;
    FrmASCThrouRep frmASCThrouRep;
    FrmASCTransRep frmASCTransRep;
    FrmASCCanslAns frmASCCanslAns;
    FrmASCTrnchReq frmASCTrnchReq;
    FrmASCTrnchAns frmASCTrnchAns;
    FrmASCSysmdAns frmASCSysmdAns;
    FrmASCOpcalInf frmASCOpcalInf;
    FrmASCTrnanRep frmASCTrnanRep;

    public nAppMain()
    {
      InitializeComponent();

      appcomm = new nAppComm.nAppComm();

      InitLocalVars();
      InitGUIVars();

      StandbySystem();
    }


    public void InitLocalVars()
    {

      appcomm.dcp = new nAppComm.DlgtCallbackProc(OnCBCallback);
      //appcomm.dcmp = new nAppComm.DlgtCallbackMsgProc(OnMsgCallback);
      dlgtLog = new DlgtLog(OnLogCallback);
      dlgtDoClose = new DlgtDoClose(DoClose);
      //dlgtWriteLog = new DlgtWriteLog(DoMsgCallback);
      tmr = new Timer();

    }

    public void InitGUIVars()
    {
      txtIP.Text = "127.0.0.1";
      txtPort.Text = "4002";

      cbSys.Items.Add("SLAVE");
      cbSys.Items.Add("MASTER");
      cbSys.SelectedIndex = 0;
      appcomm.cmn.sysMode = 'S';
      cbSys.DropDownStyle = ComboBoxStyle.DropDownList;

      cbDisplayType.Items.Add("HEX");
      cbDisplayType.Items.Add("ASCII");
      cbDisplayType.SelectedIndex = 0;
      appcomm.cmn.dispType = 'H';
      cbDisplayType.DropDownStyle = ComboBoxStyle.DropDownList;

      lstCmdSet.Items.Add(appcomm.cmn.READY);
      lstCmdSet.Items.Add(appcomm.cmn.OPEN);
      lstCmdSet.Items.Add(appcomm.cmn.CONNECT);
      lstCmdSet.Items.Add(appcomm.cmn.CLOSE);
      lstCmdSet.Items.Add(appcomm.cmn.DISCONNECT);
      lstCmdSet.Items.Add(appcomm.cmn.TRANSFER);
      lstCmdSet.Items.Add(appcomm.cmn.DONE);
      lstCmdSet.Items.Add(appcomm.cmn.FAILED);
      lstCmdSet.Items.Add(appcomm.cmn.HELLO);
      lstCmdSet.Items.Add(appcomm.cmn.FINE);
      lstCmdSet.Items.Add(appcomm.cmn.SLEEPY);


      cbMessageID.Items.Add("MessageID List");
      cbMessageID.DropDownStyle = ComboBoxStyle.DropDownList;
      cbMessageID.SelectedIndex = 0;

      cbMasterList.Items.Add("Master List");
      cbMasterList.DropDownStyle = ComboBoxStyle.DropDownList;

      InitProtocolListView();

      GUIItemEnable(false);

      cbMessageID.Enabled = false;



      chkAppend.Checked = true;

      frmCmdTr = new FrmCmdTr();
      frmCmdTrCN = new FrmCmdTrCN();
      frmCmdTrCH = new FrmCmdTrCH();
      frmCmdSysMD = new FrmCmdSysMD();
      frmCmdSysST = new FrmCmdSysST();
      frmCmdDatTM = new FrmCmdDatTM();

      frmCmdTr.Init(pnlCmd);
      frmCmdTrCN.Init(pnlCmd);
      frmCmdTrCH.Init(pnlCmd);
      frmCmdSysMD.Init(pnlCmd);
      frmCmdSysST.Init(pnlCmd);
      frmCmdDatTM.Init(pnlCmd);



      frmASCEqus1Rep = new FrmASCEqus1Rep();
      frmASCEquerRep = new FrmASCEquerRep();
      frmASCSyserRep = new FrmASCSyserRep();
      frmASCThrouRep = new FrmASCThrouRep();
      frmASCTransRep = new FrmASCTransRep();
      frmASCCanslAns = new FrmASCCanslAns();
      frmASCTrnchReq = new FrmASCTrnchReq();
      frmASCTrnchAns = new FrmASCTrnchAns();
      frmASCSysmdAns = new FrmASCSysmdAns();
      frmASCOpcalInf = new FrmASCOpcalInf();
      frmASCTrnanRep = new FrmASCTrnanRep();


      frmASCEqus1Rep.Init(pnlCmd);
      frmASCEquerRep.Init(pnlCmd);
      frmASCSyserRep.Init(pnlCmd);
      frmASCThrouRep.Init(pnlCmd);
      frmASCTransRep.Init(pnlCmd);
      frmASCCanslAns.Init(pnlCmd);
      frmASCTrnchReq.Init(pnlCmd);
      frmASCTrnchAns.Init(pnlCmd);
      frmASCSysmdAns.Init(pnlCmd);
      frmASCOpcalInf.Init(pnlCmd);
      frmASCTrnanRep.Init(pnlCmd);

    }


    public void InitProtocolListView()
    {
      int i;

      this.lstvLog.CreateColumn(36);
      this.lstvLog.AddColumnHeader(0, "Msg ID", 80);

      for (i = 1; i < 36; i++)
      {
        this.lstvLog.AddColumnHeader(i, i.ToString(), 80);
      }

    }


    public void WriteToProtocolView(byte[] packet, int len)
    {
      int i, ii=0;
      int offset = 9;
      int idx = 34;
      int cidx = 0;
      int ridx = 0;
      int t = 0;
      string val = null;
      byte[] pkt;
      int e = 0;
      if (idx >= len) return;

      //int [] numPart = null;

      //pkt = new byte[offset];
      //Buffer.BlockCopy(packet, idx, pkt, 0, offset);
      //val = appcomm.cvt.BytesToString(pkt);
      //if ( val.Equals("TRANS-CMD") == true )
      //{
      //  i = 0;
      //  numPart = new int[25];
      //  numPart[2] = 1;
      //  numPart[6] = 1;
      //  numPart[8] = 1;
      //  numPart[9] = 1;
      //  numPart[10] = 1;

      //  numPart[11] = 1;
      //  numPart[12] = 1;
      //  numPart[13] = 1;
      //  numPart[17] = 1;
      //  numPart[19] = 1;

      //  numPart[20] = 1;
      //  numPart[21] = 1;
      //  numPart[22] = 1;
      //  numPart[23] = 1;
      //  numPart[24] = 1;
      //}
      //else if (val.Equals("TRNCN-CMD") == true)
      //{
      //  i = 0;
      //  numPart = new int[6];
      //  numPart[3] = 1;
      //}
      //else if (val.Equals("TRNCH-CMD") == true)
      //{
      //  i = 0;
      //  numPart = new int[7];
      //  numPart[5] = 1;
      //  numPart[6] = 1;
      //}
      //else if (val.Equals("EQUS1-REP") == true)
      //{
      //  i = 0;
      //  numPart = new int[10];
      //  for ( i=2 ; i<10 ; i++ )
      //  {
      //    numPart[i] = 1;
      //  }
      //}
      //else if (val.Equals("EQUER-REP") == true)
      //{
      //  i = 0;
      //  numPart = new int[4];
      //  numPart[2] = 1;
      //  numPart[3] = 1;
      //}
      //else if (val.Equals("SYSER-REP") == true)
      //{
      //  i = 0;
      //  numPart = new int[2];
      //  numPart[1] = 1;
      //}
      //else if (val.Equals("THROU-REP") == true)
      //{
      //  i = 0;
      //  numPart = new int[8];
      //  numPart[3] = 1;
      //  numPart[4] = 1;
      //  numPart[5] = 1;
      //  numPart[7] = 1;
      //}
      //else if (val.Equals("TRANS-REP") == true)
      //{
      //  i = 0;
      //  numPart = new int[8];
      //  numPart[4] = 1;
      //  numPart[6] = 1;
      //  numPart[7] = 1;
      //}
      //else if (val.Equals("CANSL-ANS") == true)
      //{
      //  i = 0;
      //  numPart = new int[8];
      //  numPart[3] = 1;
      //  numPart[6] = 1;
      //}
      //else if (val.Equals("TRNCH-REQ") == true)
      //{
      //  i = 0;
      //  numPart = new int[8];
      //  numPart[3] = 1;
      //  numPart[5] = 1;
      //  numPart[6] = 1;
      //  numPart[7] = 1;
      //}


      ridx = lstvLog.GetEmptyRow();

      for (i = idx, cidx = 0, offset = 0; i < len - 1; i++, offset++)
      {
        if (packet[i] == 0x5E)
        {
          pkt = new byte[offset];
          Buffer.BlockCopy(packet, idx, pkt, 0, offset);

          //if ( numPart != null && numPart[cidx] == 1 )
          //{
          //  for (ii = 0; ii < offset; ii++)
          //  {
          //    t += (pkt[ii] << ((offset - ii - 1) * 8));
          //  }
          //  val = string.Format("{0:d}", t);
          //}
          //else
          {
            val = appcomm.cvt.BytesToString(pkt);
          }

          lstvLog.InsertText(ridx, cidx, val);
          idx += offset + 1;
          cidx++;
          offset = -1;
          t = 0;
          val = null;
          //for (ii = 0; ii < offset; ii++)
          //{
          //  if (pkt[ii] < 0x80)
          //  {
          //    if ((pkt[ii] >= 0x30 && packet[ii] <= 0x39) || (pkt[ii] >= 0x41 && packet[ii] <= 0x5A) || (packet[ii] >= 0x61 && packet[ii] <= 0x7A))
          //    {
          //      e = 1;
          //      break;
          //    }
          //  }
          //}

          //if (e == 1)
          //{
          //  val = appcomm.cvt.BytesToString(pkt);
          //}
          //else
          //{
          //  for (ii = 0; ii < offset; ii++)
          //  {
          //    t += (pkt[ii] << ((offset - ii - 1) * 8));
          //  }
          //  val = string.Format("{0:d}", t);
          //}
          //lstvLog.InsertText(ridx, cidx, val);
          //idx += offset + 1;
          //cidx++;
          //offset = -1;
          //e = 0;
          //t = 0;
          //val = null;
        }
      }

      if (idx < len)
      {
        pkt = new byte[offset];
        Buffer.BlockCopy(packet, idx, pkt, 0, offset);

        //if (numPart != null && numPart[cidx] == 1)
        //{
        //  for (ii = 0; ii < offset; ii++)
        //  {
        //    t += (pkt[ii] << ((offset - ii - 1) * 8));
        //  }
        //  val = string.Format("{0:d}", t);
        //}
        //else
        {
          val = appcomm.cvt.BytesToString(pkt);
        }

        lstvLog.InsertText(ridx, cidx, val);
        //pkt = new byte[offset];
        //Buffer.BlockCopy(packet, idx, pkt, 0, offset);
        //for (ii = 0; ii < offset; ii++)
        //{
        //  if (pkt[ii] < 0x80)
        //  {
        //    if ((pkt[ii] >= 0x30 && packet[ii] <= 0x39) || (pkt[ii] >= 0x41 && packet[ii] <= 0x5A) || (packet[ii] >= 0x61 && packet[ii] <= 0x7A))
        //    {
        //      e = 1;
        //      break;
        //    }
        //  }
        //}

        //if (e == 1)
        //{
        //  val = appcomm.cvt.BytesToString(pkt);
        //}
        //else
        //{
        //  for (ii = 0; ii < offset; ii++)
        //  {
        //    t += (pkt[ii] << ((offset - ii - 1) * 8));
        //  }
        //  val = string.Format("{0:d}", t);
        //}
        //lstvLog.InsertText(ridx, cidx, val);
      }

    }



    public void StandbySystem()
    {
      //tmr.Interval = 1000;
      //tmr.Tick += new EventHandler(TimerProc);
      //tmr.Start();

    }


    void GUIItemEnable(bool val)
    {
      btnAGVSend.Enabled = val;
      lstCmdSet.Enabled = val;
      if (val == true && chkPromiscuosMode.Checked == true)
      {
        txtSend.Enabled = true;
        btnSend.Enabled = true;
      }
      else
      {
        txtSend.Enabled = false;
        btnSend.Enabled = false;
      }
    }

    private void btnPower_Click(object sender, EventArgs e)
    {
      string status = btnPower.Text;
      if ( status == "Open" )
      {
        if ( DoOpen() < 0 )
        {
          return;
        }
        btnPower.Text = "Close";
        GUIItemEnable(true);
      }
      else
      {
        btnPower.Text = "Open";
        GUIItemEnable(false);
        DoClose();
      }
    }

    private int DoOpen()
    {
      string ip;
      ushort port;
      string sys;

      ip = txtIP.Text;
      if ( cbSys.Text == "MASTER" )
        sys = "CLIENT";
      else
        sys = "SERVER";

      port = ushort.Parse(txtPort.Text);

      ssd = appcomm.Open(ip, port, sys);
      if ( ssd > 0 )
      {
        txtLog.Append(sys + " Opened !!!");
      }
      return ssd;
    }

    private void DoClose()
    {
      string sys;
      if ( cbSys.Text == "MASTER" )
        sys = "CLIENT";
      else
        sys = "SERVER";


      btnPower.Text = "Open";
      GUIItemEnable(false);

      System.Threading.Thread.Sleep(100);

      appcomm.Close();
      txtLog.Append(sys + " Closed !!!");
      ssd = 0;

      cbMessageID.SelectedIndex = 0;
      cbMessageID.Enabled = false;
    }

    private void TimerProc(Object obj, EventArgs args)
    {
      this.txtLog.AppendText("timer\r\n");
      this.txtLog.SelectionStart = this.Text.Length;
      this.txtLog.ScrollToCaret();
    }

    public void OnASyncMsgEvent()
    {

    }



    private void OnLogCallback(int sts, int sd, byte [] packet, int len)
    {
      int i=0;
      if ( sts == (int)nAPIF.TypeOfDlgt.ONRECV )
      {
        if (appcomm.cmn.dispType == 'H')
        {
          string msg = null;
          for ( i=0 ; i<len ; i++ )
          {
            msg += string.Format("{0:x02} ", packet[i]);
          }
          txtLog.Append(msg);
        }
        else
        {
          string msg = appcomm.cvt.BytesToString(packet);
          txtLog.Append(msg);
        }

        WriteToProtocolView(packet, len);
      }
      else
      {
        if ( appcomm.cmn.sysMode == 'S' )
        {
          if ( sts == (int)nAPIF.TypeOfDlgt.ONCONNECTED )
          {
            cbMasterList.Items.Add(sd);
            txtLog.Append(sd.ToString() + " Connected");
          }
          else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTED)
          {
            cbMasterList.Items.Remove(sd);
            cbMasterList.SelectedIndex = 0;
            cbMasterList.Update();
            csd = 0;
            txtLog.Append(sd.ToString() + " Disconnected");
          }
          else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNCLOSE)
          {
            cbMasterList.Items.Remove(sd);
            cbMasterList.SelectedIndex = 0;
            cbMasterList.Update();
            csd = 0;
            txtLog.Append(sd.ToString() + " Connection Closed");
          }
          else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNFAIL)
          {
            cbMasterList.Items.Remove(sd);
            cbMasterList.SelectedIndex = 0;
            cbMasterList.Update();
            csd = 0;
            txtLog.Append(sd.ToString() + " Connection Failed");
          }
        }
        else if ( appcomm.cmn.sysMode == 'M' )
        {
          if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTED)
          {
            txtLog.Append("Connected");
          }
          else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTED)
          {
            txtLog.Append("Disconnected");
          }
          else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNCLOSE)
          {
            txtLog.Append("Connection Closed");
            BeginInvoke(dlgtDoClose);
          }
          else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNFAIL)
          {
            txtLog.Append("Connection Fail \n");
          }

        }
      }
    }


    private void OnMsgCallback(string msg)
    {
      this.Invoke(this.dlgtWriteLog, msg);
    }


    private void OnCBCallback(int sts, int sd, byte [] msg, int len)
    {
      this.Invoke(this.dlgtLog, sts, sd, msg, len);
    }


    private void cbDisplayType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( cbDisplayType.Text == "ASCII" )
      {
        appcomm.cmn.dispType = 'A';
      }
      else
      {
        appcomm.cmn.dispType = 'H';
      }
    }

    private void cbSys_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( cbSys.Text == "SLAVE" )
      {
        this.Text = "AGV ASC (SLAVE:Server) Tester #";
        appcomm.cmn.sysMode = 'S';
        txtPort.Text = "4002";
      }
      else
      {
        this.Text = "AGV ASC (MASTER:Client) Tester #";
        appcomm.cmn.sysMode = 'M';
        txtPort.Text = "4001";
      }

    }



    public void AssignDatumMaster()
    {
      string cmd = null;
      int i;

      cmd = appcomm.cmn.GetValue(cbMessageID.Text, '(', ')');
      if (cmd == "TRANS-CMD")
      {
        for (i = 0; i < frmCmdTr.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmCmdTr.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "TRNCN-CMD")
      {
        for (i = 0; i < frmCmdTrCN.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmCmdTrCN.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "TRNCH-CMD")
      {
        for (i = 0; i < frmCmdTrCH.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmCmdTrCH.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "SYSMD-CMD")
      {
        for (i = 0; i < frmCmdSysMD.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmCmdSysMD.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "SYSST-CMD")
      {
        for (i = 0; i < frmCmdSysST.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmCmdSysST.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "DATTM-CMD")
      {
        for (i = 0; i < frmCmdDatTM.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmCmdDatTM.lstvCmds.GetText(i, 1);
        }
      }
    }


    public void AssignDatumSlave()
    {
      string cmd = null;
      int i;

      cmd = appcomm.cmn.GetValue(cbMessageID.Text, '(', ')');
      if (cmd == "EQUS1-REP")
      {
        for (i = 0; i < this.frmASCEqus1Rep.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCEqus1Rep.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "EQUER-REP")
      {
        for (i = 0; i < this.frmASCEquerRep.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCEquerRep.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "SYSER-REP")
      {
        for (i = 0; i < this.frmASCSyserRep.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCSyserRep.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "THROU-REP")
      {
        for (i = 0; i < this.frmASCThrouRep.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCThrouRep.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "TRANS-REP")
      {
        for (i = 0; i < this.frmASCTransRep.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCTransRep.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "CANSL-ANS")
      {
        for (i = 0; i < this.frmASCCanslAns.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCCanslAns.lstvCmds.GetText(i, 1);
        }

      }
      else if (cmd == "TRNCH-REQ")
      {
        for (i = 0; i < this.frmASCTrnchReq.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCTrnchReq.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "TRNCH-ANS")
      {
        for (i = 0; i < this.frmASCTrnchAns.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCTrnchAns.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "SYSMD-ANS")
      {
        for (i = 0; i < this.frmASCSysmdAns.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCSysmdAns.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "OPCAL-INF")
      {
        for (i = 0; i < this.frmASCOpcalInf.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCOpcalInf.lstvCmds.GetText(i, 1);
        }
      }
      else if (cmd == "TRNAN-REP")
      {
        for (i = 0; i < this.frmASCTrnanRep.lstvCmds.Items.Count; i++)
        {
          appcomm.app_datum[i] = frmASCTrnanRep.lstvCmds.GetText(i, 1);
        }

      }

    }



    void DoSendProc(string msg)
    {
      int e = 0;
      if (appcomm.cmn.sysMode == 'M')
      {
        csd = ssd;
      }
      if ( csd > 0 )
      {
        if ( msg == "TRANSFER" )
        {
          appcomm.app_append = chkAppend.Checked;
          AssignDatumMaster();
          AssignDatumSlave();
        }
        e = appcomm.AGVSend(csd, msg);
        if ( e < 0 )
        {
          MessageBox.Show("Cannot Sent this Command : " + msg);
        }
      }
      else
      {
        MessageBox.Show("Please select your master in the MasterList");
      }
    }

    private void btnAGVSend_Click(object sender, EventArgs e)
    {
      string cmd = lstCmdSet.SelectedItem.ToString();

      DoSendProc(cmd);
    }


    private void btnSend_Click(object sender, EventArgs e)
    {
      string msg = txtSend.Text;
      if (appcomm.cmn.sysMode == 'M')
      {
        csd = ssd;
      }

      if (csd > 0)
      {
        appcomm.Send(csd, msg);
      }
      else
      {
        MessageBox.Show("Please select your master in the MasterList");
      }

    }



    private void cbMasterList_SelectedIndexChanged(object sender, EventArgs e)
    {

      if ( cbMasterList.SelectedIndex > 0 )
      {
        csd = (int)uint.Parse(cbMasterList.Text);
      }

    }


    private void chkPromiscuosMode_CheckedChanged(object sender, EventArgs e)
    {
      if ( chkPromiscuosMode.Checked == true )
      {
        txtSend.Enabled = true;
        btnSend.Enabled = true;
      }
      else
      {
        txtSend.Enabled = false;
        btnSend.Enabled = false;
      }
    }

    private void cbMessageID_SelectedIndexChanged(object sender, EventArgs e)
    {
      string selectedMsg = cbMessageID.Items[cbMessageID.SelectedIndex].ToString();
      string sMsg = appcomm.cmn.GetValue(selectedMsg, '(', ')');

      ChangedIndexMaster(sMsg);
      ChangedIndexSlave(sMsg);
    }

    public void ChangedIndexMaster(string msg)
    {
      try
      {
        frmCmdTr.Hide();
        frmCmdTrCN.Hide();
        frmCmdTrCH.Hide();
        frmCmdSysMD.Hide();
        frmCmdSysST.Hide();
        frmCmdDatTM.Hide();

        if (msg == "TRANS-CMD") frmCmdTr.Show();
        else if (msg == "TRNCN-CMD") frmCmdTrCN.Show();
        else if (msg == "TRNCH-CMD") frmCmdTrCH.Show();
        else if (msg == "SYSMD-CMD") frmCmdSysMD.Show();
        else if (msg == "SYSST-CMD") frmCmdSysST.Show();
        else if (msg == "DATTM-CMD") frmCmdDatTM.Show();
      }
      catch(Exception exp)
      {
      }
    }


    public void ChangedIndexSlave(string msg)
    {
      try
      {
        frmASCEqus1Rep.Hide();
        frmASCEquerRep.Hide();
        frmASCSyserRep.Hide();
        frmASCThrouRep.Hide();
        frmASCTransRep.Hide();
        frmASCCanslAns.Hide();
        frmASCTrnchReq.Hide();
        frmASCTrnchAns.Hide();
        frmASCSysmdAns.Hide();
        frmASCOpcalInf.Hide();
        frmASCTrnanRep.Hide();

        if (msg == "EQUS1-REP") frmASCEqus1Rep.Show();
        else if (msg == "EQUER-REP") frmASCEquerRep.Show();
        else if (msg == "SYSER-REP") frmASCSyserRep.Show();
        else if (msg == "THROU-REP") frmASCThrouRep.Show();
        else if (msg == "TRANS-REP") frmASCTransRep.Show();
        else if (msg == "CANSL-ANS") frmASCCanslAns.Show();
        else if (msg == "TRNCH-REQ") frmASCTrnchReq.Show();
        else if (msg == "TRNCH-ANS") frmASCTrnchAns.Show();
        else if (msg == "SYSMD-ANS") frmASCSysmdAns.Show();
        else if (msg == "OPCAL-INF") frmASCOpcalInf.Show();
        else if (msg == "TRNAN-REP") frmASCTrnanRep.Show();
      }
      catch(Exception exp)
      {
      }
    }

    private void lstCmdSet_MouseDblClk(object sender, MouseEventArgs e)
    {
      int index = this.lstCmdSet.IndexFromPoint(e.Location);
      string cmd = lstCmdSet.SelectedItem.ToString();

      DoSendProc(cmd);
    }

    private void lstCmdSet_MouseClk(object sender, MouseEventArgs e)
    {
      int index = this.lstCmdSet.IndexFromPoint(e.Location);
      string cmd = lstCmdSet.SelectedItem.ToString();

      if ( cmd == "TRANSFER" )
      {
        cbMessageID.Enabled = true;
        //InitMasterTRCmd();
        //InitSlaveTRCmd();
        InitTRCmd();
      }
      else
      {
        cbMessageID.Enabled = false;
      }      
    }


    public void InitTRCmd()
    {
      cbMessageID.Items.Clear();
      cbMessageID.Items.Add("Transport (TRANS-CMD)");
      cbMessageID.Items.Add("Transport Data Cancel (TRNCN-CMD)");
      cbMessageID.Items.Add("Destination Change (TRNCH-CMD)");
      cbMessageID.Items.Add("System Mode Change (SYSMD-CMD)");
      cbMessageID.Items.Add("Shutdown (SYSST-CMD)");
      cbMessageID.Items.Add("Date Setting (DATTM-CMD)");
      cbMessageID.Items.Add("Status Report (EQUS1-REP)");
      cbMessageID.Items.Add("Equip Err Report (EQUER-REP)");
      cbMessageID.Items.Add("System Err Report (SYSER-REP)");
      cbMessageID.Items.Add("Loading Report (THROU-REP)");
      cbMessageID.Items.Add("Trans Completion Report (TRANS-REP)");
      cbMessageID.Items.Add("Trans Data Cancel Report (CANSL-ANS)");
      cbMessageID.Items.Add("Destination Change Request (TRNCH-REQ)");
      cbMessageID.Items.Add("Destination Change Report (TRNCH-ANS)");
      cbMessageID.Items.Add("System Mode Change Completion Report (SYSMD-ANS)");
      cbMessageID.Items.Add("Controp CPU Operator Call (OPCAL-INF)");
      cbMessageID.Items.Add("Assigned Report (TRNAN-REP)");

      cbMasterList.SelectedIndex = 0;
    }

    public void InitMasterTRCmd()
    {
      cbMessageID.Items.Clear();
      cbMessageID.Items.Add("Transport (TRANS-CMD)");
      cbMessageID.Items.Add("Transport Data Cancel (TRNCN-CMD)");
      cbMessageID.Items.Add("Destination Change (TRNCH-CMD)");
      cbMessageID.Items.Add("System Mode Change (SYSMD-CMD)");
      cbMessageID.Items.Add("Shutdown (SYSST-CMD)");
      cbMessageID.Items.Add("Date Setting (DATTM-CMD)");
      cbMasterList.SelectedIndex = 0;
    }

    public void InitSlaveTRCmd()
    {
      cbMessageID.Items.Clear();
      cbMessageID.Items.Add("Status Report (EQUS1-REP)");
      cbMessageID.Items.Add("Equip Err Report (EQUER-REP)");
      cbMessageID.Items.Add("System Err Report (SYSER-REP)");
      cbMessageID.Items.Add("Loading Report (THROU-REP)");
      cbMessageID.Items.Add("Trans Completion Report (TRANS-REP)");
      cbMessageID.Items.Add("Trans Data Cancel Report (CANSL-ANS)");
      cbMessageID.Items.Add("Destination Change Request (TRNCH-REQ)");
      cbMessageID.Items.Add("Destination Change Report (TRNCH-ANS)");
      cbMessageID.Items.Add("System Mode Change Completion Report (SYSMD-ANS)");
      cbMessageID.Items.Add("Controp CPU Operator Call (OPCAL-INF)");
      cbMessageID.Items.Add("Assigned Report (TRNAN-REP)");
      cbMasterList.SelectedIndex = 0;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      txtLog.Clear();
      lstvLog.Items.Clear();
    }
  }
}
