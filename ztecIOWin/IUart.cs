using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecIOWin
{
  public interface IUart
  {
    Int32 OnRead(byte[] b, Int32 sz);
  }
}
