# 🏧 Laboratorio 4.5 — Mini ATM: Refactorización mediante Métodos

**Asignatura:** Fundamentos de Programación con C# — CodeArt Academy  
**Estudiante:** Jeico Arias Brito  
**Docentes:** Francis Ricardo Ramirez De Leon y Manuel Titín  
**Semana / Actividad:** Semana 4 · Actividad 4.5  
**Continuidad:** evolución de Mini ATM V1 (Semana 3, labs 3.5 y 3.10)

## 📋 Descripción del Proyecto
Cajero automático (ATM) de consola desarrollado en C#. Esta versión **refactoriza el Mini ATM V1 en métodos con responsabilidades definidas**, sin modificar el comportamiento funcional ni las reglas de negocio validadas en la Semana 3.

El programa muestra un menú repetitivo (`do-while`) que permite consultar el saldo, depositar y retirar dinero en una misma sesión, manteniendo el saldo actualizado en memoria hasta que el usuario elige **Salir**. El laboratorio se enfoca en **métodos, parámetros, argumentos, valores de retorno y alcance de variables**.

## 🎯 Objetivos
| ID | Objetivo |
|---|---|
| ON-01 | Preservar la ejecución correcta de consulta, depósito y retiro durante una misma sesión. |
| ON-02 | Reducir la duplicación de instrucciones mediante métodos reutilizables. |
| ON-03 | Facilitar la comprensión, prueba y mantenimiento del programa sin incorporar aún clases de dominio ni persistencia. |

## 🧭 Alcance
| Incluido | Excluido |
|---|---|
| Menú interactivo y operaciones consecutivas, validaciones existentes, extracción de métodos, paso de parámetros, valores de retorno y pruebas de regresión. | Base de datos, archivos, autenticación real, múltiples cuentas, historial de transacciones, clases de dominio, interfaces, APIs y servicios externos. |
| Datos de ejemplo en memoria: titular, número de cuenta, estado y saldo. | Colecciones de movimientos (`List<T>`, `Dictionary`): se incorporan en la actividad 4.10 (ATM V2). |

## 🚀 Datos de la Cuenta de Prueba
| Dato | Valor |
|---|---|
| Titular | Jeico Arias |
| Número de cuenta | 73721 |
| Estado | Activa (`true`) |
| Saldo inicial | RD$10,000.00 (`decimal`) |

## 📥 Análisis de Entradas, Proceso y Salidas (IPO)
| Entradas | Proceso | Salidas |
| :--- | :--- | :--- |
| • Opción del menú (`string` → `int`)<br>• Monto de depósito o retiro (`string` → `decimal`) | 1. Mostrar el menú y el saldo actual en un ciclo continuo.<br>2. Validar opciones y montos con `int.TryParse` y `decimal.TryParse`.<br>3. Verificar las reglas de negocio (cuenta activa, monto mayor que cero, fondos suficientes).<br>4. Actualizar el saldo con el valor devuelto por `Depositar` o `Retirar`. | • Mensajes de error controlados ante entradas no numéricas o fuera de rango.<br>• Mensajes de éxito o rechazo de cada operación.<br>• Despedida y cierre de la sesión al elegir la opción 4. |

## 🧩 Diseño Modular (Métodos)
Todos los métodos son `static` y están definidos dentro de la clase `Program`, fuera de `Main`. No se usa programación orientada a objetos en esta etapa.

| Método | Tipo de retorno | Parámetros | Responsabilidad |
|---|---|---|---|
| `MostrarMenu` | `void` | `string titular, string numeroCuenta, decimal saldo` | Imprime el encabezado y las opciones del menú. No modifica el saldo. |
| `ConsultarSaldo` | `void` | `decimal saldo` | Muestra el saldo recibido. No modifica datos. |
| `CuentaEstaActiva` | `bool` | `bool estado` | Devuelve `true` o `false` según el estado de la cuenta. |
| `LeerMonto` | `bool` | `string mensaje, out decimal monto` | Solicita un monto, lo convierte con `decimal.TryParse` y devuelve `true` si fue válido. El monto sale por el parámetro `out`. |
| `Depositar` | `decimal` | `decimal saldo, decimal monto` | Aplica las reglas del depósito y devuelve el saldo nuevo, o el anterior si se rechaza. |
| `Retirar` | `decimal` | `decimal saldo, decimal monto` | Aplica las reglas del retiro y devuelve el saldo nuevo, o el anterior si se rechaza. |

