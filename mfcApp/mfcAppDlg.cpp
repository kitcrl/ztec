
// mfcAppDlg.cpp : implementation file
//

#include "pch.h"
#include "framework.h"
#include "mfcApp.h"
#include "mfcAppDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CmfcAppDlg dialog



CmfcAppDlg::CmfcAppDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_MFCAPP_DIALOG, pParent)
    , m_strInput1(_T(""))
  , m_strInput2(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CmfcAppDlg::DoDataExchange(CDataExchange* pDX)
{
  CDialogEx::DoDataExchange(pDX);
  DDX_Control(pDX, IDC_EDIT1, m_edtInput1);
  DDX_Text(pDX, IDC_EDIT1, m_strInput1);
  DDX_Control(pDX, IDC_BUTTON1, m_btnOK);
  DDX_Control(pDX, IDC_EDIT2, m_edtInput2);
  //  DDX_Text(pDX, IDC_EDIT2, m_strInput1);
  DDX_Text(pDX, IDC_EDIT2, m_strInput2);
}

BEGIN_MESSAGE_MAP(CmfcAppDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
    ON_BN_CLICKED(IDC_BUTTON1, &CmfcAppDlg::OnClickedButton1_01)
  ON_BN_CLICKED(IDC_BUTTON2, &CmfcAppDlg::OnBnClickedButton2)
END_MESSAGE_MAP()


// CmfcAppDlg message handlers

BOOL CmfcAppDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
  m_strInput1 = TEXT("Hello");
  UpdateData(FALSE);
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CmfcAppDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CmfcAppDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CmfcAppDlg::OnClickedButton1_01()
{
  UpdateData(TRUE);
  m_strInput2 = m_strInput1;
  m_strInput1 = TEXT("");
  UpdateData(FALSE);
}


void CmfcAppDlg::OnBnClickedButton2()
{
  UpdateData(TRUE);
  m_strInput1 = m_strInput2;
  m_strInput2 = TEXT("");
  UpdateData(FALSE);

}
