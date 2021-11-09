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

  xSET_SEMAPHORE(p->_SR_, p->id, p->id);
  while ( xCHECK_SEMAPHORE(p->_SR_, 0, (p->id)>>1) )
  {
    p->f(p->o);
  }
  xSET_SEMAPHORE(p->_SR_, 0, p->id|((p->id)>>1));
  return 0;
}


__declspec(dllexport)
int32_t thread_stop(void** hdl)
{
  tagCThread* p;
  p = (tagCThread*)hdl;

  xSET_SEMAPHORE(p->_SR_, (p->id)>>1, (p->id)>>1);
  xGET_SEMAPHORE(p->_SR_, 0, p->id|((p->id)>>1), 500);

  return 0;
}



__declspec(dllexport)
int32_t thread(void** hdl, void* (*f)(void*), void* arg, uint32_t id)
{
  tagCThread* p;
  p = *hdl = (struct tagCThread*)calloc(1, sizeof(tagCThread));
  p->id = id;
  p->o = arg;
  p->f = f;
  xTHREAD_CREATE(_thread, p, &p->_tid, p->_h);
  xGET_SEMAPHORE(p->_SR_, p->id, p->id, 500);

  
  return hdl;
}
