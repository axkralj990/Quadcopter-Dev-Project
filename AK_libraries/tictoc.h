/*
 * tictoc.h
 *
 * Created: 11/7/2016 9:02:36 PM
 *  Author: Aleksij
 */ 

/* tictoc is used to time events with a resolution
of 4us. It was written for purposes of controlling and reading RC servo
signals.
*/

void init_tictoc();
/*
init_TICTOC() initializes the 8-bit timer for time
measurement and enables the overflow interrupt.
*/

void tic();
/*
tic() resets the TCNT0 register.
*/

uint32_t millis();
/*
toc() returns the elapsed time since the call of tic() in ms.
Return type is an unsigned 32-bit integer.
*/

uint32_t micros();