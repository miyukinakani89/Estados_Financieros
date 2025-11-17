using BalanceGeneral;

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