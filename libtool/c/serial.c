#include <stdint.h>

#if defined __cplusplus
extern "C"
#endif
#if defined WIN32
__declspec(dllexport)
#endif
int32_t serial_open(int8_t* comport,int8_t* bautrate,int8_t* databit,int8_t* stopbit,int8_t* parity)
{
  int32_t e = 0;

  return e;
}

#if defined __cplusplus
extern "C"
#endif
#if defined WIN32
__declspec(dllexport)
#endif
int32_t serial_close(int32_t fd)
{
  int32_t e = 0;

  return e;
}

#if defined __cplusplus
extern "C"
#endif
#if defined WIN32
__declspec(dllexport)
#endif
int32_t serial_write(int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;

  return e;
}

#if defined __cplusplus
extern "C"
#endif
#if defined WIN32
__declspec(dllexport)
#endif
int32_t serial_read(int32_t fd, int8_t* b, int32_t sz)
{
  int32_t e = 0;

  return e;
}

