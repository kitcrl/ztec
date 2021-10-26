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

  printf(" server socket ---> %d \r\n", p->fd);

  p->_in.sin_family = AF_INET;
  p->_in.sin_addr.s_addr = htonl(INADDR_ANY);
  p->_in.sin_port = htons(7810);


  e = bind(p->fd, (struct sockaddr*)&(p->_in), sizeof(struct sockaddr));

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
