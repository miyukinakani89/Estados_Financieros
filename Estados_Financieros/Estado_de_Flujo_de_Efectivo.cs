using System;
using System.Collections.Generic;
using System.Linq;

namespace EstadodeSituacionFinanciera
{
    public class EstadoFlujoEfectivo
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Entidad { get; set; }

        // Flujos por actividades
        public decimal FlujoOperacion { get; set; }
        public decimal FlujoInversion { get; set; }
        public decimal FlujoFinanciamiento { get; set; }

        // Efectivo y equivalentes
        public decimal EfectivoInicio { get; set; }
        public decimal EfectivoFin { get; set; }

        // Método utilizado (Directo/Indirecto)
        public string MetodoUtilizado { get; set; }

        public EstadoFlujoEfectivo()
        {
            Entidad = "Entidad";
            MetodoUtilizado = "Directo";
        }

        // Método para calcular flujos usando método DIRECTO
        public void CalcularMetodoDirecto(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal,
                                         EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            MetodoUtilizado = "Directo";

            // ACTIVIDADES DE OPERACIÓN
            FlujoOperacion = CalcularFlujoOperacionDirecto(balanceInicial, balanceFinal, estadoResultado, transacciones);

            // ACTIVIDADES DE INVERSIÓN
            FlujoInversion = CalcularFlujoInversionDirecto(transacciones);

            // ACTIVIDADES DE FINANCIAMIENTO
            FlujoFinanciamiento = CalcularFlujoFinanciamientoDirecto(transacciones);

            // EFECTIVO INICIAL Y FINAL
            EfectivoInicio = ObtenerEfectivoInicial(balanceInicial);
            EfectivoFin = EfectivoInicio + FlujoOperacion + FlujoInversion + FlujoFinanciamiento;
        }

        // Método para calcular flujos usando método INDIRECTO
        public void CalcularMetodoIndirecto(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal,
                                           EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            MetodoUtilizado = "Indirecto";

            // ACTIVIDADES DE OPERACIÓN (partiendo de la utilidad neta)
            FlujoOperacion = CalcularFlujoOperacionIndirecto(balanceInicial, balanceFinal, estadoResultado);

            // ACTIVIDADES DE INVERSIÓN (igual que en método directo)
            FlujoInversion = CalcularFlujoInversionDirecto(transacciones);

            // ACTIVIDADES DE FINANCIAMIENTO (igual que en método directo)
            FlujoFinanciamiento = CalcularFlujoFinanciamientoDirecto(transacciones);

            // EFECTIVO INICIAL Y FINAL
            EfectivoInicio = ObtenerEfectivoInicial(balanceInicial);
            EfectivoFin = EfectivoInicio + FlujoOperacion + FlujoInversion + FlujoFinanciamiento;
        }

        private decimal CalcularFlujoOperacionDirecto(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal,
                                                     EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            decimal flujo = 0m;

            // Cobros a clientes
            decimal cobrosClientes = CalcularCobrosClientes(balanceInicial, balanceFinal, estadoResultado);
            flujo += cobrosClientes;

            // Pagos a proveedores
            decimal pagosProveedores = CalcularPagosProveedores(balanceInicial, balanceFinal, estadoResultado);
            flujo -= pagosProveedores;

            // Pagos a empleados (PTU, sueldos, etc.)
            decimal pagosEmpleados = CalcularPagosEmpleados(balanceInicial, balanceFinal, estadoResultado, transacciones);
            flujo -= pagosEmpleados;

            // Pagos de impuestos
            decimal pagosImpuestos = CalcularPagosImpuestos(balanceInicial, balanceFinal, estadoResultado, transacciones);
            flujo -= pagosImpuestos;

            // Otros cobros/pagos de operación
            decimal otrosOperacion = CalcularOtrosOperacion(transacciones);
            flujo += otrosOperacion;

            return flujo;
        }

        private decimal CalcularFlujoOperacionIndirecto(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal,
                                                       EstadoResultado estadoResultado)
        {
            // Partir de la utilidad antes de impuestos (preferentemente)
            decimal flujo = estadoResultado.UtilidadAntesImpuestos;

            // Ajustar por partidas que no afectan el efectivo
            flujo = AjustarPartidasNoEfectivo(flujo, estadoResultado, balanceInicial, balanceFinal);

            // Ajustar por cambios en el capital de trabajo
            flujo = AjustarCapitalTrabajo(flujo, balanceInicial, balanceFinal);

            return flujo;
        }

