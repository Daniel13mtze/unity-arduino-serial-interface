#include <DFRobot_BMI160.h>

DFRobot_BMI160 bmi160; const int8_t i2c_addr = 0x69;

void setup()
{
Serial.begin(115200); delay(100);

//init the hardware bmin160
if (bmi160.softReset() != BMI160_OK)
{
Serial.println("reset false"); while (1);
}
  
//set and init the bmi160 i2c address
if (bmi160.I2cInit(i2c_addr) != BMI160_OK)
{
Serial.println("init false"); while (1);
}
}

void loop() { int i = 0; int rslt;
int16_t accelGyro[6] = { 0 };
rslt = bmi160.getAccelGyroData(accelGyro); if (rslt == 0) {

if ((accelGyro[1] * 3.14 / 180.0) > 0.8)
{
Serial.print("Izquierda");
}
else if ((accelGyro[1] * 3.14 / 180.0) < -0.8)
{
Serial.print("Derecha");
}
else
{
Serial.print("Centro");
}

Serial.println();
}
else
{
Serial.println("err");
}
delay(100);
}

