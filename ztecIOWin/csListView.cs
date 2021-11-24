using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ztecIOWin
{
  public class csListView : ListView
  {
    ColumnHeader[] ch;
    public csListView()
    {
    }

    public void CreateColumn(UInt32 count)
    {
      int i = 0;
      ch = new ColumnHeader[count];
      for (i = 0; i < count; i++)
      {
        ch[i] = new ColumnHeader();
      }
    }

    public void ColumnHeaderText(UInt32 idx, string title, UInt32 sz)
    {
      ch[idx].Text = title;
      this.Columns.Add(ch[idx]);
      this.Columns[(int)idx].Width = (int)sz;
    }


    public int GetEmptyRow()
    {
      int e = 0;
      int i = 0;

      for (i = 0; i < this.Items.Count; i++)
      {
        if (this.Items[i].SubItems[0].Text.Equals("") == true)
        {
          e = i;
          break;
        }
      }
      return e;
    }

    public int InsertText(string text)
    {
      int e = -1;
      int idx = GetEmptyRow();
      InsertText(idx, 1, text);
      return e;
    }


    private int InsertText(int row, int col, string text)
    {
      int e = -1;
      int i = 0;
      string[] items = new string[this.Columns.Count];
      ListViewItem lvi;
      for (i = 0; i < this.Columns.Count; i++)
      {
        items[i] = "";
      }
      lvi = new ListViewItem(items, null, System.Drawing.Color.Empty, System.Drawing.Color.Empty, null);

      //lvi = this.Items[row];
      lvi.SubItems[0].Text = string.Format("{0:d}", row);
      lvi.SubItems[col].Text = text;
      this.Items.Insert(row, lvi);

      return e;
    }





  }
}
