using System;
using System.Collections.Generic;
using System.Linq;

namespace Estadosfinancieros
{
    public class EstadoFlujoEfectivo
    {
        public string Entidad { get; set; } = "Empresa";
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal FlujoNetoOperacion { get; private set; }
        public decimal FlujoNetoInversion { get; private set; }
        public decimal FlujoNetoFinanciamiento { get; private set; }
        public decimal IncrementoNetoEfectivo { get; private set; }
        public decimal EfectivoInicial { get; private set; }
        public decimal EfectivoFinal { get; private set; }

        public void CalcularFlujosDesdeEstados(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior,
                                              EstadoResultado estadoResultado)
        {
      
            decimal utilidadNeta = CalcularUtilidadNetaDesdeEstadoResultado(estadoResultado);

            CalcularActividadesOperacion(balanceActual, balanceAnterior, utilidadNeta);
            CalcularActividadesInversion(balanceActual, balanceAnterior);
            CalcularActividadesFinanciamiento(balanceActual, balanceAnterior);

            IncrementoNetoEfectivo = FlujoNetoOperacion + FlujoNetoInversion + FlujoNetoFinanciamiento;

          
            EfectivoInicial = CalcularEfectivoInicial(balanceAnterior);
            EfectivoFinal = EfectivoInicial + IncrementoNetoEfectivo;
        }

        private decimal CalcularUtilidadNetaDesdeEstadoResultado(EstadoResultado estadoResultado)
        {
         
            Console.Write("\nIngrese la utilidad neta del período: ");
            decimal utilidadNeta;
            while (!decimal.TryParse(Console.ReadLine(), out utilidadNeta))
            {
                Console.Write("Valor inválido. Ingrese la utilidad neta: ");
            }
            return utilidadNeta;
        }

        private void CalcularActividadesOperacion(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior,
                                                 decimal utilidadNeta)
        {
            Console.WriteLine("\n=== CÁLCULO DE ACTIVIDADES DE OPERACIÓN ===");

            decimal flujoOperacion = utilidadNeta;
            Console.WriteLine($"Utilidad neta: {utilidadNeta:C2}");

            decimal depreciacionAmortizacion = CalcularDepreciacionAmortizacion(balanceActual, balanceAnterior);
            flujoOperacion += depreciacionAmortizacion;
            Console.WriteLine($"(+) Depreciación y amortización: {depreciacionAmortizacion:C2}");

        
            decimal variacionCapitalTrabajo = CalcularVariacionesCapitalTrabajo(balanceActual, balanceAnterior);
            flujoOperacion += variacionCapitalTrabajo;

            FlujoNetoOperacion = flujoOperacion;
            Console.WriteLine($"FLUJO NETO DE OPERACIÓN: {FlujoNetoOperacion:C2}");
        }

        private decimal CalcularDepreciacionAmortizacion(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            decimal depreciacionTotal = 0m;

            var cuentasDepreciacion = new[] { "depreciación", "amortización", "dep. acumulada", "amort. acumulada" };

            foreach (var cuentaActual in balanceActual.ObtenerListaPlanaCuentas())
            {
                if (cuentasDepreciacion.Any(term => cuentaActual.Nombre.ToLower().Contains(term)))
                {
                    var cuentaAnterior = balanceAnterior.ObtenerListaPlanaCuentas()
                        .FirstOrDefault(c => c.Codigo == cuentaActual.Codigo);

                    decimal montoAnterior = cuentaAnterior?.Monto ?? 0m;
                    depreciacionTotal += cuentaActual.Monto - montoAnterior;
                }
            }

            Console.WriteLine($"Depreciación/amortización total: {depreciacionTotal:C2}");
            return depreciacionTotal;
        }

        private decimal CalcularVariacionesCapitalTrabajo(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            decimal variacionTotal = 0m;

            
            var clientesActual = ObtenerSaldoCuenta(balanceActual, "Clientes");
            var clientesAnterior = ObtenerSaldoCuenta(balanceAnterior, "Clientes");
            decimal variacionClientes = clientesAnterior - clientesActual;
            variacionTotal += variacionClientes;
            Console.WriteLine($"Variación en clientes: {variacionClientes:C2}");

            var inventariosActual = ObtenerSaldoCuenta(balanceActual, "Inventario");
            var inventariosAnterior = ObtenerSaldoCuenta(balanceAnterior, "Inventario");
            decimal variacionInventarios = inventariosAnterior - inventariosActual;
            variacionTotal += variacionInventarios;
            Console.WriteLine($"Variación en inventarios: {variacionInventarios:C2}");

            var proveedoresActual = ObtenerSaldoCuenta(balanceActual, "Proveedores");
            var proveedoresAnterior = ObtenerSaldoCuenta(balanceAnterior, "Proveedores");
            decimal variacionProveedores = proveedoresActual - proveedoresAnterior;
            variacionTotal += variacionProveedores;
            Console.WriteLine($"Variación en proveedores: {variacionProveedores:C2}");

            var acreedoresActual = ObtenerSaldoCuenta(balanceActual, "Acreedores diversos");
            var acreedoresAnterior = ObtenerSaldoCuenta(balanceAnterior, "Acreedores diversos");
            decimal variacionAcreedores = acreedoresActual - acreedoresAnterior;
            variacionTotal += variacionAcreedores;
            Console.WriteLine($"Variación en acreedores diversos: {variacionAcreedores:C2}");

 
            var impuestosActual = ObtenerSaldoCuenta(balanceActual, "Impuestos por pagar");
            var impuestosAnterior = ObtenerSaldoCuenta(balanceAnterior, "Impuestos por pagar");
            decimal variacionImpuestos = impuestosActual - impuestosAnterior;
            variacionTotal += variacionImpuestos;
            Console.WriteLine($"Variación en impuestos por pagar: {variacionImpuestos:C2}");

            Console.WriteLine($"Variación total en capital de trabajo: {variacionTotal:C2}");
            return variacionTotal;
        }

