unsigned long timer_1 = 0, receiver_input_channel_1 = 0;
bool last_value_1 = 0;


void setup() 
{
  Serial.begin(9600);
  
  // pin change interrupt control register: ENABLE PCINT0->PCINT7
  PCICR |= (1<<PCIE0);
  // pin change interrupt mask register: ENABLE PCINT0
  PCMSK0 |= (1<<PCINT0);
  // data direction register for pin PINB0: OUTPUT
  DDRB &= ~(1<<DDB0);
  //pinMode(8,INPUT);
  sei();
}

void loop()
{
  Serial.println(receiver_input_channel_1);
  delay(20);
}

ISR(PCINT0_vect){
  // channel 1 =========================================
  if ((last_value_1 == 0) && (PINB & 0b00000001)){
    last_value_1 = 1;
    timer_1 = micros();
    //Serial.println("INTERRUPT 1");
  }
  else if ((last_value_1 == 1) && !(PINB & 0b00000001)){
    last_value_1 = 0;
    receiver_input_channel_1 = micros()-timer_1;
    //Serial.println("INTERRUPT 2");
  }
}

