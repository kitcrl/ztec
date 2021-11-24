using System;

namespace kr.co.ztec.io
{
  public interface ISocket
  {
    Int32 Read(Int32 fd, byte[] b, Int32 sz, UInt32 err);
    Int32 Status(Int32 fd, byte[] b, Int32 sz, UInt32 err);
  }
}
