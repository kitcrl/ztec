#include <stdint.h>
#include <common.h>

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

} tagZSerial;
#pragma pack()

void* serial_proc(void* arg)
{
  int32_t e = 0;
  tagZSerial* p = (tagZSerial*)arg;
  zDelay(4000);
  printf("Thread Start 1 \r\n");
  p->_SR_ |= 0x80000000;
  printf("Thread Start 2 \r\n");
  while ( (p->_SR_&0x00000001) == 0x00000000 )
  {
    e = (*p->on_serial_read)(p->o, 0, "1234", 4);
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

__declspec(dllexport)
int32_t serial_open(void** h, int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy, int32_t (*f)(int32_t fd, int8_t* b, int32_t sz) )
{
  int32_t e = 0;
  uint32_t tid = 0;
  tagZSerial* p = 0;

  *h = (tagZSerial*)calloc(1, sizeof(tagZSerial));

  p = (tagZSerial*)(*h);

  p->on_serial_read = f;


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

  return e;
}

__declspec(dllexport)
int32_t serial_read(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;
  tagZSerial* p = (tagZSerial*)h;

  return e;
}

__declspec(dllexport)
int32_t serial_write(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;
  tagZSerial* p = (tagZSerial*)h;

  return e;
}