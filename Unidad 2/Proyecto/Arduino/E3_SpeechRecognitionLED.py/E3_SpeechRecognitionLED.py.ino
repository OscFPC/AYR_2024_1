String cadena,palabra1,palabra2;
int inicio,cocina=2,sala=3,comedor=4,cuarto=5;

void setup() {
  pinMode(cocina,OUTPUT);
  pinMode(sala,OUTPUT);
  pinMode(comedor,OUTPUT);
  pinMode(cuarto,OUTPUT);
  Serial.begin(9600);
  Serial.setTimeout(100);
}

void loop() {
  if(Serial.available()>0){
    cadena = Serial.readString();
    palabra1 = cadena.substring(0,cadena.indexOf(','));
    palabra2 = cadena.substring(cadena.indexOf(',') + 1);

    if (strcmp(palabra1.c_str(), "apaga") == 0) {
      if(strcmp(palabra2.c_str(), "cocina") == 0){digitalWrite(cocina,HIGH);}
      else if(strcmp(palabra2.c_str(), "sala") == 0){digitalWrite(sala,HIGAzH);}
      else if(strcmp(palabra2.c_str(), "comedor") == 0){digitalWrite(comedor,HIGH);}
      else if(strcmp(palabra2.c_str(), "cuarto") == 0){digitalWrite(cuarto,HIGH);}
      
    } else if (strcmp(palabra1.c_str(), "prende") == 0) {
      if(strcmp(palabra2.c_str(), "cocina") == 0){digitalWrite(cocina,LOW);}
      else if(strcmp(palabra2.c_str(), "sala") == 0){digitalWrite(sala,LOW);}
      else if(strcmp(palabra2.c_str(), "comedor") == 0){digitalWrite(comedor,LOW);}
      else if(strcmp(palabra2.c_str(), "cuarto") == 0){digitalWrite(cuarto,LOW);}
      
    } else {
      Serial.println("Comando desconocido");
    }
  }
}
