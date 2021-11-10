using System;

namespace kr.asef.net.apif.Common
{
  unsafe public partial class CxsTimer : System.Timers.Timer
  {

    public CxsTimer()
    {

    }

    public void start()
    {
      this.AutoReset = true;
      this.Start();
    }

    public void stop()
    {
      this.AutoReset = false;
      this.Stop();
      this.Close();
    }
  }
}
