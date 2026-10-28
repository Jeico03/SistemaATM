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

            do
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

                if (!int.TryParse(System.Console.ReadLine(), out opcion))
                {
                    System.Console.WriteLine("Error: debe ingresar un número del 1 al 4.");
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            if (!cuentaActiva)
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else
                            {
                                System.Console.WriteLine($"Saldo disponible: {saldo:C}");
                            }
                            break;

                        case 2:
                            if (!cuentaActiva)
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else
                            {
                                System.Console.Write("Ingrese el monto a depositar: ");
                                if (!decimal.TryParse(System.Console.ReadLine(), out decimal montoDep))
                                {
                                    System.Console.WriteLine("Error: el monto debe ser un número.");
                                }
                                else if (montoDep <= 0)
                                {
                                    System.Console.WriteLine("Operación rechazada: el monto debe ser mayor que cero.");
                                }
                                else
                                {
                                    saldo += montoDep;
                                    System.Console.WriteLine($"Depósito realizado. Nuevo saldo: {saldo:C}");
                                }
                            }
                            break;

                        case 3:
                            if (!cuentaActiva)
                            {
                                System.Console.WriteLine("Operación rechazada: la cuenta no está activa.");
                            }
                            else
                            {
                                System.Console.Write("Ingrese el monto a retirar: ");
                                if (!decimal.TryParse(System.Console.ReadLine(), out decimal montoRet))
                                {
                                    System.Console.WriteLine("Error: el monto debe ser un número.");
                                }
                                else if (montoRet <= 0)
                                {
                                    System.Console.WriteLine("Operación rechazada: el monto debe ser mayor que cero.");
                                }
                                else if (montoRet > saldo)
                                {
                                    System.Console.WriteLine("Operación rechazada: saldo insuficiente.");
                                    System.Console.WriteLine($"Saldo disponible: {saldo:C}");
                                }
                                else
                                {
                                    saldo -= montoRet;
                                    System.Console.WriteLine($"Retiro realizado. Nuevo saldo: {saldo:C}");
                                }
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
    }
}