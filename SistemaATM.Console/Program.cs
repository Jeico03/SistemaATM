namespace SistemaATM.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titular = "Jeico Arias";
            string numeroCuenta = "73721";
            bool cuentaActiva = true;
            decimal saldo = 10000.00m;

            int opcion;
            decimal monto;

            do
            {
                MostrarMenu(titular, numeroCuenta, saldo);

                if (!int.TryParse(System.Console.ReadLine(), out opcion))
                {
                    System.Console.WriteLine("Error: debe ingresar un número del 1 al 4.");
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            if (!CuentaEstaActiva(cuentaActiva))
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else
                            {
                                ConsultarSaldo(saldo);
                            }
                            break;

                        case 2:
                            if (!CuentaEstaActiva(cuentaActiva))
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else if (LeerMonto("Ingrese el monto a depositar: ", out monto))
                            {
                                saldo = Depositar(saldo, monto);
                            }
                            break;

                        case 3:
                            if (!CuentaEstaActiva(cuentaActiva))
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else if (LeerMonto("Ingrese el monto a retirar: ", out monto))
                            {
                                saldo = Retirar(saldo, monto);
                            }
                            break;

                        case 4:
                            System.Console.WriteLine("Gracias por usar el cajero. ¡Hasta luego!");
                            break;

                        default:
                            System.Console.WriteLine("Error: opción no válida. Debe elegir del 1 al 4.");
                            break;
                    }
                }

                if (opcion != 4)
                {
                    System.Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }

            } while (opcion != 4);
        }

        static void MostrarMenu(string titular, string numeroCuenta, decimal saldo)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=== CAJERO AUTOMATICO ===");
            System.Console.WriteLine($"Titular: {titular}");
            System.Console.WriteLine($"Cuenta:  {numeroCuenta}");
            System.Console.WriteLine($"Saldo actual: {saldo:C}");
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine("1. Consultar saldo");
            System.Console.WriteLine("2. Depositar");
            System.Console.WriteLine("3. Retirar");
            System.Console.WriteLine("4. Salir");
            System.Console.Write("Seleccione una opción: ");
        }

        static void ConsultarSaldo(decimal saldo)
        {
            System.Console.WriteLine($"Saldo disponible: {saldo:C}");
        }

        static bool CuentaEstaActiva(bool estado)
        {
            return estado;
        }

        static bool LeerMonto(string mensaje, out decimal monto)
        {
            System.Console.Write(mensaje);

            if (!decimal.TryParse(System.Console.ReadLine(), out monto))
            {
                System.Console.WriteLine("Error: el monto debe ser un número.");
                return false;
            }

            return true;
        }

        static decimal Depositar(decimal saldo, decimal monto)
        {
            if (monto <= 0)
            {
                System.Console.WriteLine("Operación rechazada: el monto debe ser mayor que cero.");
                return saldo;
            }

            saldo += monto;
            System.Console.WriteLine($"Depósito realizado. Nuevo saldo: {saldo:C}");
            return saldo;
        }

        static decimal Retirar(decimal saldo, decimal monto)
        {
            if (monto <= 0)
            {
                System.Console.WriteLine("Operación rechazada: el monto debe ser mayor que cero.");
                return saldo;
            }

            if (monto > saldo)
            {
                System.Console.WriteLine("Operación rechazada: saldo insuficiente.");
                System.Console.WriteLine($"Saldo disponible: {saldo:C}");
                return saldo;
            }

            saldo -= monto;
            System.Console.WriteLine($"Retiro realizado. Nuevo saldo: {saldo:C}");
            return saldo;
        }
    }
}