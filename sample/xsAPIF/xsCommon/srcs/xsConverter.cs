using System;
using System.Collections.Generic;
using System.Text;

namespace kr.asef.net.apif.Common
{
  unsafe public partial class CxsConverter
  {

    public CxsConverter()
    {

    }

    public void BytesToBigEndian(byte [] dst, byte [] src, int len)
    {
      int j=0;
      for ( int i=len-1 ; i>=0 ; i--, j++)
      {
        dst[j] = src[i];
      }
    }

    public void IntToBytes(byte [] dst, int src, int start)
    {
      dst[3 + start] = (byte)((src & 0xFF000000) >> 24);
      dst[2 + start] = (byte)((src & 0x00FF0000) >> 16);
      dst[1 + start] = (byte)((src & 0x0000FF00) >> 8);
      dst[0 + start] = (byte)((src & 0x000000FF));
    }

    //public int ByteArrayToInt(byte[] src, int start)
    //{
    //  return (int)( (src[3 + start]<<24) + (src[2 + start]<<16) + (src[1 + start]<<8) + (src[0 + start]) );
    //}

    public int BytesToHex(byte[] src, int len)
    {
      int e = 0;
      int[] b = new int[6];
      int i = 0;

      for (i = 0; i < len; i++)
      {
        if (src[i] >= 0x30 && src[i] <= 0x39)  // 48 ~ 57 0 ~ 9
        {
          e += (src[i] - 0x30) << (4 * (len - i - 1));
        }
        else if (src[i] >= 0x41 && src[i] <= 0x46) // 65 ~ 70 A ~ F
        {
          e += (src[i] - 0x41 + 10) << (4 * (len - i - 1));
        }
        else if (src[i] >= 0x61 && src[i] <= 0x66) // 97 ~ a ~ f
        {
          e += (src[i] - 0x61 + 10) << (4 * (len - i - 1));
        }
      }
      return e;
    }


    public int BytesToInt(byte[] src, int len)
    {
      int e = 0;
      int[] b = new int[6];
      int i = 0;
      int ii = 0;
      int d = 1;
      for (i = 0; i < len; i++)
      {
        for ( d=1, ii=0 ; ii<(len-i-1) ; ii++ )
        {
          d = 10*d;
        }


        if (src[i] >= 0x30 && src[i] <= 0x39)  // 48 ~ 57 0 ~ 9
        {
          e += (src[i] - 0x30) * d;
        }
        else if (src[i] >= 0x41 && src[i] <= 0x46) // 65 ~ 70 A ~ F
        {
          e += (src[i] - 0x41 + 10) * d;
        }
        else if (src[i] >= 0x61 && src[i] <= 0x66) // 97 ~ a ~ f
        {
          e += (src[i] - 0x61 + 10) * d;
        }
      }
      return e;
    }




    public int StringToSBytes(sbyte[] dst, string src)
    {
      //ASCIIEncoding encoding = new ASCIIEncoding();
      byte[] ba = Encoding.Default.GetBytes(src);
      int len = ba.GetLength(0);
      for (int i = 0; i < ba.GetLength(0); i++)
      {
        dst[i] = (sbyte)ba[i];
      }
      return len;
    }

    public string BytesToString(byte[] src, int len)
    {
      //return System.Text.ASCIIEncoding.ASCII.GetString(src);
      return System.Text.Encoding.Default.GetString(src, 0, len);
    }


    public string StringToHex(string arg)
    {
      byte[] str = StringToBytes(arg);
      string result = "";
      foreach (byte ch in str)
      {
        result += string.Format("{0:x2} ", ch);
      }

      return result;
    }

    public byte [] StringToBytes(string src)
    {
      //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
      //return encoding.GetBytes(src);
      return Encoding.Default.GetBytes(src);
    }

    public string SBytesToString(sbyte[] src, int len)
    {
      string ret = null;

      fixed (sbyte* psb = src)
      {
        ret = new string(psb, 0, len);
      }

      return ret;
    }


    public string ConvertToHex(byte[] msg, int len)
    {
      int i;
      string _msg = null;
      for (i = 0; i < len; i++)
      {
        _msg += string.Format("{0:x02} ", msg[i]);
      }
      return _msg;
    }


    public string ConvertToASCII(string str)
    {
      byte [] uni = Encoding.Unicode.GetBytes(str);
      byte [] asc = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, uni);
      return Encoding.ASCII.GetString(asc);
    }
  }
}
