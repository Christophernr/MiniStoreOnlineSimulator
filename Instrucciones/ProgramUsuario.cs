using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conexionaSQL;
using tablas_atributos;
using negocio;
using mainProyecto;
using negocios.logicaCompartida;
using negocios.ingresarDatos.producto;
using negocio.ingresarDatos.vehiculo;
using subclases;
using System.ComponentModel;
using negocio.ingresarDatos.empleado;
using negocios.ingresarDatos.ruta;
using negocios.ingresarDatos.viajes;
//using instrucciones;
using menu;

namespace mainProyecto
{
    public class ProgramUsuario
    {
        public CompartirFunciones compartir = new CompartirFunciones();
        public Menus utilidad;

        public ProgramUsuario(Menus menu)
        {
            utilidad = menu;
        }

        public void ProductoUsuario()
        {
            var productos = new ServicioProducto().listar();

            Console.WriteLine("Productos disponibles");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Id del producto {producto.Idproducto}, Producto: {producto.producto}, Precio: {producto.precio} y Cantidad disponible: {producto.stock}");
            }
        }

        public void HistorialPedidos()
        {
            compartir.Historial();
        }

        public void Ofertas()
        {
            var ofertas = new ServicioProducto().listar();
            List<Producto> products = ofertas.Where(c => c.stock > 170).ToList();

            Console.WriteLine("Oferta especial!");
            foreach (var producto in products)
            {
                products = ofertas.Where(c => c.stock > 174).ToList();
                Console.WriteLine($"Id producto: {producto.Idproducto}, Producto: {producto.producto}, Precio especial: {producto.oferta}, Stock: {producto.stock}");
            }
        }

        public void RealizarPedido()
        {
            ProductoUsuario();

            Console.WriteLine("Digite id de producto que quiere comprar");
            string id = Console.ReadLine();

            ServicioProducto servicio = new ServicioProducto();
            var enlace = servicio.Buscar(id);
            Producto producto = enlace.FirstOrDefault();

            compartir.ListaRuta();
            Rutas rutaelegida = compartir.BuscarRuta();

            Console.WriteLine("1.Desea realizar la compra" +
                "2.No comprar");

            string realizarS = Console.ReadLine();

            if (int.TryParse(realizarS, out int realizar))
            {

                if (producto != null)
                {
                    while (realizar == 1)
                    {
                        Console.WriteLine("Digite cantidad a comprar");
                        int cantidad = int.Parse(Console.ReadLine());

                        var conductores = new ServiciosEmpleado();
                        var conductoresFiltro = conductores.filtrarConductor();
                        List<Conductor> filtroLicencias = new List<Conductor>();

                        
                        var vehiculos = new ServiciosVehiculo().listar();
                        List<Vehiculo> listaDisponible = new List<Vehiculo>();

                        int almacenamientoVehiculo = 0;
                        int almacenamientoEmpleado = 0;

                        Conductor conductorSeleccionado= null;
                        decimal costoTotal = 0;
                        decimal gasolina = 0;

                        if (producto.stock >= cantidad)
                        {
                            ServiciosVehiculo transporte = new ServiciosVehiculo();
                            decimal precio = 0;
                            //int validarSiesOferta = 0;
                            viaje viajes = new viaje();
                            
                            if (cantidad >= 40)
                            {
                                precio = producto.oferta * cantidad;
                                viajes.compraOferta = 1;
                                Console.WriteLine($"Se aplicó precio de oferta: {producto.oferta}");

                            }
                            else
                                precio = producto.precio * cantidad;



                            if (cantidad <= 137)
                            {
                                filtroLicencias = conductoresFiltro.Where(c => c.tipoLicencia == "A1").ToList();
                                listaDisponible = vehiculos.Where(c => c.vehiculo == "Moto").ToList();
                            }
                            else if (cantidad >= 138)
                            {
                                filtroLicencias = conductoresFiltro.Where(c => c.tipoLicencia == "B2" || c.tipoLicencia == "C1").ToList();
                                listaDisponible = vehiculos.Where(c => c.vehiculo == "Carro").ToList();
                            }
                            else if (cantidad > 411)
                            {
                                filtroLicencias = conductoresFiltro.Where(c => c.tipoLicencia == "C1").ToList();
                                listaDisponible = vehiculos.Where(c => c.vehiculo == "Camion").ToList();
                            }
                            else
                                Console.WriteLine("Digite cantidad correcta");

                            if (filtroLicencias.Count > 0 && listaDisponible.Count > 0)
                            {
                                Random random = new Random();
                                int conductorRandom = random.Next(0, filtroLicencias.Count);
                                int vehiculoRandom = random.Next(0, listaDisponible.Count);

                                conductorSeleccionado = filtroLicencias[conductorRandom];
                                var vehiculoSeleccionado = listaDisponible[vehiculoRandom];

                                
                                almacenamientoVehiculo = vehiculoSeleccionado.placa;
                                almacenamientoEmpleado = conductorSeleccionado.idEmpleado;

                                var rendimiento = vehiculoSeleccionado.rendimiento;
                                var distancia = rutaelegida.distanciaKm;
                                var consumoEstimado = rendimiento / distancia;
                                var totalEstimado = consumoEstimado * vehiculoSeleccionado.precioCombustible;
                                gasolina = totalEstimado;
                                costoTotal = totalEstimado + precio;
                            }
                            else
                                Console.WriteLine("Conductores no disponibles");
                            Console.WriteLine($"Monto a pagar: {costoTotal}");

                            Console.WriteLine("Digite dinero");
                            int dinero = int.Parse(Console.ReadLine());

                            if (costoTotal == dinero || dinero > costoTotal)
                            {
                                producto.stock -= cantidad;
                                servicio.modificar(producto);

                                //viaje viaje = new viaje
                                //{
                                viajes.vehiculoId = almacenamientoVehiculo;
                                viajes.empleadoid = almacenamientoEmpleado;
                                viajes.rutaId = rutaelegida.codigo;
                                viajes.productoId = producto.Idproducto;
                                viajes.cantidades = cantidad;
                                viajes.costoTotal = costoTotal;
                                viajes.NombreProducto = producto.producto;
                                //};
                                ServicioViaje viajesServicio = new ServicioViaje();
                                viajesServicio.Insertar(viajes);

                                if (dinero > costoTotal)
                                {
                                    Console.WriteLine($"Su vuelto es de: {dinero - costoTotal}");
                                }

                                Console.WriteLine("Compra realizada");
                                Console.WriteLine($"Numero de factura: {viajes.idViaje}");
                                Console.WriteLine($"Id del producto: {producto.Idproducto}");
                                Console.WriteLine($"Pedido realizado: {producto.producto}");
                                Console.WriteLine($"Id del conductor: {viajes.empleadoid}");
                                Console.WriteLine($"Cantidad solicitada: {cantidad}");
                                Console.WriteLine($"Costo de envio: {gasolina}");
                                Console.WriteLine($"Costo del producto neto: {precio}");
                                Console.WriteLine($"Costo total: {viajes.costoTotal}");

                                Console.WriteLine("1. Desea agregar propina");
                                Console.WriteLine("2.No agregar propina");
                                string propina= Console.ReadLine();

                                if (int.TryParse(propina, out int propinaC) && propina=="1")
                                { 
                                    Console.WriteLine("Digite monto de propina");
                                    string montoPropina = Console.ReadLine();

                                    if(int.TryParse(montoPropina, out int montoPropinaC))
                                    {
                                        conductorSeleccionado.eficienciaBono += montoPropinaC;
                                        conductores.Modificar(conductorSeleccionado);
                                        
                                    }

                                
                                }else if(propina=="2")
                                {
                                    utilidad.MenuUsuarios();
                                }
                                else
                                {
                                    Console.WriteLine("Digite bien");
                                }

                            }
                            else
                                Console.WriteLine("No ha digitado suficiente dinero para hacer la compra");
                        }
                        else
                            Console.WriteLine("No hay suficiente stock para realizar la compra");
                        utilidad.MenuUsuarios();
                    }
                }
                else
                    Console.WriteLine("Producto no encontrado");

            }
            else
                Console.WriteLine("Digite bien");

            utilidad.MenuUsuarios();
            return;
        }

