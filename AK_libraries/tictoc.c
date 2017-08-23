/*
 * tictoc.c
 *
 * Created: 11/7/2016 9:01:53 PM
 * Author : Aleksij
 */ 



#include <avr/io.h>
#include "tictoc.h"
#include <avr/interrupt.h>

volatile uint32_t timer_us = 0, timer_ms = 0;

void init_tictoc()
{
	TCCR0A |= (1<<WGM01);
	OCR0A = 250;
	// Set 64 clock prescaller on timer 0
	TCCR0B |= (1<<CS01) | (1<<CS00);
	// Set Timer/Counter0 Overflow interrupt Enable
	TIMSK0 |= (1<<OCIE0A);
	// Global interrupt enable
	sei();
	TCNT0 = 0;
}

void tic()
{
	TCNT0 = 0;
	timer_us = 0;
	timer_ms = 0;
}

uint32_t millis()
{
	return timer_ms;
}

uint32_t micros()
{
	timer_us = (millis()*1000) + (TCNT0*4);
	return timer_us;
}

ISR(TIMER0_COMPA_vect)
{
	timer_ms += 1;
}