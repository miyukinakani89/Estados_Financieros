using EstadodeSituacionFinanciera;
using System;
using System.Collections.Generic;

namespace SistemaFinanciero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Estados Financieros";

            // Crear instancias de las clases
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
                Console.WriteLine("\n1. Ingresar Datos Balance General");
                Console.WriteLine("2. Ingresar Datos Estado de Resultados");
                Console.WriteLine("3. Ingresar Transacciones de Efectivo");
                Console.WriteLine("4. Generar Estado de Flujos de Efectivo (Directo)");
                Console.WriteLine("5. Generar Estado de Flujos de Efectivo (Indirecto)");
                Console.WriteLine("6. Mostrar Todos los Estados");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresarDatosBalance(balanceGeneral);
                        break;
                    case "2":
                        IngresarDatosEstadoResultados(estadoResultado);
                        break;
                    case "3":
                        IngresarTransacciones(transacciones);
                        break;
                    case "4":
                        GenerarFlujoEfectivoDirecto(estadoFlujoEfectivo, balanceGeneral, estadoResultado, transacciones);
                        break;
                    case "5":
                        GenerarFlujoEfectivoIndirecto(estadoFlujoEfectivo, balanceGeneral, estadoResultado, transacciones);
                        break;
                    case "6":
                        MostrarTodosEstados(balanceGeneral, estadoResultado, estadoFlujoEfectivo);
                        break;
                    case "7":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausa();
                        break;
                }
            }

            Console.WriteLine("¡Gracias por usar el sistema!");
        }

        static void IngresarDatosBalance(BalanceGeneral balance)
        {
            Console.Clear();
            Console.WriteLine("=== INGRESAR DATOS BALANCE GENERAL ===");

            // Aquí el usuario ingresaría los datos manualmente
            // Por ahora solo mostramos la estructura
            balance.MostrarBalanceCompleto();

            Console.WriteLine("\nNota: Ingrese los datos directamente en las cuentas mostradas arriba.");
            Pausa();
        }

        static void IngresarDatosEstadoResultados(EstadoResultado estadoResultado)
        {
            Console.Clear();
            Console.WriteLine("=== INGRESAR DATOS ESTADO DE RESULTADOS ===");

            // Aquí llamaríamos a los métodos de entrada de datos de EstadoResultado
            Console.WriteLine("Ejecutando módulo de Estado de Resultados...");

            // En una implementación real, aquí llamarías a los métodos de entrada
            // de tu clase EstadoResultado existente

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