        public void Devoluciones()
        {
            Console.WriteLine("Digite número de factura");
            string factura= Console.ReadLine();



            //llamar al afacura
            ServicioViaje serviciosViajes = new ServicioViaje();
            var buscarFactura = serviciosViajes.Buscar(factura);
            viaje almacenViaje= buscarFactura.FirstOrDefault();
            //llamar al producto con el id del producto en la clase viaje 

            ServicioProducto serviciosProductos= new ServicioProducto();
            int idProductoBuscar =almacenViaje.productoId;
            var buscarProducto = serviciosProductos.Buscar(idProductoBuscar.ToString());
            Producto almacenProducto= buscarProducto.FirstOrDefault();

            if (almacenViaje != null && almacenProducto != null)
            {
                Console.WriteLine("Digite cantidad a dwvolver");
                int cantidadDevolver = int.Parse(Console.ReadLine());

                if (almacenViaje.cantidades == cantidadDevolver || almacenViaje.cantidades > cantidadDevolver)
                {
                    //Console.WriteLine("complera");
                    almacenProducto.devoluciones = cantidadDevolver;
                    almacenProducto.stock +=cantidadDevolver;
                    decimal vuelto = 0;
                    if (almacenViaje.compraOferta == 1)
                    {
                        vuelto = cantidadDevolver * almacenProducto.oferta;

                    }
                    else
                        vuelto = cantidadDevolver * almacenProducto.precio;


                    Console.WriteLine($"Su dinero a devolver es de: {vuelto}");

                    serviciosProductos.modificar(almacenProducto);

                }
                else if (almacenViaje.cantidades < cantidadDevolver)
                {
                    //Console.WriteLine("Se le da vuelto");
                    Console.WriteLine("eatas devolviendo de mas, volver a digitar");
                    Devoluciones();
                }
                else
                    Console.WriteLine("Digte bien");

            } else
                Console.WriteLine("No encontrado");
            return;   
        }   
    }
}