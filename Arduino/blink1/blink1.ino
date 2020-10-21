// constants won't change. They're used here to set pin numbers:
const int buttonPin = 0;     // the number of the pushbutton pin
const int ledPin =  1;      // the number of the LED pin

// variables will change:
int buttonState = 0;         // variable for reading the pushbutton status
int lastButtonState = 0;

void setup() {
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
  // initialize the pushbutton pin as an input:
  pinMode(buttonPin, INPUT);
  Serial.begin(9600);
}

void loop() {
  // read the state of the pushbutton value:
  buttonState = digitalRead(buttonPin);

  // check if the pushbutton is pressed. If it is, the buttonState is HIGH:
  if (buttonState != lastButtonState) {
    if (buttonState == HIGH){
      digitalWrite(ledPin, HIGH);
    }
    else {
      Serial.println("1");
      digitalWrite(ledPin, LOW);
    }
    
  }
  lastButtonState = buttonState;
}
