// #include "I2Cdev.h"
#include "MPU6050.h"
#include "Wire.h"

/* Sensitivity
 *  Gyro:
 *  0: 250 deg/s, 131 LSB/(deg/s)
 *  1: 500 deg/s, 65.5 LSB/(deg/s)
 *  2: 1000 deg/s, 32.8 LSB/(deg/s)
 *  3: 2000 deg/s, 16.4 LSB/(deg/s)
 *  
 *  Accelerometer:
 *  0: 2 g, 16384 LSB/g
 *  1: 4 g, 8192 LSB/g
 *  2: 8 g, 4096 LSB/g
 *  3: 16 g, 2048 LSB/g
 *  
 *  Termometer:
 *  340 LSB/C
 */


int16_t X_read;
float acc_sens = 16384; // range: 0
float gyro_sens = 131; // range: 0 LSB/(deg/ms)

void setup() {
    Wire.begin();
    Serial.begin(38400);

    Wire.beginTransmission(0x68);
    Wire.write(MPU6050_RA_PWR_MGMT_1);
    Wire.write(B00000000);
    Wire.endTransmission();
    
    Wire.beginTransmission(0x68);
    Wire.write(MPU6050_RA_ACCEL_CONFIG);
    Wire.write(B00000000);
    Wire.endTransmission();

    Wire.beginTransmission(0x68);
    Wire.write(MPU6050_RA_GYRO_CONFIG);
    Wire.write(B00000000);
    Wire.endTransmission();
}

void loop() {
    Serial.println(X_read);

    delay(10);
}