        private void CalcularActividadesInversion(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            Console.WriteLine("\n=== CÁLCULO DE ACTIVIDADES DE INVERSIÓN ===");

            decimal flujoInversion = 0m;

     
            decimal compraVentaActivos = CalcularCompraVentaActivosFijos(balanceActual, balanceAnterior);
            flujoInversion += compraVentaActivos;
            Console.WriteLine($"Compra/venta neta de activos fijos: {compraVentaActivos:C2}");

            decimal variacionInversiones = CalcularVariacionInversiones(balanceActual, balanceAnterior);
            flujoInversion += variacionInversiones;
            Console.WriteLine($"Variación en inversiones: {variacionInversiones:C2}");

            FlujoNetoInversion = flujoInversion;
            Console.WriteLine($"FLUJO NETO DE INVERSIÓN: {FlujoNetoInversion:C2}");
        }

        private decimal CalcularCompraVentaActivosFijos(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
      
            var activosFijosNombres = new[] { "Terrenos", "Edificios", "Maquinaria", "Vehículos", "Mobiliario y equipo de oficina" };

            decimal totalActual = 0m;
            decimal totalAnterior = 0m;

            foreach (var nombre in activosFijosNombres)
            {
                totalActual += ObtenerSaldoCuenta(balanceActual, nombre);
                totalAnterior += ObtenerSaldoCuenta(balanceAnterior, nombre);
            }

            return totalAnterior - totalActual;
        }

        private decimal CalcularVariacionInversiones(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            var inversionesActual = ObtenerSaldoCuenta(balanceActual, "Inversiones Temporales") +
                                   ObtenerSaldoCuenta(balanceActual, "Inversiones permanentes");
            var inversionesAnterior = ObtenerSaldoCuenta(balanceAnterior, "Inversiones Temporales") +
                                     ObtenerSaldoCuenta(balanceAnterior, "Inversiones permanentes");

            return inversionesAnterior - inversionesActual;
        }

        private void CalcularActividadesFinanciamiento(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            Console.WriteLine("\n=== CÁLCULO DE ACTIVIDADES DE FINANCIAMIENTO ===");

            decimal flujoFinanciamiento = 0m;

  
            decimal emisionCapital = CalcularEmisionCapital(balanceActual, balanceAnterior);
            flujoFinanciamiento += emisionCapital;
            Console.WriteLine($"(+) Emisión de capital: {emisionCapital:C2}");

  
            decimal prestamosNetos = CalcularPrestamosNetos(balanceActual, balanceAnterior);
            flujoFinanciamiento += prestamosNetos;
            Console.WriteLine($"(+) Préstamos netos: {prestamosNetos:C2}");

   
            decimal dividendosPagados = CalcularDividendosPagados(balanceActual, balanceAnterior);
            flujoFinanciamiento -= dividendosPagados;
            Console.WriteLine($"(-) Dividendos pagados: {dividendosPagados:C2}");

            FlujoNetoFinanciamiento = flujoFinanciamiento;
            Console.WriteLine($"FLUJO NETO DE FINANCIAMIENTO: {FlujoNetoFinanciamiento:C2}");
        }

        private decimal CalcularEmisionCapital(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            var capitalActual = ObtenerSaldoCuenta(balanceActual, "Capital social");
            var capitalAnterior = ObtenerSaldoCuenta(balanceAnterior, "Capital social");
            return Math.Max(capitalActual - capitalAnterior, 0);
        }

        private decimal CalcularPrestamosNetos(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            var prestamosActual = ObtenerSaldoCuenta(balanceActual, "Acreedores bancarios") +
                                 ObtenerSaldoCuenta(balanceActual, "Documentos por pagar");
            var prestamosAnterior = ObtenerSaldoCuenta(balanceAnterior, "Acreedores bancarios") +
                                   ObtenerSaldoCuenta(balanceAnterior, "Documentos por pagar");
            return prestamosActual - prestamosAnterior;
        }