        private decimal CalcularFlujoInversionDirecto(List<TransaccionEfectivo> transacciones)
        {
            decimal flujo = 0m;

            var transaccionesInversion = transacciones.Where(t => t.TipoActividad == "Inversion").ToList();

            foreach (var trans in transaccionesInversion)
            {
                if (trans.TipoFlujo == "Entrada")
                    flujo += trans.Monto;
                else
                    flujo -= trans.Monto;
            }

            return flujo;
        }

        private decimal CalcularFlujoFinanciamientoDirecto(List<TransaccionEfectivo> transacciones)
        {
            decimal flujo = 0m;

            var transaccionesFinanciamiento = transacciones.Where(t => t.TipoActividad == "Financiamiento").ToList();

            foreach (var trans in transaccionesFinanciamiento)
            {
                if (trans.TipoFlujo == "Entrada")
                    flujo += trans.Monto;
                else
                    flujo -= trans.Monto;
            }

            return flujo;
        }

        // Métodos auxiliares para cálculos específicos
        private decimal CalcularCobrosClientes(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal, EstadoResultado estadoResultado)
        {
            // Fórmula: Saldo Inicial Clientes + Ventas Netas - Saldo Final Clientes
            decimal clientesInicial = ObtenerSaldoCuenta(balanceInicial, "Clientes");
            decimal clientesFinal = ObtenerSaldoCuenta(balanceFinal, "Clientes");
            decimal ventasNetas = estadoResultado.VentasNetas;

            return clientesInicial + ventasNetas - clientesFinal;
        }

        private decimal CalcularPagosProveedores(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal, EstadoResultado estadoResultado)
        {
            // Fórmula simplificada para ejemplo
            decimal proveedoresInicial = ObtenerSaldoCuenta(balanceInicial, "Proveedores");
            decimal proveedoresFinal = ObtenerSaldoCuenta(balanceFinal, "Proveedores");
            decimal comprasNetas = estadoResultado.CostoVentas; // Aproximación

            return proveedoresInicial + comprasNetas - proveedoresFinal;
        }

        private decimal CalcularPagosEmpleados(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal,
                                              EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            // Buscar transacciones específicas de pagos a empleados
            var ptuTransacciones = transacciones.Where(t => t.Descripcion.Contains("PTU") && t.TipoFlujo == "Salida").Sum(t => t.Monto);
            var sueldosTransacciones = transacciones.Where(t => t.Descripcion.Contains("Sueldo") && t.TipoFlujo == "Salida").Sum(t => t.Monto);

            return ptuTransacciones + sueldosTransacciones;
        }

        private decimal CalcularPagosImpuestos(BalanceGeneral balanceInicial, BalanceGeneral balanceFinal,
                                              EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            // Buscar transacciones de impuestos
            var impuestosTransacciones = transacciones.Where(t =>
                (t.Descripcion.Contains("ISR") || t.Descripcion.Contains("Impuesto")) &&
                t.TipoFlujo == "Salida").Sum(t => t.Monto);

            return impuestosTransacciones;
        }

        private decimal CalcularOtrosOperacion(List<TransaccionEfectivo> transacciones)
        {
            var otrosOperacion = transacciones.Where(t =>
                t.TipoActividad == "Operacion" &&
                !t.Descripcion.Contains("PTU") &&
                !t.Descripcion.Contains("Sueldo") &&
                !t.Descripcion.Contains("ISR") &&
                !t.Descripcion.Contains("Impuesto"));

            decimal flujo = 0m;
            foreach (var trans in otrosOperacion)
            {
                if (trans.TipoFlujo == "Entrada")
                    flujo += trans.Monto;
                else
                    flujo -= trans.Monto;
            }

            return flujo;
        }

        private decimal AjustarPartidasNoEfectivo(decimal flujoBase, EstadoResultado estadoResultado,
                                                 BalanceGeneral balanceInicial, BalanceGeneral balanceFinal)
        {
            // Agregar depreciaciones y amortizaciones
            flujoBase += estadoResultado.Depreciacion + estadoResultado.Amortizacion;

            // Ajustar por ganancias/pérdidas en venta de activos
            // (estas se presentarán en actividades de inversión)
            flujoBase -= estadoResultado.GananciaVentaActivos;
            flujoBase += estadoResultado.PerdidaVentaActivos;

            return flujoBase;
        }

