int sensor = 13;

void setup() {
  Serial.begin(9600);
  pinMode(sensor, INPUT);
}

void loop() {
  int v = digitalRead(sensor);
  Serial.println(v);
  delay(50);
}
