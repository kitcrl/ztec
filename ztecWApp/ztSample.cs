using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecWApp
{
  class ztSample
  {
    private int value;
    private int item;
    private DateTime tm;

    public int Value
    {
      set
      {
        this.value = value;
      }
      get
      {
        return this.value;
      }
    }
    public int Item
    {
      get
      {
        return this.item;
      }
    }



  }
}
