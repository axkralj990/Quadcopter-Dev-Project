/*
 * AK_tictoc_lib.c
 *
 * Created: 9/20/2016 3:56:45 PM
 *  Author: Aleksij
 */ 

#include <avr/io.h>

void init_TICTOC()
{
	
	if (F_CPU == 8000000)
	{
		//TCCR1B |= (1<<CS11) | (1<<CS10); // clock prescaler 64
		TCCR1B |= (1<<CS11); // clock prescaler 8
	}
	else if (F_CPU == 16000000)
	{
		TCCR1B |= (1<<CS11) | (1<<CS10); // clock prescaler 64
	}
	else if (F_CPU == 1000000)
	{
		TCCR1B |= (1<<CS11); // clock prescaler 8
	}
	else
	{
		//TCCR1B |= (1<<CS11) | (1<<CS10); //default for 8MHz
		//TCCR1B |= (1<<CS11); // clock prescaler 64
		TCCR1B |= (1<<CS11); // clock prescaler 64
	}
	//TCCR1B |= (1<<CS11);
	//TCCR1B |= (1<<CS11) | (1<<CS10);
	// WGM -> NORMAL mode is default
	//TIMSK0 |= (1<<TOIE1); // Timer/Counter1 Overflow Interrupt Enable
}

void tic()
{
	TCNT1 = 0;
}

uint32_t toc()
{
	uint32_t micro_time = TCNT1;
	return micro_time;
}
