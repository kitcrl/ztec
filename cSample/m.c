#include <Windows.h>
#include <stdio.h>
#include <stdint.h>

typedef struct
{
  void*  hmodule;

  int32_t fd;
  int32_t (*serial_open)(int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy);
  int32_t (*serial_close)(int32_t fd);
  int32_t (*serial_read)(int32_t fd, int8_t* b, int32_t sz);
  int32_t (*serial_write)(int32_t fd, int8_t* b, int32_t sz);
}tagIO;


void main()
{

  tagIO _io;

  memset(&_io, 0, sizeof(tagIO));

  _io.hmodule = LoadLibrary("libio.dll");
  if ( _io.hmodule == 0 )
  {
    printf("libio.dll load fail \r\n");
    return 0;
  }
  printf("libio.dll load success \r\n");


  *(FARPROC*)&_io.serial_open = GetProcAddress(_io.hmodule, "serial_open");
  if ( _io.serial_open == 0 )
  {
    printf("serial_open load fail\r\n");
  }
  else
  {
    printf("serial_open load success \r\n");
  }

  *(FARPROC*)&_io.serial_close = GetProcAddress(_io.hmodule, "serial_close");
  *(FARPROC*)&_io.serial_write = GetProcAddress(_io.hmodule, "serial_write");


  _io.fd = _io.serial_open("COM3", "115200", "8", "0", "0");



  printf("Press Any Key to Close ......\r\n");
  getch();




  _io.serial_close(_io.fd);
}