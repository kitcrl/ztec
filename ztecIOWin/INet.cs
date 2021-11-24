using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecIOWin
{
  public interface INet
  {
    Int32 OnRead(Int32 fd, byte[] b, Int32 sz, UInt32 err);
    Int32 OnStatus(Int32 fd, byte[] b, Int32 sz, UInt32 err);
  }
}
