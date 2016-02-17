#define potPin A0
float data;
float time1;

void setup() {
  Serial.begin(9600);
  pinMode(potPin,INPUT);
}

void loop() {
  data = analogRead(potPin);
  time1 = millis();
  Serial.println(data);
  delay(10);
}
