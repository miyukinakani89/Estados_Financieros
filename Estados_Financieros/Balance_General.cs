//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceGeneralApp
{
    // Representa una cuenta individual
    public class Cuenta
    {
        public string Codigo { get; set; } // opcional, p.ej. "1.1.1"
        public string Nombre { get; set; }
        public decimal Monto { get; set; } = 0m;
        public string Clasificacion { get; set; }

        public Cuenta(string codigo, string nombre, string clasificacion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Clasificacion = clasificacion;
        }

        public override string ToString()
        {
            return $"{(string.IsNullOrWhiteSpace(Codigo) ? "" : Codigo + " ")}{Nombre}: {Monto:C2}";
        }
    }
    // Grupo de cuentas (por ejemplo Activo Circulante)
    public class GrupoCuenta
    {
        public string Nombre { get; private set; }
        public List<Cuenta> Cuentas { get; private set; } = new List<Cuenta>();

        public GrupoCuenta(string nombre)
        {
            Nombre = nombre;
        }

        public decimal Subtotal()
        {
            return Cuentas.Sum(c => c.Monto);
        }

        public void AñadirCuenta(Cuenta c)
        {
            Cuentas.Add(c);
        }

        public void MostrarListado(bool numerar = true, int offsetIndex = 0)
        {
            Console.WriteLine($"\n--- {Nombre} ---");
            for (int i = 0; i < Cuentas.Count; i++)
            {
                var idx = offsetIndex + i + 1;
                Console.WriteLine($"{(numerar ? idx.ToString().PadLeft(3) + ". " : "")}{Cuentas[i].Nombre} (Código: {Cuentas[i].Codigo}) - Actual: {Cuentas[i].Monto:C2}");
            }
        }
    }

    // Balance General - contiene todos los grupos
    public class BalanceGeneral
    {
        public List<GrupoCuenta> ActivoCirculante { get; private set; } = new List<GrupoCuenta>();
        public List<GrupoCuenta> ActivoNoCirculante { get; private set; } = new List<GrupoCuenta>();
        public List<GrupoCuenta> PasivoCirculante { get; private set; } = new List<GrupoCuenta>();
        public List<GrupoCuenta> PasivoNoCirculante { get; private set; } = new List<GrupoCuenta>();
        public GrupoCuenta Capital { get; private set; } = new GrupoCuenta("Capital Contable");

        // Constructor -> crea la estructura completa con cuentas por defecto
        public BalanceGeneral()
        {
            CrearEstructuraActivos();
            CrearEstructuraPasivos();
            CrearEstructuraCapital();
        }

        private void CrearEstructuraActivos()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // ACTIVO CIRCULANTE
            var disponible = new GrupoCuenta("Activo Circulante - Disponible (Efectivo y equivalentes)");
            disponible.AñadirCuenta(new Cuenta("1.1.1", "Caja", disponible.Nombre));
            disponible.AñadirCuenta(new Cuenta("1.1.2", "Fondos de caja chica", disponible.Nombre));
            disponible.AñadirCuenta(new Cuenta("1.1.3", "Bancos (cuentas corrientes y de ahorro)", disponible.Nombre));

            var realizable = new GrupoCuenta("Activo Circulante - Realizable");
            realizable.AñadirCuenta(new Cuenta("1.2.1", "Clientes / Cuentas por cobrar comerciales", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.2", "Documentos por cobrar (corto plazo)", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.3", "Funcionarios y empleados (anticipo/otros)", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.4", "IVA acreditable / Impuestos recuperables", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.5", "Inversiones temporales (corto plazo)", realizable.Nombre));

            var otrosActCir = new GrupoCuenta("Activo Circulante - Otros");
            otrosActCir.AñadirCuenta(new Cuenta("1.3.1", "Otros activos circulantes", otrosActCir.Nombre));

            ActivoCirculante.Add(disponible);
            ActivoCirculante.Add(realizable);
            ActivoCirculante.Add(otrosActCir);

            // ACTIVO NO CIRCULANTE (No realizable a corto plazo)
            var activoFijo = new GrupoCuenta("Activo No Circulante - Muebles, Maquinaria y Equipo (Activo Fijo)");
            activoFijo.AñadirCuenta(new Cuenta("2.1.1", "Terrenos", activoFijo.Nombre));
            activoFijo.AñadirCuenta(new Cuenta("2.1.2", "Edificios", activoFijo.Nombre));
            activoFijo.AñadirCuenta(new Cuenta("2.1.3", "Maquinaria", activoFijo.Nombre));
            activoFijo.AñadirCuenta(new Cuenta("2.1.4", "Vehículos", activoFijo.Nombre));
            activoFijo.AñadirCuenta(new Cuenta("2.1.5", "Mobiliario y equipo de oficina", activoFijo.Nombre));
            activoFijo.AñadirCuenta(new Cuenta("2.1.6", "Depreciación acumulada (resta)", activoFijo.Nombre));

            var intangible = new GrupoCuenta("Activo No Circulante - Intangible");
            intangible.AñadirCuenta(new Cuenta("2.2.1", "Derechos de autor", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.2", "Patentes", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.3", "Marca y nombres comerciales", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.4", "Crédito mercantil (goodwill)", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.5", "Amortización acumulada (resta)", intangible.Nombre));

            var otrosNoCirc = new GrupoCuenta("Activo No Circulante - Otros");
            otrosNoCirc.AñadirCuenta(new Cuenta("2.3.1", "Inversiones permanentes y otras no circulantes", otrosNoCirc.Nombre));
            otrosNoCirc.AñadirCuenta(new Cuenta("2.3.2", "Activos diferidos a largo plazo", otrosNoCirc.Nombre));

            ActivoNoCirculante.Add(activoFijo);
            ActivoNoCirculante.Add(intangible);
            ActivoNoCirculante.Add(otrosNoCirc);
        }

        private void CrearEstructuraPasivos()
        {
            // PASIVO CIRCULANTE (Corto plazo)
            var pasivoCorto = new GrupoCuenta("Pasivo Circulante (Corto plazo)");
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.1", "Proveedores", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.2", "Documentos por pagar (corto plazo)", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.3", "Acreedores varios", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.4", "Impuestos por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.5", "Sueldos y prestaciones por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.6", "Porciones cortas de deuda a largo plazo", pasivoCorto.Nombre));

            // PASIVO NO CIRCULANTE (Largo plazo)
            var pasivoLargo = new GrupoCuenta("Pasivo No Circulante (Largo plazo)");
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.1", "Préstamos bancarios a largo plazo", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.2", "Obligaciones hipotecarias", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.3", "Pasivos laborales a largo plazo", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.4", "Provisiones a largo plazo", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.5", "Otros pasivos no circulantes", pasivoLargo.Nombre));

            PasivoCirculante.Add(pasivoCorto);
            PasivoNoCirculante.Add(pasivoLargo);
        }

        private void CrearEstructuraCapital()
        {
            Capital = new GrupoCuenta("Capital Contable");
            Capital.AñadirCuenta(new Cuenta("4.1.1", "Capital social", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.2", "Aportaciones adicionales (prima emisión)", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.3", "Reservas legales y estatutarias", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.4", "Utilidades retenidas", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.5", "Resultado del ejercicio (utilidad/pérdida)", Capital.Nombre));

        }

        // Recorre todas las cuentas y crea una lista plana para interacción con el usuario
        public List<Cuenta> ObtenerListaPlanaCuentas()
        {
            var lista = new List<Cuenta>();
            foreach (var g in ActivoCirculante) lista.AddRange(g.Cuentas);
            foreach (var g in ActivoNoCirculante) lista.AddRange(g.Cuentas);
            foreach (var g in PasivoCirculante) lista.AddRange(g.Cuentas);
            foreach (var g in PasivoNoCirculante) lista.AddRange(g.Cuentas);
            lista.AddRange(Capital.Cuentas);
            return lista;
        }

        // Métodos para calcular totales
        public decimal TotalActivo()
        {
            decimal sum = 0m;
            foreach (var g in ActivoCirculante) sum += g.Subtotal();
            foreach (var g in ActivoNoCirculante) sum += g.Subtotal();
            return sum;
        }

        public decimal TotalPasivo()
        {
            decimal sum = 0m;
            foreach (var g in PasivoCirculante) sum += g.Subtotal();
            foreach (var g in PasivoNoCirculante) sum += g.Subtotal();
            return sum;
        }

        public decimal TotalCapital()
        {
            return Capital.Subtotal();
        }

        public void MostrarBalanceCompleto()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n==================== BALANCE GENERAL ====================\n");
            Console.WriteLine("ACTIVO:");
            foreach (var g in ActivoCirculante)
            {
                Console.WriteLine($"\n  {g.Nombre} (Subtotal: {g.Subtotal():C2})");
                foreach (var c in g.Cuentas) Console.WriteLine($"    - {c.Nombre}: {c.Monto:C2}");
            }
            foreach (var g in ActivoNoCirculante)
            {
                Console.WriteLine($"\n  {g.Nombre} (Subtotal: {g.Subtotal():C2})");
                foreach (var c in g.Cuentas) Console.WriteLine($"    - {c.Nombre}: {c.Monto:C2}");
            }

            Console.WriteLine($"\nTOTAL ACTIVO: {TotalActivo():C2}\n");

            Console.WriteLine("PASIVO:");
            foreach (var g in PasivoCirculante)
            {
                Console.WriteLine($"\n  {g.Nombre} (Subtotal: {g.Subtotal():C2})");
                foreach (var c in g.Cuentas) Console.WriteLine($"    - {c.Nombre}: {c.Monto:C2}");
            }
            foreach (var g in PasivoNoCirculante)
            {
                Console.WriteLine($"\n  {g.Nombre} (Subtotal: {g.Subtotal():C2})");
                foreach (var c in g.Cuentas) Console.WriteLine($"    - {c.Nombre}: {c.Monto:C2}");
            }

            Console.WriteLine($"\nTOTAL PASIVO: {TotalPasivo():C2}\n");

            Console.WriteLine("CAPITAL CONTABLE:");
            Console.WriteLine($"\n  {Capital.Nombre} (Subtotal: {Capital.Subtotal():C2})");
            foreach (var c in Capital.Cuentas) Console.WriteLine($"    - {c.Nombre}: {c.Monto:C2}");

            Console.WriteLine($"\nTOTAL CAPITAL: {TotalCapital():C2}\n");
        }

        // Verifica si cuadra el balance
        public (bool cuadra, decimal diferencia) VerificarCuadre()
        {
            var activo = TotalActivo();
            var pasycap = TotalPasivo() + TotalCapital();
            var diff = Math.Round(activo - pasycap, 2);
            // si la diferencia es menor a 0.01 se considera cuadrado
            return (Math.Abs(diff) < 0.01m, diff);
        }

        // Muestra un resumen con solo cuentas con montos != 0
        public void MostrarResumenCuentasNoCero()
        {
            var lista = ObtenerListaPlanaCuentas().Where(c => Math.Round(c.Monto, 2) != 0m)
                .OrderBy(c => c.Clasificacion).ThenBy(c => c.Codigo).ToList();

            Console.WriteLine("\n\n=== RESUMEN: CUENTAS CON MONTO DIFERENTE DE CERO ===");
            if (!lista.Any())
            {
                Console.WriteLine("No se ingresaron montos (todas las cuentas en cero).");
                return;
            }

            decimal suma = 0m;
            foreach (var c in lista)
            {
                Console.WriteLine($"- [{c.Clasificacion}] {c.Codigo} {c.Nombre} => {c.Monto:C2}");
                suma += c.Monto;
            }
            Console.WriteLine($"\nSuma de partidas no cero: {suma:C2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // var config = new ConfigurationBuilder()
            //.SetBasePath(AppContext.BaseDirectory)
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.Build();

            //string cadena = config.GetConnectionString("MiConexion") ?? ("");

            //using var conexion = new SqlConnection(cadena);
            //try
            //{
            //  conexion.Open();
            //Console.WriteLine("Conexión con Windows Authentication establecida.");
            //}
            //catch (Exception ex)
            //{
            //  Console.WriteLine($"Error al conectar: {ex.Message}");
            //}


            Console.ForegroundColor = ConsoleColor.White;
            //Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("========== BALANCE GENERAL ==========\n");

            var balance = new BalanceGeneral();

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
        }
    }
}
