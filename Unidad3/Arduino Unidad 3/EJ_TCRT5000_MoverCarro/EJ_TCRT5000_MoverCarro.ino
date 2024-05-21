int inputs[4]={2,4,7,8};
int mestados[5][4]={{1,0,1,0},{0,1,0,1},{0,0,0,0},{0,1,1,0},{1,0,0,1}}; /*"avanzar,Retroceder,Detener,Izq,Der----Primera tabla*/
int velocidades[5][2]={{255,255},{255,255},{0,0},{255,255},{255,255}};/*Velocidades------Segunda tabla*/
int enables[2]={5,6};

int sensor1=12;
int sensor2=13;

void setup() {
  Serial.begin(9600);
  pinMode(sensor1,INPUT);
  pinMode(sensor2,INPUT);
}

void loop() {
  int s1=digitalRead(sensor1);
  int s2=digitalRead(sensor2);
  Serial.println(s1);
  Serial.println(s2);

  if(s1==1 and s2==1){
    //avanzar
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
  else if(s1==1 and s2==0){
    //derecha
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
  else if(s1==0 and s2==1){
    //izquierda
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
  else if(s1==0 and s2==0){
    //detenerse
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
  
  delay(1000);

}
