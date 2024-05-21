#include <SoftwareSerial.h>

//SoftwareSerial bt(10, 11);

int inputs[4] = {2, 4, 7, 8};
int mestados[5][4]={{1,0,1,0},{0,1,0,1},{0,0,0,0},{0,1,1,0},{1,0,0,1}}; /*"avanzar,Retroceder,Detener,Izq,Der----Primera tabla*/
int enables[2] = {5, 6};
int velocidades[5][2]={{250,250},{250,250},{0,0},{200,200},{200,200}};/*Velocidades------Segunda tabla*/

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  // Serial.setTimeout(100);
  //bt.begin(9600);
  //bt.setTimeout(10);
  for(int i = 0; i<4; i++){
    pinMode(inputs[i], OUTPUT);
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()>0){
    byte number = (byte)Serial.read();
    Serial.println(number);

    if(number == 87){
      int estado = 0;
      for(int i = 0; i<4; i++){
        digitalWrite(inputs[i], mestados[estado][i]);
        Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
      }

      for(int i = 0; i<2; i++){
        analogWrite(enables[i], velocidades[estado][i]);
        Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
      }
    }

    if(number == 83){
      int estado = 1;
      for(int i = 0; i<4; i++){
        digitalWrite(inputs[i], mestados[estado][i]);
        Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
      }

      for(int i = 0; i<2; i++){
        analogWrite(enables[i], velocidades[estado][i]);
        Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
      }
    }

    if(number == 88){
      int estado = 2;
      for(int i = 0; i<4; i++){
        digitalWrite(inputs[i], mestados[estado][i]);
        Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
      }

      for(int i = 0; i<2; i++){
        analogWrite(enables[i], velocidades[estado][i]);
        Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
      }
    }

    if(number == 65){
      int estado = 3;
      for(int i = 0; i<4; i++){
        digitalWrite(inputs[i], mestados[estado][i]);
        Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
      }

      for(int i = 0; i<2; i++){
        analogWrite(enables[i], velocidades[estado][i]);
        Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
      }
    }

    if(number == 68){
      int estado = 4;
      for(int i = 0; i<4; i++){
        digitalWrite(inputs[i], mestados[estado][i]);
        Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
      }

      for(int i = 0; i<2; i++){
        analogWrite(enables[i], velocidades[estado][i]);
        Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
      }
    }
  }
}
