﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr.co.ztec.io
{
  struct cBuffer
  {
    public byte[][] b;
    public int tail;
    public int head;
  };

  class csBuffer
  {
    public cBuffer [] _b;
    public csBuffer(Int32 tcount, Int32 count, Int32 size)
    {
      int i;
      int j;
      _b = new cBuffer[tcount];

      for (j = 0; j < tcount; j++)
      {
        _b[j].b = new byte[count][];
        _b[j].head = _b[j].tail = 0;
        for (i = 0; i < count; i++)
        {
          _b[j].b[i] = new byte[size];
        }
      }
    }
  }
}
