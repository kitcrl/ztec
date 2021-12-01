using kr.co.ztec.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecIOWin
{

  class zSerial : kr.co.ztec.io.ISerial
  {
    kr.co.ztec.io.Serial _serial;
    IUart _iuart;

    public zSerial(IUart i)
    {
      _iuart = i;
      _serial = new kr.co.ztec.io.Serial(this);
    }

    public Int32 Open(string name, string baudrate)
    {
      return _serial.Open(name, baudrate, "8", "0", "1");
    }

    public Int32 Close()
    {
      return _serial.Close();
    }

    public Int32 Write(byte[] b, int sz)
    {
      return _serial.Write(b, sz);
    }
    public int Read(byte[] b, int sz)
    {
      _iuart.OnRead(b, sz);
      return 0;
    }
  }
}