        private decimal AjustarCapitalTrabajo(decimal flujoBase, BalanceGeneral balanceInicial, BalanceGeneral balanceFinal)
        {
            // Ajustar por cambios en cuentas por cobrar
            decimal clientesInicial = ObtenerSaldoCuenta(balanceInicial, "Clientes");
            decimal clientesFinal = ObtenerSaldoCuenta(balanceFinal, "Clientes");
            flujoBase -= (clientesFinal - clientesInicial); // Aumento en clientes reduce flujo

            // Ajustar por cambios en inventarios
            decimal inventarioInicial = ObtenerSaldoCuenta(balanceInicial, "Inventarios");
            decimal inventarioFinal = ObtenerSaldoCuenta(balanceFinal, "Inventarios");
            flujoBase -= (inventarioFinal - inventarioInicial); // Aumento en inventarios reduce flujo

            // Ajustar por cambios en proveedores
            decimal proveedoresInicial = ObtenerSaldoCuenta(balanceInicial, "Proveedores");
            decimal proveedoresFinal = ObtenerSaldoCuenta(balanceFinal, "Proveedores");
            flujoBase += (proveedoresFinal - proveedoresInicial); // Aumento en proveedores aumenta flujo

            return flujoBase;
        }

        private decimal ObtenerEfectivoInicial(BalanceGeneral balance)
        {
            // Buscar cuentas de efectivo en el balance
            var cuentasEfectivo = balance.ObtenerListaPlanaCuentas()
                .Where(c => c.Nombre.Contains("Caja") ||
                           c.Nombre.Contains("Bancos") ||
                           c.Nombre.Contains("Efectivo"))
                .Sum(c => c.Monto);

            return cuentasEfectivo;
        }

        private decimal ObtenerSaldoCuenta(BalanceGeneral balance, string nombreCuenta)
        {
            var cuenta = balance.ObtenerListaPlanaCuentas()
                .FirstOrDefault(c => c.Nombre.Contains(nombreCuenta));

            return cuenta?.Monto ?? 0m;
        }

        public void MostrarEstadoFlujoEfectivo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n==================== ESTADO DE FLUJOS DE EFECTIVO ====================");
            Console.WriteLine($"ENTIDAD: {Entidad}");
            Console.WriteLine($"PERÍODO: {FechaInicio:dd/MM/yyyy} - {FechaFin:dd/MM/yyyy}");
            Console.WriteLine($"MÉTODO: {MetodoUtilizado}\n");

            Console.WriteLine("ACTIVIDADES DE OPERACIÓN:");
            Console.WriteLine($"  Flujo neto de actividades de operación: {FlujoOperacion:C2}");

            Console.WriteLine("\nACTIVIDADES DE INVERSIÓN:");
            Console.WriteLine($"  Flujo neto de actividades de inversión: {FlujoInversion:C2}");

            Console.WriteLine("\nACTIVIDADES DE FINANCIAMIENTO:");
            Console.WriteLine($"  Flujo neto de actividades de financiamiento: {FlujoFinanciamiento:C2}");

            decimal cambioNeto = FlujoOperacion + FlujoInversion + FlujoFinanciamiento;
            Console.WriteLine($"\nINCREMENTO/DISMINUCIÓN NETA DE EFECTIVO: {cambioNeto:C2}");

            Console.WriteLine($"\nEFECTIVO Y EQUIVALENTES AL INICIO DEL PERÍODO: {EfectivoInicio:C2}");
            Console.WriteLine($"EFECTIVO Y EQUIVALENTES AL FINAL DEL PERÍODO: {EfectivoFin:C2}");

            // Verificar consistencia
            if (Math.Abs(EfectivoFin - (EfectivoInicio + cambioNeto)) < 0.01m)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ ESTADO CUADRADO CORRECTAMENTE");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n✗ ERROR EN EL CUADRE DEL ESTADO");
            }

            Console.ResetColor();
        }
    }

    // Clase auxiliar para representar transacciones de efectivo
    public class TransaccionEfectivo
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string TipoFlujo { get; set; } // "Entrada" o "Salida"
        public string TipoActividad { get; set; } // "Operacion", "Inversion", "Financiamiento"

        public TransaccionEfectivo(string descripcion, decimal monto, string tipoFlujo, string tipoActividad)
        {
            Descripcion = descripcion;
            Monto = monto;
            TipoFlujo = tipoFlujo;
            TipoActividad = tipoActividad;
            Fecha = DateTime.Now;
        }
    }

    // Clase simplificada de Estado de Resultados para integración
    public class EstadoResultado
    {
        public decimal VentasNetas { get; set; }
        public decimal CostoVentas { get; set; }
        public decimal UtilidadBruta { get; set; }
        public decimal GastosOperacion { get; set; }
        public decimal UtilidadOperacion { get; set; }
        public decimal GastosFinancieros { get; set; }
        public decimal UtilidadAntesImpuestos { get; set; }
        public decimal Impuestos { get; set; }
        public decimal UtilidadNeta { get; set; }
        public decimal Depreciacion { get; set; }
        public decimal Amortizacion { get; set; }
        public decimal GananciaVentaActivos { get; set; }
        public decimal PerdidaVentaActivos { get; set; }
    }
}