### Conceptos aplicados
* **Parámetros y argumentos:** el saldo y el monto se pasan a `Depositar` y `Retirar` como argumentos.
* **Valores de retorno:** `Depositar` y `Retirar` devuelven el saldo resultante, y `LeerMonto` y `CuentaEstaActiva` devuelven un `bool`.
* **Parámetro `out`:** `LeerMonto` entrega el monto convertido sin usar variables globales.
* **Paso por valor:** `decimal` se pasa por valor, así que el método trabaja con una copia. Por eso el resultado se asigna en `Main`: `saldo = Depositar(saldo, monto);`.
* **Alcance de variables:** `saldo`, `cuentaActiva` y `monto` viven en `Main` y los métodos solo ven lo que reciben por parámetro.

### Decisión de diseño heredada de V1
En V1, la consulta de saldo también se rechaza si la cuenta está inactiva. Se conservó ese comportamiento para cumplir RN-10 (la refactorización no puede cambiar el comportamiento validado).

## 🧠 Pseudocódigo (actualizado)
```text
INICIO
    titular ← "Jeico Arias"
    numeroCuenta ← "73721"
    cuentaActiva ← verdadero
    saldo ← 10000.00

    REPETIR
        MostrarMenu(titular, numeroCuenta, saldo)
        LEER entrada

        SI entrada no es un número ENTONCES
            MOSTRAR error de opción
        SINO
            SEGÚN opción
                1: SI NO CuentaEstaActiva(cuentaActiva) ENTONCES MOSTRAR rechazo
                   SINO ConsultarSaldo(saldo)

                2: SI NO CuentaEstaActiva(cuentaActiva) ENTONCES MOSTRAR rechazo
                   SINO SI LeerMonto("monto a depositar", monto) ENTONCES
                            saldo ← Depositar(saldo, monto)

                3: SI NO CuentaEstaActiva(cuentaActiva) ENTONCES MOSTRAR rechazo
                   SINO SI LeerMonto("monto a retirar", monto) ENTONCES
                            saldo ← Retirar(saldo, monto)

                4: MOSTRAR despedida
                OTRO: MOSTRAR error de opción no válida
        FIN SEGÚN

        SI opción ≠ 4 ENTONCES pausar y limpiar pantalla
    HASTA QUE opción = 4
FIN

Depositar(saldo, monto):
    SI monto ≤ 0 → MOSTRAR rechazo; DEVOLVER saldo
    saldo ← saldo + monto; MOSTRAR éxito; DEVOLVER saldo

Retirar(saldo, monto):
    SI monto ≤ 0     → MOSTRAR rechazo; DEVOLVER saldo
    SI monto > saldo → MOSTRAR fondos insuficientes; DEVOLVER saldo
    saldo ← saldo - monto; MOSTRAR éxito; DEVOLVER saldo
```

## ✅ Requerimientos Funcionales
| ID | Descripción | Origen |
|---|---|---|
| RF-01 | Mostrar un menú de consultar saldo, depositar, retirar y salir. | Heredado 3.5 |
| RF-02 | Permitir múltiples operaciones hasta elegir salir. | Heredado 3.10 |
| RF-03 | Consultar el saldo actual de la cuenta. | Heredado 3.5 |
| RF-04 | Depositar un monto válido y actualizar el saldo. | Heredado 3.5 |
| RF-05 | Retirar un monto válido y actualizar el saldo. | Heredado 3.5 |
| RF-06 | Rechazar depósitos y retiros si la cuenta está inactiva. | Heredado 3.5 |
| RF-07 | Rechazar montos no numéricos, cero o negativos. | Heredado 3.5 |
| RF-08 | Rechazar retiros superiores al saldo disponible. | Heredado 3.5 |
| RF-09 | Rechazar opciones de menú inválidas sin finalizar la sesión. | Heredado 3.10 |
| RF-10 | Separar la presentación del menú en `MostrarMenu`. | Nuevo 4.5 |
| RF-11 | Separar la consulta de saldo en `ConsultarSaldo`. | Nuevo 4.5 |
| RF-12 | Implementar `Depositar` y `Retirar` con retorno del saldo resultante. | Nuevo 4.5 |
| RF-13 | Centralizar la lectura y validación numérica en `LeerMonto`. | Nuevo 4.5 |
| RF-14 | Verificar la cuenta activa mediante `CuentaEstaActiva`. | Nuevo 4.5 |
| RF-15 | Mantener el saldo de sesión actualizado tras invocar los métodos. | Nuevo 4.5 |

