#include <stdint.h>
#include <Windows.h>
#include "resource.h"

enum
{
  _IDC_BUTTON1,
  _IDC_TOTAL
};

HWND item[_IDC_TOTAL];
BOOL fxWM_INITDIALOG(HWND hwnd, UINT msg, WPARAM wparam, LPARAM lparam)
{
  item[_IDC_BUTTON1] = GetDlgItem(hwnd, IDC_BUTTON1);
  SetWindowText(item[_IDC_BUTTON1], "CLOSE");
  return TRUE;
}

BOOL fxWM_COMMAND(HWND hwnd, UINT msg, WPARAM wparam, LPARAM lparam)
{
  switch(LOWORD(wparam))
  {
    case IDC_BUTTON1:
      MessageBox(hwnd, "button", "BUTTON", MB_OK);
      break;
  }
  return TRUE;
}

BOOL CALLBACK dlgproc(HWND hwnd, UINT msg, WPARAM wparam, LPARAM lparam)
{
  switch(msg)
  {
    case WM_INITDIALOG:
      fxWM_INITDIALOG(hwnd,msg,wparam,lparam);
      break;

    case WM_COMMAND:
      fxWM_COMMAND(hwnd,msg,wparam,lparam);
      break;

    case WM_CLOSE:
      PostQuitMessage(0);
      break;
  }
  return FALSE;
}

int32_t WINAPI WinMain(HINSTANCE hinst, HINSTANCE hpinst, LPSTR cmd, int32_t nshow)
{
  DialogBox(hinst, (LPCSTR)IDD_DIALOG1, HWND_DESKTOP, (DLGPROC)dlgproc);
  return TRUE;
}