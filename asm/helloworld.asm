SECTION .data
hello_msg db 'Hello, World!', 0ah

SECTION .text
global _start

_start:
mov edx, 13 ; Lengte van het bericht, 1 byte per karakter plus newline.
mov ecx, hello_msg ; Adres van het bericht.
mov ebx, 1 ; Schrijf naar stdout, de output dus.
mov eax, 4 ; Systeemoproepnummer voor sys_write, om tekst te schrijven.
int 80h

mov ebx, 0 ; Exit code 0, wat betekent dat het programma succesvol is beëindigd.
mov eax, 1 ; Systeemoproepnummer voor sys_exit, om het programma te beëindigen.
int 80h