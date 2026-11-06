# 🏧 Mini ATM V2 — Modularización e Historial de Movimientos

**Asignatura:** Fundamentos de Programación con C# — CodeArt Academy  
**Estudiante:** Jeico Arias Brito  
**Docentes:** Francis Ricardo Ramirez De Leon y Manuel Titín  
**Semana 4 · Caso transversal Mini ATM V2** · Consola C# (.NET 8) · Versión 2.0

## 📋 Descripción
Cajero automático de consola que evoluciona el Mini ATM V1: conserva sus funcionalidades, organiza el código en **métodos independientes** y registra en un **historial en memoria (`List<string>`)** los depósitos y retiros exitosos. El menú se repite hasta que el usuario elige **Salir**.

**Incluye:** consulta de saldo, depósitos, retiros, validaciones, historial de movimientos y salida controlada.  
**Excluye:** bases de datos, autenticación real, transferencias, múltiples cuentas y persistencia entre ejecuciones.

## 🚀 Cuenta de Prueba
| Dato | Valor |
|---|---|
| Titular | Jeico Arias |
| Número de cuenta | 73721 |
| Estado | Activa (`true`) |
| Saldo inicial | RD$5,000.00 (`decimal`) |

## 🖥️ Menú
```
=== MINI ATM V2 ===
1. Consultar saldo
2. Depositar dinero
3. Retirar dinero
4. Consultar movimientos
5. Salir
```

## 🧩 Métodos
Todos son `static` y están dentro de `Program`, fuera de `Main`.

| Método | Retorno | Parámetros | Responsabilidad |
|---|---|---|---|
| `MostrarMenu` | `void` | `titular, numeroCuenta, saldo` | Presenta el menú y los datos de la cuenta. |
| `ConsultarSaldo` | `void` | `decimal saldo` | Muestra el saldo actual. |
| `CuentaEstaActiva` | `bool` | `bool estado` | Indica si la cuenta está activa. |
| `LeerMonto` | `decimal` | `string mensaje` | Lee un monto con `TryParse` y lo solicita de nuevo si es inválido. |
| `Depositar` | `bool` | `ref decimal saldo, decimal monto` | Valida el depósito y actualiza el saldo. Devuelve `true` si fue exitoso. |
| `Retirar` | `bool` | `ref decimal saldo, decimal monto` | Valida el retiro y actualiza el saldo. Devuelve `true` si fue exitoso. |
| `RegistrarMovimiento` | `void` | `List<string> historial, tipo, monto, saldoResultante` | Agrega una operación exitosa al historial. |
| `MostrarMovimientos` | `void` | `List<string> historial` | Muestra el historial en orden o avisa si está vacío. |

**Decisión heredada de V1:** la consulta de saldo también se rechaza con la cuenta inactiva, para no alterar el comportamiento validado (RN-09).

## ✅ Requerimientos Funcionales
| ID | Requerimiento |
|---|---|
| RF-01 | Mostrar un menú interactivo con las opciones disponibles. |
| RF-02 | Permitir seleccionar una operación y validar la opción ingresada. |
| RF-03 | Consultar y mostrar el saldo actual. |
| RF-04 | Permitir depósitos con montos numéricos mayores que cero. |
| RF-05 | Permitir retiros válidos que no superen el saldo disponible. |
| RF-06 | Mantener el saldo actualizado durante toda la ejecución. |
| RF-07 | Validar las entradas numéricas utilizando `TryParse`. |
| RF-08 | Impedir operaciones cuando la cuenta esté inactiva. |
| RF-09 | Implementar las operaciones mediante métodos independientes y reutilizables. |
| RF-10 | Registrar cada depósito exitoso en la lista de movimientos. |
| RF-11 | Registrar cada retiro exitoso en la lista de movimientos. |
| RF-12 | Consultar el historial en orden cronológico de registro. |
| RF-13 | Mostrar un mensaje cuando el historial esté vacío. |
| RF-14 | No registrar operaciones rechazadas o inválidas. |
| RF-15 | Permitir múltiples operaciones hasta seleccionar Salir. |
| RF-16 | Finalizar la aplicación de manera controlada. |

