using System;
namespace Estadoderesultado
{
    class Estadoderesultado
    {
        static void Ingresosleer(out decimal VentasTotales, out decimal Devoluciones, out decimal RebajasSobreVentas, out decimal Descuentos)
        {
            VentasTotales = 0m;
            Devoluciones = 0m;
            RebajasSobreVentas = 0m;
            Descuentos = 0m;

            Console.WriteLine("=======================================");
            Console.WriteLine("           INGRESO DE VENTAS");
            Console.WriteLine("=======================================\n");

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Ventas Totales");
                    VentasTotales = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }

            } while (VentasTotales < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Devoluciones(Valor Negativo)");
                    Devoluciones = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (Devoluciones > 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Rebajas sobre la venta(Valor Negativo)");
                    RebajasSobreVentas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (RebajasSobreVentas > 0);
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Descuentos(Valor Negativo)");
                    Descuentos = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (Descuentos > 0);

        }

        static void CostosLeer(out decimal Compras, out decimal GastosDeCompra, out decimal DevolucionesSobreCompra, out decimal RebajasSobreCompras, out decimal DescuentoSobreCompra, out decimal InventarioInicial, out decimal InventarioFinal)
        {
            Compras = 0m;
            GastosDeCompra = 0m;
            DevolucionesSobreCompra = 0m;
            RebajasSobreCompras = 0m;
            DescuentoSobreCompra = 0m;
            InventarioInicial = 0m;
            InventarioFinal = 0m;

            Console.WriteLine("=======================================");
            Console.WriteLine("           COSTOS DE VENTAS");
            Console.WriteLine("=======================================\n");

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Inventario Inicial");
                    InventarioInicial = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (InventarioInicial < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Compras");
                    GastosDeCompra = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (GastosDeCompra < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Gastos de compra");
                    GastosDeCompra = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (GastosDeCompra < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Devoluciones sobre compra(Valor Negativo)");
                    DevolucionesSobreCompra = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (DevolucionesSobreCompra > 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Rebajas sobre compras(Valor Negativo)");
                    RebajasSobreCompras = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (RebajasSobreCompras > 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Descuentos sobre compra(Valor Negativo)");
                    DescuentoSobreCompra = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (DescuentoSobreCompra > 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de Inventario Final(Valor Negativo)");
                    InventarioFinal = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (InventarioFinal > 0);

        }

        static void GastosDeVentaLeer(out decimal SueldoDeLosJefesDeVenta, out decimal SueldoDeLosEmpleadosDeAlmacen, out decimal SueldoDeLosEmpleadosDeLaVenta, out decimal SueldosDeLosChoferesDelEquipoDeEntrega, out decimal ComisionesDeAgentesYDependientes, out decimal SeguroSocialesDelPersonalDeVenta, out decimal Propaganda, out decimal ConsumoDeEtiquetasEnvolturaYEmpaque, out decimal FletesYAcarreosDeLaMercanciasVendidas, out decimal GastosDeMantenimientoDelEquipoDeReparto, out decimal ImpuestosSobreIngresosMercantiles, out decimal RentaDeOficinaVentas, out decimal GastosDeDepreciacionDeVenta)
        {
            SueldoDeLosJefesDeVenta = 0m;
            SueldoDeLosEmpleadosDeAlmacen = 0m;
            SueldoDeLosEmpleadosDeLaVenta = 0m;
            SueldosDeLosChoferesDelEquipoDeEntrega = 0m;
            ComisionesDeAgentesYDependientes = 0m;
            SeguroSocialesDelPersonalDeVenta = 0m;
            Propaganda = 0m;
            ConsumoDeEtiquetasEnvolturaYEmpaque = 0m;
            FletesYAcarreosDeLaMercanciasVendidas = 0m;
            GastosDeMantenimientoDelEquipoDeReparto = 0m;
            ImpuestosSobreIngresosMercantiles = 0m;
            RentaDeOficinaVentas = 0m;
            GastosDeDepreciacionDeVenta = 0m;

            Console.WriteLine("=======================================");
            Console.WriteLine("           GASTO DE VENTAS");
            Console.WriteLine("=======================================\n");
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo de jefes de venta");
                    SueldoDeLosJefesDeVenta = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDeLosJefesDeVenta < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo de Empleados del almacén");
                    SueldoDeLosEmpleadosDeAlmacen = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDeLosEmpleadosDeAlmacen < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo de los Empleados de Venta");
                    SueldoDeLosEmpleadosDeLaVenta = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDeLosEmpleadosDeLaVenta < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo de los choferes de equipo de entrega");
                    SueldosDeLosChoferesDelEquipoDeEntrega = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldosDeLosChoferesDelEquipoDeEntrega < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Comisiones de Agentes y Dependientes");
                    ComisionesDeAgentesYDependientes = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ComisionesDeAgentesYDependientes < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Seguro Social del personal de Venta");
                    SeguroSocialesDelPersonalDeVenta = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SeguroSocialesDelPersonalDeVenta < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de la Propaganda");
                    Propaganda = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (Propaganda < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Consumo de Empaque");
                    ConsumoDeEtiquetasEnvolturaYEmpaque = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ConsumoDeEtiquetasEnvolturaYEmpaque < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de el Acarreo de las Mercancias Vendidas");
                    FletesYAcarreosDeLaMercanciasVendidas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (FletesYAcarreosDeLaMercanciasVendidas < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Gasto de Mantenimiento del equipo de ventas");
                    GastosDeMantenimientoDelEquipoDeReparto = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (GastosDeMantenimientoDelEquipoDeReparto < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Impuesto sobre ingresos mercantiles");
                    ImpuestosSobreIngresosMercantiles = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ImpuestosSobreIngresosMercantiles < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de la Renta de Oficina de ventas");
                    RentaDeOficinaVentas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (RentaDeOficinaVentas < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Gastos de Depreciacion de venta");
                    GastosDeDepreciacionDeVenta = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (GastosDeDepreciacionDeVenta < 0);
        }
        static void GastosDeAdministracionLeer(out decimal SueldoDeGerente, out decimal ServiciosBasicosVentas, out decimal SueldoDeViceGerente, out decimal SueldoDeContador, out decimal SueldoDelPersonalDeOficina, out decimal SeguroSocialDelPersonal, out decimal ConsumoDePapeleríaYUtilesDeEscritorio, out decimal GastosDeCoreoYTelegrafo, out decimal AlquilerDeOficina, out decimal GastosDeDepreciacion)
        {
            SueldoDeGerente = 0m;
            SueldoDeViceGerente = 0m;
            SueldoDeContador = 0m;
            SueldoDelPersonalDeOficina = 0m;
            SeguroSocialDelPersonal = 0m;
            ConsumoDePapeleríaYUtilesDeEscritorio = 0m;
            GastosDeCoreoYTelegrafo = 0m;
            AlquilerDeOficina = 0m;
            GastosDeDepreciacion = 0m;
            ServiciosBasicosVentas = 0m;

            Console.WriteLine("=======================================");
            Console.WriteLine("       GASTO DE ADMINISTRACION");
            Console.WriteLine("=======================================\n");

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo De Gerente");
                    SueldoDeGerente = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDeGerente < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo De Vice Gerente");
                    SueldoDeViceGerente = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDeViceGerente < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo Del Contador");
                    SueldoDeContador = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDeContador < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Sueldo Del Personal");
                    SueldoDelPersonalDeOficina = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SueldoDelPersonalDeOficina < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Seguro Social del Personal");
                    SeguroSocialDelPersonal = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (SeguroSocialDelPersonal < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de papeleria y utiles de escritorio");
                    ConsumoDePapeleríaYUtilesDeEscritorio = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ConsumoDePapeleríaYUtilesDeEscritorio < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Gastos de Correo");
                    GastosDeCoreoYTelegrafo = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (GastosDeCoreoYTelegrafo < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Alquiler de oficina");
                    AlquilerDeOficina = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (AlquilerDeOficina < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Servicios Basicos del departamento de ventas");
                    ServiciosBasicosVentas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ServiciosBasicosVentas < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Gasto de depreciación");
                    GastosDeDepreciacion = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (GastosDeDepreciacion < 0);

        }

        static void GastosFinancieros(out decimal InteresesSobreDocumentos, out decimal DescuentoPorPagoAnticipado, out decimal InteresesSobrePrestamosBancarios, out decimal PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera)
        {
            InteresesSobreDocumentos = 0m;
            DescuentoPorPagoAnticipado = 0m;
            InteresesSobrePrestamosBancarios = 0m;
            PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera = 0m;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Intereses sobre Documentos");
                    InteresesSobreDocumentos = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (InteresesSobreDocumentos < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del descuento por pago anticipado");
                    DescuentoPorPagoAnticipado = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (DescuentoPorPagoAnticipado < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Interes sobre prestamos bancarios");
                    InteresesSobrePrestamosBancarios = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (InteresesSobrePrestamosBancarios < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las perdidas o utilidades que resulten del intercambio de moneda extranjera");
                    PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera < 0);

        }

        static void EgresosLeer(out decimal InteresesPagados, out decimal ServiciosBancarios, out decimal RentasCobradas, out decimal PerdidasoUtilidadesEnVentaDeVariosActivosFijo, out decimal PerdidasoUtilidadesEnCompraDeActivos, out decimal RentasPagadas, out decimal DividendoDeAcciones, out decimal ComisionesCobradas)
        {
            InteresesPagados = 0m;
            ServiciosBancarios = 0m;
            RentasPagadas = 0m;
            PerdidasoUtilidadesEnVentaDeVariosActivosFijo = 0m;
            RentasCobradas = 0m;
            PerdidasoUtilidadesEnCompraDeActivos = 0m;
            DividendoDeAcciones = 0m;
            ComisionesCobradas = 0m;

            Console.WriteLine("=======================================");
            Console.WriteLine("             OTROS GASTOS");
            Console.WriteLine("=======================================\n");
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Intereses Pagados");
                    InteresesPagados = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (InteresesPagados < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los Servicios Bancarios");
                    ServiciosBancarios = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ServiciosBancarios < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Rentas Pagadas");
                    RentasPagadas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (RentasPagadas < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto del Dividendo de Acciones");
                    DividendoDeAcciones = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (DividendoDeAcciones < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Perdidas en venta de activo fijo");
                    PerdidasoUtilidadesEnVentaDeVariosActivosFijo = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (PerdidasoUtilidadesEnVentaDeVariosActivosFijo < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Perdidas o Utilidades en compra de activos");
                    PerdidasoUtilidadesEnCompraDeActivos = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (PerdidasoUtilidadesEnCompraDeActivos < 0);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Rentas Cobradas");
                    RentasCobradas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (RentasCobradas < 0);
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de las Comisiones Cobradas");
                    ComisionesCobradas = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ComisionesCobradas < 0);


        }

        static void OtrosIngresosLeer(out decimal InteresesCobrados, out decimal DividendosCobrados)
        {
            InteresesCobrados = 0m;
            DividendosCobrados = 0m;

            Console.WriteLine("=======================================");
            Console.WriteLine("           OTROS INGRESOS");
            Console.WriteLine("=======================================\n");

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los intereses Cobrados");
                    InteresesCobrados = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (InteresesCobrados < 0);
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el monto de los dividendos Cobrados");
                    DividendosCobrados = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVALIDO");
                }
            } while (DividendosCobrados < 0);





        }
        static void TotalVentasNetas(decimal VentasTotales, decimal Devoluciones, decimal RebajasSobreVentas, decimal Descuentos, out decimal TotalVentasN)
        {
            TotalVentasN = 0m;
            TotalVentasN = VentasTotales + Devoluciones + RebajasSobreVentas + Descuentos;

            Console.WriteLine("=======================================");
            Console.WriteLine("                VENTAS");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("Ventas Totales: " + VentasTotales);
            Console.WriteLine("Devoluciones: " + Devoluciones);
            Console.WriteLine("Rebajas Sobre Ventas: " + RebajasSobreVentas);
            Console.WriteLine("Descuentos: " + Descuentos);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total de ventas Netas: " + TotalVentasN);
            Console.WriteLine("=======================================");
        }

        static void TotalComprasNetas(decimal Compras, decimal MercanciaDisponible, decimal GastosDeCompra, decimal DevolucionesSobreCompra, decimal RebajasSobreCompras, decimal DescuentoSobreCompra, decimal InventarioInicial, decimal InventarioFinal, out decimal TotalComprasN)
        {
            MercanciaDisponible = 0m;
            TotalComprasN = 0m;
            MercanciaDisponible = InventarioInicial + Compras + GastosDeCompra + DevolucionesSobreCompra + RebajasSobreCompras;
            TotalComprasN = MercanciaDisponible - InventarioFinal;
            Console.WriteLine("=======================================");
            Console.WriteLine("                COMPRAS");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("Inventario Inicial: " + InventarioInicial);
            Console.WriteLine("Compras: " + Compras);
            Console.WriteLine("Gastos de Compra: " + GastosDeCompra);
            Console.WriteLine("Devoluciones sobre la compra: " + DevolucionesSobreCompra);
            Console.WriteLine("Rebajas Sobre la Compra: " + RebajasSobreCompras);
            Console.WriteLine("Descuento sobre la compra: " + DescuentoSobreCompra);
            Console.WriteLine("Mercancia Disponible: " + MercanciaDisponible);
            Console.WriteLine("Inventario Final: " + InventarioFinal);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total De Compras: " + TotalComprasN);
            Console.WriteLine("=======================================");

        }
        static void CalcUtilidadBruta(decimal TotalVentasN, decimal TotalComprasN, out decimal UtilidadBruta)
        {
            UtilidadBruta = 0m;
            UtilidadBruta = TotalVentasN - TotalComprasN;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad Bruta: " + UtilidadBruta);
            Console.WriteLine("=======================================");
        }
        static void TotalGastosDeVenta(decimal SueldoDeLosJefesDeVenta, decimal ServiciosBasicosVenta, decimal SueldoDeLosEmpleadosDeAlmacen, decimal SueldoDeLosEmpleadosDeLaVenta, decimal SueldosDeLosChoferesDelEquipoDeEntrega, decimal ComisionesDeAgentesYDependientes, decimal SeguroSocialesDelPersonalDeVenta, decimal Propaganda, decimal ConsumoDeEtiquetasEnvolturaYEmpaque, decimal FletesYAcarreosDeLaMercanciasVendidas, decimal GastosDeMantenimientoDelEquipoDeReparto, decimal ImpuestosSobreIngresosMercantiles, decimal RentaDeOficinaVentas, decimal GastosDeDepreciacionDeVenta, out decimal TotalGastosV)
        {
            TotalGastosV = 0m;
            TotalGastosV = SueldoDeLosJefesDeVenta + SueldoDeLosEmpleadosDeAlmacen + SueldoDeLosEmpleadosDeLaVenta + SueldosDeLosChoferesDelEquipoDeEntrega + ComisionesDeAgentesYDependientes + SeguroSocialesDelPersonalDeVenta + Propaganda + ConsumoDeEtiquetasEnvolturaYEmpaque + FletesYAcarreosDeLaMercanciasVendidas + GastosDeMantenimientoDelEquipoDeReparto + ImpuestosSobreIngresosMercantiles + RentaDeOficinaVentas + GastosDeDepreciacionDeVenta;
            Console.WriteLine("=======================================");
            Console.WriteLine("            GASTOS DE VENTA");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("Sueldo de los jefes de Venta: " + SueldoDeLosJefesDeVenta);
            Console.WriteLine("Sueldo de los empleados del almacen: " + SueldoDeLosEmpleadosDeAlmacen);
            Console.WriteLine("Sueldo de los empleados de la venta: " + SueldoDeLosEmpleadosDeLaVenta);
            Console.WriteLine("Sueldo de los choferes del equipo de entrega: " + SueldosDeLosChoferesDelEquipoDeEntrega);
            Console.WriteLine("Comisiones de Agentes y Dependientes: " + ComisionesDeAgentesYDependientes);
            Console.WriteLine("Seguro Social de personal de venta: " + SeguroSocialesDelPersonalDeVenta);
            Console.WriteLine("Propaganda: " + Propaganda);
            Console.WriteLine("Consumo de etiquetas, envoltura y empaque: " + ConsumoDeEtiquetasEnvolturaYEmpaque);
            Console.WriteLine("Impuestos sobre ingresos mercantiles: " + ImpuestosSobreIngresosMercantiles);
            Console.WriteLine("Acarreos de Mercancia Vencida: " + FletesYAcarreosDeLaMercanciasVendidas);
            Console.WriteLine("Gastos de mantenimiento de equipo de reparto: " + GastosDeMantenimientoDelEquipoDeReparto);
            Console.WriteLine("Renta de Oficina de Venta: " + RentaDeOficinaVentas);
            Console.WriteLine("Gastos de depreciacion de venta: " + GastosDeDepreciacionDeVenta);
            Console.WriteLine("Gastos de mantenimiento de equipo de reparto: " + GastosDeMantenimientoDelEquipoDeReparto);
            Console.WriteLine("Renta de Oficina de Venta: " + ServiciosBasicosVenta);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total de Gastos de Ventas: " + TotalGastosV);
            Console.WriteLine("=======================================");

        }

        static void TotalGastosDeAdministración(decimal SueldoDeGerente, decimal SueldoDeViceGerente, decimal SueldoDeContador, decimal SueldoDelPersonalDeOficina, decimal SeguroSocialDelPersonal, decimal ConsumoDePapeleríaYUtilesDeEscritorio, decimal GastosDeCoreoYTelegrafo, decimal AlquilerDeOficina, decimal GastosDeDepreciacion, out decimal TotalGastosAdmin)
        {
            TotalGastosAdmin = 0m;
            TotalGastosAdmin = SueldoDeGerente + SueldoDeViceGerente + SueldoDeContador + SueldoDelPersonalDeOficina + SeguroSocialDelPersonal + ConsumoDePapeleríaYUtilesDeEscritorio + ConsumoDePapeleríaYUtilesDeEscritorio + GastosDeCoreoYTelegrafo + AlquilerDeOficina + GastosDeDepreciacion;
            Console.WriteLine("=======================================");
            Console.WriteLine("       GASTOS DE ADMINISTRACION");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("Sueldo del Gerente: " + SueldoDeGerente);
            Console.WriteLine("Sueldo del Vice Gerente: " + SueldoDeViceGerente);
            Console.WriteLine("Sueldo de Contador: " + SueldoDeContador);
            Console.WriteLine("Sueldo del personal de oficina: " + SueldoDelPersonalDeOficina);
            Console.WriteLine("Seguro Social Del Personal: " + SeguroSocialDelPersonal);
            Console.WriteLine("Consumo de Papelería y Utiles de escritorio: " + ConsumoDePapeleríaYUtilesDeEscritorio);
            Console.WriteLine("Gastos de Correo: " + GastosDeCoreoYTelegrafo);
            Console.WriteLine("Alquiler de Oficina: " + AlquilerDeOficina);
            Console.WriteLine("Gastos de Depreciacion: " + GastosDeDepreciacion);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total de Gastos de Administración: " + TotalGastosAdmin);
            Console.WriteLine("=======================================");
        }

        static void TotalGastosFinancieros(decimal InteresesSobreDocumentos, decimal DescuentoPorPagoAnticipado, decimal InteresesSobrePrestamosBancarios, decimal PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera, out decimal TotalGastosFi)
        {
            TotalGastosFi = 0m;
            TotalGastosFi = InteresesSobreDocumentos + DescuentoPorPagoAnticipado + InteresesSobrePrestamosBancarios + PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera;
            Console.WriteLine("=======================================");
            Console.WriteLine("       GASTOS DE FINANCIAMIENTO");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Intereses sobre documentos: " + InteresesSobreDocumentos);
            Console.WriteLine("Descuentos Por Pago Anticipado: " + DescuentoPorPagoAnticipado);
            Console.WriteLine("Intereses Sobre Prestamos bancarios: " + InteresesSobrePrestamosBancarios);
            Console.WriteLine("Perdidas o Utilidades Que resulten de Intercambio de Moneda Extrangera: " + PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total Gastos Financieros: " + TotalGastosFi);
            Console.WriteLine("=======================================");

        }
        static void CalcUtilidadDeOperación(decimal TotalGastosV, decimal TotalGastosAdmin, decimal TotalGastosFi, decimal UtilidadBruta, out decimal UtilidadDeOperación)
        {
            UtilidadDeOperación = UtilidadBruta - TotalGastosAdmin - TotalGastosV - TotalGastosFi;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad de Operación: " + UtilidadDeOperación);
            Console.WriteLine("=======================================");
        }

        static void TotalOtrosIngresos(decimal InteresesCobrados, decimal DividendosCobrados, out decimal TotalOI)
        {
            TotalOI = 0m;
            TotalOI = InteresesCobrados + DividendosCobrados;
            Console.WriteLine("=======================================");
            Console.WriteLine("          OTROS INGRESOS");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Intereses Cobrados: " + InteresesCobrados);
            Console.WriteLine("Dividendos Cobrados: " + DividendosCobrados);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total de Otros Ingresos: " + TotalOI);
            Console.WriteLine("=======================================");
        }

        static void TotalOtrosegresos(decimal InteresesPagados, decimal ServiciosBancarios, decimal RentasCobradas, decimal PerdidasoUtilidadesEnVentaDeVariosActivosFijo, decimal PerdidasoUtilidadesEnCompraDeActivos, decimal RentasPagadas, decimal DividendoDeAcciones, decimal ComisionesCobradas, out decimal TotalOtrosGastos)
        {
            TotalOtrosGastos = 0m;
            TotalOtrosGastos = InteresesPagados + ServiciosBancarios + RentasPagadas + PerdidasoUtilidadesEnVentaDeVariosActivosFijo + RentasCobradas + PerdidasoUtilidadesEnCompraDeActivos + DividendoDeAcciones + ComisionesCobradas;
            Console.WriteLine("=======================================");
            Console.WriteLine("          OTROS GASTOS");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Intereses Pagados: " + InteresesPagados);
            Console.WriteLine("Servicios Bancarios: " + ServiciosBancarios);
            Console.WriteLine("Rentas Pagadas: " + RentasPagadas);
            Console.WriteLine("Perdidas En Ventas de Activo fijo: " + PerdidasoUtilidadesEnVentaDeVariosActivosFijo);
            Console.WriteLine("Intereses Pagados: " + RentasCobradas);
            Console.WriteLine("Servicios Bancarios: " + PerdidasoUtilidadesEnCompraDeActivos);
            Console.WriteLine("Rentas Pagadas: " + ComisionesCobradas);
            Console.WriteLine("Perdidas En Ventas de Activo fijo: " + DividendoDeAcciones);
            Console.WriteLine("=======================================");
            Console.WriteLine("Total de Otros Gastos: " + TotalOtrosGastos);
            Console.WriteLine("=======================================");
        }
        static void CalcUtilidadAntesdeISR(decimal TotalOI, decimal UtilidadDeOperacion, decimal TotalOtrosGastos, out decimal UtilidadAntesDeImpuesto)
        {
            UtilidadAntesDeImpuesto = 0m;
            UtilidadAntesDeImpuesto = UtilidadDeOperacion + TotalOI + TotalOtrosGastos;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad Antes De Impuestos: " + UtilidadAntesDeImpuesto);
            Console.WriteLine("=======================================");
        }

        static void Pregunta(out decimal ISR)
        {
            ISR = 0m;

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el Impuesto sobre la renta");
                    ISR = decimal.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {

                    Console.WriteLine("DATO INVALIDO");
                }
            } while (ISR < 0);
        }
        static void CalcUtilidadNeta(decimal ISR, decimal UtilidadAntesDeImpuesto, out decimal UtilidadNeta)
        {
            UtilidadNeta = 0m;
            UtilidadNeta = UtilidadAntesDeImpuesto - ISR;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad Neta: " + UtilidadNeta);
            Console.WriteLine("=======================================");
        }
        static void Main(string[] args)
        {
            decimal VentasTotales;
            decimal Devoluciones;
            decimal RebajasSobreVentas;
            decimal MercanciaDisponible = 0;
            decimal Descuentos;

            //Entradas de Información

            Ingresosleer(out VentasTotales, out Devoluciones, out RebajasSobreVentas, out Descuentos);
            CostosLeer(out decimal Compras, out decimal GastosDeCompra, out decimal DevolucionesSobreCompra, out decimal RebajasSobreCompras, out decimal DescuentoSobreCompra, out decimal InventarioInicial, out decimal InventarioFinal);
            GastosDeVentaLeer(out decimal SueldoDeLosJefesDeVenta, out decimal SueldoDeLosEmpleadosDeAlmacen, out decimal SueldoDeLosEmpleadosDeLaVenta, out decimal SueldosDeLosChoferesDelEquipoDeEntrega, out decimal ComisionesDeAgentesYDependientes, out decimal SeguroSocialesDelPersonalDeVenta, out decimal Propaganda, out decimal ConsumoDeEtiquetasEnvolturaYEmpaque, out decimal FletesYAcarreosDeLaMercanciasVendidas, out decimal GastosDeMantenimientoDelEquipoDeReparto, out decimal ImpuestosSobreIngresosMercantiles, out decimal RentaDeOficinaVentas, out decimal GastosDeDepreciacionDeVenta);
            GastosDeAdministracionLeer(out decimal SueldoDeGerente, out decimal ServiciosBasicosVenta, out decimal SueldoDeViceGerente, out decimal SueldoDeContador, out decimal SueldoDelPersonalDeOficina, out decimal SeguroSocialDelPersonal, out decimal ConsumoDePapeleríaYUtilesDeEscritorio, out decimal GastosDeCoreoYTelegrafo, out decimal AlquilerDeOficina, out decimal GastosDeDepreciacion);
            GastosFinancieros(out decimal InteresesSobreDocumentos, out decimal DescuentoPorPagoAnticipado, out decimal InteresesSobrePrestamosBancarios, out decimal PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera);
            EgresosLeer(out decimal InteresesPagados, out decimal ServiciosBancarios, out decimal RentasCobradas, out decimal PerdidasoUtilidadesEnVentaDeVariosActivosFijo, out decimal PerdidasoUtilidadesEnCompraDeActivos, out decimal RentasPagadas, out decimal DividendoDeAcciones, out decimal ComisionesCobradas);
            OtrosIngresosLeer(out decimal InteresesCobrados, out decimal DividendosCobrados);
            Pregunta(out decimal ISR);

            //Estado de resultado en si
            TotalVentasNetas(VentasTotales, Devoluciones, RebajasSobreVentas, Descuentos, out decimal TotalVentasN);
            TotalComprasNetas(Compras, GastosDeCompra, DevolucionesSobreCompra, RebajasSobreCompras, DescuentoSobreCompra, InventarioInicial, InventarioFinal, MercanciaDisponible, out decimal TotalComprasN);
            CalcUtilidadBruta(TotalVentasN, TotalComprasN, out decimal UtilidadBruta);
            TotalGastosDeVenta(SueldoDeLosJefesDeVenta, ServiciosBasicosVenta, SueldoDeLosEmpleadosDeAlmacen, SueldoDeLosEmpleadosDeLaVenta, SueldosDeLosChoferesDelEquipoDeEntrega, ComisionesDeAgentesYDependientes, SeguroSocialesDelPersonalDeVenta, Propaganda, ConsumoDeEtiquetasEnvolturaYEmpaque, FletesYAcarreosDeLaMercanciasVendidas, GastosDeMantenimientoDelEquipoDeReparto, ImpuestosSobreIngresosMercantiles, RentaDeOficinaVentas, GastosDeDepreciacionDeVenta, out decimal TotalGastosV);
            TotalGastosDeAdministración(SueldoDeGerente, SueldoDeViceGerente, SueldoDeContador, SueldoDelPersonalDeOficina, SeguroSocialDelPersonal, ConsumoDePapeleríaYUtilesDeEscritorio, GastosDeCoreoYTelegrafo, AlquilerDeOficina, GastosDeDepreciacion, out decimal TotalGastosAdmin);
            TotalGastosFinancieros(InteresesSobreDocumentos, DescuentoPorPagoAnticipado, InteresesSobrePrestamosBancarios, PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera, out decimal TotalGastosFi);
            CalcUtilidadDeOperación(TotalGastosV, TotalGastosAdmin, TotalGastosFi, UtilidadBruta, out decimal UtilidadDeOperación);
            TotalOtrosIngresos(InteresesCobrados, DividendosCobrados, out decimal TotalOI);
            TotalOtrosegresos(InteresesPagados, ServiciosBancarios, RentasCobradas, PerdidasoUtilidadesEnVentaDeVariosActivosFijo, PerdidasoUtilidadesEnCompraDeActivos, RentasPagadas, DividendoDeAcciones, ComisionesCobradas, out decimal TotalOtrosGastos);
            CalcUtilidadAntesdeISR(TotalOI, UtilidadDeOperación, TotalOtrosGastos, out decimal UtilidadAntesDeImpuesto);
            CalcUtilidadNeta(ISR, UtilidadAntesDeImpuesto, out decimal UtilidadNeta);
        }
    }
}