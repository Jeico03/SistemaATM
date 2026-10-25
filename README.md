# Sistema ATM — Validaciones y menú de operaciones

**Actividad 3.5 · Semana 3 · Día 1 — Fundamentos de Programación con C#**
**Estudiante:** Jeico Arias

## Descripción

Prototipo educativo de cajero automático en consola, con datos en memoria.
Permite consultar saldo, depositar y retirar sobre una única cuenta, aplicando
reglas de validación. El menú se procesa una sola vez: no se usan ciclos en
esta entrega.

## Objetivos

- OB-01. Consultar el saldo de una cuenta.
- OB-02. Permitir depósitos y retiros sujetos a reglas.
- OB-03. Evitar cambios de saldo ante operaciones rechazadas.
- OB-04. Comunicar el resultado de cada solicitud.
- OB-05. Mantener la trazabilidad entre requerimientos y pruebas.

## Datos de la cuenta

| Dato | Valor |
|---|---|
| Titular | Jeico Arias |
| Número de cuenta | 73721 |
| Estado | Activa |
| Saldo inicial | RD$10,000.00 |

## Reglas de negocio

- La cuenta debe estar activa.
- El monto debe ser un número válido y mayor que cero.
- El retiro no puede superar el saldo disponible.
- Una operación rechazada no modifica el saldo.

## Estructuras utilizadas

`switch` para el menú; `if / else` para las validaciones; `TryParse` para
controlar entradas no numéricas. Sin ciclos.

## Casos de prueba

Saldo inicial RD$10,000 y cuenta activa. Cada prueba reinicia el saldo.

| Código | Caso | Resultado esperado |
|---|---|---|
| CP-01 | Consultar saldo | Muestra RD$10,000.00 |
| CP-02 | Depositar 2,500 | Nuevo saldo: RD$12,500.00 |
| CP-03 | Retirar 4,000 | Nuevo saldo: RD$6,000.00 |
| CP-04 | Retirar 15,000 | Rechaza: saldo insuficiente |
| CP-05 | Retirar -500 | Rechaza: monto debe ser mayor que cero |
| CP-06 | Depositar 0 | Rechaza: monto debe ser mayor que cero |
| CP-07 | Opción "abc" | Error: debe ingresar un número |
| CP-08 | Opción 7 | Error: opción no válida |
| CP-09 | Cuenta inactiva | Rechaza: la cuenta no está activa |
| CP-10 | Opción 4 | Mensaje de despedida y fin |

## Matriz de trazabilidad

| Objetivo | Casos de prueba |
|---|---|
| OB-01 | CP-01 |
| OB-02 | CP-02, CP-03 |
| OB-03 | CP-04, CP-05, CP-06, CP-09 |
| OB-04 | CP-01 a CP-10 |
| OB-05 | Esta matriz |

## Cómo ejecutar

```bash
dotnet run --project SistemaATM.Console
