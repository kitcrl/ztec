using System;
using System.Threading.Tasks;

namespace kr.co.ztec.util
{
  public delegate void dlgtOnRead(byte[] b, Int32 sz);

  public class Serial
  {

    /****
     * +----+----+ +----+----+ +----+----+ +----+----+
     * +----+----+ +----+----+ +----+----+ +----+----+
     *  ^                                           ^
     *  |                                           |
     *  |                                           +------ 1 : Thread Stop Request
     *  |
     *  +-------------------------------------------------- 1 : in Thread
    ****/
    protected UInt32 _SR_ = 0;
    protected System.Threading.Thread _thread;
    protected System.IO.Ports.SerialPort sport = new System.IO.Ports.SerialPort();

    public dlgtOnRead _dlgtOnRead;
    public ISerial _isrl = null;
    public Serial(ISerial isrl)
    {
      SetInterface(isrl);
      _dlgtOnRead = new dlgtOnRead(OnCallbackRead);
    }

    public void SetInterface(ISerial isrl)
    {
      this._isrl = isrl;
    }

    public Int32 Open(string port, string baudrate)
    {
      Int32 eCode = 0;

      sport.PortName = port;
      sport.BaudRate = System.Int32.Parse(baudrate);
      sport.DataBits = 8;

      sport.Open();
      if (sport.IsOpen)
      {
        sport.ReadTimeout = 0;
        _thread = new System.Threading.Thread(
                      new System.Threading.ThreadStart(DoRead));
        _thread.Start();
        eCode = 1;
      }
      return eCode;
    }

    public Int32 Close()
    {
      Int32 eCode = 0;

      if (sport.IsOpen)
      {
        _SR_ |= 0x00000001;
        for (; (_SR_&0x00000001)==0x00000001 ; );
        sport.Close();
        eCode = 1;
      }
      return eCode;
    }

    public void OnCallbackRead(byte[] b, Int32 sz)
    {
      if (_isrl != null) _isrl.Read(b, sz);
    }


    public void DoRead()
    {
      Int32 r = 0;
      byte[] rbuf = new byte[128];
      _SR_ |= 0x80000000;
      while (true)
      {
        if ((_SR_ & 0x00000001) == 0x00000001) break;

        System.Diagnostics.Debug.WriteLine("DoRead");
        try
        {
          r = Read(rbuf, 128);
        }
        catch (TimeoutException exp)
        {

        }
        if (r > 0)
        {
          if ( _dlgtOnRead != null ) _dlgtOnRead.Invoke(rbuf, r);
        }
        System.Threading.Thread.Sleep(1);
      }
      _SR_ &= 0x7FFFFFFE;
    }

    public Int32 Read(byte[] b, Int32 sz)
    {
      Int32 eCode = 0;
      eCode = this.sport.Read(b, 0, sz);
      return eCode;
    }

    public Int32 Write(byte[] b, Int32 sz)
    {
      Int32 eCode = 0;
      this.sport.Write(b, 0, sz);
      return eCode;
    }



  }
}
