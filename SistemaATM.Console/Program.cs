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

            System.Console.WriteLine("Bienvenido al Sistema ATM");
            System.Console.WriteLine($"Titular: {titular}");
            System.Console.WriteLine($"Cuenta:  {numeroCuenta}");
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine("1. Consultar saldo");
            System.Console.WriteLine("2. Depositar");
            System.Console.WriteLine("3. Retirar");
            System.Console.WriteLine("4. Salir");
            System.Console.Write("Seleccione una opción: ");

            if (!int.TryParse(System.Console.ReadLine(), out int opcion))
            {
                System.Console.WriteLine("Error: debe ingresar un número del 1 al 4.");
            }
            else
            {
                switch (opcion)
                {
                    case 1:
                        System.Console.WriteLine("Consulta de saldo");
                        break;

                    case 2:
                        System.Console.WriteLine("Depósito");
                        break;

                    case 3:
                        System.Console.WriteLine("Retiro");
                        break;

                    case 4:
                        System.Console.WriteLine("Gracias por usar el cajero. ¡Hasta luego!");
                        break;

                    default:
                        System.Console.WriteLine("Error: opción no válida. Debe elegir del 1 al 4.");
                        break;
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Presione una tecla para salir...");
            System.Console.ReadKey();

        }
    }
}
