using System;
using System.Collections.Generic;
using System.Text;

namespace kr.asef.net.apif.Common
{
  public class CxsRegistryKey
  {
    Microsoft.Win32.RegistryKey key;
    private string subkey_pfx = "ASE";

    public CxsRegistryKey(string pfx)
    {
      subkey_pfx = pfx;
    }

    public void Write(string sub, string id, string param)
    {
      key = Microsoft.Win32.Registry.CurrentUser;

      key = key.CreateSubKey( @"Software\" + subkey_pfx + "\\" + sub,
                              Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

      key.SetValue(id, param);
    }

    public string Read(string sub, string id)
    {
      key = Microsoft.Win32.Registry.CurrentUser;

      key = key.CreateSubKey( @"Software\" + subkey_pfx + "\\" + sub,
                              Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

      return (string)key.GetValue(id);
    }
  }
}
