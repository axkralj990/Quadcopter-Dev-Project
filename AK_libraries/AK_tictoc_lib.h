/*
 * AK_tictoc_lib.h
 *
 * Created: 9/20/2016 3:56:28 PM
 *  Author: Aleksij
 */ 

/* AK_tictoc_lib is used to time events with a resolution
of 8us. It was written for purposes of controlling RC servo
signals.
NOTE: Return value from function toc() overflows at 524280us!
*/

void init_TICTOC();
/* 
init_TICTOC() initializes the 16-bit timer for time
measurement and enables the overflow interrupt.
*/

void tic();
/*
tic() resets the TCNT1 register.
*/

uint32_t toc();
/*
toc() returns the elapsed time since the call of tic().
Return type is an unsigned 32-bit integer.
*/