        private decimal CalcularDividendosPagados(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            var dividendosActual = ObtenerSaldoCuenta(balanceActual, "Dividendos por pagar");
            var dividendosAnterior = ObtenerSaldoCuenta(balanceAnterior, "Dividendos por pagar");

            return Math.Max(dividendosAnterior - dividendosActual, 0);
        }

        private decimal CalcularEfectivoInicial(BalanceGeneral balanceAnterior)
        {
            return ObtenerSaldoCuenta(balanceAnterior, "Caja") +
                   ObtenerSaldoCuenta(balanceAnterior, "Bancos") +
                   ObtenerSaldoCuenta(balanceAnterior, "Fondos de caja chica");
        }

        private decimal ObtenerSaldoCuenta(BalanceGeneral balance, string nombreCuenta)
        {
            var cuenta = balance.ObtenerListaPlanaCuentas()
                .FirstOrDefault(c => c.Nombre.ToLower().Contains(nombreCuenta.ToLower()));
            return cuenta?.Monto ?? 0m;
        }

        public void MostrarEstadoFlujoEfectivo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine($"       ESTADO DE FLUJOS DE EFECTIVO");
            Console.WriteLine($"         (MÉTODO INDIRECTO - NIF B-2)");
            Console.WriteLine($"           {Entidad}");
            Console.WriteLine($"Del {FechaInicio:dd/MM/yyyy} al {FechaFin:dd/MM/yyyy}");
            Console.WriteLine("==================================================\n");

            Console.WriteLine("ACTIVIDADES DE OPERACIÓN:");         
            Console.WriteLine($"  Utilidad neta del período: {FlujoNetoOperacion,15:C2}");
            Console.WriteLine($"  Ajustes por partidas no monetarias");
            Console.WriteLine($"  Cambios en capital de trabajo");
            Console.WriteLine($"  Flujo neto de actividades de operación: {FlujoNetoOperacion,8:C2}\n");

     
            Console.WriteLine("ACTIVIDADES DE INVERSIÓN:");      
            Console.WriteLine($"  Compra/venta de activos fijos");
            Console.WriteLine($"  Inversiones financieras");
            Console.WriteLine($"  Flujo neto de actividades de inversión: {FlujoNetoInversion,9:C2}\n");


            Console.WriteLine("ACTIVIDADES DE FINANCIAMIENTO:");
            Console.WriteLine($"  Emisión de capital y deuda");
            Console.WriteLine($"  Pago de dividendos");
            Console.WriteLine($"  Flujo neto de actividades de financiamiento: {FlujoNetoFinanciamiento,5:C2}\n");

            Console.WriteLine("RESUMEN:");
            Console.WriteLine($"  Efectivo al inicio del período: {EfectivoInicial,13:C2}");
            Console.WriteLine($"  Incremento/Disminución neta de efectivo: {IncrementoNetoEfectivo,3:C2}");
            Console.WriteLine($"  EFECTIVO AL FINAL DEL PERÍODO: {EfectivoFinal,17:C2}");

            Console.ResetColor();
            Console.WriteLine("\n==================================================");
        }

        public void MostrarVariacionAO_AI_AF()
        {
            Console.WriteLine("\n=== VARIACIÓN POR TIPO DE ACTIVIDAD ===");
            Console.WriteLine($"Actividades de Operación (AO):    {FlujoNetoOperacion,12:C2}");
            Console.WriteLine($"Actividades de Inversión (AI):    {FlujoNetoInversion,12:C2}");
            Console.WriteLine($"Actividades de Financiamiento (AF): {FlujoNetoFinanciamiento,9:C2}");
            Console.WriteLine($"INCREMENTO/DISMINUCIÓN NETA: {IncrementoNetoEfectivo,12:C2}");


            decimal efectivoExcedente = FlujoNetoOperacion + FlujoNetoInversion;
            if (efectivoExcedente > 0)
            {
                Console.WriteLine($"\nEFECTIVO EXCEDENTE PARA FINANCIAMIENTO: {efectivoExcedente:C2}");
            }
            else
            {
                Console.WriteLine($"\nEFECTIVO REQUERIDO DE FINANCIAMIENTO: {Math.Abs(efectivoExcedente):C2}");
            }

            Console.WriteLine("\n=== ANÁLISIS DE LA SITUACIÓN FINANCIERA ===");
            if (FlujoNetoOperacion > 0)
            {
                Console.WriteLine("La empresa genera efectivo positivo de sus operaciones principales");
            }
            else
            {
                Console.WriteLine("La empresa no genera suficiente efectivo de sus operaciones");
            }

            if (FlujoNetoInversion < 0)
            {
                Console.WriteLine(" La empresa está invirtiendo en activos para crecimiento futuro");
            }

            if (FlujoNetoFinanciamiento > 0)
            {
                Console.WriteLine("La empresa está obteniendo financiamiento externo");
            }
        }
    }
}