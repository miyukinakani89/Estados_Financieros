using System;
using Estadoderesultado;
using EstadodeSituacionFinanciera;

namespace Estado
{
    public class EstadoFlujoEfectivo
    {
        private Estadoderesultado.EstadodeResultado er;
        private BalanceGeneral bg;

        public EstadoFlujoEfectivo(Estadoderesultado.EstadodeResultado estadoResultados, BalanceGeneral balanceGeneral)
        {
            er = estadoResultados;
            bg = balanceGeneral;
        }

        public decimal CalcularFlujoOperacion()
        {
            
            decimal utilidadNeta = ObtenerUtilidadNeta();
            decimal depreciacion = ObtenerDepreciacion();
            decimal variacionCapitalTrabajo = CalcularVariacionCapitalTrabajo();
            
            return utilidadNeta + depreciacion - variacionCapitalTrabajo;
        }

        private decimal ObtenerUtilidadNeta()
        {
            
            return 0m;
        }

        private decimal ObtenerDepreciacion()
        {
            // Necesitarías acceder a los gastos de depreciación
            return 0m;
        }

        private decimal CalcularVariacionCapitalTrabajo()
        {
            // Calcular variación en activos y pasivos circulantes
            return 0m;
        }

        public void GenerarFlujo()
        {
            Console.WriteLine("=== ESTADO DE FLUJO DE EFECTIVO ===");
            
            
            decimal flujoOperacion = CalcularFlujoOperacion();
            Console.WriteLine($"Flujo de Actividades Operativas: {flujoOperacion:C2}");
            
          
            decimal flujoInversion = CalcularFlujoInversion();
            Console.WriteLine($"Flujo de Actividades de Inversión: {flujoInversion:C2}");
            
           
            decimal flujoFinanciamiento = CalcularFlujoFinanciamiento();
            Console.WriteLine($"Flujo de Actividades de Financiamiento: {flujoFinanciamiento:C2}");
           
            decimal cambioNetoEfectivo = flujoOperacion + flujoInversion + flujoFinanciamiento;
            Console.WriteLine($"Cambio Neto en Efectivo: {cambioNetoEfectivo:C2}");
        }

        private decimal CalcularFlujoInversion()
        {
            // Implementar cálculo de flujo de inversión
            return 0m;
        }

        private decimal CalcularFlujoFinanciamiento()
        {
            // Implementar cálculo de flujo de financiamiento
            return 0m;
        }
    }
}