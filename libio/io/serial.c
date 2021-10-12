#include <stdint.h>
#include <common.h>

void* serial_proc(void* arg)
{
  while ( 1 )
  {
    printf("serial_proc \r\n");
    zDelay(1000);
  }
  return 0;
}

__declspec(dllexport)
int32_t serial_open(int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy)
{
  int32_t e = 0;
  uint32_t tid = 0;
  void* r = 0;

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