using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloATM
{
    internal class Cuenta
    {
        public string NumeroCuenta { get; set; } = "";
        public decimal Saldo { get; set; }
        public bool Activa { get; set; }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Cuenta {NumeroCuenta} - Saldo: RD${Saldo:N2}");
        }

        public void Depositar(decimal monto)
        {
            if (monto > 0)
                Saldo += monto;
        }

    }
}
