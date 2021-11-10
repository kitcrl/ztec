using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LineJJ
{
  public delegate void DlgtMasterEvent(int mode, int sleep);
  public delegate void DlgtSlaveEvent(int mode, int sleep);
  public delegate void DlgtLog(int sts, int sd, byte[] msg, int len);
  public delegate void DlgtMasterPacketLog(byte[] msg, int len);
  public delegate void DlgtSlavePacketLog(byte[] msg, int len);
  public delegate void DlgtMasterStringLog(string msg);
  public delegate void DlgtSlaveStringtLog(string msg);

  public enum DIRECTION
  {
    LEFT = 0,
    RIGHT
  };

  public partial class AppMain : Form
  {
    public nAppComm.nAppComm appcommMaster = null;
    public nAppComm.nAppComm appcommSlave = null;
    DlgtLog dlgtMasterLog = null;
    DlgtLog dlgtSlaveLog = null;
    DlgtMasterPacketLog dmpl = null;
    DlgtSlavePacketLog dspl = null;
    DlgtMasterStringLog dmsl = null;
    DlgtSlaveStringtLog dssl = null;


    DlgtMasterEvent dlgtMasterEvent = null;
    DlgtSlaveEvent dlgtSlaveEvent = null;

    nDebug dbgWnd;
    nSetup setupWnd = new nSetup();

    public int sdMaster = 0;
    public int sdSlave = 0;
    Timer tmr;

    Timer tmrConnectProc;

    Matrix mtx;

    LinePoint linePt;

    int moveComplete = 0;

    bool closeStatus = true;

    public AppMain()
    {
      InitializeComponent();

      InitLocalVars();
      InitGUIVars();

      StandbySystem();
    }

    public void InitLocalVars()
    {
      appcommMaster = new nAppComm.nAppComm();
      appcommSlave = new nAppComm.nAppComm();

      appcommMaster.dcp = new nAppComm.DlgtCallbackProc(OnCBMasterCallback);
      appcommSlave.dcp = new nAppComm.DlgtCallbackProc(OnCBSlaveCallback);

      appcommMaster.dcpp = new nAppComm.DlgtCallbackProcPacket(OnCBMasterPacketCallback);
      appcommSlave.dcpp = new nAppComm.DlgtCallbackProcPacket(OnCBSlavePacketCallback);

      appcommMaster.dcps = new nAppComm.DlgtCallbackProcString(OnCBMasterStringCallback);
      appcommSlave.dcps = new nAppComm.DlgtCallbackProcString(OnCBSlaveStringCallback);


      dlgtMasterLog = new DlgtLog(OnLogCallbackMaster);
      dlgtSlaveLog = new DlgtLog(OnLogCallbackSlave);

      dmpl = new DlgtMasterPacketLog(OnMasterPacketLogCallback);
      dspl = new DlgtSlavePacketLog(OnSlavePacketLogCallback);
      dmsl = new DlgtMasterStringLog(OnMasterStringLogCallback);
      dssl = new DlgtSlaveStringtLog(OnSlaveStringLogCallback);


      dlgtMasterEvent = new DlgtMasterEvent(DoMasterEvent);
      dlgtSlaveEvent = new DlgtSlaveEvent(DoSlaveEvent);



      tmr = new Timer();
      tmrConnectProc = new Timer();

      mtx = new Matrix();
    }

    public void InitGUIVars()
    {
      InitProtocolListView();

    }


    public void StandbySystem()
    {
      InitPoint();

      tmr.Interval = 1;
      tmr.Tick += new EventHandler(TimerProc);
      tmr.Start();


      tmrConnectProc.Interval = 3000;
      tmrConnectProc.Tick += new EventHandler(TimerConnectProc);

      txtLog.Visible = false;

      if (txtLog.Visible == false)
      {
        lstProtocolView.Width = pnlLineMain.Width;
        lstProtocolView.Left = pnlLineMain.Left;
      }

      //picAGV.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
    }



    public void InitPoint()
    {
      linePt = new LinePoint(picAGV.Image.Width / 2, picAGV.Image.Height / 2);

      picAGV.Location = linePt.ptAGV;
      picAGV.Refresh();
    }

    public void InitProtocolListView()
    {
      int i=0;
      int colCount = 40;

      lstProtocolView.CreateColumn(colCount);
      lstProtocolView.AddColumnHeader(i++, "HOST", 50);
      lstProtocolView.AddColumnHeader(i++, "-", 30);
      lstProtocolView.AddColumnHeader(i++, "ASC", 50);
      lstProtocolView.AddColumnHeader(i++, "STS", 120);
      lstProtocolView.AddColumnHeader(i++, "CMD", 80);
      lstProtocolView.AddColumnHeader(i++, "Msg-ID", 80);

      for ( ; i < colCount; i++)
      {
        lstProtocolView.AddColumnHeader(i, i.ToString(), 80);
      }

    }


    public void WriteToProtocolView(string hType, string direction, string aType, string status, byte [] packet, int len)
    {
      int i,ii;
      int offset=9;
      int idx = 34;
      int cidx = 0;
      int ridx = 0;
      int t=0;
      string val = null;
      byte[] pkt;
      int e=0;

      string cmd = null;
      byte[] p = new byte[10];

      if ( len > 0 )
      {
        Buffer.BlockCopy(packet, 1, p, 0, 10);
        cmd = appcommMaster.cvt.BytesToString(p);
      }


      ridx = lstProtocolView.GetEmptyRow();

      lstProtocolView.InsertText(ridx, cidx++, hType);
      lstProtocolView.InsertText(ridx, cidx++, direction);
      lstProtocolView.InsertText(ridx, cidx++, aType);
      lstProtocolView.InsertText(ridx, cidx++, status);

      if ( len > 0 )
      lstProtocolView.InsertText(ridx, cidx++, cmd);


      for ( i=idx, offset=0; i<len-1 ; i++, offset++ )
      {
        if ( packet[i] == 0x5E )
        {
          pkt = new byte[offset];
          Buffer.BlockCopy(packet, idx, pkt, 0, offset);
          for (ii = 0; ii < offset; ii++)
          {
            if ( pkt[ii] < 0x80 )
            {
              if ((pkt[ii] >= 0x30 && packet[ii] <= 0x39) || (pkt[ii] >= 0x41 && packet[ii] <= 0x5A) || (packet[ii] >= 0x61 && packet[ii] <= 0x7A))
              {
                e=1;
                break;
              }
            }
          }

          if ( e == 1 )
          {
            val = appcommMaster.cvt.BytesToString(pkt);
          }
          else
          {
            for ( ii=0 ; ii<offset ; ii++ )
            {
              t += (pkt[ii]<<((offset-ii-1)*8));
            }
            val += string.Format("{0:d}", t);
          }
          lstProtocolView.InsertText(ridx, cidx, val);
          idx += offset + 1;
          cidx++;
          offset = -1;
          e = 0;
          t = 0;
          val = null;
        }
      }
      
      if ( idx < len )
      {
        pkt = new byte[offset];
        Buffer.BlockCopy(packet, idx, pkt, 0, offset);
        for (ii = 0; ii < offset; ii++)
        {
          if ( pkt[ii] < 0x80 )
          {
            if ((pkt[ii] >= 0x30 && packet[ii] <= 0x39) || (pkt[ii] >= 0x41 && packet[ii] <= 0x5A) || (packet[ii] >= 0x61 && packet[ii] <= 0x7A))
            {
              e = 1;
              break;
            }
          }
        }

        if (e == 1)
        {
          val = appcommMaster.cvt.BytesToString(pkt);
        }
        else
        {
          for (ii = 0; ii < offset; ii++)
          {
            t += (pkt[ii] << ((offset - ii - 1) * 8));
          }
          val += string.Format("{0:d}", t);
        }
        lstProtocolView.InsertText(ridx, cidx, val);
      }

    }

    private void OnLogCallbackMaster(int sts, int sd, byte [] msg, int len)
    {
      if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTED)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave Connected !!!");
        WriteToProtocolView("Master", "->", "Slave", "Connected", msg, 0);

      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTING)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave Connecting...");
        WriteToProtocolView("Master", "->", "Slave", "Connecting", msg, 0);

      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNCLOSE)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave Connection Closed !!!");
        WriteToProtocolView("Master", "->", "Slave", "Connection Closed", msg, 0);

        if (closeStatus == false)
        {
          BeginInvoke(dlgtMasterEvent, 0, 1000);
        }
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNFAIL)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave Connection Fail !!!");
        WriteToProtocolView("Master", "->", "Slave", "Connection Fail", msg, 0);

        if (closeStatus == false)
        {
          tmrConnectProc.Start();

        }
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTED)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave Disconnected !!!");
        WriteToProtocolView("Master", "->", "Slave", "Disconnected", msg, 0);

        if (closeStatus == false)
        {
          BeginInvoke(dlgtMasterEvent, 1, 1000);
        }
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTING)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave Disconnecting...");
        WriteToProtocolView("Master", "->", "Slave", "Disconnecting", msg, 0);
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONRECV)
      {
        WriteToProtocolView("Master", "<-", "Slave", "Recv", msg, len);
      }
    }



    private void OnLogCallbackSlave(int sts, int sd, byte[] msg, int len)
    {
      if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTED)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master Connected !!!");
        WriteToProtocolView("Slave", "<-", "Master", "Connected", msg, 0);
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTING)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master Connecting...");
        WriteToProtocolView("Slave", "<-", "Master", "Connecting", msg, 0);
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNCLOSE)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master Connection Closed !!!");
        WriteToProtocolView("Slave", "<-", "Master", "Connection Closed", msg, 0);
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNFAIL)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master Connection Fail !!!");
        WriteToProtocolView("Slave", "<-", "Master", "Connection Fail", msg, 0);
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTED)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master Disconnected !!!");
        WriteToProtocolView("Slave", "<-", "Master", "Disconnected", msg, 0);
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTING)
      {
        if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master Disconnecting...");
        WriteToProtocolView("Slave", "<-", "Master", "Disconnecting", msg, 0);

      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONRECV)
      {
        WriteToProtocolView("Slave", "<-", "Master", "Recv", msg, len);
      }
    }


    private void OnMasterPacketLogCallback(byte[] msg, int len)
    {
      string _msg = null;
      byte[] p = new byte[10];
      Buffer.BlockCopy(msg, 1, p, 0, 10);
      _msg = appcommMaster.cvt.BytesToString(p);

      if (txtLog.Visible == true) txtLog.Append("[H]Master -> [A]Slave " + _msg);
      WriteToProtocolView("Master", "->", "Slave", "Send", msg, len);
    }
    private void OnSlavePacketLogCallback(byte[] msg, int len)
    {
      string _msg = null;
      byte[] p = new byte[10];
      Buffer.BlockCopy(msg, 1, p, 0, 10);
      _msg = appcommMaster.cvt.BytesToString(p);

      if (txtLog.Visible == true) txtLog.Append("[H]Slave -> [A]Master " + _msg);
      WriteToProtocolView("Slave", "->", "Master", "Send", msg, len);
    }


    private void OnMasterStringLogCallback(string str)
    {
      if (txtLog.Visible == true) txtLog.Append("[H]Master <- [A]Slave " + str);
    }
    private void OnSlaveStringLogCallback(string str)
    {
      if (txtLog.Visible == true) txtLog.Append("[H]Slave <- [A]Master " + str);
    }

    private void OnStringLogCallback(string msg)
    {
      if (txtLog.Visible == true) txtLog.Append(msg);
    }


    private string ConvertToHex(byte [] msg, int len)
    {
      int i;
      string _msg = null;
      for (i = 0; i < len; i++)
      {
        _msg += string.Format("{0:x02} ", msg[i]);
      }
      return _msg;
    }




    private void TimerConnectProc(Object obj, EventArgs args)
    {
      tmrConnectProc.Stop();
      DoOpenMaster();

    }



    private void DoOpenMaster()
    {
      string ip = setupWnd.txtIP.Text;
      string sys = "CLIENT";

      appcommMaster.cmn.sysMode = 'M';
      sdMaster = appcommMaster.Open(ip, 3002, sys);
      //sdMaster = appcommMaster.Open(ip, 3000, sys);
      if (sdMaster > 0)
      {

      }
      else
      {

      }
    }

    private void DoOpenSlave()
    {
      string ip = setupWnd.txtIP.Text;
      string sys = "SERVER";

      appcommSlave.cmn.sysMode = 'S';
      sdSlave = appcommSlave.Open(ip, 3001, sys);
      if (sdSlave > 0)
      {

      }
      else
      {
      }
    }


    private void DoCloseMaster()
    {
      System.Threading.Thread.Sleep(100);
      appcommMaster.Close();
      sdMaster = 0;
    }

    private void DoCloseSlave()
    {
      System.Threading.Thread.Sleep(100);
      appcommSlave.Close();
      sdSlave = 0;
    }


    private void DoCloseRequestMaster()
    {
      appcommMaster.CloseRequest();
      sdMaster = 0;
      BeginInvoke(dlgtMasterEvent, -1, 1000);
    }

    private void DoCloseRequestSlave()
    {
      appcommSlave.CloseRequest();
      sdSlave = 0;
      BeginInvoke(dlgtSlaveEvent, -1, 1000);
    }


    public void DoOpen()
    {
      closeStatus = false;
      DoMasterEvent(1, 0);
      DoSlaveEvent(1, 0);
    }

    public void DoClose()
    {
      closeStatus = true;
      DoMasterEvent(0, 200);
      DoSlaveEvent(0, 200);
      //this.btnPower.Text = "Open";
    }


    private void DoMasterEvent(int mode, int sleep)
    {
      System.Threading.Thread.Sleep(sleep);
      if (mode == 1)
      {
        DoOpenMaster();
      }
      else if ( mode == 0 )
      {
        DoCloseRequestMaster();
      }
      else
      {
        DoCloseMaster();
      }
    }

    private void DoSlaveEvent(int mode, int sleep)
    {
      System.Threading.Thread.Sleep(sleep);
      if (mode == 1)
      {
        DoOpenSlave();
      }
      else if ( mode == 0 )
      {
        DoCloseRequestSlave();
      }
      else
      {
        DoCloseSlave();
      }
    }


    private void CheckMasterStatus(int sts)
    {
      if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTED)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTING)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNCLOSE)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNFAIL)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTED)
      {
        if (closeStatus == false)
        {
          //tmrConnectProc.Start();
        }
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTING)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONRECV)
      {
      }
    }

    private void CheckSlaveStatus(int sts)
    {
      if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTED)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNECTING)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNCLOSE)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONCONNFAIL)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTED)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONDISCONNECTING)
      {
      }
      else if (sts == (int)nAPIF.TypeOfDlgt.ONRECV)
      {
      }
    }

    private void OnCBMasterCallback(int sts, int sd, byte [] msg, int len)
    {
      CheckMasterStatus(sts);
      this.Invoke(this.dlgtMasterLog, sts, sd, msg, len);
    }
    private void OnCBSlaveCallback(int sts, int sd, byte[] msg, int len)
    {
      CheckSlaveStatus(sts);
      this.Invoke(this.dlgtSlaveLog, sts, sd, msg, len);
    }

    private void OnCBMasterPacketCallback(byte[] msg, int len)
    {
      this.Invoke(this.dmpl, msg, len);
    }
    private void OnCBSlavePacketCallback(byte[] msg, int len)
    {
      this.Invoke(this.dspl, msg, len);
    }

    private void OnCBMasterStringCallback(string msg)
    {
      this.Invoke(this.dmsl, msg);
    }
    private void OnCBSlaveStringCallback(string msg)
    {
      this.Invoke(this.dssl, msg);
    }

    int CheckDirection(Point from, Point to, int directionion)
    {
      int e = 0;


      return e;
    }



    private void btnPower_Click(object sender, EventArgs e)
    {
      //if ( btnPower.Text == "Open" )
      //{
      //  this.btnPower.Text = "Close";
      //  DoOpen();
      //}
      //else
      //{
      //  this.btnPower.Text = "Open";
      //  DoClose();
      //}
    }


    //int CheckCurveA(Point pt)
    //{
    //  int e = 0;
    //  if ((pt.X <= ptCurveA01.X) && (pt.Y >= ptCurveA01.Y) && (pt.X >= ptCurveA02.X) && (pt.Y <= ptCurveA02.Y))
    //  {
    //    e = 1;
    //  }
    //  return e;
    //}
    //int CheckCurveB(Point pt)
    //{
    //  int e = 0;
    //  if ((pt.X <= ptCurveB01.X) && (pt.Y >= ptCurveB01.Y) && (pt.X >= ptCurveB02.X) && (pt.Y <= ptCurveB02.Y))
    //  {
    //    e = 1;
    //  }
    //  return e;
    //}
    //int CheckCurveC(Point pt)
    //{
    //  int e = 0;
    //  if ((pt.X >= ptCurveC01.X) && (pt.Y >= ptCurveC01.Y) && (pt.X <= ptCurveC02.X) && (pt.Y <= ptCurveC02.Y))
    //  {
    //    e = 1;
    //  }
    //  return e;
    //}
    private void TimerProc(Object obj, EventArgs args)
    {
      int e = 0;
      return;
      //if (moveComplete == 0)
      //{
      //  e = MoveAGV(linePt.ptParking, linePt.ptE4[01], (int)DIRECTION.LEFT);
      //  if (e == 1) moveComplete = 1;
      //}
      if (moveComplete == 0)
      {
        e = MoveAGV(linePt.ptParking, linePt.ptA4[14], (int)DIRECTION.LEFT);
        if (e == 1) moveComplete = 1;
      }
      if (moveComplete == 1)
      {
        e = MoveAGV(linePt.ptA4[14], linePt.ptA4[23], (int)DIRECTION.RIGHT);
        if (e == 1) moveComplete = 2;
      }
      if (moveComplete == 2)
      {
        e = MoveAGV(linePt.ptA4[23], linePt.ptA4[14], (int)DIRECTION.LEFT);
        if (e == 1) moveComplete = 3;
      }
      if (moveComplete == 3)
      {
        e = MoveAGV(linePt.ptA4[14], linePt.ptParking, (int)DIRECTION.RIGHT);
        if (e == 1) moveComplete = 4;
      }
      if (moveComplete == 4)
      {
        e = MoveAGV(linePt.ptParking, linePt.ptE4[01], (int)DIRECTION.LEFT);
        if (e == 1) moveComplete = 5;
      }
      if (moveComplete == 5)
      {
        e = MoveAGV(linePt.ptE4[01], linePt.ptParking, (int)DIRECTION.RIGHT);
        if (e == 1) moveComplete = 0;
      }




      //if (moveComplete == 1)
      //{
      //  e = MoveAGV(linePt.ptParking, linePt.ptB4[13], (int)DIRECTION.LEFT);
      //  if (e == 1) moveComplete = 2;
      //}

      //if (moveComplete == 2)
      //{
      //  e = MoveAGV(linePt.ptParking, linePt.ptC4[12], (int)DIRECTION.LEFT);
      //  if (e == 1) moveComplete = 3;
      //}


      //if (moveComplete == 3)
      //{
      //  e = MoveAGV(linePt.ptParking, linePt.ptD4[11], (int)DIRECTION.LEFT);
      //  if (e == 1) moveComplete = 4;
      //}

      //if (moveComplete == 4)
      //{
      //  e = MoveAGV(linePt.ptParking, linePt.ptE4[10], (int)DIRECTION.LEFT);
      //  if (e == 1) moveComplete = 5;
      //}

      //if (moveComplete == 5)
      //{
      //  e = MoveAGV(linePt.ptE4[10], linePt.ptParking, (int)DIRECTION.RIGHT);
      //  if (e == 1) moveComplete = 6;
      //}


      //if (moveComplete == 6)
      //{
      //  e = MoveAGV(linePt.ptParking, linePt.ptEnd02, (int)DIRECTION.LEFT);
      //  if (e == 1) moveComplete = 7;
      //}

      //if (moveComplete == 7)
      //{
      //  e = MoveAGV(linePt.ptEnd02, linePt.ptParking, (int)DIRECTION.RIGHT);
      //  if (e == 1) moveComplete = 8;
      //}

      //this.if ( txtLog.Visible == true ) txtLog.AppendText("timer\r\n");

      //MoveFromParkingToPoint(ptA);
      //MoveFromParkingToPoint(ptB);
      //MoveFromParkingToPoint(ptC);
      //MoveFromParkingToPoint(ptD);

      //if ( moveComplete == 0 )
      //{
      //  MoveFromParkingToPoint(ptE);
      //}
      //else
      //{
      //  MoveFromPointToParking(ptE);
      //}
      //mtx.RotateAt(10.0f, new PointF(0,0));
      //mtx.Rotate(90);
      //Graphics g = CreateGraphics();
      //g.Transform = mtx;
      //Image oldImage = picAGV.Image;
      //picAGV.Image = RotateImage(picAGV.Image, new PointF(0, 0), 90F);
      //if ( oldImage != null ) oldImage.Dispose();
      //picAGV.Refresh();

    }


    int MovePos(Point from, Point to, int direction)
    {
      int e = 0;

      //// the Inside of CurveA
      if (CheckPosition(picAGV.Location, linePt.ptCurveA) == 1)
      {
        if (direction == (int)DIRECTION.LEFT)
        {
          linePt.ptAGV.X--;
          linePt.ptAGV.Y++;

          //// the last point of CurveA
          if (linePt.ptAGV.Y > linePt.ptLineRect[0].Y)
          {
            linePt.ptAGV.Y = linePt.ptLineRect[0].Y;
            
          }
        }
        else if (direction == (int)DIRECTION.RIGHT)
        {
          if ( picAGV.Location.Y != to.Y )
          {
            linePt.ptAGV.Y--;
            linePt.ptAGV.X++;
            if (linePt.ptAGV.X > linePt.ptCurveA[0].X) linePt.ptAGV.X = linePt.ptCurveA[0].X;
          }
          else
          {
            linePt.ptAGV.X++;
          }
        }
      }
      //// the Inside of CurveB
      else if (CheckPosition(picAGV.Location, linePt.ptCurveB) == 1)
      {
        if (direction == (int)DIRECTION.LEFT)
        {
          linePt.ptAGV.X--;
          linePt.ptAGV.Y++;
          if (linePt.ptAGV.X < linePt.ptLineRect[1].X) linePt.ptAGV.X = linePt.ptLineRect[1].X;
        }
        else if (direction == (int)DIRECTION.RIGHT)
        {
          linePt.ptAGV.X++;
          linePt.ptAGV.Y--;
          if (linePt.ptAGV.Y < linePt.ptLineRect[0].Y) linePt.ptAGV.Y = linePt.ptLineRect[0].Y;
        }
      }
      //// the Inside of CurveC
      else if (CheckPosition(picAGV.Location, linePt.ptCurveC) == 1)
      {
        if (direction == (int)DIRECTION.LEFT)
        {
          linePt.ptAGV.X++;
          linePt.ptAGV.Y++;
          if (linePt.ptAGV.Y > linePt.ptLineRect[1].Y) linePt.ptAGV.Y = linePt.ptLineRect[1].Y;
        }
        else if (direction == (int)DIRECTION.RIGHT)
        {
          linePt.ptAGV.X--;
          linePt.ptAGV.Y--;
          if (linePt.ptAGV.X < linePt.ptLineRect[1].X) linePt.ptAGV.X = linePt.ptLineRect[1].X;
        }
      }
      else
      {
        //// between the ParkingPoint with the CurveA
        if (CheckPosition(linePt.ptAGV, linePt.ptParking, linePt.ptCurveA[0]) == 1)
        {
          if (direction == (int)DIRECTION.LEFT)
          {
            linePt.ptAGV.Y++;
          }
          else if (direction == (int)DIRECTION.RIGHT)
          {
            linePt.ptAGV.Y--;
          }
        }
        //// between the CurveA with the CurveB
        else if (CheckPosition(linePt.ptAGV, linePt.ptCurveA[1], linePt.ptCurveB[0]) == 1)
        {
          if (direction == (int)DIRECTION.LEFT)
          {
            linePt.ptAGV.X--;
          }
          else if (direction == (int)DIRECTION.RIGHT)
          {
            linePt.ptAGV.X++;
          }
        }
        //// between the CurveB with the CurveC
        else if (CheckPosition(linePt.ptAGV, linePt.ptCurveB[1].X, linePt.ptCurveB[1].Y, linePt.ptCurveC[1].X, linePt.ptCurveC[0].Y) == 1)
        {
          if (direction == (int)DIRECTION.LEFT)
          {
            linePt.ptAGV.Y++;
          }
          else if (direction == (int)DIRECTION.RIGHT)
          {
            linePt.ptAGV.Y--;
          }
        }
        //// between the End02 with the CurveC
        else if (CheckPosition(linePt.ptAGV, linePt.ptEnd02.X, linePt.ptCurveC[0].Y, linePt.ptCurveC[0].X, linePt.ptCurveC[1].Y) == 1)
        {
          if (direction == (int)DIRECTION.LEFT)
          {
            linePt.ptAGV.X++;
          }
          else if (direction == (int)DIRECTION.RIGHT)
          {
            linePt.ptAGV.X--;
          }
        }
        //// between the End01 with the CurveA
        else if (CheckPosition(linePt.ptAGV, linePt.ptEnd01.X, linePt.ptEnd01.Y, linePt.ptCurveA[0].X, linePt.ptCurveA[1].Y) == 1)
        {
          if (direction == (int)DIRECTION.LEFT)
          {
            linePt.ptAGV.X--;
          }
          else if (direction == (int)DIRECTION.RIGHT)
          {
            linePt.ptAGV.X++;
          }
        }
      }

      if (((linePt.ptAGV.X - 1) <= to.X) && ((linePt.ptAGV.X + 1) >= to.X) &&
          ((linePt.ptAGV.Y - 1) <= to.Y) && ((linePt.ptAGV.Y + 1) >= to.Y))
      {
        linePt.ptAGV = to;
        e = 1;
      }
      return e;
    }

    int MoveAGV(Point from, Point to, int direction)
    {
      int e = 0;

      e = MovePos(from, to, direction);

      picAGV.Location = linePt.ptAGV;
      return e;
    }


    int CheckPosition(Point pt, Point [] curve)
    {
      int e = 0;
      if ( (curve[0].X == curve[1].X) )
      {
        if ( curve[0].X == pt.X )
        {
          if ( (pt.Y >= curve[0].Y) && (pt.Y <= curve[1].Y))
          {
            e = 1;
          }
        }
      }
      else if ((curve[0].Y == curve[1].Y))
      {
        if ( curve[0].Y == pt.Y )
        {
          if ( (pt.X <= curve[0].X) && (pt.X >= curve[1].X) )
          {
            e = 1;
          }
        }
      }
      else if ((pt.X <= curve[0].X) && (pt.Y >= curve[0].Y) && (pt.X >= curve[1].X) && (pt.Y <= curve[1].Y))
      {
        e = 1;
      }
      return e;
    }

    int CheckPosition(Point pt, Point righttop, Point leftbottom)
    {
      Point [] ptRect = new Point[2];
      ptRect[0] = righttop;
      ptRect[1] = leftbottom;

      return CheckPosition(pt, ptRect);
    }

    int CheckPosition(Point pt, int rx, int ry, int lx, int ly)
    {
      Point[] ptRect = new Point[2];
      ptRect[0].X = rx;
      ptRect[0].Y = ry;

      ptRect[1].X = lx;
      ptRect[1].Y = ly;

      return CheckPosition(pt, ptRect);
    }
    public static Bitmap RotateImage(Image image, PointF offset, float angle)
    {
      if (image == null)
        throw new ArgumentNullException("image");

      //create a new empty bitmap to hold rotated image
      Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
      rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

      //make a graphics object from the empty bitmap
      Graphics g = Graphics.FromImage(rotatedBmp);

      //Put the rotation point in the center of the image
      g.TranslateTransform(offset.X, offset.Y);

      //rotate the image
      g.RotateTransform(angle);

      //move the image back
      g.TranslateTransform(-offset.X, -offset.Y);

      //draw passed in image onto graphics object
      g.DrawImage(image, new PointF(0, 0));

      return rotatedBmp;
    }

    private void btnDebug_Click(object sender, EventArgs e)
    {
      dbgWnd = new nDebug();
      dbgWnd.Open(this);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      txtLog.Clear();
      this.lstProtocolView.Items.Clear();
    }

    private void btnSetup_Click(object sender, EventArgs e)
    {
      setupWnd.Open(this);
    }

  }
}
