#include <stdint.h>

__declspec(dllexport)
int32_t hexsim(uint8_t* a, uint8_t* b)
{
  int32_t i = 0;
  srand(time(0));
  for (i = 0; *a; a++, b++, i++)
  {
    if ((*(a) == 'X') || (*(a) == 'x') || (*(a) == '?'))
    {
      *b = (rand() % 16);
      *b = (((*b >= 0) && (*b <= 9)) ? *b + 0x30 : *b + 0x37);
    }
    else if (*a != ' ')
    {
      *b = *a;
    }
    else
    {
      b--;
      i--;
    }
  }
  *b = 0;
  return i;
}
