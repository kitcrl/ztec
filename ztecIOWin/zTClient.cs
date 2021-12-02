using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecIOWin
{
  struct clientInfo
  {
    public Int32 fd;
    public Int32 ip;  //  192.168.0.10   ->   C0 A8 00 0A
    public Int32 port;
    public byte[] rb;
    //public byte[] wb;
  };
  class zTClient
  {
    public Int32 MAX_CLIENT = 256;
    public Int32 MAX_BUF_SZ = 1024;
    public Int32 MAX_BUF_COUNT = 128;
    public clientInfo[] cinfo;
    public zTClient()
    {
      cinfo = new clientInfo[MAX_CLIENT];
    }
    public void Init()
    {
      Int32 i = 0;

      for (i = 0; i < MAX_CLIENT; i++)
      {
        cinfo[i].fd = 0;
        cinfo[i].ip = 0;
        cinfo[i].port = 0;
        cinfo[i].rb = new byte[MAX_BUF_SZ * MAX_BUF_COUNT];
      }
    }
    public Int32 Set(Int32 fd, string ip, Int32 port)
    {
      Int32 e = -1;
      Int32 i = 0;

      for (i = 0; i < MAX_CLIENT; i++)
      {
        if (cinfo[i].fd == 0)
        {
          cinfo[i].fd = fd;
          cinfo[i].port = port;
          e = i;
          break;
        }
      }
      return e;
    }

    public Int32 Reset(Int32 fd)
    {
      Int32 e = -1;
      Int32 i = 0;

      for (i = 0; i < MAX_CLIENT; i++)
      {
        if (cinfo[i].fd == fd)
        {
          cinfo[i].fd = 0;
          cinfo[i].ip = 0;
          cinfo[i].port = 0;
          e = i;
          break;
        }
      }
      return e;
    }

    public Int32 GetFD(Int32 index)
    {
      if (index >= MAX_CLIENT && index < 0) return -1;
      return cinfo[index].fd;
    }

    public Int32 GetIndex(Int32 fd)
    {
      Int32 e = -1;
      Int32 i = 0;

      for (i = 0; i < MAX_CLIENT; i++)
      {
        if (cinfo[i].fd == fd)
        {
          e = i;
          break;
        }
      }
      return e;
    }


  }
}
