using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztecWApp
{
  class ztButton : System.Windows.Forms.Button
  {
    public ztButton(string ftext="ztButton")
    {
      this.BackColor = System.Drawing.Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
      this.ForeColor = System.Drawing.Color.FromArgb(0xFF, 0xFF, 0xFF, 0x00);
      this.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Font = new System.Drawing.Font("Courier New", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Size = new System.Drawing.Size(117, 92);
      this.TabIndex = 0;
      this.Text = ftext;

    }

  }
}
