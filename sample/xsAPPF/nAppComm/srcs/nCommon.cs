using System;
using System.Collections.Generic;

namespace nAppComm
{
  unsafe public class CCommon
  {
    public char sysMode;
    public char dispType;
    public List<int>   masterList = new List<int>();

    public string READY = "READY";
    public string OPEN =  "OPEN";
    public string CONNECT = "CONNECT";
    public string CLOSE   = "CLOSE";
    public string DISCONNECT = "DISCONNECT";
    public string TRANSFER = "TRANSFER";
    public string DONE = "DONE";
    public string FAILED = "FAILED";
    public string HELLO = "HELLO";
    public string FINE  = "FINE";
    public string SLEEPY = "SLEEPY";

    nAPIF.CConverter cvt;

    public CCommon()
    {
      cvt = new nAPIF.CConverter();
    }

    public void AddToMasterList(int sd)
    {
      masterList.Add(sd);
    }

    public void DeleteFromMasterList(int sd)
    {
      int i = masterList.Count;
      int idx = masterList.IndexOf(sd);

      if ( idx >= 0 )  masterList.RemoveAt(idx);
    }



    public string GetValue(string str, char pfx, char sfx)
    {
      sbyte[] tgt_str = new sbyte[str.Length];
      sbyte[] retval = new sbyte[str.Length];
      int retval_i = 0;
      string ret_str = null;
      int i = 0;
      int tot_len = 0;
      cvt.StringToSByteArray(tgt_str, str);
      for (i = 0; i < str.Length; i++)
      {
        if (tgt_str[i] == pfx)
        {
          i++;
          break;
        }
      }
      if (i == str.Length) return null;
      tot_len = (str.Length - i);
      for (retval_i = 0; retval_i < tot_len; retval_i++)
      {
        if (tgt_str[i] == sfx)
        {
          break;
        }
        retval[retval_i] = tgt_str[i];
        i++;
      }

      fixed (sbyte* psb = retval)
      {
        ret_str = new string(psb, 0, retval_i);
      }
      return ret_str;
    }
  }
}
