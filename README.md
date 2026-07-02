# Human-Computer Interface (HCI): Unity & Arduino Integration

Este proyecto fue desarrollado originalmente como parte de mi proyecto de residencias profesionales en el Hospital General del Estado de Sonora. Consiste en una interfaz interactiva en tiempo real donde el movimiento de un entorno virtual 3D es controlado mediante hardware externo (acelerómetro y giroscopio) conectado a un microcontrolador.

## 🛠️ Arquitectura Técnica

El sistema se compone de dos elementos principales independientes del entorno clínico:
1. **Firmware (C++ / Arduino):** Captura de señales físicas desde sensores inerciales (acelerómetro y giroscopio) y transmisión de datos procesados mediante comunicación serial (UART/USB).
2. **Software (C# / Unity):** Adquisición de datos seriales en tiempo real, parseo de strings y mapeo de variables físicas en un entorno de físicas 3D desarrollado en Visual Studio.

---

## 💻 Modos de Ejecución (Hardware & Simulación)

Para efectos de demostración y pruebas en este portafolio digital, el código fuente del script principal de Unity ha sido adaptado con un **Modo de Simulación por Teclado**:
- **Modo Hardware:** (`useHardware = true`) Realiza la apertura del puerto serial y lee los datos dinámicos del Arduino.
- **Modo Teclado / Simulación:** (`useHardware = false`) Permite controlar el entorno y validar la lógica de las físicas utilizando las **flechas del teclado (o WASD)**, haciendo el proyecto ejecutable de forma independiente del hardware físico para su evaluación de software.

---

## 📂 Estructura del Repositorio
- `/Arduino_Firmware`: Contiene el código en C++ desarrollado para el microcontrolador.
- `/Unity_Scripts`: Contiene la arquitectura completa de scripts en C# que gestionan la interfaz gráfica, lógica de escenas, obstáculos y el flujo general del sistema.
