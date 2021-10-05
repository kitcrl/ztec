using System;

namespace kr.co.ztec.util
{
  public interface ISerial
  {
    void Read(byte[] b, Int32 sz);
  }
}
