using System;
using System.Runtime.InteropServices;

namespace kr.co.ztec.io
{
  unsafe public partial class Common
  {
    [DllImport("libio.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern Int32 hexsim(byte* a, byte* b);


    public Int32 HexSim(byte[] a, byte[] b)
    {
      fixed (byte* _a = a)
      fixed (byte* _b = b)
      {
        return hexsim(_a, _b);
      }
    }
  }
}
