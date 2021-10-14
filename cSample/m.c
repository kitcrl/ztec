#include <Windows.h>
#include <stdio.h>
#include <stdint.h>

typedef struct
{
  void*  hmodule;

  int32_t fd;
  int32_t (*serial_open)(void**, int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy, int32_t (*f)(int32_t,int8_t*,int32_t), void*);
  int32_t (*serial_close)(void**, int32_t fd);
  int32_t (*serial_read)(void*, int32_t fd, int8_t* b, int32_t sz);
  int32_t (*serial_write)(void*, int32_t fd, int8_t* b, int32_t sz);

  void* hSerial;
}tagIO;


int32_t on_serial_callback(void* h, int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;

  printf("on_serial_callback( %d, %s, %d );\r\n", fd, b, sz);

  return e;  /// 0 : NORMAL,  0<e : .....,   0>e : ....
}



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


  _io.fd = _io.serial_open(&_io.hSerial, "COM3", "115200", "8", "0", "0", on_serial_callback, &_io);



  printf("Press Any Key to Close ......\r\n");
  getch();




  _io.serial_close(&_io.hSerial, _io.fd);


  printf("Press Any Key to Continue ......\r\n");
  getch();



}