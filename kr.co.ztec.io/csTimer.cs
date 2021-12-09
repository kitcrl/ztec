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
    System.Timers.Timer tmr = new System.Timers.Timer();

    public csTimer(Int32 ms)
    {
      tmr.Interval = ms;
      tmr.Elapsed += new ElapsedEventHandler(timer_event);
      tmr.Start();
    }


    public void timer_event(object sender, ElapsedEventArgs e)
    {
      
    }
  }
}
