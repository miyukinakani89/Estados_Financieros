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


        public void CalcularFlujosDesdeEstados(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior,
                                              decimal utilidadNeta)
        {
            CalcularActividadesOperacion(balanceActual, balanceAnterior, utilidadNeta);

            CalcularActividadesInversion(balanceActual, balanceAnterior);

            CalcularActividadesFinanciamiento(balanceActual, balanceAnterior);

            IncrementoNetoEfectivo = FlujoNetoOperacion + FlujoNetoInversion + FlujoNetoFinanciamiento;
        }

        private void CalcularActividadesOperacion(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior,
                                                 decimal utilidadNeta)
        {
            Console.WriteLine("\n ===CÁLCULO DE ACTIVIDADES DE OPERACIÓN ---");

            // 1. Utilidad neta como punto de partida
            decimal flujoOperacion = utilidadNeta;
            Console.WriteLine($"Utilidad neta: {utilidadNeta:C2}");

            // 2. Ajustes por partidas no monetarias
            decimal depreciacionAmortizacion = CalcularDepreciacionAmortizacion(balanceActual, balanceAnterior);
            flujoOperacion += depreciacionAmortizacion;
            Console.WriteLine($"(+) Depreciación y amortización: {depreciacionAmortizacion:C2}");

            // 3. Cambios en el capital de trabajo
            decimal variacionCapitalTrabajo = CalcularVariacionesCapitalTrabajo(balanceActual, balanceAnterior);
            flujoOperacion += variacionCapitalTrabajo;

            FlujoNetoOperacion = flujoOperacion;
            Console.WriteLine($"FLUJO NETO DE OPERACIÓN: {FlujoNetoOperacion:C2}");
        }

        private decimal CalcularDepreciacionAmortizacion(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            decimal depreciacionTotal = 0m;

            // Buscar todas las cuentas de depreciación y amortización
            var cuentasDepreciacionActual = balanceActual.ObtenerListaPlanaCuentas()
                .Where(c => c.Nombre.ToLower().Contains("depreciación") ||
                           c.Nombre.ToLower().Contains("amortización") ||
                           c.Nombre.ToLower().Contains("dep. acumulada"))
                .ToList();

            var cuentasDepreciacionAnterior = balanceAnterior.ObtenerListaPlanaCuentas()
                .Where(c => c.Nombre.ToLower().Contains("depreciación") ||
                           c.Nombre.ToLower().Contains("amortización") ||
                           c.Nombre.ToLower().Contains("dep. acumulada"))
                .ToList();

            foreach (var cuentaActual in cuentasDepreciacionActual)
            {
                var cuentaAnterior = cuentasDepreciacionAnterior
                    .FirstOrDefault(c => c.Nombre == cuentaActual.Nombre);

                if (cuentaAnterior != null)
                {
                    depreciacionTotal += cuentaActual.Monto - cuentaAnterior.Monto;
                }
            }

            Console.WriteLine($"Depreciación/amortización total: {depreciacionTotal:C2}");
            return depreciacionTotal;
        }

        private decimal CalcularVariacionesCapitalTrabajo(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            decimal variacionTotal = 0m;

            // Cuentas por cobrar (clientes) - Aumento disminuye flujo, disminución aumenta flujo
            var clientesActual = ObtenerSaldoCuenta(balanceActual, "Clientes");
            var clientesAnterior = ObtenerSaldoCuenta(balanceAnterior, "Clientes");
            decimal variacionClientes = clientesAnterior - clientesActual;
            variacionTotal += variacionClientes;
            Console.WriteLine($"Variación en clientes: {variacionClientes:C2} ({clientesAnterior} - {clientesActual})");

            // Inventarios - Aumento disminuye flujo, disminución aumenta flujo
            var inventariosActual = ObtenerSaldoCuenta(balanceActual, "Inventarios");
            var inventariosAnterior = ObtenerSaldoCuenta(balanceAnterior, "Inventarios");
            decimal variacionInventarios = inventariosAnterior - inventariosActual;
            variacionTotal += variacionInventarios;
            Console.WriteLine($"Variación en inventarios: {variacionInventarios:C2} ({inventariosAnterior} - {inventariosActual})");

            // Proveedores - Aumento aumenta flujo, disminución disminuye flujo
            var proveedoresActual = ObtenerSaldoCuenta(balanceActual, "Proveedores");
            var proveedoresAnterior = ObtenerSaldoCuenta(balanceAnterior, "Proveedores");
            decimal variacionProveedores = proveedoresActual - proveedoresAnterior;
            variacionTotal += variacionProveedores;
            Console.WriteLine($"Variación en proveedores: {variacionProveedores:C2} ({proveedoresActual} - {proveedoresAnterior})");

            // Acreedores diversos
            var acreedoresActual = ObtenerSaldoCuenta(balanceActual, "Acreedores diversos");
            var acreedoresAnterior = ObtenerSaldoCuenta(balanceAnterior, "Acreedores diversos");
            decimal variacionAcreedores = acreedoresActual - acreedoresAnterior;
            variacionTotal += variacionAcreedores;
            Console.WriteLine($"Variación en acreedores diversos: {variacionAcreedores:C2}");

            // ISR por pagar
            var isrActual = ObtenerSaldoCuenta(balanceActual, "ISR por Pagar");
            var isrAnterior = ObtenerSaldoCuenta(balanceAnterior, "ISR por Pagar");
            decimal variacionISR = isrActual - isrAnterior;
            variacionTotal += variacionISR;
            Console.WriteLine($"Variación en ISR por pagar: {variacionISR:C2}");

            // PTU por pagar
            var ptuActual = ObtenerSaldoCuenta(balanceActual, "PTU por pagar");
            var ptuAnterior = ObtenerSaldoCuenta(balanceAnterior, "PTU por pagar");
            decimal variacionPTU = ptuActual - ptuAnterior;
            variacionTotal += variacionPTU;
            Console.WriteLine($"Variación en PTU por pagar: {variacionPTU:C2}");

            Console.WriteLine($"Variación total en capital de trabajo: {variacionTotal:C2}");
            return variacionTotal;
        }

        private void CalcularActividadesInversion(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            Console.WriteLine("\n--- CÁLCULO DE ACTIVIDADES DE INVERSIÓN ---");

            decimal flujoInversion = 0m;

            // Compra/venta de activos fijos
            decimal compraVentaActivos = CalcularCompraVentaActivosFijos(balanceActual, balanceAnterior);
            flujoInversion += compraVentaActivos;
            Console.WriteLine($"Compra/venta neta de activos fijos: {compraVentaActivos:C2}");

            FlujoNetoInversion = flujoInversion;
            Console.WriteLine($"FLUJO NETO DE INVERSIÓN: {FlujoNetoInversion:C2}");
        }

        private decimal CalcularCompraVentaActivosFijos(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            // Calcular el cambio neto en activos fijos (excluyendo depreciación)
            var activosFijosActual = CalcularTotalActivosFijos(balanceActual);
            var activosFijosAnterior = CalcularTotalActivosFijos(balanceAnterior);

            // Si los activos aumentaron, fue por compra (flujo negativo)
            // Si los activos disminuyeron, fue por venta (flujo positivo)
            return activosFijosAnterior - activosFijosActual;
        }

        private decimal CalcularTotalActivosFijos(BalanceGeneral balance)
        {
            // Sumar todos los activos fijos excluyendo depreciación acumulada
            decimal total = 0m;

            // Terrenos
            total += ObtenerSaldoCuenta(balance, "Terrenos");

            // Edificios (valor bruto)
            total += ObtenerSaldoCuenta(balance, "Edificios");

            // Maquinaria
            total += ObtenerSaldoCuenta(balance, "Maquinaria");

            // Mobiliario y equipo
            total += ObtenerSaldoCuenta(balance, "Mobiliario y equipo de oficina");

            // Equipo de transporte
            total += ObtenerSaldoCuenta(balance, "Equipo de Transporte");

            return total;
        }

        private void CalcularActividadesFinanciamiento(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            Console.WriteLine("\n--- CÁLCULO DE ACTIVIDADES DE FINANCIAMIENTO ---");

            decimal flujoFinanciamiento = 0m;

            // Emisión de capital
            decimal emisionCapital = CalcularEmisionCapital(balanceActual, balanceAnterior);
            flujoFinanciamiento += emisionCapital;
            Console.WriteLine($"(+) Emisión de capital: {emisionCapital:C2}");

            // Obtención y pago de préstamos netos
            decimal prestamosNetos = CalcularPrestamosNetos(balanceActual, balanceAnterior);
            flujoFinanciamiento += prestamosNetos;
            Console.WriteLine($"(+) Préstamos netos: {prestamosNetos:C2}");

            // Dividendos pagados (estimado)
            decimal dividendosPagados = CalcularDividendosPagados(balanceActual, balanceAnterior);
            flujoFinanciamiento -= dividendosPagados;
            Console.WriteLine($"(-) Dividendos pagados: {dividendosPagados:C2}");

            FlujoNetoFinanciamiento = flujoFinanciamiento;
            Console.WriteLine($"FLUJO NETO DE FINANCIAMIENTO: {FlujoNetoFinanciamiento:C2}");
        }

        private decimal CalcularEmisionCapital(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            var capitalActual = ObtenerSaldoCuenta(balanceActual, "Capital Social");
            var capitalAnterior = ObtenerSaldoCuenta(balanceAnterior, "Capital Social");
            return Math.Max(capitalActual - capitalAnterior, 0);
        }

        private decimal CalcularPrestamosNetos(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            var prestamosActual = ObtenerSaldoCuenta(balanceActual, "Préstamos bancarios a largo plazo") +
                                 ObtenerSaldoCuenta(balanceActual, "Acreedores Bancarios");
            var prestamosAnterior = ObtenerSaldoCuenta(balanceAnterior, "Préstamos bancarios a largo plazo") +
                                   ObtenerSaldoCuenta(balanceAnterior, "Acreedores Bancarios");
            return prestamosActual - prestamosAnterior;
        }

        private decimal CalcularDividendosPagados(BalanceGeneral balanceActual, BalanceGeneral balanceAnterior)
        {
            // Estimación simple: si las utilidades retenidas disminuyeron más allá de la utilidad neta,
            // probablemente se pagaron dividendos
            var utilidadesActual = ObtenerSaldoCuenta(balanceActual, "Utilidades retenidas");
            var utilidadesAnterior = ObtenerSaldoCuenta(balanceAnterior, "Utilidades retenidas");

            // Esta es una estimación - en un sistema real se tendría el dato exacto
            return Math.Max(utilidadesAnterior - utilidadesActual, 0);
        }

        private decimal ObtenerSaldoCuenta(BalanceGeneral balance, string nombreCuenta)
        {
            var cuenta = balance.ObtenerListaPlanaCuentas()
                .FirstOrDefault(c => c.Nombre.Contains(nombreCuenta));
            return cuenta?.Monto ?? 0m;
        }

        public void MostrarEstadoFlujoEfectivo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================================================");
            Console.WriteLine($"       ESTADO DE FLUJOS DE EFECTIVO");
            Console.WriteLine($"         (MÉTODO INDIRECTO - NIF B-2)");
            Console.WriteLine($"           {Entidad}");
            Console.WriteLine($"Del {FechaInicio:dd/MM/yyyy} al {FechaFin:dd/MM/yyyy}");
            Console.WriteLine("==================================================\n");

            // ACTIVIDADES DE OPERACIÓN
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ACTIVIDADES DE OPERACIÓN:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  Flujo neto de actividades de operación: {FlujoNetoOperacion,10:C2}\n");

            // ACTIVIDADES DE INVERSIÓN
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ACTIVIDADES DE INVERSIÓN:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  Flujo neto de actividades de inversión: {FlujoNetoInversion,12:C2}\n");

            // ACTIVIDADES DE FINANCIAMIENTO
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ACTIVIDADES DE FINANCIAMIENTO:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  Flujo neto de actividades de financiamiento: {FlujoNetoFinanciamiento,6:C2}\n");

            // RESUMEN FINAL
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("RESUMEN:");
            Console.ForegroundColor = ConsoleColor.White;

            // Obtener efectivo inicial del balance anterior
            decimal efectivoInicial = ObtenerSaldoCuenta(new BalanceGeneral(), "Caja") +
                                     ObtenerSaldoCuenta(new BalanceGeneral(), "Bancos");
            decimal efectivoFinal = efectivoInicial + IncrementoNetoEfectivo;

            Console.WriteLine($"  Efectivo al inicio del período: {efectivoInicial,4:C2}");
            Console.WriteLine($"  Incremento/Disminución neta de efectivo: {IncrementoNetoEfectivo,0:C2}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  EFECTIVO AL FINAL DEL PERÍODO: {efectivoFinal,8:C2}");

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

            // Análisis según NIF B-2
            decimal efectivoExcedente = FlujoNetoOperacion + FlujoNetoInversion;
            if (efectivoExcedente > 0)
            {
                Console.WriteLine($"\nEFECTIVO EXCEDENTE PARA FINANCIAMIENTO: {efectivoExcedente:C2}");
            }
            else
            {
                Console.WriteLine($"\nEFECTIVO REQUERIDO DE FINANCIAMIENTO: {Math.Abs(efectivoExcedente):C2}");
            }
        }
    }
}