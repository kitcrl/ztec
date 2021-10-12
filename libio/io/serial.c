#include <stdint.h>
#include <common.h>

int32_t (*on_serial_read)(int32_t fd, int8_t* b, int32_t sz);

void* serial_proc(void* arg)
{
  int32_t e = 0;
  while ( 1 )
  {
    e = (*on_serial_read)(0, "1234", 4);
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
int32_t serial_open(int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy, int32_t (*f)(int32_t fd, int8_t* b, int32_t sz) )
{
  int32_t e = 0;
  uint32_t tid = 0;
  void* r = 0;


  on_serial_read = f;


  zTHREAD_CREATE(serial_proc, 0, &tid, r);

  return e;
}

__declspec(dllexport)
int32_t serial_close(int32_t fd)
{
  int32_t e = 0;

  return e;
}

__declspec(dllexport)
int32_t serial_read(int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;

  return e;
}

__declspec(dllexport)
int32_t serial_write(int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;

  return e;
}