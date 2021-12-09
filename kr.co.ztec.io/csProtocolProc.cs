using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace kr.co.ztec.io
{
  class csProtocolProc
  {
    public byte[] buf;
    public UInt32 pos;
    public csProtocolProc(Int32 sz)
    {
      buf = new byte[sz];
      pos = 0;
    }


    public Int32 AssignBuffer(byte[] s, Int32 sz)
    {
      Int32 e = 0;

      s.CopyTo(buf, pos);
      string item = System.Text.Encoding.UTF8.GetString(buf);
      System.Diagnostics.Debug.WriteLine(item);


      string dbg = string.Format("{0:d} {1:X02} {2:X02}", pos, buf[pos], buf[pos + 1]);
      System.Diagnostics.Debug.WriteLine("-------------------------");
      System.Diagnostics.Debug.WriteLine(dbg);
      System.Diagnostics.Debug.WriteLine("-------------------------");



      for (; pos < sz; pos++)
      {
        if (buf[pos] == '\r' && buf[pos + 1] == '\n' && buf[pos + 2] == '\r' && buf[pos + 3] == '\n')
        {
          e = (Int32)pos;
          pos = 0;
          break;
        }
      }
      return e;
    }





  }
}
