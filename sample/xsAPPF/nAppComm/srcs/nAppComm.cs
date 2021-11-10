using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using nAPIF;

namespace nAppComm
{
  public delegate void DlgtCallbackProc(int sts, int sd, byte [] msg, int len);
  public delegate void DlgtCallbackProcPacket(byte[] msg, int len);
  public delegate void DlgtCallbackProcString(string msg);

  public class xEventArgs
  {
    private int ecode;

    public xEventArgs(int e)
    {
      ecode = e;
    }

    public int Arg
    {
      get{return ecode;}
    }
  }


  public class xEventHandler
  {
    public delegate void DlgtXEvent(Object sender, xEventArgs e);
    public event DlgtXEvent evt;

    public void ActivateEvent(int ecode)
    {
      xEventArgs args = new xEventArgs(ecode);
      evt(this, args);
    }
  }


  unsafe public class nAppComm
  {
    public byte STX = 0x02;
    public byte ETX = 0x03;
    public byte [] trxid = new byte[6];

    CAPIF apif;


    public CConverter cvt;
    public CCommon cmn = null;

    public DlgtCallbackProc dcp = null;
    public DlgtCallbackProcPacket dcpp = null;
    public DlgtCallbackProcString dcps = null;

    public uint tid = 0;
    public static int tid_len = 6;
    public bool app_append = false;
    public CListView  lv = null;
    public string [] app_datum = new string[25];

    int sock=0;

    static System.Threading.AutoResetEvent   evt = new System.Threading.AutoResetEvent(false);

    xEventHandler  evtHandler = new xEventHandler();

    public nAppComm()
    {
      cvt = new CConverter();
      cmn = new CCommon();
      apif = new CAPIF();
      evtHandler.evt += new xEventHandler.DlgtXEvent(xEvent);
    }

    public void InitDlgtHandler()
    {
      apif.dor += new DlgtOnRecv(OnRecvCallback);
      apif.docc += new DlgtOnConnClose(OnConnCloseCallback);
      apif.docf += new DlgtOnConnFail(OnConnFailCallback);
      apif.docing += new DlgtOnConnecting(OnConnectingCallback);
      apif.doced += new DlgtOnConnected(OnConnectedCallback);
      apif.dodcing += new DlgtOnDisConnecting(OnDisConnectingCallback);
      apif.dodced += new DlgtOnDisConnected(OnDisConnectedCallback);
    }

    public void ReleaeDlgtHandler()
    {
      apif.dor -= new DlgtOnRecv(OnRecvCallback);
      apif.docc -= new DlgtOnConnClose(OnConnCloseCallback);
      apif.docf -= new DlgtOnConnFail(OnConnFailCallback);
      apif.docing -= new DlgtOnConnecting(OnConnectingCallback);
      apif.doced -= new DlgtOnConnected(OnConnectedCallback);
      apif.dodcing -= new DlgtOnDisConnecting(OnDisConnectingCallback);
      apif.dodced -= new DlgtOnDisConnected(OnDisConnectedCallback);
    }


    public static void xEvent(object sender, xEventArgs e)
    {
      nAppComm appcomm = sender as nAppComm;
      //System.Windows.Forms.MessageBox.Show(e.Arg.ToString());
    }

    public int Open(string ip, ushort port, string sys)
    {
      int e = 0;
      InitDlgtHandler();
      e = apif.Open(ip, port, sys);
      if ( e < 0 )
      {
        ReleaeDlgtHandler();
      }
      else
      {
        if ( cmn.sysMode == 'M' ) sock = e;
      }
      return e;
    }

    public int Close()
    {
      int e = 0;
      e = apif.Close();
      ReleaeDlgtHandler();
      return e;
    }


    public int CloseRequest()
    {
      int e = 0;
      if (cmn.sysMode == 'M')
        AGVSend_CLOSE(sock);
      else
      {
        if ( sock > 0 ) AGVSend_DISCONNECT(sock);
      }

      return e;
    }



    public void OnEventProc(int evtCode)
    {

    }


