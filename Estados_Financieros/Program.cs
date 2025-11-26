using Estadosfinancieros;
using System;
using System.Collections.Generic;

namespace SistemaFinanciero
{
    class Program
    {
        static BalanceGeneral balanceActual = new BalanceGeneral();
        static BalanceGeneral balanceAnterior = new BalanceGeneral();
        static EstadoResultado estadoResultado = new EstadoResultado();
        static EstadoFlujoEfectivo estadoFlujoEfectivo = new EstadoFlujoEfectivo();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("==========================================");
                Console.WriteLine("       SISTEMA DE ESTADOS FINANCIEROS");
                Console.WriteLine("==========================================");
                Console.ResetColor();
                Console.WriteLine("\n1. Ingresar Datos del Balance General (Período Actual)");
                Console.WriteLine("2. Ingresar Datos del Balance General (Período Anterior)");
                Console.WriteLine("3. Ingresar Datos del Estado de Resultados");
                Console.WriteLine("4. Generar Estado de Flujos de Efectivo (Método Indirecto)");
                Console.WriteLine("5. Mostrar Resumen de Datos Ingresados");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                int opcion = 0;
                do
                {
                    try
                    {
                        opcion = int.Parse(Console.ReadLine() ?? "");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada no válida. Intente de nuevo:");
                    }
                } while (opcion < 1 || opcion > 6);

