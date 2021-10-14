using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr.co.ztec.io
{
  public interface ISerial
  {
    Int32 Read(byte[] b, Int32 sz);
  }
}
