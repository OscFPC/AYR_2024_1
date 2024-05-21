#include <SoftwareSerial.h>

SoftwareSerial bt(10,11); //rx tx -> se conectan al reves en el bt

void setup() {
  // put your setup code here, to run once:
  Serial.begin(38400);
  bt.begin(38400);
}

void loop() {
  // put your main code here, to run repeatedly:

  if(Serial.available()>0){
    bt.write(Serial.read());
  }

  if(bt.available()>0){
    Serial.write(bt.read());
  }
}
