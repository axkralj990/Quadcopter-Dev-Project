/*
 * AK_ADC_lib.h
 *
 * Created: 9/2/2016 2:15:41 PM
 *  Author: Aleksij
 */

void init_ADC(uint8_t ADpin, uint8_t ADbitMode, uint8_t ADclkPrescale);
/* init_ADC() initializes the ADC
ADpin -> select the ADx port to which a sensor is connected
	0: AD0, 1: AD1, 2: AD2, 3: AD3, 4: AD4, 5: AD5
ADbitMode -> select between the two modes, 8-bit or 10-bit ADC
	0: 8-bit mode, 1: 10-bit mode
ADclkPrescale -> select the clock prescaler !!!Speeds above 200kHZ are not guaranteed to work!!!
	Prescales 2, 4, 8, 16, 32, 64
*/

void start_FreeRunning_ADC();
/* start_FreeRunnning_ADC() starts the analog2digital free-running conversion */

void start_SingleConversion_ADC();
/* start_SingleConversion_ADC() starts the analog2digital single conversion */

void stop_ADC();
/* stop_ADC() stops the analog2digital conversion */

uint8_t read_ADC_8bit();
/* read_ADC_8bit() reads the ADCH register for the 8-bit ADC value*/

uint16_t read_ADC_10bit();
/* read_ADC_10bit() reads the ADC register for the 10-bit ADC value*/