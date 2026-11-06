using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloATM
{
    internal class Transaccion
    {
        public string Tipo { get; set; } = "";
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public void MostrarDetalle()
        {
            Console.WriteLine($"{Fecha:dd/MM/yyyy HH:mm} | {Tipo} | RD${Monto:N2}");
        }
    }
}
