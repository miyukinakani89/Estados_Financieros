using System;
namespace Estadosfinancieros
{
    public class LecturaDeDatos
    {
        public void Ingresosleer(out decimal VentasTotales, out decimal Devoluciones, out decimal RebajasSobreVentas, out decimal Descuentos)
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

        public void CostosLeer(out decimal Compras, out decimal GastosDeCompra, out decimal DevolucionesSobreCompra, out decimal RebajasSobreCompras, out decimal DescuentoSobreCompra, out decimal InventarioInicial, out decimal InventarioFinal)
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

        public void GastosDeVentaLeer(out decimal SueldoDeLosJefesDeVenta, out decimal SueldoDeLosEmpleadosDeAlmacen, out decimal SueldoDeLosEmpleadosDeLaVenta, out decimal SueldosDeLosChoferesDelEquipoDeEntrega, out decimal ComisionesDeAgentesYDependientes, out decimal SeguroSocialesDelPersonalDeVenta, out decimal Propaganda, out decimal ConsumoDeEtiquetasEnvolturaYEmpaque, out decimal FletesYAcarreosDeLaMercanciasVendidas, out decimal GastosDeMantenimientoDelEquipoDeReparto, out decimal ImpuestosSobreIngresosMercantiles, out decimal RentaDeOficinaVentas, out decimal GastosDeDepreciacionDeVenta)
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
        public void GastosDeAdministracionLeer(out decimal SueldoDeGerente, out decimal ServiciosBasicosVentas, out decimal SueldoDeViceGerente, out decimal SueldoDeContador, out decimal SueldoDelPersonalDeOficina, out decimal SeguroSocialDelPersonal, out decimal ConsumoDePapeleríaYUtilesDeEscritorio, out decimal GastosDeCoreoYTelegrafo, out decimal AlquilerDeOficina, out decimal GastosDeDepreciacion)
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

        public void GastosFinancieros(out decimal InteresesSobreDocumentos, out decimal DescuentoPorPagoAnticipado, out decimal InteresesSobrePrestamosBancarios, out decimal PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera)
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

        public void EgresosLeer(out decimal InteresesPagados, out decimal ServiciosBancarios, out decimal RentasCobradas, out decimal PerdidasoUtilidadesEnVentaDeVariosActivosFijo, out decimal PerdidasoUtilidadesEnCompraDeActivos, out decimal RentasPagadas, out decimal DividendoDeAcciones, out decimal ComisionesCobradas)
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

        public void OtrosIngresosLeer(out decimal InteresesCobrados, out decimal DividendosCobrados)
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
       
        public void EjecutarEstadoResultadoCompleto()
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

       
        }

    }
}
