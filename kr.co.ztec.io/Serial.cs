using System;
using System.IO.Ports;
using System.Threading;

namespace kr.co.ztec.io
{
  public delegate void dlgtOnRead(byte[] b, Int32 sz);

  public class Serial
  {
    SerialPort _srl = new SerialPort();
    Thread _thr;
    UInt32 _SR_ = 0x00000000;

    public dlgtOnRead _dlgtOnRead = null;

    public Serial()
    {
    }

    public Int32 Open(string strComPort, string strBaudRate, string strDataBit, string strStopBit, string strFlowControl)
    {
      Int32 ecode = 0;

      _srl.PortName = strComPort;
      _srl.BaudRate = int.Parse(strBaudRate);
      _srl.DataBits = int.Parse(strDataBit);
      //_srl.StopBits = StopBits.None;
      //_srl.Parity = Parity.None;
      _srl.Open();

      if (_srl.IsOpen)
      {
        _srl.ReadTimeout = 0;
        _thr = new Thread(new ThreadStart(DoRead));
        _thr.Start();
        ecode = 1;
      }
      return ecode;
    }

    public Int32 Close()
    {
      Int32 ecode = 0;

      if (_srl.IsOpen)
      {
        _SR_ |= 0x00000001;
      }

      while (true)
      {
        if ((_SR_ & 0x80000001) == 0)
        {
          break;
        }
      }

      _srl.Close();

      if (!_srl.IsOpen)
      {
        ecode = 1;
      }
      return ecode;
    }

    public void DoRead()
    {
      Int32 r = 0;
      byte[] rbuf = new byte[128];

      _SR_ |= 0x80000000;

      while (true)
      {
        if ((_SR_ & 0x00000001) == 0x00000001) break;
        try
        {
          r = Read(rbuf, 128);
        }
        catch (TimeoutException exp)
        {
        }

        if (r > 0)
        {
         
        }

        System.Diagnostics.Debug.WriteLine("DoRead");
        System.Threading.Thread.Sleep(1);
      }
      _SR_ &= 0x7FFFFFFE;
    }
    public Int32 Read(byte[] b, Int32 sz)
    {
      Int32 ecode = 0;

      ecode = _srl.Read(b, 0, sz);

      return ecode;
    }

    public Int32 Write(byte[] b, Int32 sz)
    {
      Int32 ecode = 0;

      _srl.Write(b, 0, sz);

      return ecode;
    }


  }

}