## 🛠️ Reglas de Negocio
| ID | Regla |
|---|---|
| RN-01 | El saldo no podrá ser negativo. |
| RN-02 | Los depósitos deberán ser mayores que cero. |
| RN-03 | Los retiros deberán ser mayores que cero y menores o iguales al saldo. |
| RN-04 | Una cuenta inactiva no podrá depositar ni retirar. |
| RN-05 | Solo se registrarán operaciones completadas exitosamente. |
| RN-06 | Los movimientos se conservan únicamente durante la ejecución. |
| RN-07 | El historial conserva el orden en que se realizaron las operaciones. |
| RN-08 | Los errores de entrada no finalizan inesperadamente el programa. |
| RN-09 | La refactorización no altera las funcionalidades válidas del V1. |

## ⚙️ Requerimientos No Funcionales
Aplicación de consola en C# (RNF-01), código en métodos con responsabilidades específicas (RNF-02), montos con `decimal` (RNF-03), condicionales y ciclos para el flujo (RNF-04), historial con `List<string>` sin base de datos (RNF-05), nombres descriptivos y código legible (RNF-06), ejecución sin errores de compilación y con control de entradas inválidas (RNF-07).

## 👤 Casos de Uso
| ID | Caso de uso | Descripción |
|---|---|---|
| CU-01 | Consultar saldo | Visualizar el saldo disponible. |
| CU-02 | Realizar depósito | Incrementar el saldo con un monto válido. |
| CU-03 | Realizar retiro | Disminuir el saldo cuando existan fondos suficientes. |
| CU-04 | Consultar historial | Visualizar depósitos y retiros exitosos. |
| CU-05 | Finalizar sesión | Salir del sistema de forma controlada. |

## 🧪 Casos de Prueba y Criterios de Aceptación
Los casos de prueba **CP-01 a CP-12** fueron ejecutados con saldo inicial de RD$5,000.00 y sus evidencias se encuentran en el **PDF de evidencias** incluido en este repositorio.

## 🔗 Matriz de Trazabilidad
| Requerimientos | Casos de uso | Pruebas |
|---|---|---|
| RF-03, RF-06 | CU-01 | CP-01, CP-11 |
| RF-04, RF-07, RF-08, RF-10 | CU-02 | CP-02, CP-04, CP-06, CP-09 |
| RF-05, RF-07, RF-08, RF-11 | CU-03 | CP-03, CP-05, CP-09 |
| RF-12, RF-13, RF-14 | CU-04 | CP-07, CP-08, CP-10 |
| RF-15, RF-16 | CU-05 | CP-11, CP-12 |
| RF-09 | Todos | Revisión de código |

## 🌿 Versionado (Git)
| Rama | Propósito |
|---|---|
| `master` | Rama base de la versión anterior. |
| `feature/mini-atm-v1` | Mini ATM V1 (respaldo intacto). |
| `feature/atm-refactor-metodos` | Día 1: refactorización en métodos. |
| `feature/atm-historial-movimientos` | Día 2: historial con `List<string>` y menú de 5 opciones (esta versión). |

Los commits siguen la convención de **Conventional Commits** (`feat:`, `refactor:`, `docs:`).

## 📦 Entregables
- [x] Proyecto Mini ATM V2 desarrollado en C#.
- [x] Código modularizado mediante métodos independientes.
- [x] Historial de movimientos implementado con `List<string>`.
- [x] Matriz de trazabilidad de requerimientos y pruebas.
- [x] Evidencias de ejecución de los casos de prueba (PDF).
- [x] Archivo `README.md` con instrucciones.
- [x] Repositorio GitHub con historial de cambios.

## ▶️ Cómo Ejecutar
Requiere el SDK de **.NET 8**. Desde la carpeta raíz de la solución:

```bash
dotnet run --project SistemaATM.Console
```