                switch (opcion)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n=== BALANCE GENERAL (PERÍODO ACTUAL) ===");
                        Console.ResetColor();
                        IngresarDatosBalance(balanceActual);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n=== BALANCE GENERAL ( PERÍODO ANTERIOR) ===");
                        Console.ResetColor();
                        IngresarDatosBalance(balanceAnterior);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n=== ESTADO DE RESULTADOS ===");
                        Console.ResetColor();
                        IngresarDatosEstadoResultados(estadoResultado);
                        break;
                    case 4:
                        GenerarFlujoEfectivo();
                        break;
                    case 5:
                        MostrarResumenDatos();
                        break;
                    case 6:
                        salir = true;
                        break;
                }
            }

            Console.WriteLine("Finalizando....");
        }

        static void MostrarResumenDatos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========================================");
            Console.WriteLine("           RESUMEN DE DATOS INGRESADOS");
            Console.WriteLine("==========================================");
            Console.ResetColor();

            Console.WriteLine("\n--- BALANCE GENERAL PERÍODO ANTERIOR ---");
            balanceAnterior.MostrarResumenCuentasNoCero();
            Console.WriteLine($"Total Activo Anterior: balanceAnterior.TotalActivo()");

            Console.WriteLine("\n--- BALANCE GENERAL PERÍODO ACTUAL ---");
            balanceActual.MostrarResumenCuentasNoCero();
            Console.WriteLine($"Total Activo Actual: balanceActual.TotalActivo()");

            Console.WriteLine("\n--- VERIFICACIÓN DE CUADRE ---");
            var (cuadraAnterior, diferenciaAnterior) = balanceAnterior.VerificarCuadre();
            var (cuadraActual, diferenciaActual) = balanceActual.VerificarCuadre();

            Console.WriteLine($"Balance Anterior: {(cuadraAnterior ? "Cuadra" : " No cuadra")} (Diferencia: {diferenciaAnterior:C2})");
            Console.WriteLine($"Balance Actual: {(cuadraActual ? " Cuadra" : "No cuadra")} (Diferencia: {diferenciaActual:C2})");

            Pausa();
        }

        static void GenerarFlujoEfectivo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========================================");
            Console.WriteLine("     GENERAR ESTADO DE FLUJOS DE EFECTIVO");
            Console.WriteLine("==========================================");
            Console.ResetColor();
            bool datosCompletos = true;

            Console.WriteLine("\nDatos Necesarios");

            if (balanceAnterior.TotalActivo() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falta el balance general del período anterior");
                datosCompletos = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Balance General del período anterior: Completado");
            }

            if (balanceActual.TotalActivo() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falta el balane del periodo actual");
                datosCompletos = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Balance General del período actual: Completado");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Estado de Resultados: Se solicitará la utilidad neta");

            if (!datosCompletos)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n No se pueden generar los flujos de efectivo. Faltan datos.");
                Console.WriteLine("Por favor, ingrese todos los balances generales requeridos.");
                Pausa();
                return;
            }


            estadoFlujoEfectivo.FechaInicio = DateTime.Now.AddYears(-1);
            estadoFlujoEfectivo.FechaFin = DateTime.Now;
            estadoFlujoEfectivo.Entidad = "Empresa";

            Console.WriteLine($"\nPeríodo: {estadoFlujoEfectivo.FechaInicio:dd/MM/yyyy} al {estadoFlujoEfectivo.FechaFin:dd/MM/yyyy}");

            estadoFlujoEfectivo.CalcularFlujosDesdeEstados(balanceActual, balanceAnterior, estadoResultado);

            Console.WriteLine("\n");
            estadoFlujoEfectivo.MostrarEstadoFlujoEfectivo();
            estadoFlujoEfectivo.MostrarVariacionAO_AI_AF();

            Pausa();
        }

        static void IngresarDatosBalance(BalanceGeneral balance)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========== INGRESAR DATOS BALANCE GENERAL ==========\n");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("\nElija una opción para ingresar montos:");
                Console.WriteLine("1. Ingresar montos por sección (Activo circulante, Activo no circulante, Pasivo, Capital)");
                Console.WriteLine("2. Ingresar montos para todas las cuentas en orden (más rápido)");
                Console.WriteLine("3. Mostrar Balance actual y verificar cuadre");
                Console.WriteLine("4. Mostrar resumen de cuentas no cero");
                Console.WriteLine("5. Finalizar y guardar");

                Console.Write("\nOpción: ");
                var opt = Console.ReadLine()?.Trim();

                if (opt == "1")
                {
                    IngresarPorSecciones(balance);
                }
                else if (opt == "2")
                {
                    IngresarTodasCuentas(balance);
                }
                else if (opt == "3")
                {
                    balance.MostrarBalanceCompleto();
                    var (cuadra, diferencia) = balance.VerificarCuadre();
                    if (cuadra)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("El Balance cuadra: ACTIVO = PASIVO + CAPITAL");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" El Balance NO cuadra. Diferencia: {diferencia:C2}");
                        Console.WriteLine("Revisa los montos ingresados.");
                    }
                    Console.ResetColor();
                    Pausa();
                }
                else if (opt == "4")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    balance.MostrarResumenCuentasNoCero();
                    Pausa();
                }
                else if (opt == "5")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Datos del Balance General guardados correctamente.");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.ResetColor();
                }
            }
        }

        static void IngresarTodasCuentas(BalanceGeneral balance)
        {
            var lista = balance.ObtenerListaPlanaCuentas();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nIngresando para todas las cuentas {Para omitir una cuenta, deje en blanco o escriba 0}.");

            for (int i = 0; i < lista.Count; i++)
            {
                var c = lista[i];
                Console.Write($"\n{c.Codigo} {c.Nombre} ({c.Clasificacion}) - Monto actual {c.Monto:C2}. Ingrese monto nuevo: ");
                var entrada = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(entrada)) continue;

                decimal val = BalanceGeneral.ObtenerDecimal(entrada);
                c.Monto = val;
            }

            Console.WriteLine("\nIngreso completo.");
            Pausa();
        }

        static void IngresarPorSecciones(BalanceGeneral balance)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nSecciones disponibles:");
            Console.WriteLine("1. Activo Circulante");
            Console.WriteLine("2. Activo No Circulante");
            Console.WriteLine("3. Pasivo Circulante");
            Console.WriteLine("4. Pasivo No Circulante");
            Console.WriteLine("5. Capital Contable");

            Console.Write("\nSeleccione una opción: ");
            var opt = Console.ReadLine()?.Trim();

            List<GrupoCuenta>? grupo = null;
            GrupoCuenta? grupoUnico = null;

            switch (opt)
            {
                case "1": grupo = balance.ActivoCirculante; break;
                case "2": grupo = balance.ActivoNoCirculante; break;
                case "3": grupo = balance.PasivoCirculante; break;
                case "4": grupo = balance.PasivoNoCirculante; break;
                case "5": grupoUnico = balance.Capital; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pausa();
                    return;
            }

            if (grupo != null)
            {
                for (int i = 0; i < grupo.Count; i++)
                {
                    grupo[i].MostrarListado();
                    foreach (var c in grupo[i].Cuentas)
                    {
                        Console.Write($"\n{c.Nombre} ({c.Codigo}) - Monto actual {c.Monto:C2}. Ingrese monto nuevo: ");
                        var entrada = Console.ReadLine()?.Trim();
                        if (string.IsNullOrWhiteSpace(entrada)) continue;
                        decimal val = BalanceGeneral.ObtenerDecimal(entrada);
                        c.Monto = val;
                    }
                }
            }
            else if (grupoUnico != null)
            {
                grupoUnico.MostrarListado();
                foreach (var c in grupoUnico.Cuentas)
                {
                    Console.Write($"\n{c.Nombre} ({c.Codigo}) - Monto actual {c.Monto:C2}. Ingrese monto nuevo: ");
                    var entrada = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(entrada)) continue;
                    decimal val = BalanceGeneral.ObtenerDecimal(entrada);
                    c.Monto = val;
                }
            }
            Console.WriteLine("\nSección completada.");
            Pausa();
        }

        static void IngresarDatosEstadoResultados(EstadoResultado estadoResultado)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== INGRESAR DATOS ESTADO DE RESULTADOS =====");
            Console.ResetColor();
            estadoResultado.EjecutarEstadoResultadoCompleto();

            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}