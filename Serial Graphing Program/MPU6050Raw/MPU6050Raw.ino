#include "I2Cdev.h"
#include "MPU6050.h"

#if I2CDEV_IMPLEMENTATION == I2CDEV_ARDUINO_WIRE
    #include "Wire.h"
#endif

#define ACCELSENS 16384.0f // LSB/mg

MPU6050 accelgyro;

int16_t ax, ay, az;
int16_t gx, gy, gz;
int16_t readings[6];
int sampleSize = 100;
int axOS=0,ayOS=0,azOS=0,gxOS=0,gyOS=0,gzOS=0;

void MPU6050GetOffsets(int &axOS,int &ayOS,int &azOS,int &gxOS,int &gyOS,int &gzOS);
int DataAverage(int dt[]);

#define OUTPUT_READABLE_ACCELGYRO

void setup() {
    // join I2C bus (I2Cdev library doesn't do this automatically)
    #if I2CDEV_IMPLEMENTATION == I2CDEV_ARDUINO_WIRE
        Wire.begin();
    #elif I2CDEV_IMPLEMENTATION == I2CDEV_BUILTIN_FASTWIRE
        Fastwire::setup(400, true);
    #endif

    Serial.begin(9600);

    // initialize device
    accelgyro.initialize();
    //Gyro initialized to 250 || Accelerometer initialized to 2
    delay(500);
    MPU6050GetOffsets(axOS,ayOS,azOS,gxOS,gyOS,gzOS);
    delay(500);
}

void loop() {

    // read raw accel/gyro measurements from device
    accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
    
    #ifdef OUTPUT_READABLE_ACCELGYRO
        // display tab-separated accel/gyro x/y/z values
        Serial.print((ax-axOS)/ACCELSENS); Serial.print(" ");
        Serial.print((ay-ayOS)/ACCELSENS); Serial.print(" ");
        Serial.println((az)/ACCELSENS);
        //delay(8);
        // gyro offsets gx:+836 gy:+221 gz:-434
        //Serial.print(gx);
        //Serial.print(gy);
        //Serial.println(gz);
    #endif
    
}

void MPU6050GetOffsets(int &axOS,int &ayOS,int &azOS,int &gxOS,int &gyOS,int &gzOS) {
   int MPU_offsets[6]={0,0,0,0,0,0};
   int offset_buffer[6][sampleSize];
   for (int k=0;k<6;k++) {
     for (int i=0;i<sampleSize;i++){
      //accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
      accelgyro.getMotion6(&readings[0],&readings[1],
                           &readings[2],&readings[3],
                           &readings[4],&readings[5]);
                           
      offset_buffer[k][i] = readings[k];
      //Serial.println(offset_buffer[k][i]);
     }
     MPU_offsets[k] = DataAverage(offset_buffer[k]);
   }
   axOS = MPU_offsets[0];
   ayOS = MPU_offsets[1];
   azOS = MPU_offsets[2];
   gxOS = MPU_offsets[3];
   gyOS = MPU_offsets[4];
   gzOS = MPU_offsets[5];
   return;
}

int DataAverage(int dt[]) {
  float data_sum = 0;
  int data_average = 0;
  for (int i=0;i<sampleSize;i++){
    data_sum += dt[i];
  }
  data_average = data_sum/sampleSize;
  return data_average;
}
