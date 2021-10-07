#include <stdio.h>
#include <serial.h>

void main()
{
  int32_t fd;

  fd = serial_open(0,0,0,0,0);


  serial_close(fd);

}