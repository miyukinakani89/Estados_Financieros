using Estadosfinancieros;
using System;
using System.Collections.Generic;

namespace SistemaFinanciero
{
    class Program
    {
        static void Main(string[] args)
        {

            var balanceGeneral = new BalanceGeneral();
            var estadoFlujoEfectivo = new EstadoFlujoEfectivo();
            var estadoResultado = new EstadoResultado();
            
           

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("==========================================");
                Console.WriteLine("           ESTADOS FINANCIEROS");
                Console.WriteLine("==========================================");
                Console.ResetColor();
                Console.WriteLine("\n1. Ingresar Datos del Balance General");
                Console.WriteLine("2. Ingresar Datos del Estado de Resultados");
                Console.WriteLine("3. Generar Estado de Flujos de Efectivo (Método Indirecto)");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");
                int opcion=0;
                do
                {
                    try
                    {
                        opcion = int.Parse(Console.ReadLine() ?? "");

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                        
                    }
                } while (opcion <1 || opcion >7 );

                switch (opcion)
                {
                    case 1:
                        IngresarDatosBalance(balanceGeneral);
                        break;
                    case 2:
                        IngresarDatosEstadoResultados(estadoResultado);
                        break;                
                    case 3:
                        Console.WriteLine("=== PARA GENERAR FLUJO DE EFECTIVO SE NECESITA BALANCE ANTERIOR ===");
                        Console.WriteLine("Vamos a crear el balance general del período anterior...");
                        var balanceAnterior = new BalanceGeneral();
                        IngresarDatosBalance(balanceAnterior);
                        var estadoFlujoEfectivoPasado = new EstadoFlujoEfectivo();
                        GenerarFlujoEfectivo(estadoFlujoEfectivo, balanceGeneral, balanceAnterior, estadoResultado);
                        break;
                    case 4:
                        salir = true;
                        break;
                }
            }

            Console.WriteLine("¡Gracias por usar el sistema!");
        }


        static void IngresarDatosBalance(BalanceGeneral balance)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;      
            Console.WriteLine("========== BALANCE GENERAL ==========\n");
            Console.ResetColor();
            while (true)
            {
                
                Console.WriteLine("\nElija una opción para ingresar montos:");
                Console.WriteLine("1. Ingresar montos por sección (Activo circulante, Activo no circulante, Pasivo, Capital)");
                Console.WriteLine("2. Ingresar montos para todas las cuentas en orden (más rápido)");
                Console.WriteLine("3. Mostrar Balance actual y verificar cuadre");
                Console.WriteLine("4. Mostrar resumen de cuentas no cero");
                Console.WriteLine("5. Salir");

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
                        Console.WriteLine(" El Balance cuadra: ACTIVO = PASIVO + CAPITAL");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($" El Balance NO cuadra. Diferencia ACTIVO - (PASIVO+CAPITAL) = {diferencia:C2}");
                        Console.WriteLine("Revisa los montos ingresados.");
                    }
                }
                else if (opt == "4")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    balance.MostrarResumenCuentasNoCero();
                }
                else if (opt == "5")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Saliendo... Gracias.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }
        }

        static void IngresarTodasCuentas(BalanceGeneral balance)
        {
            var lista = balance.ObtenerListaPlanaCuentas();
            Console.ForegroundColor = ConsoleColor.White;
           // int datos ;

            Console.WriteLine("\nIngresando para todas las cuentas {Para omitir una cuenta, deje en blanco o escriba 0}.");

            for (int i = 0; i < lista.Count; i++)
            {
                var c = lista[i];
                Console.Write($"\n{c.Codigo} {c.Nombre} ({c.Clasificacion}) - Monto actual {c.Monto:C2}. Ingrese monto nuevo: ");
                var entrada = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(entrada)) continue;

                if (decimal.TryParse(entrada, out decimal val))
                {
                    c.Monto = val;
                }
                else
                {
                    Console.WriteLine("Valor no válido. Se mantiene el valor actual.");
                }

            }


            Console.WriteLine("\nIngreso completo.");
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
                    Console.WriteLine("Opción no válida."); return;
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
                        if (decimal.TryParse(entrada, out decimal val)) c.Monto = val;
                        else Console.WriteLine("Valor no válido.");
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
                    if (decimal.TryParse(entrada, out decimal val)) c.Monto = val;
                    else Console.WriteLine("Valor no válido.");
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
        static void GenerarFlujoEfectivo(EstadoFlujoEfectivo flujoEfectivo,
                                         BalanceGeneral balanceActual, BalanceGeneral balanceAnterior,
                                         EstadoResultado estadoResultado)
        {
            Console.Clear();
            Console.WriteLine("=== ESTADO DE FLUJOS DE EFECTIVO - MÉTODO INDIRECTO ===");

            // Configurar período
            flujoEfectivo.FechaInicio = DateTime.Now.AddYears(-1);
            flujoEfectivo.FechaFin = DateTime.Now;

            // Solicitar utilidad neta
            Console.Write("\nIngrese la utilidad neta del período: ");
            decimal utilidadNeta;
            while (!decimal.TryParse(Console.ReadLine(), out utilidadNeta))
            {
                Console.Write("Valor inválido. Ingrese la utilidad neta: ");
            }

            Console.WriteLine($"\nGenerando estado para el período: {flujoEfectivo.FechaInicio:dd/MM/yyyy} al {flujoEfectivo.FechaFin:dd/MM/yyyy}");

            // Calcular flujos usando solo los balances y la utilidad neta
            flujoEfectivo.CalcularFlujosDesdeEstados(balanceActual, balanceAnterior, utilidadNeta);

            // Mostrar resultados
            flujoEfectivo.MostrarEstadoFlujoEfectivo();
            flujoEfectivo.MostrarVariacionAO_AI_AF();

            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();

        }        
    }
}
