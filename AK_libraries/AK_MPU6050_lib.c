/*
 * AK_MPU6050_lib.c
 *
 * Created: 9/18/2016 11:20:39 AM
 *  Author: Aleksij Kraljic
 *
 * Library created for purposes of developing ATMEGA328P based quadcopter flight controller.
 * Library requires "i2c_master.h" library for TWI communications written by g4lvanix (source: https://github.com/g4lvanix/I2C-master-lib).
 */ 

#include <avr/io.h>
#include "AK_MPU6050_lib.h"
#include "i2c_master.h"

void MPU6050_init()
{
	i2c_init();
	MPU6050_set_clockSource(1);
	MPU6050_set_sleepMode(0);
	MPU6050_set_gyroFS(0);
	MPU6050_set_accelFS(0);
}

uint8_t MPU6050_test_I2C()
{
	unsigned char Data = 0x00;
	uint8_t MPU6050_test = 0;
	
	i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_WHO_AM_I, &Data, 1);
	
	if(Data == 0x68)
	{
		MPU6050_test = 1;
	}
	else
	{
		MPU6050_test = 0;
	}
	return MPU6050_test;
}

void MPU6050_get_accel(uint16_t* acceleration) 
{
	uint8_t accel_XL, accel_XH, accel_YL, accel_YH, accel_ZL, accel_ZH;
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_ACCEL_XOUT_L,&accel_XL,1);
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_ACCEL_XOUT_H,&accel_XH,1);
	acceleration[0] = (accel_XH << 8) | (accel_XL & 0xff);
	
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_ACCEL_YOUT_L,&accel_YL,1);
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_ACCEL_YOUT_H,&accel_YH,1);
	acceleration[1] = (accel_YH << 8) | (accel_YL & 0xff);
	
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_ACCEL_ZOUT_L,&accel_ZL,1);
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_ACCEL_ZOUT_H,&accel_ZH,1);
	acceleration[2] = (accel_ZH << 8) | (accel_ZL & 0xff);
}

void MPU6050_get_gyro(uint16_t* gyroRates)
{
	uint8_t gyro_XL, gyro_XH, gyro_YL, gyro_YH, gyro_ZL, gyro_ZH;
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_GYRO_XOUT_L,&gyro_XL,1);
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_GYRO_XOUT_H,&gyro_XH,1);
	gyroRates[0] = (gyro_XH << 8) | (gyro_XL & 0xff);
	
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_GYRO_YOUT_L,&gyro_YL,1);
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_GYRO_YOUT_H,&gyro_YH,1);
	gyroRates[1] = (gyro_YH << 8) | (gyro_YL & 0xff);
	
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_GYRO_ZOUT_L,&gyro_ZL,1);
	i2c_readReg(MPU6050_ADDRESS,MPU6050_RA_GYRO_ZOUT_H,&gyro_ZH,1);
	gyroRates[2] = (gyro_ZH << 8) | (gyro_ZL & 0xff);
}

void MPU6050_set_sleepMode(uint8_t enableSleep)
{
	uint8_t power_reg_read, power_reg_write;
	switch(enableSleep) {
		case 1:
				i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
				power_reg_write = power_reg_read & ~(0b01000000);
				power_reg_write |= (0b01000000);
				i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
				break;
		case 0:
				i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
				power_reg_write = power_reg_read & ~(0b01000000);
				power_reg_write |= (0b00000000);
				i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
				break;
		default:
				i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
				power_reg_write = power_reg_read & ~(0b01000000);
				power_reg_write |= (0b01000000);
				i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
				break;
	}
}

void MPU6050_set_gyroFS(uint8_t gyroFS)
{
	switch(gyroFS) {
		case 0:
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_GYRO_CONFIG,(uint8_t*)0b00000000,1);
			break;
		case 1:
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_GYRO_CONFIG,(uint8_t*)0b00001000,1);
			break;
		case 2:
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_GYRO_CONFIG,(uint8_t*)0b00010000,1);
			break;
		case 3:
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_GYRO_CONFIG,(uint8_t*)0b00011000,1);
			break;
		default:
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_GYRO_CONFIG,(uint8_t*)0b00000000,1);
			break;
	}
}

void MPU6050_set_accelFS(uint8_t accelFS)
{
	uint8_t accel_config_read, accel_config_write;
	
	switch(accelFS) {
		case 0:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_read, 1);
			accel_config_write = accel_config_read & ~(0b00011000);
			accel_config_write |= (0b00000000);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_write, 1);
			break;
		case 1:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_read, 1);
			accel_config_write = accel_config_read & ~(0b00011000);
			accel_config_write |= (0b00001000);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_write, 1);
			break;
		case 2:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_read, 1);
			accel_config_write = accel_config_read & ~(0b00011000);
			accel_config_write |= (0b00010000);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_write, 1);
			break;
		case 3:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_read, 1);
			accel_config_write = accel_config_read & ~(0b00011000);
			accel_config_write |= (0b00011000);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_write, 1);
			break;
		default:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_read, 1);
			accel_config_write = accel_config_read & ~(0b00011000);
			accel_config_write |= (0b00000000);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_ACCEL_CONFIG, &accel_config_write, 1);
			break;
	}
}

void MPU6050_set_clockSource(uint8_t clockSource)
{
	uint8_t power_reg_read, power_reg_write;
	switch(clockSource) {
		case 0:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
			power_reg_write = power_reg_read & ~(0b00000111);
			power_reg_write |= (0b00000000);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);;
			break;
		case 1:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
			power_reg_write = power_reg_read & ~(0b00000111);
			power_reg_write |= (0b00000001);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
			break;
		case 2:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
			power_reg_write = power_reg_read & ~(0b00000111);
			power_reg_write |= (0b00000010);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
			break;
		case 3:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
			power_reg_write = power_reg_read & ~(0b00000111);
			power_reg_write |= (0b00000011);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
			break;
		default:
			i2c_readReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_read, 1);
			power_reg_write = power_reg_read & ~(0b00000111);
			power_reg_write |= (0b00000001);
			i2c_writeReg(MPU6050_ADDRESS, MPU6050_RA_PWR_MGMT_1, &power_reg_write, 1);
			break;
	}
}