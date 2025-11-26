using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estadosfinancieros
{
    public class Cuenta
    {
        public string Codigo { get; set; } 
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

    public class BalanceGeneral
    {
        public List<GrupoCuenta> ActivoCirculante { get; private set; } = new List<GrupoCuenta>();
        public List<GrupoCuenta> ActivoNoCirculante { get; private set; } = new List<GrupoCuenta>();
        public List<GrupoCuenta> PasivoCirculante { get; private set; } = new List<GrupoCuenta>();
        public List<GrupoCuenta> PasivoNoCirculante { get; private set; } = new List<GrupoCuenta>();
        public GrupoCuenta Capital { get; private set; } = new GrupoCuenta("Capital Contable");

        public BalanceGeneral()
        {
            CrearEstructuraActivos();
            CrearEstructuraPasivos();
            CrearEstructuraCapital();
        }

        private void CrearEstructuraActivos()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("          ACTIVOS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            // ACTIVO CIRCULANTE
            var disponible = new GrupoCuenta("Activo Circulante - Disponible (Efectivo y equivalentes)");
            disponible.AñadirCuenta(new Cuenta("1.1.1", "Caja", disponible.Nombre));
            disponible.AñadirCuenta(new Cuenta("1.1.2", "Fondos de caja chica", disponible.Nombre));
            disponible.AñadirCuenta(new Cuenta("1.1.3", "Bancos (cuentas corrientes y de ahorro)", disponible.Nombre));
            disponible.AñadirCuenta(new Cuenta("1.1.4", "Fondo de oportunidades", disponible.Nombre));
            disponible.AñadirCuenta(new Cuenta("1.1.5", "Inversiones Temporales", disponible.Nombre));

            var realizable = new GrupoCuenta("Activo Circulante - Realizable");
            realizable.AñadirCuenta(new Cuenta("1.2.1", "Clientes / Cuentas por cobrar comerciales", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.2", "Documentos por cobrar (corto plazo)", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.3", "Funcionarios y empleados (anticipo/otros)", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.4", "IVA acreditable / Impuestos recuperables", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.5", "Inversiones temporales (corto plazo)", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.6", "Deudores", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.7", "Inventario", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.8", "Anticipo de impuestos", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.9", "Mercancía en tránsito", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.10", "Papelería y útiles", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.11", "Propaganda y publicidad", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.12", "Muestras médicas y literaturas", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.13", "Primas a seguros y fianzas", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.14", "Rentas pagadas por anticipado", realizable.Nombre));
            realizable.AñadirCuenta(new Cuenta("1.2.15", "Intereses pagados por anticipado", realizable.Nombre));
           

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
            intangible.AñadirCuenta(new Cuenta("2.2.5", "Gastos pre operativos", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.6", "Descuentos en emisiones de obligaciones", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.7", "Gastos en colocación de Valores", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.8", "Gastos de constitución", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.9", "Gastos e organización", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.10", "Gastos de instalación", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.11", "Papelería y útiles", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.9", "Primas de seguro y fianzas", intangible.Nombre));
            intangible.AñadirCuenta(new Cuenta("2.2.", "Amortización acumulada (resta)", intangible.Nombre));

            var otrosNoCirc = new GrupoCuenta("Activo No Circulante - Otros");
            otrosNoCirc.AñadirCuenta(new Cuenta("2.3.1", "Inversiones permanentes y otras no circulantes", otrosNoCirc.Nombre));
            otrosNoCirc.AñadirCuenta(new Cuenta("2.3.2", "Activos diferidos a largo plazo", otrosNoCirc.Nombre));

            ActivoNoCirculante.Add(activoFijo);
            ActivoNoCirculante.Add(intangible);
            ActivoNoCirculante.Add(otrosNoCirc);
        }

        private void CrearEstructuraPasivos()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("       PASIVOS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            // PASIVO CIRCULANTE (Corto plazo)
            var pasivoCorto = new GrupoCuenta("Pasivo Circulante (Corto plazo)");
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.1", "Proveedores", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.2", "Documentos por pagar (corto plazo)", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.3", "Acreedores diversos", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.4", "Acreedores bancarios", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.5", "Impuestos por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.6", "Anticipo de clientes", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.7", "Dividendos por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.8", "IVA por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.9", "Impuesto sobre la renta por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.10", "Impuestos y derechcos retenidos por enterar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.11", "Intereses por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.12", "Gastos acumulados por pagar", pasivoCorto.Nombre));
            pasivoCorto.AñadirCuenta(new Cuenta("3.1.13", "Ingresos cobrados por anticipado", pasivoCorto.Nombre));

            // PASIVO NO CIRCULANTE (Largo plazo)
            var pasivoLargo = new GrupoCuenta("Pasivo No Circulante (Largo plazo)");
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.1", "Acreedores hipotecarios", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.2", "Acreedores bancarios", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.3", "Documentos por pagar a largo plazo", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.4", "Obligaciones a circulación", pasivoLargo.Nombre));
            pasivoLargo.AñadirCuenta(new Cuenta("3.2.5", "Bonos por pagar", pasivoLargo.Nombre));

            PasivoCirculante.Add(pasivoCorto);
            PasivoNoCirculante.Add(pasivoLargo);
        }

        private void CrearEstructuraCapital()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("       CAPITAL");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            Capital = new GrupoCuenta("Capital Contable");
            Capital.AñadirCuenta(new Cuenta("4.1.1", "Capital social", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.2", "Aportaciones adicionales (prima emisión)", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.3", "Primas en Ventas de acciones", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.4", "Donaciones", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.5", "Utilidades retenidas", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.6", "Reservas legales y estatutarias", Capital.Nombre));
            Capital.AñadirCuenta(new Cuenta("4.1.7", "Resultado del ejercicio (utilidad/pérdida)", Capital.Nombre));
           
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
        public static decimal ObtenerDecimal(string texto)
        {
            decimal resultado;

            while (!decimal.TryParse(texto, out resultado))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada no válida. Intente de nuevo:");
                Console.ResetColor();
                texto = Console.ReadLine() ?? "";
            }

            return resultado;
        }
    }

   
    }

