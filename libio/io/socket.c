#include <stdint.h>
#include <WinSock2.h>
#include <common.h>
#pragma comment(lib, "ws2_32.lib")



#pragma pack(1)
typedef struct
{
  int32_t (*on_read)(void* h, int32_t fd, int8_t* b, int32_t sz);
  void*    o;
  void*    _thr;
  uint32_t _tid;
  uint32_t _SR_;
  int32_t  fd;

  struct sockaddr_in  _in;

} tagCSocket;
#pragma pack()


__declspec(dllexport)
int32_t socket_read()
{
  int32_t e = 0;

  return e;
}

__declspec(dllexport)
int32_t socket_write()
{
  int32_t e = 0;

  return e;
}

__declspec(dllexport)
int32_t socket_open(void** h)
{
  int32_t e = 0;
	WSADATA wsaData = {0};
  tagCSocket* p;

	if ( WSAStartup(0x202, &wsaData) != 0 ) return 0xE0000001;

  p = *h = (tagCSocket*)calloc(1, sizeof(tagCSocket));


  p->fd = socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);

  p->_in.sin_family = AF_INET;
  p->_in.sin_addr.s_addr = htonl(INADDR_ANY);
  p->_in.sin_port = htons(7810);


  e = bind(p->fd, (struct sockaddr*)&(p->_in), sizeof(struct sockaddr));
  

  listen(p->fd, 5);

  return e;
}

__declspec(dllexport)
int32_t socket_close(void** h)
{
  int32_t e = 0;
  tagCSocket* p = (tagCSocket*)(*h);

  shutdown(p->fd, SD_BOTH);
  close(p->fd);

  if ( *h )
  {
    free(*h);
    *h = 0;
  }
	WSACleanup();

  return e;
}
