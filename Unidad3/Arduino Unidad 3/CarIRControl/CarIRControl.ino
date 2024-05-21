#include <SoftwareSerial.h>

SoftwareSerial bt(10, 11);

int inputs[4] = {2, 4, 7, 8};
int mestados[5][4]={{1,0,1,0},{0,1,0,1},{0,0,0,0},{0,1,1,0},{1,0,0,1}}; /*"avanzar,Retroceder,Detener,Izq,Der----Primera tabla*/
int enables[2] = {5, 6};
int velocidades[5][2]={{150,150},{150,150},{0,0},{100,100},{100,100}};/*Velocidades------Segunda tabla*/
int sensorL = 12;
int sensorR = 13;
int vSensorL = 0;
int vSensorR = 0;
int nuevoEstado;
int estadoActual = -1;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  delay(1000);
  // Serial.setTimeout(100);

  for(int i = 0; i<4; i++){
    pinMode(inputs[i], OUTPUT);
  }

  pinMode(sensorL, INPUT);
  pinMode(sensorR, INPUT);
}

void loop() {

  vSensorL = digitalRead(sensorL);
  vSensorR = digitalRead(sensorR);

  int nuevoEstado = -1;
  

  if(vSensorL == 0 && vSensorR == 0){
    nuevoEstado = 0;
  }

  if(vSensorL == 1 && vSensorR == 0){
    nuevoEstado = 3;
  }

  if(vSensorR == 1 && vSensorL == 0){
    nuevoEstado = 4;
  }

  if(vSensorL == 1 && vSensorR == 1){
    nuevoEstado = 2;
  }

  // Solo establecer el estado si ha cambiado
  if (nuevoEstado != estadoActual) {
    establecerEstado(nuevoEstado);
    estadoActual = nuevoEstado;
  }
}

void establecerEstado(int estado){

      for(int i = 0; i<4; i++){
        digitalWrite(inputs[i], mestados[estado][i]);
        Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
      }

      for(int i = 0; i<2; i++){
        analogWrite(enables[i], velocidades[estado][i]);
        Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
      }
}
