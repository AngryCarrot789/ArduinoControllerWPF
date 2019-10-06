String inputString = "";
bool stringComplete = false;

void setup()
{
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);

  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(A4, INPUT);
  pinMode(A5, INPUT);

  Serial.begin(115200);
  inputString.reserve(200);
}

void loop()
{
  
  if (stringComplete) {
    String data = inputString.substring(0, inputString.length() - 1);
    Serial.println(data);
    if (data == "02HIGH") digitalWrite(2,  HIGH); else if (data == "02LOW") digitalWrite(2,  LOW);
    if (data == "03HIGH") digitalWrite(3,  HIGH); else if (data == "03LOW") digitalWrite(3,  LOW);
    if (data == "04HIGH") digitalWrite(4,  HIGH); else if (data == "04LOW") digitalWrite(4,  LOW);
    if (data == "05HIGH") digitalWrite(5,  HIGH); else if (data == "05LOW") digitalWrite(5,  LOW);
    if (data == "06HIGH") digitalWrite(6,  HIGH); else if (data == "06LOW") digitalWrite(6,  LOW);
    if (data == "07HIGH") digitalWrite(7,  HIGH); else if (data == "07LOW") digitalWrite(7,  LOW);
    if (data == "08HIGH") digitalWrite(8,  HIGH); else if (data == "08LOW") digitalWrite(8,  LOW);
    if (data == "09HIGH") digitalWrite(9,  HIGH); else if (data == "09LOW") digitalWrite(9,  LOW);
    if (data == "10HIGH") digitalWrite(10, HIGH); else if (data == "10LOW") digitalWrite(10, LOW);
    if (data == "11HIGH") digitalWrite(11, HIGH); else if (data == "11LOW") digitalWrite(11, LOW);
    if (data == "12HIGH") digitalWrite(12, HIGH); else if (data == "12LOW") digitalWrite(12, LOW);
    if (data == "13HIGH") digitalWrite(13, HIGH); else if (data == "13LOW") digitalWrite(13, LOW);
    // clear the string:
    inputString = "";
    data = "";
    stringComplete = false;
  }
  String a0Msg = "A0" + (String)analogRead(A0);
  String a1Msg = "A1" + (String)analogRead(A1);
  String a2Msg = "A2" + (String)analogRead(A2);
  String a3Msg = "A3" + (String)analogRead(A3);
  String a4Msg = "A4" + (String)analogRead(A4);
  String a5Msg = "A5" + (String)analogRead(A5);
  Serial.println(a0Msg);
  Serial.println(a1Msg);
  Serial.println(a2Msg);
  Serial.println(a3Msg);
  Serial.println(a4Msg);
  Serial.println(a5Msg);
  delay(100);
}

void serialEvent()
{
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag so the main loop can
    // do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}