    public void CheckTransferCommand(byte[] packet)
    {
      byte[] pack = new byte[9];
      Buffer.BlockCopy(packet, 34, pack, 0, 9);
      string cmd = cvt.BytesToString(pack);

      if (cmd == "TRANS-CMD")
      {

      }
      else if (cmd == "TRNCH-CMD")
      {

      }
      else if (cmd == "TRNCH-CMD")
      {

      }
      else if (cmd == "SYSMD-CMD")
      {

      }
      else if (cmd == "SYSST-CMD")
      {

      }
      else if (cmd == "DATTM-CMD")
      {

      }
      else if (cmd == "EQUS1-REP")
      {

      }
      else if (cmd == "EQUER-REP")
      {

      }
      else if (cmd == "SYSER-REP")
      {

      }
      else if (cmd == "THROU-REP")
      {

      }
      else if (cmd == "TRANS-REP")
      {
        CheckTransRep(packet);
      }
      else if (cmd == "CANSL-ANS")
      {

      }
      else if (cmd == "TRNCH-REQ")
      {

      }
      else if (cmd == "TRNCH-ANS")
      {

      }
      else if (cmd == "SYSMD-ANS")
      {

      }
      else if (cmd == "OPCAL-INF")
      {

      }
      else if (cmd == "TRNAN-REP")
      {

      }
    }

    public void CheckTransRep(byte[] packet)
    {
      int e = 0;
      string str = "(Transport Report:";
      if (packet[44] == 'T')
      {
        str += "Transport Complete ";
      }
      else if (packet[44] == 'H')
      {
        str += "Dest. Change ";
      }
      else if (packet[44] == 'E')
      {
        str += "Error ";
      }

      str += ")";
      if (dcps != null)
      {
        dcps.Invoke(str);
      }

      //evtHandler.ActivateEvent(100);
      //System.Windows.Forms.MessageBox.Show("CheckTransRep");
    }



    public int OnRecvProc(int sd, IntPtr buf, int len)
    {
      byte[] packet = new byte[len];
      Marshal.Copy(buf, packet, 0, len);
      char[] pca = System.Text.Encoding.ASCII.GetString(packet).ToCharArray();

      if ((pca[1] == 'R') &&
          (pca[2] == 'E') &&
          (pca[3] == 'A') &&
          (pca[4] == 'D') &&
          (pca[5] == 'Y'))
      {
        if (cmn.sysMode == 'S')
        {
        }
        else
        {
          AGVSend_OPEN(sd);
        }
      }
      else if ( (pca[1] == 'O') &&
                (pca[2] == 'P') &&
                (pca[3] == 'E') &&
                (pca[4] == 'N'))
      {
        if ( cmn.sysMode == 'S' )
        {
          AGVSend_CONNECT(sd);
        }
        else
        {
          
        }
      }
      else if ((pca[1] == 'C') &&
                (pca[2] == 'O') &&
                (pca[3] == 'N') &&
                (pca[4] == 'N') &&
                (pca[5] == 'E') &&
                (pca[6] == 'C') &&
                (pca[7] == 'T'))
      {
        if (cmn.sysMode == 'S' )
        {
        }
        else
        {

        }
      }

      else if ((pca[1] == 'C') &&
                (pca[2] == 'L') &&
                (pca[3] == 'O') &&
                (pca[4] == 'S') &&
                (pca[5] == 'E'))
      {
        if (cmn.sysMode == 'S')
        {
          AGVSend_DISCONNECT(sd);
        }
        else
        {
        }
      }
      else if ((pca[1] == 'D') &&
              (pca[2] == 'I') &&
              (pca[3] == 'S') &&
              (pca[4] == 'C') &&
              (pca[5] == 'O') &&
              (pca[6] == 'N') &&
              (pca[7] == 'N') &&
              (pca[8] == 'E') &&
              (pca[9] == 'C') &&
              (pca[10] == 'T') )
      {
        if ( cmn.sysMode == 'S' )
        {

        }
        else
        {
        }
      }
      else if ((pca[1] == 'T') &&
              (pca[2] == 'R') &&
              (pca[3] == 'A') &&
              (pca[4] == 'N') &&
              (pca[5] == 'S') &&
              (pca[6] == 'F') &&
              (pca[7] == 'E') &&
              (pca[8] == 'R'))
      {
        //AGVSend_DONE(sd);
        CheckTransferCommand(packet);
      }
      else if ((pca[1] == 'D') &&
              (pca[2] == 'O') &&
              (pca[3] == 'N') &&
              (pca[4] == 'E'))
      {
      }
      else if ((pca[1] == 'F') &&
              (pca[2] == 'A') &&
              (pca[3] == 'I') &&
              (pca[4] == 'L') &&
              (pca[5] == 'E') &&
              (pca[6] == 'D'))
      {
      }
      else if ((pca[1] == 'H') &&
              (pca[2] == 'E') &&
              (pca[3] == 'L') &&
              (pca[4] == 'L') &&
              (pca[5] == 'O'))
      {
        AGVSend_FINE(sd);
      }
      else if ((pca[1] == 'F') &&
              (pca[2] == 'I') &&
              (pca[3] == 'N') &&
              (pca[4] == 'E'))
      {
      }
      else if ((pca[1] == 'S') &&
              (pca[2] == 'L') &&
              (pca[3] == 'E') &&
              (pca[4] == 'E') &&
              (pca[5] == 'P') &&
              (pca[6] == 'Y'))
      {
      }


      return 0;
    }


