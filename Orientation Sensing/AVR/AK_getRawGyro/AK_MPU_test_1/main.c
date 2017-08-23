/*
 * AK_MPU_test_1.c
 *
 * Created: 9/18/2016 12:24:07 PM
 * Author : Aleksij
 */ 

#include <avr/io.h>
#include "AK_MPU6050_lib.h"
#include <avr/power.h>
#include <util/delay.h>
#include "USART.h"
#include <stdlib.h>
#include "i2c_master.h"

void statusLED(uint8_t status);

int main(void)
{
	uint8_t timing_bit = 0;
	int16_t gyr[3];
	char gyrX_str[16], gyrY_str[16], gyrZ_str[16];
	
	// set status LED as output
	DDRB |= (1<<DDB5);
	
	initUSART();
	clock_prescale_set(clock_div_1); // set clock to 16MHz
	MPU6050_init();
	
	MPU6050_set_accelFS(3);
	
	if (MPU6050_test_I2C()) {
		printLine("=== IMU working properly ===");
		statusLED(1);
	}
	else {
		statusLED(1);
		printLine("=== IMU ERROR ===");
		for(uint8_t i = 0; i < 50; i++){
			statusLED(0);
			_delay_ms(50);
			statusLED(1);
			_delay_ms(50);
			printString(".");
		}
	}
	
	printLine("Calibrating Gyro...");
	MPU6050_auto_set_gyro_bias();
	printLine("Calibration OK");
	
	/*
	MPU6050_set_gyroFS() set the gyro full scale range.
	gyroFS:
	0 - 250 deg/s, 131 LSB/(deg/s)
	1 - 500 deg/s, 65.5 LSB/(deg/s)
	2 - 1000 deg/s, 32.8 LSB/(deg/s)
	3 - 2000 deg/s, 16.4 LSB/(deg/s)
	*/
	MPU6050_set_gyroFS(3);

    while (1) 
    {
		MPU6050_get_gyro(gyr);
		//MPU6050_get_accel(gyr);
		itoa(gyr[0],gyrX_str,10);
		itoa(gyr[1],gyrY_str,10);
		itoa(gyr[2],gyrZ_str,10);
		printString(gyrX_str); printString(" ");
		printString(gyrY_str); printString(" ");
		printLine(gyrZ_str);
		_delay_ms(10);
		timing_bit = !timing_bit;
		statusLED(timing_bit);
    }
}

void statusLED(uint8_t status)
{
	if (status) {
		PORTB |= (1<<PORTB5);
	}
	else {
		PORTB &= ~(1<<PORTB5);
	}
	
}