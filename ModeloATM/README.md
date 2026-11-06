# Modelado del Sistema ATM — POO (Semana 5 · Día 1)

Caso práctico 5.5 — Modelado del Sistema ATM de Deitel · CodeArt Academy · Ingeniería de Software

**Estudiante:** Jeico Arias

## Objetivo

Producir un modelo inicial orientado a objetos de un cajero automático (ATM): identificar sus clases, su estado, su comportamiento y su responsabilidad, y demostrar que el modelo es viable implementando dos clases en C# y utilizándolas desde `Program.cs`.

Esta actividad toma como referencia pedagógica el caso ATM de Deitel y Deitel. La selección de clases es una adaptación didáctica, no una reproducción del libro.

## Contenido del repositorio

| Archivo | Descripción |
|---|---|
| `ModeloATM/Cuenta.cs` | Clase `Cuenta` |
| `ModeloATM/Transaccion.cs` | Clase `Transaccion` |
| `ModeloATM/Program.cs` | Crea y utiliza los objetos desde consola |
| `ModeloATM/ModeloATM.csproj` | Proyecto de consola para .NET 8 |
| `README.md` | Este archivo |

> Ajusta las rutas si tu proyecto quedó en otra carpeta.

## Clases analizadas

| Clase | Responsabilidad | Implementada |
|---|---|---|
| `ATM` | Coordinar el flujo de interacción y las operaciones del cajero | No |
| `Cuenta` | Mantener los datos básicos y el saldo | Sí |
| `Pantalla` | Presentar mensajes y resultados | No |
| `Teclado` | Capturar los datos que introduce el usuario | No |
| `DispensadorEfectivo` | Representar la disponibilidad y entrega de efectivo | No |
| `Transaccion` | Representar los datos de una operación | Sí |

El detalle de cada clase está en el documento de análisis.

## Clases implementadas

**`Cuenta`**
- Propiedades: `NumeroCuenta`, `Saldo`, `Activa`.
- Métodos: `ConsultarSaldo()`, `Depositar(decimal monto)`.

**`Transaccion`**
- Propiedades: `Tipo`, `Monto`, `Fecha`.
- Métodos: `MostrarDetalle()`.

`Program.cs` crea un objeto de cada clase con `new`, asigna y consulta sus propiedades, ejecuta sus métodos y muestra los resultados por consola.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

Para verificar la instalación:

```bash
dotnet --version
```

## Cómo ejecutarlo

```bash
git clone <URL-del-repositorio>
cd <carpeta-del-repositorio>/ModeloATM
dotnet run
```

Si trabajas en una rama distinta de la principal, cámbiate a ella antes de ejecutar:

```bash
git checkout <nombre-de-la-rama>
```

## Salida esperada

```text
=== Objeto Cuenta ===
Cuenta 73721 - Saldo: RD$5,000.00
Cuenta 73721 - Saldo: RD$6,000.00

=== Objeto Transaccion ===
06/11/2026 18:30 | Depósito | RD$1,000.00
```

La fecha y el formato de los números pueden variar según la configuración regional del equipo.

## Alcance

**Incluye:**
- Análisis de seis clases candidatas del dominio ATM.
- Catálogo de responsabilidades, propiedades y métodos.
- Ejemplos de objetos y tabla consolidada.
- Implementación de dos clases (`Cuenta` y `Transaccion`) y demostración por consola.

**No incluye:**
- Un cajero bancario completo ni operaciones financieras integrales.
- Autenticación, base de datos o persistencia.
- Herencia, polimorfismo e interfaces.
- Diagramas UML.

Los constructores avanzados, el encapsulamiento y el UML se estudian en el Día 2.

## Relación con el Mini ATM anterior

El Mini ATM hecho con programación estructurada se mantiene sin cambios en su propio proyecto. Esta actividad es un análisis independiente del dominio, con una demostración mínima de clases y objetos.