    public int OnRecvFromProc()
    {

      return 0;
    }

    public int OnConnFailProc()
    {

      return 0;
    }

    public int OnConnCloseProc()
    {

      return 0;
    }

    public int OnConnectingProc()
    {
      return 0;
    }

    public int OnConnectedProc(int sd, sbyte[] ip, short port)
    {
      if (cmn.sysMode == 'S') // Server Mode, Slave Mode
      {
        sock = sd;
        cmn.AddToMasterList(sd);
        AGVSend(sd, "READY");
      }
      else
      {

      }
      return 0;
    }

    public int OnDisConnectingProc()
    {

      return 0;
    }

    public int OnDisConnectedProc(int sd)
    {
      if (cmn.sysMode == 'S')
      {
        cmn.DeleteFromMasterList(sd);
      }
      else
      {
        AGVSend_CLOSE(sd);
      }
      return 0;
    }


    private int OnRecvCallback(int sd, IntPtr buf, int len)
    {
      byte[] packet = new byte[len];
      Marshal.Copy(buf, packet, 0, len);
      string msg = cvt.BytesToString(packet);
      if ( dcp != null )
      {
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONRECV, sd, packet, len);
      }
      OnRecvProc(sd, buf, len);

      Buffer.BlockCopy(packet, 11, trxid, 0, 6);

      return 0;
    }


    private int OnConnFailCallback(int sd, sbyte[] ip, short port)
    {
      byte[] packet = new byte[16];
      Buffer.BlockCopy(ip, 0, packet, 0, 16);
      if (dcp != null)
      {
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONCONNFAIL, sd, packet, port);
      }

