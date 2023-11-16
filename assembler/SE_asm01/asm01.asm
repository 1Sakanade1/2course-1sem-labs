.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST 

Arr sdword 3, 2, 6, 8, 

.DATA

str1 DB "Lab_17", 0
str2 DB "Min =   ; Max =   ", 0

MB_OK EQU 0	
HW DWORD ?

min sdword ?
max sdword ?

.CODE

main PROC
START:

; - - - - - - - - - - - - - -  Test getMin - - - - - - - - - - - -

push lengthof Arr
push offset Arr

call getMin
mov min, eax

; - - - - - - - - - - - - - -  Test getMax - - - - - - - - - - - -
push lengthof Arr
push offset Arr
call getmax
mov max, eax

; - - - - - - - - - - - - - -  Write Result - - - - - - - - - - -
    mov eax, min;
	add eax, 30h;
	mov str2 + 6, al;
	
	mov eax, max;
	add eax, 30h;
	mov str2 + 16, al;
    INVOKE MessageBoxA, HW, offset str2,offset str1, 0

push 0
call ExitProcess
main ENDP

; - - - - - - - - - - - - - -  procedure getMin - - - - - - - - - 

getMin PROC uses ecx esi ebx, parm01: dword, parm02: dword

      mov   ecx, parm02
      mov   esi, parm01
      mov   eax, [esi]

CYCLE: 

      mov   ebx, [esi]
      add   esi, 4
      cmp   eax, ebx
      jl    False
      xchg  eax, ebx

False: 

      loop  CYCLE

	  ret

getMin ENDP

; - - - - - - - - - - - - - -  procedure getMax - - - - - - - - - 

getMax PROC uses ecx esi ebx, parm01: dword, parm02: dword

      mov   ecx, parm02
      mov   esi, parm01
      mov   eax, [esi]

CYCLE: 

      mov   ebx, [esi]
      add   esi, 4
      cmp   eax, ebx
      jg    False
      xchg  eax, ebx

False: 

      loop  CYCLE

	  ret

getMax ENDP

END main