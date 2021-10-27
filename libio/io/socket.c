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
  *  ^^   ^^
  *  ||   ||
  *  ||   |+-------------------------------------------- 1 : Reader Stop Request
  *  ||   +--------------------------------------------- 1 : Reader in Thread
  *  ||
  *  |+------------------------------------------------- 1 : accepter stop
  *  +-------------------------------------------------- 1 : accepter in thread
****/


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

  void*    _thr[SOCKET_CALLBACK];
  uint32_t _tid[SOCKET_CALLBACK];
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



void* socket_accepter(void* arg)
{
  int32_t e = 0;
  int8_t b[32] = {0};
  struct sockaddr client = {0};
  struct sockaddr_in* pc = &client;
  int32_t csz = sizeof(struct sockaddr_in);
  int32_t cfd = 0;
  int32_t cbinfo[1024] = {0};
  tagCSocket* p = (tagCSocket*)arg;

  p->_SR_ |= 0x80000000;
  while ( (p->_SR_&0x40000000) == 0x00000000 )
  {
    p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDAB, 0);
    cfd = accept(p->fd, &client, &csz);
    if ( cfd > 0 )
    {
      sprintf(cbinfo, "%d:%d.%d.%d.%d:%d",cfd,
              (pc->sin_addr.s_addr&0x000000FF),
              (pc->sin_addr.s_addr&0x0000FF00)>>8,
              (pc->sin_addr.s_addr&0x00FF0000)>>16,
              (pc->sin_addr.s_addr&0xFF000000)>>24,
              htons(pc->sin_port));
    }
    p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDAA, cfd>0?cbinfo:0);
    zDelay(1);
  }
  p->_SR_ &= 0x3FFFFFFF;
  CloseHandle(p->_thr[0]);
  return 0;
}



void* socket_reader(void* arg)
{
  int32_t e = 0;
  int8_t b[1024] = {0};
  tagCSocket* p = (tagCSocket*)arg;

  p->_SR_ |= 0x08000000;
  while ( (p->_SR_&0x04000000) == 0x00000000 )
  {
    p->callback[SOCKET_ON_READ](p->o, p->fd, 0, 0, 0xE000101B, 0);

    p->callback[SOCKET_ON_READ](p->o, p->fd, 0, 0, 0xE000101A, 0);
    zDelay(1);
  }
  p->_SR_ &= 0xF3FFFFFF;
  CloseHandle(p->_thr[1]);
  return 0;
}



int32_t socket_option(int32_t fd)
{
  uint64_t  opt = 1;
  ioctlsocket(fd, FIONBIO, &opt);
  return 0;
}

__declspec(dllexport)
int32_t socket_open(void** h, int32_t (*callback[])(void*,int32_t,int8_t*,int32_t,int32_t,void*), void* o)
{
  int32_t e = 0;
	WSADATA wsaData = {0};
  tagCSocket* p = 0;

	if ( WSAStartup(0x202, &wsaData) != 0 ) return 0xE0000001;

  p = *h = (tagCSocket*)calloc(1, sizeof(tagCSocket));

  p->callback[SOCKET_ON_STATUS] = callback[SOCKET_ON_STATUS];
  p->callback[SOCKET_ON_READ]   = callback[SOCKET_ON_READ];
  p->o = o;

  p->callback[SOCKET_ON_STATUS](p->o, 0, 0, 0, 0xE000FD0B, 0);
  p->fd = socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);
  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FD0A, 0);

  socket_option(p->fd);

  p->_in.sin_family = AF_INET;
  p->_in.sin_addr.s_addr = htonl(INADDR_ANY);
  p->_in.sin_port = htons(7810);


  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDBB, 0);
  e = bind(p->fd, (struct sockaddr*)&(p->_in), sizeof(struct sockaddr));
  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDBA, 0);

  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FD7B, 0);
  listen(p->fd, 5);
  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FD7A, 0);

  ////// create thread
  zTHREAD_CREATE(socket_accepter, p, &p->_tid[0], p->_thr[0]);
  zTHREAD_CREATE(socket_reader, p, &p->_tid[1], p->_thr[1]);
  while ( 1 ) if( (p->_SR_&0x88000000) == 0x88000000 ) break;



  return e;
}

__declspec(dllexport)
int32_t socket_close(void** h)
{
  int32_t e = 0;
  tagCSocket* p = (tagCSocket*)(*h);

  p->_SR_|=0x44000000;
  while ( 1 ) if ( (p->_SR_&0xCC000000) == 0x00000000 ) break;

  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDCB, 0);
  shutdown(p->fd, SD_BOTH);
  closesocket(p->fd);
  p->callback[SOCKET_ON_STATUS](p->o, p->fd, 0, 0, 0xE000FDCA, 0);

  if ( *h )
  {
    free(*h);
    *h = 0;
  }
	WSACleanup();

  return e;
}
