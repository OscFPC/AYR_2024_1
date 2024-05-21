int inputs[4]={9,10,11,12};
int mestados[5][4]={{1,0,1,0},{0,1,0,1},{0,0,0,0},{0,1,1,0},{1,0,0,1}}; /*"avanzar,Retroceder,Detener,Izq,Der----Primera tabla*/
int enables[2]={5,6};
int velocidades[5][2]={{250,250},{250,250},{0,0},{250,250},{250,250}};/*Velocidades------Segunda tabla*/

String nEstados[5]={"Avanzar","Retroceder","Detenerse","Izquierda","Derecha"};

void setup() {
  Serial.begin(9600);
  Serial.setTimeout(100);
  for (int i=0; i<4; i++){
    pinMode(inputs[i],OUTPUT);
  }

}

void loop() {
  if(Serial.available()>0){
    int estado=Serial.readString().toInt();
    Serial.println(nEstados[estado]);
  

    for (int i=0;i<4;i++){
      digitalWrite(inputs[i],mestados[estado][i]);
      Serial.println(String(inputs[i])+"estado :"+String(mestados[estado][i]));
    }

    for (int i=0; i<2; i++){
      analogWrite(enables[i],velocidades[estado][i]);
      Serial.println(String(enables[i])+" estado: "+ String(velocidades[estado][i]));
    }
  }
delay(100);
}
