# 🏧 Laboratorio 3.10 — Mini ATM V1 (Operaciones Iterativas)

**Asignatura:** Fundamentos de Programación con C# — CodeArt Academy  
**Estudiante:** Jeico Arias Brito  
**Docentes:** Francis Ricardo Ramirez De Leon y Manuel Titín  

## 📋 Descripción del Proyecto
Evolución del prototipo de cajero automático en consola. Esta versión incorpora un **menú repetitivo (mediante bucle `do-while`)** que permite al usuario efectuar múltiples operaciones consecutivas (consultas, depósitos y retiros) en una misma sesión sin necesidad de reiniciar el programa. El sistema mantiene el saldo actualizado en memoria y valida de forma robusta las entradas y reglas de negocio.

## 📥 Análisis de Entradas, Proceso y Salidas (IPO)
| Entradas (Inputs) | Proceso (Process) | Salidas (Outputs) |
| :--- | :--- | :--- |
| • Opción del menú (`string` convertida a `int`)<br>• Montos de depósito o retiro (`string` convertida a `decimal`) | 1. Mostrar menú interactivo y saldo actual en un ciclo continuo.<br>2. Validar opciones y montos con `int.TryParse` y `decimal.TryParse`.<br>3. Comprobar reglas de negocio (estado de cuenta, montos mayores a cero y fondos disponibles).<br>4. Actualizar el saldo acumulado en memoria tras cada transacción válida. | • Mensajes de error controlados ante entradas no numéricas o fuera de rango.<br>• Mensajes de éxito o rechazo detallados.<br>• Despedida y cierre controlado de la sesión al seleccionar la opción 4. |

## 🚀 Datos de la Cuenta de Prueba
| Dato | Valor |
|---|---|
| Titular | Jeico Arias |
| Número de cuenta | 73721 |
| Estado | Activa (`true`) |
| Saldo inicial | RD$10,000.00 |

## 🛠️ Reglas de Negocio Implementadas
* **RN-01:** La cuenta debe estar activa para permitir depósitos y retiros.
* **RN-02 / RN-03:** Los montos de depósito y retiro deben ser mayores que cero.
* **RN-04:** El retiro no puede superar el saldo disponible en la cuenta.
* **RN-05 a RN-07:** Las operaciones válidas actualizan el saldo; las rechazadas lo conservan intacto.
* **RN-08 / RN-11:** Las opciones inválidas o entradas no numéricas generan un error controlado sin cerrar la sesión.
* **RN-09 / RN-10:** El menú se repite de forma indefinida hasta que el usuario selecciona explícitamente la opción `4` (Salir).
* **RN-12:** El saldo resultante de una operación es la base para la siguiente transacción dentro de la misma sesión.

## 🔗 Matriz de Trazabilidad
| Necesidad / Requisito | Reglas asociadas | Casos de uso | Casos de prueba vinculados |
|---|---|---|---|
| **RB-01** (Operaciones consecutivas) | RN-09 | CU-01 a CU-04 | CP-01, CP-07, CP-09 |
| **RB-02** (Secuencia y saldo actualizado) | RN-05, RN-06, RN-12 | CU-01 a CU-03 | CP-02, CP-03, CP-09 |
| **RB-03** (Protección ante errores y rechazos) | RN-01 a RN-04, RN-07, RN-08, RN-11 | CU-02 a CU-04 | CP-04 a CP-08, CP-10, CP-12 |
| **RB-04** (Salida controlada) | RN-09, RN-10 | CU-05 | CP-11 |
| **RB-05** (Trazabilidad integral) | RN-01 a RN-12 | CU-01 a CU-05 | CP-01 a CP-12 |

## 🚦 Casos de Prueba Validados
*(Condición inicial por defecto: cuenta activa y saldo en RD$10,000.00. En pruebas de secuencia, las operaciones se ejecutan de forma consecutiva sin reiniciar).*

| ID | Escenario / Secuencia de operaciones | Resultado Esperado |
|---|---|---|
| **CP-01** | Opción `1` (Consultar saldo) | Muestra RD$10,000.00 y regresa al menú |
| **CP-02** | Opción `2` → Depositar `2,000` → Consultar | Muestra nuevo saldo: RD$12,000.00 |
| **CP-03** | Opción `3` → Retirar `3,000` → Consultar | Muestra nuevo saldo: RD$7,000.00 |
| **CP-04** | Opción `2` → Depositar `0` | Rechaza el depósito y conserva RD$10,000.00 |
| **CP-05** | Opción `3` → Retirar `15,000` | Rechaza por fondos insuficientes y conserva saldo |
| **CP-06** | Opción `3` → Retirar `-500` | Rechaza el monto negativo y conserva saldo |
| **CP-07** | Opción `9` (Menú inválido) | Muestra error y vuelve a mostrar el menú operativo |
| **CP-08** | Opción `ABC` (Texto en menú) | Error controlado con `int.TryParse` y menú operativo |
| **CP-09** | Secuencia: `+2,000` ➔ `-3,000` ➔ Consultar | Muestra saldo actualizado final: RD$9,000.00 |
| **CP-10** | Cuenta inactiva → Intentar depósito o retiro | Rechaza la operación de inmediato sin cambiar saldo |
| **CP-11** | Opción `4` (Salir) | Mensaje de despedida y terminación limpia de la sesión |
| **CP-12** | Monto `ABC` en depósito o retiro | Rechazo controlado sin cerrar la sesión ni alterar saldo |

## 🌿 Estrategia de Versionado (Git)
El desarrollo de esta evolución se estructuró siguiendo una estrategia de ramas limpia y ordenada:
* **`main` / `master`:** Rama base correspondiente a la versión anterior del cajero (actividad previa).
* **`feature/mini-atm-v1`:** Rama independiente dedicada exclusivamente al desarrollo, pruebas y refactorización del ciclo iterativo (`do-while`), control de saldo y validaciones del Laboratorio 3.10.

## 🛠️ Cómo Ejecutar
Abre tu terminal en la carpeta raíz de la solución y ejecuta el siguiente comando:

```bash
dotnet run --project SistemaATM.Console