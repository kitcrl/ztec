#include <stdint.h>
#include <common.h>
#include <process.h>


#pragma pack(1)
typedef struct
{
  void* _h;
  uint32_t _tid;
  void* (*f)(void* o);
  void* o;
  uint32_t id;
  uint32_t _SR_;
} tagCThread;
#pragma pack()


void* _thread(void* arg)
{
  tagCThread* p;
  p = (tagCThread*)arg;

  xSET_SEMAPHORE(p->_SR_, 0x80000000, 0x80000000);
  while ( xCHECK_SEMAPHORE(p->_SR_, 0, 0x40000000) )
  {
    p->f(p->o);
  }
  xSET_SEMAPHORE(p->_SR_, 0, 0xC0000000);
  return 0;
}


__declspec(dllexport)
int32_t thread_stop(void** hdl)
{
  tagCThread* p;
  p = (tagCThread*)hdl;

  xSET_SEMAPHORE(p->_SR_, 0x40000000, 0x40000000);
  xGET_SEMAPHORE(p->_SR_, 0,0xC0000000, 500);

  free(*hdl);
  *hdl = 0;

  return 0;
}



__declspec(dllexport)
int32_t thread(void** hdl, void* (*f)(void*), void* arg)
{
  tagCThread* p;
  p = *hdl = (struct tagCThread*)calloc(1, sizeof(tagCThread));
  p->o = arg;
  p->f = f;
  xTHREAD_CREATE(_thread, p, &p->_tid, p->_h);
  xGET_SEMAPHORE(p->_SR_, 0x80000000, 0x80000000, 500);

  
  return hdl;
}