      return 0;
    }


    private int OnConnCloseCallback(int sd, sbyte[] ip, short port)
    {
      byte[] packet = new byte[16];
      Buffer.BlockCopy(ip, 0, packet, 0, 16);

      if (dcp != null)
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONCONNCLOSE, sd, packet, port);

      return 0;
    }


    private int OnConnectingCallback(int sd, sbyte[] ip, short port)
    {
      byte[] packet = new byte[16];
      Buffer.BlockCopy(ip, 0, packet, 0, 16);

      if (dcp != null)
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONCONNECTING, sd, packet, port);

      return 0;
    }


    private int OnConnectedCallback(int sd, sbyte[] ip, short port)
    {
      byte[] packet = new byte[16];
      Buffer.BlockCopy(ip, 0, packet, 0, 16);

      if (dcp != null)
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONCONNECTED, sd, packet, port);

      OnConnectedProc(sd, ip, port);
      return 0;
    }

    private int OnDisConnectingCallback(int sd)
    {
      
      if (dcp != null)
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONDISCONNECTING, sd, null, 0);

      return 0;
    }

    private int OnDisConnectedCallback(int sd)
    {
      if (dcp != null)
        dcp.Invoke((int)nAPIF.TypeOfDlgt.ONDISCONNECTED, sd, null, 0);

      OnDisConnectedProc(sd);
      return 0;
    }

    public int Send(int sd, string msg)
    {
      byte[] ba;
      ba = cvt.StringToBytes(msg);
      return apif.Send(sd, ba, msg.Length);
    }

    public int AGVSend(int sd, string msg)
    {
      int e = 0;
      if ((msg == cmn.READY))           e = AGVSend_READY(sd);
      else if ((msg == cmn.OPEN))       e = AGVSend_OPEN(sd);
      else if ((msg == cmn.CONNECT))    e = AGVSend_CONNECT(sd);
      else if ((msg == cmn.CLOSE))      e = AGVSend_CLOSE(sd);
      else if ((msg == cmn.DISCONNECT)) e = AGVSend_DISCONNECT(sd);
      else if ((msg == cmn.TRANSFER))   e = AGVSend_TRANSFER(sd);
      else if ((msg == cmn.DONE))       e = AGVSend_DONE(sd);
      else if ((msg == cmn.FAILED))     e = AGVSend_FAILED(sd);
      else if ((msg == cmn.HELLO))      e = AGVSend_HELLO(sd);
      else if ((msg == cmn.FINE))       e = AGVSend_FINE(sd);
      else if ((msg == cmn.SLEEPY))     e = AGVSend_SLEEPY(sd);
      else e = -1;


      if ( e > 0 )
      {
      }


      return e;
    }


    public void WriteToPacketLog(byte [] packet, int len)
    {
      if ( dcpp != null )
      {
        dcpp.Invoke(packet, len);
      }
    }


    public int AGVSend_READY(int sd)
    {
      string msg = "READY";
      int len = 32;
      byte[] baPacket;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);

      WriteToPacketLog(baPacket, len + 2);
      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_OPEN(int sd)
    {
      string msg = "OPEN";
      int len = 32;
      byte[] baPacket;
      byte[] p;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }

      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);


      p = cvt.StringToBytes("001024");
      Buffer.BlockCopy(p, 0, baPacket, 11, 6);
      Buffer.BlockCopy(p, 0, baPacket, 17, 6);

      WriteToPacketLog(baPacket, len + 2);
      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_CONNECT(int sd)
    {
      string msg = "CONNECT";
      int len = 32;
      byte[] baPacket;
      byte[] p;

      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);


      p = cvt.StringToBytes("001024");
      Buffer.BlockCopy(p, 0, baPacket, 11, 6);
      Buffer.BlockCopy(p, 0, baPacket, 17, 6);


      WriteToPacketLog(baPacket, len + 2);
      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_CLOSE(int sd)
    {
      string msg = "CLOSE";
      int len = 32;
      byte[] baPacket;

      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);

      WriteToPacketLog(baPacket, len + 2);
      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_DISCONNECT(int sd)
    {
      string msg = "DISCONNECT";
      int len = 32;
      byte[] baPacket;

      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);

      WriteToPacketLog(baPacket, len + 2);
      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_TRANSFER(int sd)
    {
      string _tid = null;
      string msg = "TRANSFER";
      int len = 32;
      int alen = 0;
      byte[] baPacket;
      byte[] appendee = new byte[126];
      int i;

      _tid = string.Format("{0:d06}", tid);
      tid++;

      if (app_append == true)
      {
        alen = GenerateAppendee(appendee);
      }

      baPacket = new byte[len + alen + 2];
      for (i = 0; i < len + alen + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[len + alen + 1] = ETX;

      byte[] command = cvt.StringToBytes(msg);
      byte[] tranxid = cvt.StringToBytes(_tid);
      byte[] packnos = cvt.StringToBytes("000000");

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);
      Buffer.BlockCopy(trxid, 0, baPacket, 11, tid_len);
      Buffer.BlockCopy(packnos, 0, baPacket, 17, 6);
      if (alen > 0)
      {
        string size = string.Format("{0:d06}", alen);
        byte[] datSize = cvt.StringToBytes(size);

        Buffer.BlockCopy(datSize, 0, baPacket, 27, 6);
        Buffer.BlockCopy(appendee, 0, baPacket, 33, alen);
      }
      else
      {
        baPacket[27] = 0x30;
        baPacket[28] = 0x30;
        baPacket[29] = 0x30;
        baPacket[30] = 0x30;
        baPacket[31] = 0x30;
        baPacket[32] = 0x30;
      }

      WriteToPacketLog(baPacket, len + alen + 2);
      return apif.Send(sd, baPacket, len + alen + 2);
    }









    public int AGVSend_DONE(int sd)
    {
      string msg = "DONE";
      int len = 32;
      byte[] baPacket;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);
      Buffer.BlockCopy(trxid, 0, baPacket, 11, 6);
      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_FAILED(int sd)
    {
      string msg = "FAILED";
      int len = 32;
      byte[] baPacket;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);
      Buffer.BlockCopy(trxid, 0, baPacket, 11, 6);

      return apif.Send(sd, baPacket, len + 2);
    }

    public int AGVSend_HELLO(int sd)
    {
      string msg = "HELLO";
      int len = 32;
      byte[] baPacket;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);

      return apif.Send(sd, baPacket, len + 2);
    }
    public int AGVSend_FINE(int sd)
    {
      string msg = "FINE";
      int len = 32;
      byte[] baPacket;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);

      return apif.Send(sd, baPacket, len + 2);
    }
    public int AGVSend_SLEEPY(int sd)
    {
      string msg = "SLEEPY";
      int len = 32;
      byte[] baPacket;
      int i;
      baPacket = new byte[len + 2];

      for (i = 0; i < len + 2; i++)
      {
        baPacket[i] = 0x20;
      }
      baPacket[0] = STX;
      baPacket[33] = ETX;

      byte[] command = cvt.StringToBytes(msg);

      Buffer.BlockCopy(command, 0, baPacket, 1, msg.Length);

      return apif.Send(sd, baPacket, len + 2);
    }






    public int GenerateAppendee(byte[] packet)
    {
      int e = 0;
      if (app_datum.Length == 0) return 0;


      //// Slave
      if (app_datum[0] == "TRANS-CMD")
      {
        e = Gen_TRANS_CMD(packet);
      }
      else if (app_datum[0] == "TRNCN-CMD")
      {
        e = Gen_TRACN_CMD(packet);
      }
      else if (app_datum[0] == "TRNCH-CMD")
      {
        e = Gen_TRACH_CMD(packet);
      }
      else if (app_datum[0] == "SYSMD-CMD")
      {
        e = Gen_SYSMD_CMD(packet);
      }
      else if (app_datum[0] == "SYSST-CMD")
      {
        e = Gen_SYSST_CMD(packet);
      }
      else if (app_datum[0] == "DATTM-CMD")
      {
        e = Gen_DATTM_CMD(packet);
      }


      //// Master
      else if (app_datum[0] == "EQUS1-REP")
      {
        e = Gen_EQUS1_REP(packet);
      }
      else if (app_datum[0] == "EQUER-REP")
      {
        e = Gen_EQUER_REP(packet);
      }
      else if (app_datum[0] == "SYSER-REP")
      {
        e = Gen_SYSER_REP(packet);
      }
      else if (app_datum[0] == "THROU-REP")
      {
        e = Gen_THROU_REP(packet);
      }
      else if (app_datum[0] == "TRANS-REP")
      {
        e = Gen_TRANS_REP(packet);
      }
      else if (app_datum[0] == "CANSL-ANS")
      {
        e = Gen_CANSL_ANS(packet);
      }
      else if (app_datum[0] == "TRNCH-REQ")
      {
        e = Gen_TRNCH_REQ(packet);
      }
      else if (app_datum[0] == "TRNCH-ANS")
      {
        e = Gen_TRNCH_ANS(packet);
      }
      else if (app_datum[0] == "SYSMD-ANS")
      {
        e = Gen_SYSMD_ANS(packet);
      }
      else if (app_datum[0] == "OPCAL-INF")
      {
        e = Gen_OPCAL_INF(packet);
      }
      else if (app_datum[0] == "TRNAN-REP")
      {
        e = Gen_TRNAN_REP(packet);
      }

      return e;
    }



    public int Gen_EQUS1_REP(byte[] packet)
    {
      byte[] p;
      long n = 0;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);


        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 14, 1);


        //// AGV No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 15, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 17, 1);



        //// Curr Point No.
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 18, 4);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 22, 1);


        //// Op Mode.
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 23, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 24, 1);


        //// Error Code
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 25, 4);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 29, 1);


        //// System Mode
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 0, packet, 30, 4);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 34, 1);

        //// Loader Status
        p = cvt.StringToBytes(app_datum[7]);
        Buffer.BlockCopy(p, 0, packet, 35, 4);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 39, 1);

        //// Spare 1
        p = cvt.StringToBytes(app_datum[8]);
        Buffer.BlockCopy(p, 0, packet, 40, 4);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 44, 1);


        //// Spare 2
        p = cvt.StringToBytes(app_datum[9]);
        Buffer.BlockCopy(p, 0, packet, 45, 4);

      }
      catch (Exception exp)
      {
      }
      return 49;
    }


    public int Gen_EQUER_REP(byte[] packet)
    {
      byte[] p;
      long n = 0;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);



        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 14, 1);


        //// Equip Info
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 15, 6);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 21, 1);


        //// Error Code
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 22, 4);

      }
      catch (Exception exp)
      {
      }
      return 26;
    }


    public int Gen_SYSER_REP(byte[] packet)
    {
      byte[] p;
      long n = 0;
      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);



        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);



        //// Equip Info
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 2);

      }
      catch (Exception exp)
      {
      }
      return 13;
    }


    public int Gen_THROU_REP(byte[] packet)
    {
      byte[] p;
      long n = 0;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);

        //// Pass Point Type
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 17, 1);


        //// Pass Point No.
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 18, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 26, 1);



        //// Final Dest Point Type
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 27, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 30, 1);

        //// Final Dest Point No.
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 31, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 39, 1);


        //// Final Dest Point No.
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 0, packet, 40, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 48, 1);



        //// AGV No.
        p = cvt.StringToBytes(app_datum[7]);
        Buffer.BlockCopy(p, 0, packet, 49, 2);
      }
      catch (Exception exp)
      {
      }
      return 51;
    }

    public int Gen_TRANS_REP(byte[] packet)
    {
      byte[] p;
      long n = 0;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Completion Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 14, 1);




        //// Completion Point Type
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 15, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 18, 1);


        //// Completion Point No.
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 19, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 27, 1);



        //// Transport Command Data No.
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 28, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 36, 1);

        //// Final Dest Point No.
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 0, packet, 37, 4);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 41, 1);


        //// AGV No.
        p = cvt.StringToBytes(app_datum[7]);
        Buffer.BlockCopy(p, 0, packet, 42, 2);
      }
      catch (Exception exp)
      {
      }
      return 44;
    }





    public int Gen_CANSL_ANS(byte[] packet)
    {
      byte[] p;
      long n = 0;
      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);



        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);



        //// Cancel Point Type
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 16, 1);


        //// Cancel Point No.
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 17, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 25, 1);


        //// Trans Cmd Data No.
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 26, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 34, 1);

        //// Cancel Result
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 35, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 37, 1);


        //// Cancel Type
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 0, packet, 38, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 39, 1);


        //// Cancel Result
        p = cvt.StringToBytes(app_datum[7]);
        Buffer.BlockCopy(p, 0, packet, 40, 20);
      }
      catch (Exception exp)
      {
      }
      return 60;
    }



    public int Gen_TRNCH_REQ(byte[] packet)
    {
      byte[] p;
      long n = 0;
      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);



        //// Req Point Type
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 16, 1);


        //// Req Point No.
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 17, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 25, 1);


        //// Trans Cmd Data No.
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 26, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 34, 1);


        //// AGV No.
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 35, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 37, 1);


        //// Req No.
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 0, packet, 38, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 39, 1);


        //// AGV No.
        p = cvt.StringToBytes(app_datum[7]);
        Buffer.BlockCopy(p, 0, packet, 40, 1);

      }
      catch (Exception exp)
      {
      }
      return 41;
    }



    public int Gen_TRNCH_ANS(byte[] packet)
    {
      byte[] p;
      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);



        //// Trans Cmd Data No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 21, 1);



        //// Dest Change Result.
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 22, 2);
      }
      catch (Exception exp)
      {
      }
      return 24;
    }




    public int Gen_SYSMD_ANS(byte[] packet)
    {
      byte[] p;
      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 13, 1);



        //// Trans Cmd Data No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 14, 20);

      }
      catch (Exception exp)
      {
      }
      return 34;
    }




    public int Gen_OPCAL_INF(byte[] packet)
    {
      byte[] p;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);



        //// Trans Cmd Data No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 100);

      }
      catch (Exception exp)
      {
      }
      return 113;
    }




    public int Gen_TRNAN_REP(byte[] packet)
    {
      byte[] p;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Assigned Data No.
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 19, 1);

        //// AGV No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 20, 2);
      }
      catch (Exception exp)
      {
      }
      return 22;
    }


    /// <summary>
    /// Slave
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public int Gen_TRANS_CMD(byte[] packet)
    {
      byte[] p;
      int tr_cmd_dt_itm = 0;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);


        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);


        //// Transport Command Data Items
        tr_cmd_dt_itm = int.Parse(app_datum[2]);
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 14, 1);



        //// Transport Command Type
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 15, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 16, 1);


        //// Transport Command Data No.
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 17, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 25, 1);


        //// From Point Type
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 26, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 29, 1);


        //// From Point No.
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 0, packet, 30, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 38, 1);



        //// To Point Type
        p = cvt.StringToBytes(app_datum[7]);
        Buffer.BlockCopy(p, 0, packet, 39, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 42, 1);


        //// To Point No.
        p = cvt.StringToBytes(app_datum[8]);
        Buffer.BlockCopy(p, 0, packet, 43, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 51, 1);


        //// Transport Moe
        p = cvt.StringToBytes(app_datum[9]);
        Buffer.BlockCopy(p, 0, packet, 52, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 54, 1);


        //// Transport Group No.
        p = cvt.StringToBytes(app_datum[10]);
        Buffer.BlockCopy(p, 0, packet, 55, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 58, 1);


        //// Transport Seq No.
        p = cvt.StringToBytes(app_datum[11]);
        Buffer.BlockCopy(p, 0, packet, 59, 5);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 64, 1);



        ///// Number of Unit.
        p = cvt.StringToBytes(app_datum[12]);
        Buffer.BlockCopy(p, 0, packet, 65, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 67, 1);


        ///// AGV No Setting.
        p = cvt.StringToBytes(app_datum[13]);
        Buffer.BlockCopy(p, 0, packet, 68, 2);

        if (tr_cmd_dt_itm == 1) return 70;


        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 70, 1);


        //// Transport Command Type
        p = cvt.StringToBytes(app_datum[14]);
        Buffer.BlockCopy(p, 0, packet, 71, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 72, 1);


        //// Transport Command Data No.
        p = cvt.StringToBytes(app_datum[15]);
        Buffer.BlockCopy(p, 0, packet, 73, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 81, 1);


        //// From Point Type
        p = cvt.StringToBytes(app_datum[16]);
        Buffer.BlockCopy(p, 0, packet, 82, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 85, 1);


        //// From Point No.
        p = cvt.StringToBytes(app_datum[17]);
        Buffer.BlockCopy(p, 0, packet, 86, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 94, 1);



        //// To Point Type
        p = cvt.StringToBytes(app_datum[18]);
        Buffer.BlockCopy(p, 0, packet, 95, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 98, 1);


        //// To Point No.
        p = cvt.StringToBytes(app_datum[19]);
        Buffer.BlockCopy(p, 0, packet, 99, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 107, 1);


        //// Transport Moe
        p = cvt.StringToBytes(app_datum[20]);
        Buffer.BlockCopy(p, 0, packet, 108, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 110, 1);


        //// Transport Group No.
        p = cvt.StringToBytes(app_datum[21]);
        Buffer.BlockCopy(p, 0, packet, 111, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 114, 1);


        //// Transport Seq No.
        p = cvt.StringToBytes(app_datum[22]);
        Buffer.BlockCopy(p, 0, packet, 115, 5);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 120, 1);



        ///// Number of Unit.
        p = cvt.StringToBytes(app_datum[23]);
        Buffer.BlockCopy(p, 0, packet, 121, 2);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 123, 1);


        ///// AGV No Setting.
        p = cvt.StringToBytes(app_datum[24]);
        Buffer.BlockCopy(p, 0, packet, 124, 2);
      }
      catch (Exception exp)
      {
      }
      return 126;
    }

    public int Gen_TRACN_CMD(byte[] packet)
    {
      byte[] p;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);





        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);






        //// Cancel Point Type
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 16, 1);





        //// Cancel Point No.
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 17, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 25, 1);






        //// Cancel Transport Data No.
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 26, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 34, 1);






        //// Control Info
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 35, p.Length);
      }
      catch (Exception exp)
      {
      }

      return 55;
    }



    public int Gen_TRACH_CMD(byte[] packet)
    {
      byte[] p;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);





        //// Equip Type
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 12, 1);





        //// Transport Command Data No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 13, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 21, 1);




        //// Error Type
        p = cvt.StringToBytes(app_datum[3]);
        Buffer.BlockCopy(p, 0, packet, 22, 1);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 23, 1);



        //// TO Point Type
        p = cvt.StringToBytes(app_datum[4]);
        Buffer.BlockCopy(p, 0, packet, 24, 3);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 27, 1);


        //// Cancel Point No.
        p = cvt.StringToBytes(app_datum[5]);
        Buffer.BlockCopy(p, 0, packet, 28, 8);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 36, 1);


        //// Pallet Size
        p = cvt.StringToBytes(app_datum[6]);
        Buffer.BlockCopy(p, 7, packet, 37, 1);
      }
      catch (Exception exp)
      {
      }

      return 38;
    }


    public int Gen_SYSMD_CMD(byte[] packet)
    {
      byte[] p;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);





        //// Mode
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, p.Length);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 13, 1);





        //// Transport Command Data No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 14, p.Length); //20
      }
      catch (Exception exp)
      {
      }

      return 34;
    }




    public int Gen_SYSST_CMD(byte[] packet)
    {

      byte[] p;

      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);
      }
      catch (Exception exp)
      {
      }


      return 10;
    }


    public int Gen_DATTM_CMD(byte[] packet)
    {

      byte[] p;
      try
      {
        p = cvt.StringToBytes("/");
        Buffer.BlockCopy(p, 0, packet, 0, 1);

        //// Message ID
        p = cvt.StringToBytes(app_datum[0]);
        Buffer.BlockCopy(p, 0, packet, 1, 9);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 10, 1);





        //// Date
        p = cvt.StringToBytes(app_datum[1]);
        Buffer.BlockCopy(p, 0, packet, 11, 10);

        p = cvt.StringToBytes("^");
        Buffer.BlockCopy(p, 0, packet, 21, 1);





        //// Transport Command Data No.
        p = cvt.StringToBytes(app_datum[2]);
        Buffer.BlockCopy(p, 0, packet, 22, 8);
      }
      catch (Exception exp)
      {
      }

      return 30;
    }





  }
}
