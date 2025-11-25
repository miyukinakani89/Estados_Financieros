using Estadosfinancieros;
using System;
using System.Collections.Generic;

namespace SistemaFinanciero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Estados Financieros";

            var balanceGeneral = new BalanceGeneral();
            var estadoFlujoEfectivo = new EstadoFlujoEfectivo();
            var estadoResultado = new EstadoResultado();
            var transacciones = new List<TransaccionEfectivo>();
            

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==========================================");
                Console.WriteLine("     SISTEMA DE ESTADOS FINANCIEROS");
                Console.WriteLine("==========================================");
                Console.ResetColor();
                Console.WriteLine("\n1. Ingresar Datos del Balance General");
                Console.WriteLine("2. Ingresar Datos del Estado de Resultados");
                Console.WriteLine("3. Ingresar Transacciones de Efectivo");
                Console.WriteLine("4. Generar Estado de Flujos de Efectivo (Directo)");
                Console.WriteLine("5. Generar Estado de Flujos de Efectivo (Indirecto)");
                Console.WriteLine("6. Mostrar Todos los Estados");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione una opción: ");
                int opcion=0;
                do
                {
                    try
                    {
                        opcion = int.Parse(Console.ReadLine());

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
                        IngresarTransacciones(transacciones);
                        break;
                    case 4:
                        GenerarFlujoEfectivoDirecto(estadoFlujoEfectivo, balanceGeneral, estadoResultado, transacciones);
                        break;
                    case 5:
                        GenerarFlujoEfectivoIndirecto(estadoFlujoEfectivo, balanceGeneral, estadoResultado, transacciones);
                        break;
                    case 6:
                        MostrarTodosEstados(balanceGeneral, estadoResultado, estadoFlujoEfectivo);
                        break;
                    case 7:
                        salir = true;
                        break;
                }
            }

            Console.WriteLine("¡Gracias por usar el sistema!");
        }


        static void IngresarDatosBalance(BalanceGeneral balance)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            //Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("========== BALANCE GENERAL ==========\n");

        

            // Menú para que usuario ingrese montos por grupo o por todas las cuentas
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
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
                    // Mostrar secciones y permitir seleccionar una
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

        // Permite ingresar cuenta por cuenta todas en orden
        static void IngresarTodasCuentas(BalanceGeneral balance)
        {
            var lista = balance.ObtenerListaPlanaCuentas();
            Console.ForegroundColor = ConsoleColor.White;
            int datos;

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

        // Permite elegir sección a sección y llenar las cuentas de esa sección
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

            List<GrupoCuenta> grupo = null;
            GrupoCuenta grupoUnico = null;

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
            Console.WriteLine("=== INGRESAR DATOS ESTADO DE RESULTADOS ===");

            estadoResultado.EjecutarEstadoResultadoCompleto();

            Pausa();
        }
        

        static void IngresarTransacciones(List<TransaccionEfectivo> transacciones)
        {
            Console.Clear();
            Console.WriteLine("=== INGRESAR TRANSACCIONES DE EFECTIVO ===");

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n--- Nueva Transacción ---");

                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();

                Console.Write("Monto: ");
                decimal monto = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Tipo de Flujo (1=Entrada, 2=Salida): ");
                string tipoFlujo = Console.ReadLine() == "1" ? "Entrada" : "Salida";

                Console.WriteLine("Actividad (1=Operación, 2=Inversión, 3=Financiamiento): ");
                string tipoActividad = Console.ReadLine() switch
                {
                    "1" => "Operacion",
                    "2" => "Inversion",
                    "3" => "Financiamiento",
                    _ => "Operacion"
                };

                transacciones.Add(new TransaccionEfectivo(descripcion, monto, tipoFlujo, tipoActividad));

                Console.Write("¿Agregar otra transacción? (s/n): ");
                continuar = Console.ReadLine().ToLower() == "s";
            }

            Console.WriteLine($"✓ Se agregaron {transacciones.Count} transacciones.");
            Pausa();
        }

        static void GenerarFlujoEfectivoDirecto(EstadoFlujoEfectivo flujoEfectivo, BalanceGeneral balance,
                                               EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            Console.Clear();
            Console.WriteLine("=== ESTADO DE FLUJOS DE EFECTIVO - MÉTODO DIRECTO ===");

            flujoEfectivo.Entidad = "Empresa";
            flujoEfectivo.FechaInicio = DateTime.Now.AddYears(-1);
            flujoEfectivo.FechaFin = DateTime.Now;

            flujoEfectivo.CalcularMetodoDirecto(balance, balance, estadoResultado, transacciones);
            flujoEfectivo.MostrarEstadoFlujoEfectivo();

            Pausa();
        }

        static void GenerarFlujoEfectivoIndirecto(EstadoFlujoEfectivo flujoEfectivo, BalanceGeneral balance,
                                                 EstadoResultado estadoResultado, List<TransaccionEfectivo> transacciones)
        {
            Console.Clear();
            Console.WriteLine("=== ESTADO DE FLUJOS DE EFECTIVO - MÉTODO INDIRECTO ===");

            flujoEfectivo.Entidad = "Empresa";
            flujoEfectivo.FechaInicio = DateTime.Now.AddYears(-1);
            flujoEfectivo.FechaFin = DateTime.Now;

            flujoEfectivo.CalcularMetodoIndirecto(balance, balance, estadoResultado, transacciones);
            flujoEfectivo.MostrarEstadoFlujoEfectivo();

            Pausa();
        }

        static void MostrarTodosEstados(BalanceGeneral balance, EstadoResultado estadoResultado,
                                       EstadoFlujoEfectivo flujoEfectivo)
        {
            Console.Clear();
            Console.WriteLine("=== RESUMEN DE TODOS LOS ESTADOS ===");

            Console.WriteLine("\n--- BALANCE GENERAL ---");
            balance.MostrarBalanceCompleto();

            Console.WriteLine("\n--- ESTADO DE RESULTADOS ---");
            // Aquí mostrarías el estado de resultados

            Console.WriteLine("\n--- ESTADO DE FLUJOS DE EFECTIVO ---");
            // Aquí mostrarías el último estado generado

            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}