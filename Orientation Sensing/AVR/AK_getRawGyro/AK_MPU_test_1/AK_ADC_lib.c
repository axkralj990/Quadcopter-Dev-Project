/*
 * AK_ADC_lib.c
 *
 * Created: 9/2/2016 2:13:05 PM
 * Author : Aleksij
 */

#include <avr/io.h>
#include "AK_ADC_lib.h"

void init_ADC(uint8_t ADpin, uint8_t ADbitMode, uint8_t ADclkPrescale)
{
	ADMUX |= (1<<REFS0); //AVcc with external capacitor at AREF pin

	switch (ADbitMode) { // Select whether to use 8-bit or 10-bit ADC
		case 8: // 8-bit mode
		ADMUX |= (1<<ADLAR);
		break;
		case 10: // 10-bit mode
		ADMUX &= ~(1<<ADLAR);
		break;
		default:
		ADMUX &= ~(1<<ADLAR);
	}

	ADMUX &= ~(0b00001111); // reset MUX to all zeros
	switch (ADpin) { // Select which pin to use for ADC
		case 0:
		break;
		case 1:
		ADMUX |= (1<<MUX0);
		break;
		case 2:
		ADMUX |= (1<<MUX1);
		break;
		case 3:
		ADMUX |= (1<<MUX0) | (1<<MUX1);
		break;
		case 4:
		ADMUX |= (1<<MUX2);
		break;
		case 5:
		ADMUX |= (1<<MUX0) | (1<<MUX2);
		break;
	}

	ADCSRA |= (1<<ADEN); // ADC enable

	switch (ADclkPrescale) {
		case 2:
			ADCSRA |= (1<<ADPS0);
			break;
		case 4:
			ADCSRA |= (1<<ADPS1);
			break;
		case 8:
			ADCSRA |= (1<<ADPS0) | (1<<ADPS1);
			break;
		case 16:
			ADCSRA |= (1<<ADPS2);
			break;
		case 32:
			ADCSRA |= (1<<ADPS0) | (1<<ADPS2);
			break;
		case 64:
			ADCSRA |= (1<<ADPS1) | (1<<ADPS2);
			break;
		case 128:
			ADCSRA |= (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2) ;
			break;
		default:
			ADCSRA |= (1<<ADPS0) | (1<<ADPS1);
	}
	
}

void start_FreeRunning_ADC() {
	ADCSRA |= (1<<ADSC); // ADC start conversion
	ADCSRA |= (1<<ADATE); // Initialize free running mode
}

void start_SingleConversion_ADC() {
	//ADCSRA &= ~(1<<ADATE); // Disable free running mode
	ADCSRA |= (1<<ADSC); // ADC start conversion
	while((ADCSRA & (1<<ADSC)) != 0);
}

void stop_ADC() {
	ADCSRA &= ~(1<<ADSC); // ADC stop conversion
}

uint8_t read_ADC_8bit() {
	return ADCH;
}

uint16_t read_ADC_10bit() {
	return ADC;
}