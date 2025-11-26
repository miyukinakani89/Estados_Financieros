using System;
namespace Estadosfinancieros
{
    public class EstadoResultado
    {
        public void Ingresosleer(out decimal VentasTotales, out decimal Devoluciones, out decimal RebajasSobreVentas, out decimal Descuentos)
        {
            VentasTotales = 0m;
            Devoluciones = 0m;
            RebajasSobreVentas = 0m;
            Descuentos = 0m;
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("           INGRESO DE VENTAS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            do
            {           
                    Console.WriteLine("Ingrese el monto de Ventas Totales");          
                    texto = Console.ReadLine() ?? "";
                     VentasTotales = ObtenerNumero(texto);
            } while (VentasTotales < 0);

            do
            {                
                    Console.WriteLine("Ingrese el monto de Devoluciones(Valor Negativo)");
                    texto = Console.ReadLine() ?? "";
                   Devoluciones = ObtenerNumero(texto);
            } while (Devoluciones > 0);

            do
            {             
                    Console.WriteLine("Ingrese el monto de Rebajas sobre la venta(Valor Negativo)");
                    texto = Console.ReadLine() ?? "";
                    RebajasSobreVentas = ObtenerNumero(texto);
            } while (RebajasSobreVentas > 0);

            do
            {
                    Console.WriteLine("Ingrese el monto de Descuentos(Valor Negativo)");
                    texto = Console.ReadLine() ?? "";
                    Descuentos= ObtenerNumero(texto);

            } while (Descuentos > 0);

        }

        public void CostosLeer(out decimal Compras,out decimal GastosDeCompra, out decimal DevolucionesSobreCompra, out decimal RebajasSobreCompras, out decimal DescuentoSobreCompra, out decimal InventarioInicial, out decimal InventarioFinal)
        {
            Compras = 0m;
            GastosDeCompra = 0m;
            DevolucionesSobreCompra = 0m;
            RebajasSobreCompras = 0m;
            DescuentoSobreCompra = 0m;
            InventarioInicial = 0m;
            InventarioFinal = 0m;
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("           COSTOS DE VENTAS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            do
            {           
                    Console.WriteLine("Ingrese el monto del Inventario Inicial");
                    texto = Console.ReadLine() ?? "";
                    InventarioInicial = ObtenerNumero(texto);
            } while (InventarioInicial < 0);

            do
            {        
                    Console.WriteLine("Ingrese el monto de las Compras");
                   texto = Console.ReadLine() ?? "";
                   GastosDeCompra = ObtenerNumero(texto);

            } while (GastosDeCompra < 0);

            do
            {            
                    Console.WriteLine("Ingrese el monto de los Gastos de compra");
                    texto = Console.ReadLine() ?? "";
                    GastosDeCompra = ObtenerNumero(texto);
            } while (GastosDeCompra < 0);

            do
            {             
                    Console.WriteLine("Ingrese el monto de las Devoluciones sobre compra(Valor Negativo)");                
                    texto = Console.ReadLine() ?? "";
                    DevolucionesSobreCompra = ObtenerNumero(texto);
            } while (DevolucionesSobreCompra > 0);

            do
            {
                    Console.WriteLine("Ingrese el monto de Rebajas sobre compras(Valor Negativo)");
                    texto = Console.ReadLine() ?? "";
                    RebajasSobreCompras = ObtenerNumero(texto);
            } while (RebajasSobreCompras > 0);

            do
            {            
                    Console.WriteLine("Ingrese el monto de Descuentos sobre compra(Valor Negativo)");
                    texto = Console.ReadLine() ?? "";
                    DescuentoSobreCompra = ObtenerNumero(texto);
            } while (DescuentoSobreCompra > 0);

            do
            {              
                    Console.WriteLine("Ingrese el monto de Inventario Final(Valor Negativo)");
                    texto = Console.ReadLine() ?? "";
                    InventarioFinal = ObtenerNumero(texto);
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
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("           GASTO DE VENTAS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            do
            {              
                    Console.WriteLine("Ingrese el monto del Sueldo de jefes de venta");
                    texto = Console.ReadLine() ?? "";
                    SueldoDeLosJefesDeVenta= ObtenerNumero(texto);
             } while (SueldoDeLosJefesDeVenta < 0);

            do
            {               
                    Console.WriteLine("Ingrese el monto del Sueldo de Empleados del almacén");
                    texto = Console.ReadLine() ?? "";
                    SueldoDeLosEmpleadosDeAlmacen = ObtenerNumero(texto);

            } while (SueldoDeLosEmpleadosDeAlmacen < 0);

            do
            {
            
                    Console.WriteLine("Ingrese el monto del Sueldo de los Empleados de Venta");
                    texto = Console.ReadLine() ?? "";
                    SueldoDeLosEmpleadosDeLaVenta = ObtenerNumero(texto);
               
            } while (SueldoDeLosEmpleadosDeLaVenta < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Sueldo de los choferes de equipo de entrega");
                texto = Console.ReadLine() ?? "";
                SueldosDeLosChoferesDelEquipoDeEntrega = ObtenerNumero(texto);

            } while (SueldosDeLosChoferesDelEquipoDeEntrega < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de las Comisiones de Agentes y Dependientes");
                texto = Console.ReadLine() ?? "";
                ComisionesDeAgentesYDependientes = ObtenerNumero(texto);
            } while (ComisionesDeAgentesYDependientes < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Seguro Social del personal de Venta");
                texto = Console.ReadLine() ?? "";
                SeguroSocialesDelPersonalDeVenta = ObtenerNumero(texto);
            } while (SeguroSocialesDelPersonalDeVenta < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de la Propaganda");
                texto = Console.ReadLine() ?? "";
                Propaganda = ObtenerNumero(texto);
            } while (Propaganda < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Consumo de Empaque");
                texto = Console.ReadLine() ?? "";
                ConsumoDeEtiquetasEnvolturaYEmpaque = ObtenerNumero(texto);
            } while (ConsumoDeEtiquetasEnvolturaYEmpaque < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de el Acarreo de las Mercancias Vendidas");
                texto = Console.ReadLine() ?? "";
                FletesYAcarreosDeLaMercanciasVendidas = ObtenerNumero(texto);
            } while (FletesYAcarreosDeLaMercanciasVendidas < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Gasto de Mantenimiento del equipo de ventas");
                texto = Console.ReadLine() ?? "";
                GastosDeMantenimientoDelEquipoDeReparto = ObtenerNumero(texto);
            } while (GastosDeMantenimientoDelEquipoDeReparto < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Impuesto sobre ingresos mercantiles");
                texto = Console.ReadLine() ?? "";
                ImpuestosSobreIngresosMercantiles = ObtenerNumero(texto);
            } while (ImpuestosSobreIngresosMercantiles < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de la Renta de Oficina de ventas");
                texto = Console.ReadLine() ?? "";
                RentaDeOficinaVentas = ObtenerNumero(texto);
            } while (RentaDeOficinaVentas < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de los Gastos de Depreciacion de venta");
                texto = Console.ReadLine() ?? "";
                GastosDeDepreciacionDeVenta = ObtenerNumero(texto);
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
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("       GASTO DE ADMINISTRACION");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            do
            {
                Console.WriteLine("Ingrese el monto del Sueldo De Gerente");
                texto = Console.ReadLine() ?? "";
                SueldoDeGerente = ObtenerNumero(texto);
            } while (SueldoDeGerente < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Sueldo De Vice Gerente");
                texto = Console.ReadLine() ?? "";
                SueldoDeViceGerente = ObtenerNumero(texto);
            } while (SueldoDeViceGerente < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Sueldo Del Contador");
                texto = Console.ReadLine() ?? "";
                SueldoDeContador = ObtenerNumero(texto);
            } while (SueldoDeContador < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Sueldo Del Personal");
                texto = Console.ReadLine() ?? "";
                SueldoDelPersonalDeOficina = ObtenerNumero(texto);

            } while (SueldoDelPersonalDeOficina < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Seguro Social del Personal");
                texto = Console.ReadLine() ?? "";
                SeguroSocialDelPersonal = ObtenerNumero(texto);
            } while (SeguroSocialDelPersonal < 0);

            do
            {
                
                    Console.WriteLine("Ingrese el monto de papeleria y utiles de escritorio");
                texto = Console.ReadLine() ?? "";
               ConsumoDePapeleríaYUtilesDeEscritorio = ObtenerNumero(texto);
            } while (ConsumoDePapeleríaYUtilesDeEscritorio < 0);

            do
            {
                  Console.WriteLine("Ingrese el monto de los Gastos de Correo");
                texto = Console.ReadLine() ?? "";
               GastosDeCoreoYTelegrafo = ObtenerNumero(texto);

            } while (GastosDeCoreoYTelegrafo < 0);

            do
            {
              
                    Console.WriteLine("Ingrese el monto del Alquiler de oficina");
                texto = Console.ReadLine() ?? "";
                AlquilerDeOficina = ObtenerNumero(texto);

            } while (AlquilerDeOficina < 0);

            do
            {             
                  Console.WriteLine("Ingrese el monto de los Servicios Basicos del departamento de ventas");
                texto = Console.ReadLine() ?? "";
                ServiciosBasicosVentas = ObtenerNumero(texto);

            } while (ServiciosBasicosVentas < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Gasto de depreciación");
                texto = Console.ReadLine() ?? "";
                GastosDeDepreciacion = ObtenerNumero(texto);
            } while (GastosDeDepreciacion < 0);

        }

        public void GastosFinancieros(out decimal InteresesSobreDocumentos, out decimal DescuentoPorPagoAnticipado, out decimal InteresesSobrePrestamosBancarios, out decimal PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera)
        {
            InteresesSobreDocumentos = 0m;
            DescuentoPorPagoAnticipado = 0m;
            InteresesSobrePrestamosBancarios = 0m;
            PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera = 0m;
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("       GASTOS FINANCIEROS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            do
            {
                Console.WriteLine("Ingrese el monto de los Intereses sobre Documentos");
                texto = Console.ReadLine() ?? "";
                InteresesSobreDocumentos= ObtenerNumero(texto);
            } while (InteresesSobreDocumentos < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del descuento por pago anticipado");
                texto = Console.ReadLine() ?? "";
               DescuentoPorPagoAnticipado = ObtenerNumero(texto);
            } while (DescuentoPorPagoAnticipado < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Interes sobre prestamos bancarios");
                texto = Console.ReadLine() ?? "";
                InteresesSobrePrestamosBancarios = ObtenerNumero(texto);
            } while (InteresesSobrePrestamosBancarios < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de las perdidas o utilidades que resulten del intercambio de moneda extranjera");
                texto = Console.ReadLine() ?? "";
                PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera = ObtenerNumero(texto);
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
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("             OTROS GASTOS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            do
            {
                Console.WriteLine("Ingrese el monto de los Intereses Pagados");
                texto = Console.ReadLine() ?? "";
                InteresesPagados = ObtenerNumero(texto);

            } while (InteresesPagados < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de los Servicios Bancarios");
                texto = Console.ReadLine() ?? "";
                ServiciosBancarios = ObtenerNumero(texto);
            } while (ServiciosBancarios < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de las Rentas Pagadas");
                texto = Console.ReadLine() ?? "";
                RentasPagadas = ObtenerNumero(texto);
            } while (RentasPagadas < 0);

            do
            {
                Console.WriteLine("Ingrese el monto del Dividendo de Acciones");
                texto = Console.ReadLine() ?? "";
                DividendoDeAcciones = ObtenerNumero(texto);
            } while (DividendoDeAcciones < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de las Perdidas en venta de activo fijo");
                texto = Console.ReadLine() ?? "";
                PerdidasoUtilidadesEnVentaDeVariosActivosFijo = ObtenerNumero(texto);
            } while (PerdidasoUtilidadesEnVentaDeVariosActivosFijo < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de las Perdidas o Utilidades en compra de activos");
                texto = Console.ReadLine() ?? "";
                PerdidasoUtilidadesEnCompraDeActivos = ObtenerNumero(texto);
            } while (PerdidasoUtilidadesEnCompraDeActivos < 0);

            do
            {
                Console.WriteLine("Ingrese el monto de las Rentas Cobradas");
                    texto = Console.ReadLine() ?? "";
                    RentasCobradas = ObtenerNumero(texto);
                } while (RentasCobradas < 0);
            do
            {           
                    Console.WriteLine("Ingrese el monto de las Comisiones Cobradas");
                texto = Console.ReadLine() ?? "";
                ComisionesCobradas = ObtenerNumero(texto);
            } while (ComisionesCobradas < 0);


        }

        public void OtrosIngresosLeer(out decimal InteresesCobrados, out decimal DividendosCobrados)
        {
            InteresesCobrados = 0m;
            DividendosCobrados = 0m;
            string texto = "";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("           OTROS INGRESOS");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();
            do
            {          
                    Console.WriteLine("Ingrese el monto de los intereses Cobrados");                
                    texto = Console.ReadLine() ?? "";
                   InteresesCobrados = ObtenerNumero(texto);
                } while (InteresesCobrados < 0);
            do
            {
               
                    Console.WriteLine("Ingrese el monto de los dividendos Cobrados");
                texto = Console.ReadLine() ?? "";
               DividendosCobrados = ObtenerNumero(texto);

            } while (DividendosCobrados < 0);





        }
        public void TotalVentasNetas(decimal VentasTotales, decimal Devoluciones, decimal RebajasSobreVentas, decimal Descuentos, out decimal TotalVentasN)
        {
            TotalVentasN = 0m;
            TotalVentasN = VentasTotales + Devoluciones + RebajasSobreVentas + Descuentos;

            Console.WriteLine("\n=======================================");
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

        public void TotalComprasNetas(decimal Compras, decimal MercanciaDisponible, decimal GastosDeCompra, decimal DevolucionesSobreCompra, decimal RebajasSobreCompras, decimal DescuentoSobreCompra, decimal InventarioInicial, decimal InventarioFinal, out decimal TotalComprasN)
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
        public void CalcUtilidadBruta(decimal TotalVentasN, decimal TotalComprasN, out decimal UtilidadBruta)
        {
            UtilidadBruta = 0m;
            UtilidadBruta = TotalVentasN - TotalComprasN;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad Bruta: " + UtilidadBruta);
            Console.WriteLine("=======================================");
        }
        public void TotalGastosDeVenta(decimal SueldoDeLosJefesDeVenta, decimal ServiciosBasicosVenta, decimal SueldoDeLosEmpleadosDeAlmacen, decimal SueldoDeLosEmpleadosDeLaVenta, decimal SueldosDeLosChoferesDelEquipoDeEntrega, decimal ComisionesDeAgentesYDependientes, decimal SeguroSocialesDelPersonalDeVenta, decimal Propaganda, decimal ConsumoDeEtiquetasEnvolturaYEmpaque, decimal FletesYAcarreosDeLaMercanciasVendidas, decimal GastosDeMantenimientoDelEquipoDeReparto, decimal ImpuestosSobreIngresosMercantiles, decimal RentaDeOficinaVentas, decimal GastosDeDepreciacionDeVenta, out decimal TotalGastosV)
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

        public void TotalGastosDeAdministración(decimal SueldoDeGerente, decimal SueldoDeViceGerente, decimal SueldoDeContador, decimal SueldoDelPersonalDeOficina, decimal SeguroSocialDelPersonal, decimal ConsumoDePapeleríaYUtilesDeEscritorio, decimal GastosDeCoreoYTelegrafo, decimal AlquilerDeOficina, decimal GastosDeDepreciacion, out decimal TotalGastosAdmin)
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

        public void TotalGastosFinancieros(decimal InteresesSobreDocumentos, decimal DescuentoPorPagoAnticipado, decimal InteresesSobrePrestamosBancarios, decimal PerdidasOUtilidadesQueResultenDelIntercambioDeMonedaExtrangera, out decimal TotalGastosFi)
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
        public void CalcUtilidadDeOperación(decimal TotalGastosV, decimal TotalGastosAdmin, decimal TotalGastosFi, decimal UtilidadBruta, out decimal UtilidadDeOperación)
        {
            UtilidadDeOperación = UtilidadBruta - TotalGastosAdmin - TotalGastosV - TotalGastosFi;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad de Operación: " + UtilidadDeOperación);
            Console.WriteLine("=======================================");
        }

        public void TotalOtrosIngresos(decimal InteresesCobrados, decimal DividendosCobrados, out decimal TotalOI)
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

        public void TotalOtrosegresos(decimal InteresesPagados, decimal ServiciosBancarios, decimal RentasCobradas, decimal PerdidasoUtilidadesEnVentaDeVariosActivosFijo, decimal PerdidasoUtilidadesEnCompraDeActivos, decimal RentasPagadas, decimal DividendoDeAcciones, decimal ComisionesCobradas, out decimal TotalOtrosGastos)
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
        public void CalcUtilidadAntesdeISR(decimal TotalOI, decimal UtilidadDeOperacion, decimal TotalOtrosGastos, out decimal UtilidadAntesDeImpuesto)
        {
            UtilidadAntesDeImpuesto = 0m;
            UtilidadAntesDeImpuesto = UtilidadDeOperacion + TotalOI + TotalOtrosGastos;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad Antes De Impuestos: " + UtilidadAntesDeImpuesto);
            Console.WriteLine("=======================================");
        }

        public void Pregunta(out decimal ISR)
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
        public void CalcUtilidadNeta(decimal ISR, decimal UtilidadAntesDeImpuesto, out decimal UtilidadNeta)
        {
            UtilidadNeta = 0m;
            UtilidadNeta = UtilidadAntesDeImpuesto - ISR;
            Console.WriteLine("=======================================");
            Console.WriteLine("Utilidad Neta: " + UtilidadNeta);
            Console.WriteLine("=======================================");
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
        static int ObtenerNumero(string texto)
        {
            int resultado;

            while (!int.TryParse(texto, out resultado))
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo:");
                texto = Console.ReadLine() ?? "";
            }

            return resultado;
        }

    }
}
