SECTION .data
hello_msg db 'Hello, World! It is a beautiful day today.', 0ah

SECTION .text
global _start

_start:

mov ebx, hello_msg ; Laad het adres van het bericht in ebx.
mov eax, ebx ; Laad het adres van het bericht in eax, ze wijzen nu allebei naar hetzelfde segment in memory.

nextchar:
cmp byte [eax], 0 ;vergelijk de byte op het adres in eax met nul (het einde van de string).
jz finished ;Jump naar 'finished' als het nul is (einde van de string).
inc eax ; Verhoog het adres in eax om naar het volgende karakter te gaan.
jmp nextchar ; Herhaal de lus.

finished:
sub eax, ebx ; Bereken de lengte van het bericht door het startadres af te trekken van het eindadres.

mov edx, eax ; Lengte van het bericht, 1 byte per karakter plus newline, deze waarde komt uit de vorige berekening.
mov ecx, hello_msg ; Adres van het bericht.
mov ebx, 1 ; Schrijf naar stdout, de output dus.
mov eax, 4 ; Systeemoproepnummer voor sys_write, om tekst te schrijven.
int 80h

mov ebx, 0 ; Exit code 0, wat betekent dat het programma succesvol is beëindigd.
mov eax, 1 ; Systeemoproepnummer voor sys_exit, om het programma te beëindigen.
int 80h