## 🛠️ Reglas de Negocio
| ID | Regla |
|---|---|
| RN-01 | Una cuenta inactiva no puede depositar ni retirar. |
| RN-02 | El depósito debe ser numérico y mayor que cero. |
| RN-03 | El retiro debe ser numérico y mayor que cero. |
| RN-04 | El retiro no puede exceder el saldo disponible. |
| RN-05 | Un depósito válido aumenta el saldo exactamente en el monto depositado. |
| RN-06 | Un retiro válido disminuye el saldo exactamente en el monto retirado. |
| RN-07 | Toda operación rechazada mantiene el saldo sin cambios. |
| RN-08 | Una opción inválida no termina la sesión. |
| RN-09 | El menú permanece disponible hasta seleccionar Salir. |
| RN-10 | La refactorización no debe modificar las reglas RN-01 a RN-09 ni los resultados esperados. |

## 👤 Casos de Uso
| ID | Caso de uso | Flujo resumido |
|---|---|---|
| CU-01 | Consultar saldo | Elegir opción 1 → `ConsultarSaldo` → mostrar saldo actual. |
| CU-02 | Depositar | Elegir 2 → validar estado y monto → `Depositar` → actualizar saldo o rechazar. |
| CU-03 | Retirar | Elegir 3 → validar estado, monto y fondos → `Retirar` → actualizar saldo o rechazar. |
| CU-04 | Salir | Elegir 4 → mostrar despedida → finalizar el ciclo. |
| CU-05 | Gestionar error de entrada | Entrada inválida → mostrar mensaje → regresar al menú sin cambiar el saldo. |

## 🔗 Matriz de Trazabilidad (RF → RN → CU → CP)
| Necesidad | Requerimientos | Reglas | Casos de uso | Pruebas |
|---|---|---|---|---|
| Operación de menú | RF-01, RF-02, RF-09, RF-10 | RN-08, RN-09 | CU-04, CU-05 | CP-07, CP-08 |
| Consulta de saldo | RF-03, RF-11 | RN-10 | CU-01 | CP-01 |
| Depósitos seguros | RF-04, RF-06, RF-07, RF-12 a RF-15 | RN-01, RN-02, RN-05, RN-07 | CU-02 | CP-02, CP-04, CP-06 |
| Retiros seguros | RF-05 a RF-08, RF-12 a RF-15 | RN-01, RN-03, RN-04, RN-06, RN-07 | CU-03 | CP-03, CP-05, CP-06 |
| Sin regresiones | RF-01 a RF-15 | RN-10 | CU-01 a CU-05 | CP-01 a CP-10 |

## 🌿 Estrategia de Versionado (Git)
| Rama | Propósito |
|---|---|
| `main` / `master` | Rama base de la versión anterior del cajero. |
| `feature/mini-atm-v1` | Mini ATM V1 (Laboratorio 3.10): menú repetitivo `do-while`, control de saldo y validaciones. Se conserva intacta como respaldo. |
| `feature/atm-refactor-metodos` | Laboratorio 4.5: refactorización del ATM en métodos (esta versión). |

Los commits siguen la convención de **Conventional Commits** (`refactor:`, `docs:`, `test:`).

## 📦 Entregables
- [x] **E-01:** Proyecto de consola C# con código modularizado.
- [x] **E-02:** Pseudocódigo actualizado y descripción de responsabilidades de los métodos (este README).
- [x] **E-03:** Matriz de trazabilidad RF → RN → CU → CP (este README).
- [ ] **E-04:** Evidencias de pruebas de regresión (tabla de resultados y capturas).
- [ ] **E-05:** Repositorio GitHub con README y commits significativos.
- [ ] **E-06:** Enlace del repositorio entregado en Google Classroom.

## 🔒 Restricciones y Siguiente Evolución
La implementación usa únicamente los contenidos estudiados hasta el Día 1 de la Semana 4: no se utilizan `List<T>`, `Dictionary`, clases, archivos ni bases de datos. El historial de movimientos mediante colecciones se incorporará en el laboratorio 4.10 — **Mini ATM V2**.

## ▶️ Cómo Ejecutar
Abre una terminal en la carpeta raíz de la solución y ejecuta:

```bash
dotnet run --project SistemaATM.Console
```

Para cambiar de rama y comparar con la versión anterior:

```bash
git switch feature/mini-atm-v1
git switch feature/atm-refactor-metodos
```