using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace kr.co.ztec.io
{
  class csTimer
  {
    IcsTimer _itmr;
    System.Timers.Timer tmr = new System.Timers.Timer();

    public csTimer(IcsTimer _i, Int32 ms)
    {
      _itmr = _i;
      tmr.Interval = ms;
      tmr.Elapsed += new ElapsedEventHandler(timer_event);
      tmr.Start();
    }
    public void timer_event(object sender, ElapsedEventArgs e)
    {
      _itmr.OnTimeOut();      
    }
  }
}
