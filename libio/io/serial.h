#ifndef __SERIAL_H_47A493C2_76B5_4888_AB8B_39920491CE1D__
#define __SERIAL_H_47A493C2_76B5_4888_AB8B_39920491CE1D__

#include <stdint.h>

#if defined __cplusplus
extern "C"
{
#endif
int32_t serial_open(int8_t* port, int8_t* baudrate, int8_t* databit, int8_t* stopbit, int8_t* paritiy);
int32_t serial_close(int32_t fd);
int32_t serial_read(int32_t fd, int8_t* b, int32_t sz);
int32_t serial_write(int32_t fd, int8_t* b, int32_t sz);
#if defined __cplusplus
}
#endif

#endif