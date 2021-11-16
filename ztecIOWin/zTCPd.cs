using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecIOWin
{
  class zTCPd : kr.co.ztec.io.ISocket
  {
    kr.co.ztec.io.Socket _socket;
    INet _inet;
    public Int32 fd = 0;
    public zTCPd(INet i)
    {
      _inet = i;
      _socket = new kr.co.ztec.io.Socket(this);
    }

    public Int32 Open(string port, string cstype)
    {
      return fd = _socket.Open("127.0.0.1", port, cstype, "TCP", "UNICAST");
    }

    public Int32 Close()
    {
      return _socket.Close();
    }


    public int Read(int fd, byte[] b, int sz, int err)
    {
      int e = 0;

      e = _inet.OnRead(fd, b, sz, err);

      return e;
    }

    public int Status(int fd, byte[] b, int sz, int err)
    {
      int e = 0;
      e = _inet.OnStatus(fd, b, sz, err);
      return e;
    }
  }
}
