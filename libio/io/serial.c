#include <stdint.h>
#include <common.h>

#pragma pack(1)
typedef struct
{
  int32_t (*on_serial_read)(void* h, int32_t fd, int8_t* b, int32_t sz);
  void*    o;
} tagZSerial;
#pragma pack()

void* serial_proc(void* arg)
{
  int32_t e = 0;
  tagZSerial* p = (tagZSerial*)arg;

  while ( 1 )
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
  return 0;
}

__declspec(dllexport)
int32_t serial_open(void** h, int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy, int32_t (*f)(int32_t fd, int8_t* b, int32_t sz) )
{
  int32_t e = 0;
  uint32_t tid = 0;
  void* r = 0;
  tagZSerial* p = 0;

  *h = (tagZSerial*)calloc(1, sizeof(tagZSerial));

  p = (tagZSerial*)(*h);

  p->on_serial_read = f;


  zTHREAD_CREATE(serial_proc, p, &tid, r);

  return e;
}

__declspec(dllexport)
int32_t serial_close(void** h, int32_t fd)
{
  int32_t e = 0;

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