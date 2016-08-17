#include "I2Cdev.h"
#include "MPU6050.h"
#include "Wire.h"

// class default I2C address is 0x68
// specific I2C addresses may be passed as a parameter here
// AD0 low = 0x68 (default for InvenSense evaluation board)
// AD0 high = 0x69
MPU6050 accelgyro;

int16_t ax, ay, az;
int16_t gx, gy, gz;
bool start_measuring = false;

void setup() {
    Wire.begin();

    // 38400 chosen because it works as well at 8MHz as it does at 16MHz
    Serial.begin(38400);

    // initialize device
    Serial.println("Initializing I2C devices...");
    accelgyro.initialize();

    // verify connection
    Serial.println("Testing device connections...");
    Serial.println(accelgyro.testConnection() ? "MPU6050 connection successful" : "MPU6050 connection failed");

    Wire.beginTransmission(0x68);
    Wire.write(MPU6050_RA_ACCEL_CONFIG);
    Wire.write(B00011000);
    Wire.endTransmission();
    //accelgyro.setFullScaleAccelRange(0);
    Wire.beginTransmission(0x68);
    Wire.write(MPU6050_RA_GYRO_CONFIG);
    Wire.write(B00011000);
    Wire.endTransmission();
    //accelgyro.setFullScaleGyroRange(0);
    
    accelgyro.setXAccelOffset(-1906);
    accelgyro.setYAccelOffset(1967);
    accelgyro.setZAccelOffset(1263);
    
    accelgyro.setXGyroOffset(11);
    accelgyro.setYGyroOffset(15);
    accelgyro.setZGyroOffset(17);
}

void loop() {
    if (Serial.available()) {
      String s = "";
      s = Serial.readString();
  
      if (s == "a"){
         start_measuring = true;
      }
      if (s == "b"){
         start_measuring = false;
      }
     }
     
    // read raw accel/gyro measurements from device
    accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
    //accelgyro.getAcceleration(&ax, &ay, &az);
    //accelgyro.getRotation(&gx, &gy, &gz);

    if (start_measuring) { 
      Serial.print(ax); Serial.print("_");
      Serial.print(ay); Serial.print("_");
      Serial.println(az);
    }
    
    delay(15);
}

