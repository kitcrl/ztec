using System;
using System.Runtime.InteropServices;

namespace kr.co.ztec.io
{

  struct cBuffer
  {
    public byte[][] b;
    public int idx;
  };

  unsafe public partial class Socket
  {
    private delegate Int32 OnCallback(Int32 fd, byte[] b, Int32 sz, UInt32 err);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate Int32 DlgtOnCallback(void* h, Int32 fd, byte* b, Int32 sz, UInt32 err, void* o);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 socket_open(out void* h, byte* ip, byte* port, byte* cstype, byte* protocol, byte* casttype, UInt32[] dlgt, void* o);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 socket_close(out void* h);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 socket_read(void* h, Int32 fd, byte* b, Int32 sz);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 socket_write(void* h, Int32 fd, byte* b, Int32 sz);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 socket_readfrom(void* h, Int32 fd, byte* b, Int32 sz, UInt32 addr);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 socket_writeto(void* h, Int32 fd, byte* b, Int32 sz, UInt32 addr);

    OnCallback[] _callback;
    DlgtOnCallback[] _dlgtOnCallback;
    UInt32[] _dlgtPtr;

    void* hdl = null;
    Int32 fd;
    ISocket _isck = null;
    cBuffer[] _buf = new cBuffer[32];

    Int32 CLIENT_COUNT = 32;
    Int32 BUFFER_COUNT = 128;
    Int32 BUFFER_SIZE = 256;

    public Socket(ISocket _i)
    {
      int i = 0;
      int j = 0;
      _isck = _i;

      for (i = 0; i < CLIENT_COUNT; i++)
      {
        _buf[i] = new cBuffer();
        _buf[i].idx = 0;
        _buf[i].b = new byte[BUFFER_COUNT][];
        for (j = 0; j < BUFFER_COUNT; j++)
          _buf[i].b[j] = new byte[BUFFER_SIZE];
      }


      _dlgtOnCallback = new DlgtOnCallback[2];
      _dlgtOnCallback[0] = new DlgtOnCallback(onStatus);
      _dlgtOnCallback[1] = new DlgtOnCallback(onRead);

      _dlgtPtr = new UInt32[2];
      _dlgtPtr[0] = (UInt32)Marshal.GetFunctionPointerForDelegate(_dlgtOnCallback[0]);
      _dlgtPtr[1] = (UInt32)Marshal.GetFunctionPointerForDelegate(_dlgtOnCallback[1]);

      _callback = new OnCallback[2];
      _callback[0] = new OnCallback(dlgtStatus);
      _callback[1] = new OnCallback(dlgtRead);
    }

    public Int32 Open(string ip, string port, string cstype, string protocol, string casttype)
    {
      Int32 e = 0;
      byte[] _ip = new byte[32];
      byte[] _port = new byte[32];
      byte[] _cstype = new byte[32];
      byte[] _protocol = new byte[32];
      byte[] _casttype = new byte[32];

      _ip = System.Text.Encoding.UTF8.GetBytes(ip);
      _port = System.Text.Encoding.UTF8.GetBytes(port);
      _cstype = System.Text.Encoding.UTF8.GetBytes(cstype);
      _protocol = System.Text.Encoding.UTF8.GetBytes(protocol);
      _casttype = System.Text.Encoding.UTF8.GetBytes(casttype);

      fixed (byte* __ip = _ip)
      fixed (byte* __port = _port)
      fixed (byte* __cstype = _cstype)
      fixed (byte* __protocol = _protocol)
      fixed (byte* __casttype = _casttype)
      {
        this.fd = e = socket_open(out hdl, __ip, __port, __cstype, __protocol, __casttype, _dlgtPtr, null);
      }

      return e;
    }

    public Int32 Close()
    {
      Int32 e = 0;
      socket_close(out hdl);
      return e;
    }

    public Int32 Write(Int32 fd, byte[] b, Int32 sz)
    {
      Int32 e = 0;
      fixed (byte* _b = b)
      {
        e = socket_write(hdl, fd, _b, sz);
      }
      return e;
    }

    private Int32 onRead(void* h, Int32 fd, byte* b, Int32 sz, UInt32 err, void* o)
    {
      Int32 e = 0;
      byte[] _b = new byte[sz];
      if (sz > 0)
      {
        Marshal.Copy((IntPtr)b, _b, 0, sz);
        _callback[1].Invoke(fd, _b, sz, err);
      }
      return e;
    }

    private Int32 onStatus(void* h, Int32 fd, byte* b, Int32 sz, UInt32 err, void* o)
    {
      Int32 e = 0;
      byte[] _b = new byte[sz];

      /*
       * err == 0xE000FDAA,
       * o -->  string....
       * fd:ip:port
       */

      if ((err & 0xFFFFFFF0) == 0xE000FDA0)
      {
        if (sz > 0)
        {
          Marshal.Copy((IntPtr)b, _b, 0, sz);
        }
      }
      else if (err == 0xE000FD10 || err == 0xE000101B || err == 0xE0001010)
      {
        fixed (byte* __b = this._buf[sz].b[this._buf[sz].idx])
        {
          this._buf[sz].b[this._buf[sz].idx][0] = 0x08;
          *(byte**)b = __b;

          if (err != 0xE000101B)
          {
            this._buf[sz].idx++;
            this._buf[sz].idx %= BUFFER_COUNT;
          }
        }
      }



      _callback[0].Invoke(fd, _b, sz, err);
      return e;
    }



    private Int32 dlgtRead(Int32 fd, byte[] b, Int32 sz, UInt32 err)
    {
      Int32 e = 0;
      e = _isck.Read(fd, b, sz, err);
      return e;
    }

    private Int32 dlgtStatus(Int32 fd, byte[] b, Int32 sz, UInt32 err)
    {
      Int32 e = 0;
      e = _isck.Status(fd, b, sz, err);
      return e;
    }



  }

}
