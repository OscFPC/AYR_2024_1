#include <SoftwareSerial.h>

SoftwareSerial bt(10,11); //rx tx -> se conectan al reves en el bt

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  bt.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  
  if (bt.available() > 0) {
    byte number = (byte)bt.read();
  
    if (number == 65) {
      Serial.println("A");
    }
  }
}
