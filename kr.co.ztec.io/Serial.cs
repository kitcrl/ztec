﻿using System;
using System.Runtime.InteropServices;

namespace kr.co.ztec.io
{
  unsafe public partial class Serial
  {
    private delegate Int32 OnCallbackRead(Int32 fd, byte[] b, Int32 sz);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate Int32 DlgtOnRead(void* h, Int32 fd, byte* b, Int32 sz);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_open(out void* h, byte* port, byte* brate, byte* dbit, byte* sbit, byte* pbit, UInt32 dlgt, void* o);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_close(out void* h, Int32 fd);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_read(void* h, Int32 fd, byte* b, Int32 sz);

    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 serial_write(void* h, Int32 fd, byte* b, Int32 sz);

    OnCallbackRead _callbackRead = null;
    DlgtOnRead _dlgtOnRead = null;
    UInt32 _dlgtPtr = 0;
    void* hdl = null;
    Int32 fd = 0;
    ISerial _isr = null;
    public Serial(ISerial _i)
    {
      _isr = _i;

      _dlgtOnRead = new DlgtOnRead(OnRead);
      _dlgtPtr = (UInt32)Marshal.GetFunctionPointerForDelegate(_dlgtOnRead);

      _callbackRead = new OnCallbackRead(CallbackRead);
    }

    public Int32 Open(string name, string baudrate, string databit, string stopbit, string parity)
    {
      Int32 e = 0;
      byte[] _name = new byte[32];
      byte[] _baudrate = new byte[32];
      byte[] _databit = new byte[32];
      byte[] _stopbit = new byte[32];
      byte[] _parity = new byte[32];

      _name = System.Text.Encoding.UTF8.GetBytes(name);
      _baudrate = System.Text.Encoding.UTF8.GetBytes(baudrate);
      _databit = System.Text.Encoding.UTF8.GetBytes(databit);
      _stopbit = System.Text.Encoding.UTF8.GetBytes(stopbit);
      _parity = System.Text.Encoding.UTF8.GetBytes(parity);

      fixed (byte* __name = _name)
      fixed (byte* __baudrate = _baudrate)
      fixed (byte* __databit = _databit)
      fixed (byte* __stopbit = _stopbit)
      fixed (byte* __parity = _parity)
      {
        this.fd = e = serial_open(out hdl, __name, __baudrate, __databit, __stopbit, __parity, _dlgtPtr, null);
      }

      return e;
    }

    public Int32 Close()
    {
      Int32 e = 0;
      serial_close(out hdl, this.fd);
      return e;
    }

    public Int32 Write(byte[] b, Int32 sz)
    {
      Int32 e = 0;
      fixed (byte* _b = b)
      {
        e = serial_write(hdl, this.fd, _b, sz);
      }
      return e;
    }

    private Int32 OnRead(void* h, Int32 fd, byte* b, Int32 sz)
    {
      Int32 e = 0;
      byte[] _b = new byte[sz];
      Marshal.Copy((IntPtr)b, _b, 0, sz);
      _callbackRead.Invoke(fd, _b, sz);
      return e;
    }

    private Int32 CallbackRead(Int32 fd, byte[] b, Int32 sz)
    {
      Int32 e = 0;
      e = _isr.Read(b, sz);
      return e;
    }

  }

}
