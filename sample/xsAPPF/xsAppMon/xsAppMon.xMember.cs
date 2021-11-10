using System;
using System.Collections.Generic;
using System.Text;

namespace xsAppMon
{
  public delegate void DlgtCallbackProc(byte[] msg, int len);

  public partial class xsAppMon
  {
    kr.asef.net.apif.xsAXIF.socket.xsSocket sock;
    kr.asef.net.apif.Common.CxsConverter cvt;

    public DlgtCallbackProc dlgtCallbackProc = null;
    public kr.asef.net.apif.xsAXIF.socket.xsSocket.DlgtOnConnStatus dlgtConnStatus = null;
    public kr.asef.net.apif.xsAXIF.socket.xsSocket.DlgtOnRecv       dlgtRecv = null;

  }
}
