#include "I2Cdev.h"
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


// class default I2C address is 0x68
// specific I2C addresses may be passed as a parameter here
// AD0 low = 0x68 (default for InvenSense evaluation board)
// AD0 high = 0x69
MPU6050 accelgyro;

int16_t ax, ay, az;
int16_t gx, gy, gz;
float xG, yG, zG;
float xRate, yRate, zRate;

bool start_measuring = true;
float acc_sens = 16384; // range: 0
float gyro_sens = 131; // range: 0 LSB/(deg/ms)

float theta_ACC = 0, phi_ACC = 0, theta_G = 0, phi_G = 0, theta_CF = 0, phi_CF = 0;
float dt = 0, t_now = 0, pT = 0, theta_F_G = 0, phi_F_G = 0;
bool loop_time = 0;

char timing_bit = false;

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
    Wire.write(B00000000);
    Wire.endTransmission();
    //accelgyro.setFullScaleAccelRange(0);
    Wire.beginTransmission(0x68);
    Wire.write(MPU6050_RA_GYRO_CONFIG);
    Wire.write(B00011000);
    Wire.endTransmission();
    //accelgyro.setFullScaleGyroRange(0);
    
    accelgyro.setXAccelOffset(0);
    accelgyro.setYAccelOffset(0);
    accelgyro.setZAccelOffset(0);
    
    accelgyro.setXGyroOffset(0);
    accelgyro.setYGyroOffset(0);
    accelgyro.setZGyroOffset(0);


    pinMode(3,OUTPUT);
    
    pT = millis();
}

void loop() {
    /*
    t_now = millis();
    
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
     */
    // read raw accel/gyro measurements from device
    //accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
    accelgyro.getAcceleration(&ax, &ay, &az);
    accelgyro.getRotation(&gx, &gy, &gz);
    //int GX = accelgyro.getRotationX();
    
    //xG = ax/acc_sens; yG = ay/acc_sens; zG = az/acc_sens;
    //xRate = gx/gyro_sens; yRate = gy/gyro_sens; zRate = gz/gyro_sens;
    
    /*
    // Complementary Filter Calculations =====================================
    dt = (t_now-pT)/1000;
    theta_G = theta_G + -1*yRate*dt;
    phi_G = phi_G + xRate*dt;

    theta_F_G = -1*yRate*dt + theta_CF;
    phi_F_G = -1*xRate*dt + phi_CF;
    
    theta_ACC = atan2(ax,sqrt(pow(ay,2)+pow(az,2)))*180/3.14;
    phi_ACC = -1*atan2(ay,sqrt(pow(ax,2)+pow(az,2)))*180/3.14;

    theta_CF = 0.96*theta_F_G+0.04*theta_ACC;
    phi_CF = 0.96*phi_F_G+0.04*phi_ACC;

    pT = t_now;
    // =======================================================================
    
    //ax -= 16772; ay += 17048; az -= 5092;
    */
    if (start_measuring) { 
      Serial.print(gx); Serial.print("_");
      Serial.print(gy); Serial.print("_");
      Serial.println(gz);
    }
    
    //loop_time = !loop_time;
    delay(5);
    //timing_bit = !timing_bit;
    //digitalWrite(3, timing_bit);   // turn the LED on (HIGH is the voltage level)   
}

