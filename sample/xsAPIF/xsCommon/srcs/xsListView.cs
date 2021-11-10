using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace kr.asef.net.apif.Common
{
  public class CxsListView : ListView
  {
    public int MAX_COUNT = 1024;
    private ListViewItem li;
    private int X = 0;
    private int Y = 0;
    private string subItemText;
    private int subItemSelected = 0;
    private System.Windows.Forms.TextBox editBox = new System.Windows.Forms.TextBox();
    private int [] editableIndex;
    ColumnHeader[] ch;
    object lstLock = new object();

    public CxsListView()
    {
      this.DoubleClick += new System.EventHandler(this.lvDoubleClick);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvMouseDown);

      editBox.Size = new System.Drawing.Size(0, 0);
      editBox.Location = new System.Drawing.Point(0, 0);
      this.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
      editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
      editBox.LostFocus += new System.EventHandler(this.FocusOver);
      editBox.Font = this.Font;//new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      editBox.BackColor = Color.LightGray;
      editBox.BorderStyle = BorderStyle.FixedSingle;
      editBox.Hide();
      editBox.Text = "";

      //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
      //this.UpdateStyles();
    }

    public void SetEditableRows(params object [] args)
    {
      int i;
      editableIndex = new int[args.Length];
      for ( i=0 ; i<args.Length ; i++ )
      {
        editableIndex[i] = (int)args[i];
      }
    }

    public void CreateColumn(int count)
    {
      ch = new ColumnHeader[count];
      for (int i = 0; i < count; i++)
      {
        ch[i] = new ColumnHeader();
      }
    }

    public void AddColumnHeader(int index, string val, int width)
    {
      ch[index].Text = val;
      this.Columns.Add(ch[index]);
      if ( width > 0 )
      {
        this.Columns[index].Width = width;
      }
    }

    public int GetEmptyRow()
    {
      int i = 0;
      lock ( lstLock )
      {
        if ( this.Items.Count > MAX_COUNT )
        {
          DeleteRow(-1);
          return 0;
        }

        for (; i < this.Items.Count; i++)
        {
          if (this.Items[i].SubItems[0].Text.Equals("") == true)
          {
            return i;
          }
        }
      }
      return i;
    }



    public string GetText(int row, int col)
    {
      if ( row >= this.Items.Count )
      {
        return null;
      }
      return this.Items[row].SubItems[col].Text;
    }


    public int InsertText(int col, string text)
    {
      int empty_row = GetEmptyRow();

      lock(lstLock)
      {
        InsertText(empty_row, col, text);
      }
      return empty_row;
    }


    public void DeleteRow(int row)
    {
      int i=0;
      if ( row == -1 )
      {
        for ( i=this.Items.Count-1 ; i>=0 ; i-- )
        {
          this.Items.RemoveAt(i);
        }
      }
      else
      {
        this.Items.RemoveAt(row);
      }
    }


    public void InsertText(int row, int col, string text)
    {
      string[] item_string = new string[this.Columns.Count];

      lock(lstLock)
      {
        for (int i = 0; i < this.Columns.Count; i++)
        {
          item_string[i] = "";
        }

        ListViewItem lvi = new ListViewItem(item_string, null, System.Drawing.Color.Empty, System.Drawing.Color.Empty, null);
        if (this.Items.Count > 0)
        {
          if (this.Items.Count != row)
          {
            lvi = this.Items[row];
            this.Items.RemoveAt(row);
          }
        }
        lvi.SubItems[col].Text = text;
        this.Items.Insert(row, lvi);
        this.Items[this.Items.Count - 1].EnsureVisible();
      }
    }


    private void EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        li.SubItems[subItemSelected].Text = editBox.Text;
        editBox.Hide();
      }

      if (e.KeyChar == 27)
        editBox.Hide();
    }

    private void FocusOver(object sender, System.EventArgs e)
    {
      li.SubItems[subItemSelected].Text = editBox.Text;
      editBox.Hide();
    }


    public void lvMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      li = this.GetItemAt(e.X, e.Y);
      X = e.X;
      Y = e.Y;
    }


    public void lvDoubleClick(object sender, System.EventArgs e)
    {
      // Check the subitem clicked .
      int nStart = X;
      int spos = 0;
      int epos = this.Columns[0].Width;
      int i;

      for (i = 0; i < this.Columns.Count; i++)
      {
        if (nStart > spos && nStart < epos)
        {
          subItemSelected = i;
          break;
        }

        spos = epos;
        if ( i <= this.Columns.Count-1 )
        {
          epos += this.Columns[i+1].Width;
        }
      }

//      Console.WriteLine("SUB ITEM SELECTED = " + li.SubItems[subItemSelected].Text);
      subItemText = li.SubItems[subItemSelected].Text;


      try
      {
        for (i = 0; i < editableIndex.Length; i++)
        {
          if (subItemSelected == editableIndex[i])
          {
            Rectangle r = new Rectangle(spos, li.Bounds.Y, epos, li.Bounds.Bottom);
            editBox.Size = new System.Drawing.Size(epos - spos, li.Bounds.Bottom - li.Bounds.Top);
            editBox.Location = new System.Drawing.Point(spos, li.Bounds.Y);
            editBox.Show();
            editBox.Text = subItemText;
            editBox.SelectAll();
            editBox.Focus();
          }
        }
      }
      catch (Exception)
      {

        //throw;
      }
    }

  }
}
