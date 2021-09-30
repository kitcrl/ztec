
// mfcAppDlg.h : header file
//

#pragma once


// CmfcAppDlg dialog
class CmfcAppDlg : public CDialogEx
{
// Construction
public:
	CmfcAppDlg(CWnd* pParent = nullptr);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_MFCAPP_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
  CEdit m_edtInput1;
//  CString m_strInput1;
  CButton m_btnOK;
  afx_msg void OnClickedButton1_01();
  afx_msg void OnBnClickedButton2();
  CEdit m_edtInput2;
  CString m_strInput1;
  CString m_strInput2;
};
