#include <stdio.h>
#include <winsock2.h>
#include <common.h>
#pragma comment(lib, "ws2_32.lib")

/****
  * +----+----+ +----+----+ +----+----+ +----+----+
  * +----+----+ +----+----+ +----+----+ +----+----+
  *  ^                                           ^
  *  |                                           |
  *  |                                           +------ 1 : Thread Stop Request
  *  |
  *  +-------------------------------------------------- 1 : in Thread
****/


#pragma pack(1)
typedef struct
{
  int32_t (*on_serial_read)(void* h, int32_t fd, int8_t* b, int32_t sz);
  void*    o;
  void*    _thr;
  uint32_t _tid;
  uint32_t _SR_;
  int32_t  fd;
} tagCSerial;
#pragma pack()

__declspec(dllexport)
int32_t serial_read(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;
  int32_t r = 0;
  tagCSerial* p = (tagCSerial*)h;

	e = (int32_t)ReadFile((HANDLE)fd, (LPWSABUF)b, sz,	&r,	0);

  return r;
}

__declspec(dllexport)
int32_t serial_write(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;
  int32_t w = 0;
  tagCSerial* p = (tagCSerial*)h;

	e = WriteFile((HANDLE)fd, b, (DWORD)sz, &w, 0);
  return w;
}


void* serial_reader(void* arg)
{
  int32_t e = 0;
  int8_t b[32] = {0};
  tagCSerial* p = (tagCSerial*)arg;
  xSET_SEMAPHORE(p->_SR_, 0x80000000, 0x80000000);
  while ( xCHECK_SEMAPHORE(p->_SR_, 0x40000000, 0x40000000) )
  {
    e = serial_read(p, p->fd, b, 32);
    if ( e > 0 )
    {
      e = (*p->on_serial_read)(p->o, p->fd, b, e);
      if ( e < 0 )
      {

      }
      else if ( e > 0 )
      {

      }
      else
      {

      }
    }
    zDelay(1);
  }
  xSET_SEMAPHORE(p->_SR_, 0x00000000, 0xC0000000);
  CloseHandle(p->_thr);
  return 0;
}


int32_t dev_open(int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* parity)
{
  int32_t e = 0;
  int32_t fd = 0;
  uint8_t _name[32] = {0};

	WSADATA wsaData = {0};
	COMMTIMEOUTS comTimeOut = {0};                   
	DCB		dcb = {0};

  memset(_name, 0, 32);
	sprintf(_name, "\\\\.\\%s", port);

	if ( WSAStartup(0x202, &wsaData) != 0 ) return 0xE0000001;


  fd = CreateFile(_name,GENERIC_READ|GENERIC_WRITE,0,0,OPEN_EXISTING,0,0);

	SetCommMask(fd,EV_RXCHAR);
	SetupComm(fd,81920,81920);
	PurgeComm(fd,PURGE_TXABORT|PURGE_TXCLEAR|PURGE_RXABORT|PURGE_RXCLEAR);

  /// Blocking or Non-Blocking
	comTimeOut.ReadIntervalTimeout         = 0xFFFFFFFF;
	
	SetCommTimeouts(fd,&comTimeOut);

	dcb.DCBlength = sizeof(DCB);

	if ( !GetCommState(fd, &dcb)) return 0xE0000002;

	dcb.BaudRate = atoi(baudrate);
	dcb.ByteSize = (uint8_t)atoi(databit);
	dcb.Parity   = (uint8_t)atoi(parity);
	dcb.StopBits = (uint8_t)atoi(stopbit)==1?0:atoi(stopbit)==2?1:0;

	if( !SetCommState(fd, &dcb) ) return 0xE0000003;

	return fd;
}

int32_t dev_close(int32_t fd)
{
  CloseHandle(fd);
	WSACleanup();
  return 0;
}

__declspec(dllexport)
int32_t serial_open(void** h, int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* parity, int32_t (*f)(int32_t fd, int8_t* b, int32_t sz), void* o)
{
  int32_t e = 0;
  uint32_t tid = 0;
  tagCSerial* p = 0;


  e = dev_open(port, baudrate, databit, stopbit, parity);
  if ( e < 0 ) return 0xEFFFFFFF;


  p = *h = (tagCSerial*)calloc(1, sizeof(tagCSerial));

  p->fd = e;

  p->on_serial_read = f;
  p->o = o;

  xTHREAD_CREATE(serial_reader, p, &p->_tid, p->_thr);
  xGET_SEMAPHORE(p->_SR_, 0x80000000, 0x80000000, 500);

  return e;
}

__declspec(dllexport)
int32_t serial_close(void** h, int32_t fd)
{
  int32_t e = 0;
  tagCSerial* p = 0;
  p = (tagCSerial*)(*h);

  xSET_SEMAPHORE(p->_SR_,0x40000000,0x40000000);
  xGET_SEMAPHORE(p->_SR_,0x00000000,0xC0000000,500);
  dev_close(fd);


  if (*h)
  {
    free(*h);
    *h = 0;
  }



  return e;
}

