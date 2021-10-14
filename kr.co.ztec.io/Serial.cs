using System;
using System.Runtime.InteropServices;

namespace kr.co.ztec.io
{
  unsafe public partial class Serial
  {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate Int32 DlgtOnRead(void* h, Int32 fd, byte* b, Int32 sz);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_open(out void* h, byte* port, byte* brate, byte* dbit, byte* sbit, byte* pbit, DlgtOnRead dlgt, IntPtr o);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_close(out void* h, Int32 fd);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_read(void* h, Int32 fd, byte* b, Int32 sz);


    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_write(void* h, Int32 fd, byte* b, Int32 sz);


    public Serial()
    {

    }

    public Int32 Open(string name, string baudrate, string databit, string stopbit, string parity)
    {
      Int32 e = 0;

      return e;
    }

    public Int32 Close()
    {
      Int32 e = 0;

      return e;
    }

    public Int32 Write(byte[] b, Int32 sz)
    {
      Int32 e = 0;

      return e;
    }



  }

}
