#include <stdint.h>
#include <WinSock2.h>
#include <common.h>
#pragma comment(lib, "ws2_32.lib")

enum
{
  SOCKET_ON_STATUS,
  SOCKET_ON_READ,
  SOCKET_CALLBACK,
};


/****
  * +----+----+ +----+----+ +----+----+ +----+----+
  * +----+----+ +----+----+ +----+----+ +----+----+
     1110 0000   0000 0000    F     D      0    B
                              F     D      0    A
                              F     D      B    B
                              F     D      B    A
                              1     0      0    B
                              1     0      0    A
                              1     0      1    B
                              1     0      1    A
  0xE000FD0B
  0xE000FD0A
  0xE000100B
  0xE000100A
  0xE000101B
  0xE000101A
****/


#pragma pack(1)
typedef struct
{
  int32_t (*callback[SOCKET_CALLBACK])(void* h, int32_t fd, int8_t* b, int32_t sz, int32_t err, void* o);
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
int32_t socket_open(void** h, int32_t (*callback[])(void*,int32_t,int8_t*,int32_t,int32_t,void*), void* o)
{
  int32_t e = 0;
	WSADATA wsaData = {0};
  tagCSocket* p;

	if ( WSAStartup(0x202, &wsaData) != 0 ) return 0xE0000001;

  p = *h = (tagCSocket*)calloc(1, sizeof(tagCSocket));

  p->callback[SOCKET_ON_STATUS] = callback[SOCKET_ON_STATUS];
  p->callback[SOCKET_ON_READ]   = callback[SOCKET_ON_READ];
  p->o = o;

  p->callback[SOCKET_ON_STATUS](p->o, 0, 0, 0, 0xE000FD0B, 0);
  p->fd = socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);
  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FD0A, 0);

  p->_in.sin_family = AF_INET;
  p->_in.sin_addr.s_addr = htonl(INADDR_ANY);
  p->_in.sin_port = htons(7810);


  p->callback[SOCKET_ON_STATUS](p->o, 0, 0, 0, 0xE000FDBB, 0);
  e = bind(p->fd, (struct sockaddr*)&(p->_in), sizeof(struct sockaddr));
  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDBA, 0);

  listen(p->fd, 5);

  {
    struct sockaddr client = {0};
    struct sockaddr_in* pc = &client;
    int32_t csz = sizeof(struct sockaddr_in);
    int32_t cfd = 0;
    cfd = accept(p->fd, &client, &csz);

    printf( " -> client ip   : %d.%d.%d.%d\r\n"
            " -> client port : %d\r\n"
            " -> client fd   : %d\r\n"
            " -> server fd   : %d\r\n",
              (pc->sin_addr.s_addr&0x000000FF),
              (pc->sin_addr.s_addr&0x0000FF00)>>8,
              (pc->sin_addr.s_addr&0x00FF0000)>>16,
              (pc->sin_addr.s_addr&0xFF000000)>>24,
              pc->sin_port,
              cfd,
              p->fd);

  }


  return e;
}

__declspec(dllexport)
int32_t socket_close(void** h)
{
  int32_t e = 0;
  tagCSocket* p = (tagCSocket*)(*h);

  shutdown(p->fd, SD_BOTH);
  closesocket(p->fd);

  if ( *h )
  {
    free(*h);
    *h = 0;
  }
	WSACleanup();

  return e;
}
