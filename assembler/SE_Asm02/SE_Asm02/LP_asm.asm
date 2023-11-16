.586
.model flat, stdcall
includelib libucrt.lib
includelib kernel32.lib
includelib ..\Generation\Debug\GenLib.lib

ExitProcess PROTO:DWORD 
.stack 4096

 outnum PROTO : DWORD

 outstr PROTO : DWORD

 sqroot PROTO : DWORD

 module PROTO : DWORD

 input PROTO : DWORD

.const
		printline byte 13, 10, 0
		x sdword 12
		 sdword 0
.data
		temp sdword ?
		buffer byte 256 dup(0)
.code

;----------- MAIN ------------
main PROC
push x

pop ebx
mov x, ebx


push x
call outnum

pop edx
pop ebx
;------------------------------

push 0
call ExitProcess
main ENDP
end main
