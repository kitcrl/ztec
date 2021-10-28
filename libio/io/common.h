#ifndef __COMMON_H_47A493C2_76B5_4888_AB8B_39920491CE1D__
#define __COMMON_H_47A493C2_76B5_4888_AB8B_39920491CE1D__

#include <stdio.h>
#include <stdint.h>
#include <process.h>
#include <Windows.h>

#if defined __cplusplus
extern "C"
{
#endif

#define zDelay(ms)      Sleep(ms)

#define zTHREAD_CREATE(f,arg,id,r) \
( r = _beginthreadex \
              (0,0,(uint32_t(__stdcall*)(void*))f, \
              (void*)arg, 0, (uint32_t*)id ) ) 


#define zTHREAD_EXIT(a,r) \
{ \
  if (r) CloseHandle(r); \
  _endthreadex(a); }


#define xLOCK_INIT(crit)       InitializeCriticalSection((CRITICAL_SECTION*)(crit))
#define xLOCK_FINAL(crit)      DeleteCriticalSection((CRITICAL_SECTION*)(crit));
#define xLOCK(crit)            EnterCriticalSection((CRITICAL_SECTION*)(crit));
#define xUNLOCK(crit)          LeaveCriticalSection((CRITICAL_SECTION*)(crit));




#if defined __cplusplus
}
#endif

#endif