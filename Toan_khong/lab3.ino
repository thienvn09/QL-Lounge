#include <WiFi.h>         // Thư viện Wifi
#include <DHT.h>          // Thư viện cảm biến Nhiệt độ/độ ẩm (Adafruit)
#include "ThingSpeak.h"   // Thư viện ThingSpeak

const int DHT_PIN = 15;   // Khai báo chân kết nối với Board ESP32
#define DHTTYPE DHT22     // Định nghĩa loại cảm biến (DHT22 hoặc DHT11)

// Thông tin xác thực Wi-Fi mô phỏng trên Wokwi
const char* WIFI_NAME = "Wokwi-GUEST";
const char* WIFI_PASSWORD = "";

// API Key và channel trên ThingSpeak
unsigned long myChannelNumber = 2933145;
const char* myApiKey = "P8HCO6YPWXFVOKSI";
const char* server = "api.thingspeak.com";

DHT dhtSensor(DHT_PIN, DHTTYPE); // Khởi tạo cảm biến với thư viện mới
WiFiClient client;

void setup() {
  Serial.begin(115200);
  dhtSensor.begin(); // Khởi động cảm biến với thư viện DHT

  WiFi.begin(WIFI_NAME, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.println("Wifi not connected");
  }
  Serial.println("Wifi connected !");
  Serial.println("Local IP: " + String(WiFi.localIP()));

  WiFi.mode(WIFI_STA);
  ThingSpeak.begin(client);
}

void loop() {
  // Đọc nhiệt độ từ cảm biến
  float temperature = dhtSensor.readTemperature();

  Serial.print("Nhiệt độ: ");
  Serial.print(temperature);
  Serial.println(" °C");

  // Kiểm tra dữ liệu hợp lệ trước khi gửi
  if (!isnan(temperature)) {
    ThingSpeak.setField(1, temperature);
    int httpResponseCode = ThingSpeak.writeFields(myChannelNumber, myApiKey);

    if (httpResponseCode == 200) {
      Serial.println("Gửi dữ liệu thành công lên ThingSpeak!");
    } else {
      Serial.print("Lỗi khi gửi dữ liệu: ");
      Serial.println(httpResponseCode);
    }
  } else {
    Serial.println("Dữ liệu nhiệt độ không hợp lệ, bỏ qua gửi lên ThingSpeak!");
  }

  Serial.println("--------------------");

  delay(15000);
}