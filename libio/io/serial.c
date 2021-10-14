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
} tagZSerial;
#pragma pack()



__declspec(dllexport)
int32_t serial_read(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;
  int32_t r = 0;
  tagZSerial* p = (tagZSerial*)h;

	e = ReadFile((HANDLE)fd, (LPWSABUF)b, sz,	&r,	0);

  return r;
}

__declspec(dllexport)
int32_t serial_write(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;
  int32_t w = 0;
  tagZSerial* p = (tagZSerial*)h;

	e = WriteFile((HANDLE)fd, b, (DWORD)sz, &w, 0);
  return w;
}


void* serial_proc(void* arg)
{
  int32_t e = 0;
  int8_t b[32] = {0};
  tagZSerial* p = (tagZSerial*)arg;
  printf("Thread Start 1 \r\n");
  p->_SR_ |= 0x80000000;
  printf("Thread Start 2 \r\n");
  while ( (p->_SR_&0x00000001) == 0x00000000 )
  {
    e = serial_read(p, p->fd, b, 32);

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
    zDelay(1000);
  }
  p->_SR_ &= 0x7FFFFFFE;
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
__declspec(dllexport)
int32_t serial_open(void** h, int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* parity, int32_t (*f)(int32_t fd, int8_t* b, int32_t sz), void* o)
{
  int32_t e = 0;
  uint32_t tid = 0;
  tagZSerial* p = 0;


  e = dev_open(port, baudrate, databit, stopbit, parity);
  if ( e < 0 ) return 0xEFFFFFFF;


  *h = (tagZSerial*)calloc(1, sizeof(tagZSerial));

  p = (tagZSerial*)(*h);

  p->fd = e;

  p->on_serial_read = f;
  p->o = o;

  zTHREAD_CREATE(serial_proc, p, &p->_tid, p->_thr);
  printf("Thread Start Request 1 \r\n");
  while ( (p->_SR_&0x80000000) == 0x00000000 );
  printf("Thread Start Request 2 \r\n");

  return e;
}

__declspec(dllexport)
int32_t serial_close(void** h, int32_t fd)
{
  int32_t e = 0;
  tagZSerial* p = 0;
  p = (tagZSerial*)(*h);


  p->_SR_|=0x00000001;
  while ( 1 )
  {
    if ( (p->_SR_&0x80000001) == 0x00000000 ) break;
  }

  if (*h)
  {
    free(*h);
    *h = 0;
  }



	CloseHandle(fd);
	WSACleanup();

  return e;
}

