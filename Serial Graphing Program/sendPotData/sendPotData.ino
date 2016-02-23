#define potPin A1
#define lightPin A0
#define tempPin A2

float data1, data2, data3;

void setup() {
  Serial.begin(9600);
  pinMode(potPin,INPUT);
  pinMode(lightPin,INPUT);
  pinMode(tempPin,INPUT);
}

void loop() {
  data1 = analogRead(potPin);
  data2 = analogRead(lightPin);
  data3 = analogRead(tempPin);
  Serial.print(data1);
  Serial.print(" ");
  Serial.print(data2);
  Serial.print(" ");
  Serial.println(data3);
  delay(30);
}
