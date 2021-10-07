#ifndef __SERIAL_H_6130E086_680C_4B98_A2CD_28A078ADA1E6__
#define __SERIAL_H_6130E086_680C_4B98_A2CD_28A078ADA1E6__

#include <stdint.h>

int32_t serial_open(int8_t*,int8_t*,int8_t*,int8_t*,int8_t*);
int32_t serial_close(int32_t);
int32_t serial_write(int32_t, int8_t*, int32_t);
int32_t serial_read(int32_t, int8_t*, int32_t);


#endif