namespace SistemaATM.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titular = "Jeico Arias";
            string numeroCuenta = "73721";
            bool cuentaActiva = true;
            decimal saldo = 5000.00m;

            List<string> historial = new List<string>();

            int opcion;
            decimal monto;

            do
            {
                MostrarMenu(titular, numeroCuenta, saldo);

                if (!int.TryParse(System.Console.ReadLine(), out opcion))
                {
                    System.Console.WriteLine("Error: debe ingresar un número del 1 al 5.");
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
                            else
                            {
                                monto = LeerMonto("Ingrese el monto a depositar: ");

                                if (Depositar(ref saldo, monto))
                                {
                                    RegistrarMovimiento(historial, "Depósito", monto, saldo);
                                }
                            }
                            break;

                        case 3:
                            if (!CuentaEstaActiva(cuentaActiva))
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else
                            {
                                monto = LeerMonto("Ingrese el monto a retirar: ");

                                if (Retirar(ref saldo, monto))
                                {
                                    RegistrarMovimiento(historial, "Retiro", monto, saldo);
                                }
                            }
                            break;

                        case 4:
                            MostrarMovimientos(historial);
                            break;

                        case 5:
                            System.Console.WriteLine("Gracias por usar el cajero. ¡Hasta luego!");
                            break;

                        default:
                            System.Console.WriteLine("Error: opción no válida. Debe elegir del 1 al 5.");
                            break;
                    }
                }

                if (opcion != 5)
                {
                    System.Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }

            } while (opcion != 5);
        }

        static void MostrarMenu(string titular, string numeroCuenta, decimal saldo)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=== MINI ATM V2 ===");
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine("1. Consultar saldo");
            System.Console.WriteLine("2. Depositar dinero");
            System.Console.WriteLine("3. Retirar dinero");
            System.Console.WriteLine("4. Consultar movimientos");
            System.Console.WriteLine("5. Salir");
            System.Console.Write("Seleccione una opción: ");
        }

        static void ConsultarSaldo(decimal saldo)
        {
            System.Console.WriteLine($"Saldo disponible: RD${saldo:N2}");
        }

        static bool CuentaEstaActiva(bool estado)
        {
            return estado;
        }

        static decimal LeerMonto(string mensaje)
        {
            decimal monto;
            System.Console.Write(mensaje);

            while (!decimal.TryParse(System.Console.ReadLine(), out monto))
            {
                System.Console.WriteLine("Error: el monto debe ser un número.");
                System.Console.Write(mensaje);
            }

            return monto;
        }

        static bool Depositar(ref decimal saldo, decimal monto)
        {
            if (monto <= 0)
            {
                System.Console.WriteLine("Operación rechazada: el monto debe ser mayor que cero.");
                return false;
            }

            saldo += monto;
            System.Console.WriteLine($"Depósito realizado. Nuevo saldo: RD${saldo:N2}");
            return true;
        }

        static bool Retirar(ref decimal saldo, decimal monto)
        {
            if (monto <= 0)
            {
                System.Console.WriteLine("Operación rechazada: el monto debe ser mayor que cero.");
                return false;
            }

            if (monto > saldo)
            {
                System.Console.WriteLine("Operación rechazada: saldo insuficiente.");
                System.Console.WriteLine($"Saldo disponible: RD${saldo:N2}");
                return false;
            }

            saldo -= monto;
            System.Console.WriteLine($"Retiro realizado. Nuevo saldo: RD${saldo:N2}");
            return true;
        }

        static void RegistrarMovimiento(List<string> historial, string tipo, decimal monto, decimal saldoResultante)
        {
            string registro = $"{tipo} de RD${monto:N2} | Saldo resultante: RD${saldoResultante:N2}";
            historial.Add(registro);
        }

        static void MostrarMovimientos(List<string> historial)
        {
            if (historial.Count == 0)
            {
                System.Console.WriteLine("No existen movimientos registrados.");
                return;
            }

            System.Console.WriteLine("=== HISTORIAL DE MOVIMIENTOS ===");

            for (int i = 0; i < historial.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {historial[i]}");
            }
        }
    }
}