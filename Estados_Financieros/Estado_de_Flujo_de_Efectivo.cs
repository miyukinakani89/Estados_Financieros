using System;
using System.Collections.Generic;

namespace FlujoDeEfectivo
{
    // Clase que representa un movimiento de efectivo
    class Movimiento
    {
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; } // "Ingreso" o "Egreso"

        public Movimiento(string concepto, decimal monto, string tipo)
        {
            Concepto = concepto;
            Monto = monto;
            Tipo = tipo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Lista de movimientos de efectivo
            List<Movimiento> movimientos = new List<Movimiento>()
            {
                new Movimiento("Ventas", 5000m, "Ingreso"),
                new Movimiento("Pago a proveedores", 2000m, "Egreso"),
                new Movimiento("Pago de salarios", 1500m, "Egreso"),
                new Movimiento("Intereses recibidos", 200m, "Ingreso")
            };

            decimal totalIngresos = 0;
            decimal totalEgresos = 0;

            Console.WriteLine("Estado de Flujo de Efectivo\n");
            Console.WriteLine("Concepto\t\tTipo\t\tMonto");

            foreach (var mov in movimientos)
            {
                Console.WriteLine($"{mov.Concepto}\t\t{mov.Tipo}\t\t{mov.Monto}");
                if (mov.Tipo == "Ingreso")
                    totalIngresos += mov.Monto;
                else
                    totalEgresos += mov.Monto;
            }

            decimal flujoNeto = totalIngresos - totalEgresos;

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine($"Total Ingresos: {totalIngresos}");
            Console.WriteLine($"Total Egresos: {totalEgresos}");
            Console.WriteLine($"Flujo Neto de Efectivo: {flujoNeto}");
        }
    }
}
