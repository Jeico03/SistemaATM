namespace ModeloATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.NumeroCuenta = "73721";
            cuenta.Saldo = 5000m;
            cuenta.Activa = true;

            Console.WriteLine("=== Objeto Cuenta ===");
            cuenta.ConsultarSaldo();
            cuenta.Depositar(1000m);
            cuenta.ConsultarSaldo();

            Transaccion transaccion = new Transaccion();
            transaccion.Tipo = "Depósito";
            transaccion.Monto = 1000m;
            transaccion.Fecha = DateTime.Now;

            Console.WriteLine("\n=== Objeto Transaccion ===");
            transaccion.MostrarDetalle();
        }
    }
}
