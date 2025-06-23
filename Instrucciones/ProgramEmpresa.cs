using negocio.ingresarDatos.empleado;
using negocio.ingresarDatos.vehiculo;
using negocios.ingresarDatos.producto;
using negocios.ingresarDatos.ruta;
using subclases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tablas_atributos;
using mainProyecto;
using negocios.logicaCompartida;
using System.ComponentModel.DataAnnotations;
using menu;

namespace mainProyecto
{
    public class Instrucciones
    {
        CompartirFunciones compartir = new CompartirFunciones();
        public Menus utilidad;

        public Instrucciones(Menus menu)
        {
            utilidad = menu;
        }

        //public void MenuEmpresa()
        //{
        //    Console.WriteLine("1- Gestion de vehiculos");
        //    Console.WriteLine("2- Gestion de empleados");
        //    Console.WriteLine("3- Rutas");
        //    Console.WriteLine("4- Inventario de productos");
        //    Console.WriteLine("5- Volver");

        //    string respuesta = Console.ReadLine();

        //    if (int.TryParse(respuesta, out int convertido))
        //    {
        //        switch (convertido)
        //        {
        //            case 1:
        //                utilidad.MenuEmpresaVehiculosCaso1();
        //                break;
        //            case 2:
        //                utilidad.MenuEmpresaEmpleadoCaso2();
        //                break;
        //            case 3:
        //                utilidad.MenuEmpresaRutasCaso3();
        //                break;
        //            case 4:
        //                utilidad.MenuEmpresaProductosCaso4();
        //                break;
        //            case 5:
        //                utilidad.Login();
        //                break;
        //        }
        //    }
        //}

        public void InsertarEmpleado()
        {
            Console.WriteLine("Ingrese nombre de empleado");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese puesto (Mecanico/Conductor)");
            string puesto = Console.ReadLine();
            Console.WriteLine("Ingrese salario");
            int salario = int.Parse(Console.ReadLine());

            Empleado traerTablaEmpleado = null;
            ServiciosEmpleado traerServicioEmpleado = new ServiciosEmpleado();

            if (puesto == "Conductor")
            {
                Console.WriteLine("Ingrese tipo de Licencia A1(Solo Moto)/ B2(Carro)/ C3 (Carro y Camion)");
                string licencia = Console.ReadLine();

                traerTablaEmpleado = new Conductor
                {
                    nombre = nombre,
                    salario = salario,
                    eficienciaBono = 0,
                    tipoLicencia = licencia
                };
            }
            else if (puesto == "Mecanico")
            {
                traerTablaEmpleado = new Mecanico
                {
                    nombre = nombre,
                    salario = salario,
                    reparacionesRealizadas = 0,
                    vehiculosAsignados = 0,
                };
            }
            else
            {
                Console.WriteLine("No ha digitado bien");
                utilidad.MenuEmpresaEmpleadoCaso2();
            }

            if (traerServicioEmpleado.Insertar(traerTablaEmpleado))
            {
                Console.WriteLine("Operación exitosa");
                utilidad.MenuEmpresaEmpleadoCaso2();
            }
            else
                Console.WriteLine("Operación fallida");
            utilidad.MenuEmpresaEmpleadoCaso2();
        }

        public void ListaEmpleados()
        {
            ServiciosEmpleado listaGeneral = new ServiciosEmpleado();
            List<Empleado> empleados = listaGeneral.listar();

            Console.WriteLine("Lista de empleados");

            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Id: {empleado.idEmpleado}, Nombre: {empleado.nombre}, Salario: {empleado.salario}");
                if (empleado is Conductor conductor)
                {
                    Console.WriteLine($"Bono de eficiencia: {conductor.eficienciaBono}");
                    Console.WriteLine($"Tipo de licencia: {conductor.tipoLicencia}");
                }
                else if (empleado is Mecanico mecanico)
                {
                    Console.WriteLine($"Carros asignados: {mecanico.vehiculosAsignados}, Vehiculos Reparados: {mecanico.reparacionesRealizadas}");
                }
                else
                    Console.WriteLine("No hay información adicional");
            }
            utilidad.MenuEmpresaEmpleadoCaso2();
        }

        public void InsertarVehiculo()
        {
            Console.WriteLine("Ingrese la placa del vehiculo");
            string placaNo = Console.ReadLine();

            if (!int.TryParse(placaNo, out int placa))
            {
                Console.WriteLine("DIigte bien");
            }else
            {
                Console.WriteLine("Ingrese tipo de vehiculo (Moto/Carro/Camion)");
                string tipoVehiculo = Console.ReadLine();

                ServiciosVehiculo traerServiciosVehiculo = new ServiciosVehiculo();
                Vehiculo traerTablaVehiculo = null;

                if (tipoVehiculo == "Moto" || tipoVehiculo == "Carro")
                {
                    if (tipoVehiculo == "Moto")
                    {
                        traerTablaVehiculo = new VehiculoLiguero
                        {
                            placa = placa,
                            vehiculo = tipoVehiculo,
                            capacidad = 50,
                            rendimiento = 30,
                            tipoCombustible = "Regular",
                            precioCombustible = 750,
                            LicenciausoUrbano = "A1"
                        };
                    }
                    else
                    {
                        traerTablaVehiculo = new VehiculoLiguero
                        {
                            placa = placa,
                            vehiculo = tipoVehiculo,
                            capacidad = 100,
                            rendimiento = 15,
                            tipoCombustible = "Regular",
                            precioCombustible = 770,
                            LicenciausoUrbano = "B2"
                        };
                    }
                }
                else if (tipoVehiculo == "Camion")
                {
                    traerTablaVehiculo = new VehiculoPesado
                    {
                        placa = placa,
                        vehiculo = tipoVehiculo,
                        capacidad = 200,
                        rendimiento = 8,
                        tipoCombustible = "Diesel",
                        precioCombustible = 710,
                        licenciaEspecial = "C1"
                    };
                }
                else
                    Console.WriteLine("Vehículo inválido");

                if (traerServiciosVehiculo.Insertar(traerTablaVehiculo))
                {
                    utilidad.MenuEmpresaVehiculosCaso1();
                }
                else
                    Console.WriteLine("Operación fallida");
            }

            
            utilidad.MenuEmpresaVehiculosCaso1();
        }

        public void ListarVehiculos()
        {
            ServiciosVehiculo listasGeneral = new ServiciosVehiculo();
            List<Vehiculo> vehiculo = listasGeneral.listar();

            foreach (var vehiculos in vehiculo)
            {
                Console.WriteLine($"Placa: {vehiculos.placa}, Vehiculo: {vehiculos.vehiculo}, Capacidad: {vehiculos.capacidad}, Rendimiento: {vehiculos.rendimiento}");
                if (vehiculos is VehiculoLiguero ligero)
                {
                    Console.WriteLine($"Uso urbano: {ligero.LicenciausoUrbano}");
                }
                else if (vehiculos is VehiculoPesado pesado)
                {
                    Console.WriteLine($"Licencia especial: {pesado.licenciaEspecial}");
                }
                else
                    Console.WriteLine("No hay información adicional");
            }
            utilidad.MenuEmpresaVehiculosCaso1();
        }

        public void ListarLigero()
        {
            ServiciosVehiculo listaLigera = new ServiciosVehiculo();
            List<VehiculoLiguero> ligero = listaLigera.filtrarVehiculoLigero();

            foreach (var ligeros in ligero)
            {
                Console.WriteLine($"Placa: {ligeros.placa}, Vehiculo: {ligeros.vehiculo}");
            }
            utilidad.MenuEmpresaVehiculosCaso1();
        }

        public void ListarPesado()
        {
            ServiciosVehiculo listaPesada = new ServiciosVehiculo();
            List<VehiculoPesado> pesados = listaPesada.filtrarVehiculoPesado();

            foreach (var pesaditos in pesados)
            {
                Console.WriteLine($"Placa: {pesaditos.placa}, Vehiculo: {pesaditos.vehiculo}");
            }
            utilidad.MenuEmpresaVehiculosCaso1();
        }

        public Vehiculo BuscarPlaca()
        {
            //Console.WriteLine("Escriba placa a buscar");
            //string buscarPlaca = Console.ReadLine();

            //ServiciosVehiculo placa = new ServiciosVehiculo();
            //var returnPlaca= placa.Buscar(buscarPlaca);

            //return returnPlaca.FirstOrDefault();
            ServiciosVehiculo placaServicio = new ServiciosVehiculo();
            Vehiculo vehiculoEncontrado = null;

            while (vehiculoEncontrado == null)
            {
                Console.WriteLine("Escriba placa a buscar:");
                string buscarPlaca = Console.ReadLine();

                var listaResultados = placaServicio.Buscar(buscarPlaca);
                vehiculoEncontrado = listaResultados.FirstOrDefault();

                if (vehiculoEncontrado == null)
                {
                    Console.WriteLine("Placa no encontrada. Intente de nuevo.");
                }
            }

            return vehiculoEncontrado;
        }

        public void TallerMecanico()
        { 
            var mecanicos= new ServiciosEmpleado();
            var mecanicosFiltro= mecanicos.filtrarMecanico();

            var servicio = new ServiciosEmpleado();

            Vehiculo carroReprar = new Vehiculo();

            if (mecanicosFiltro.Count == 0)
            {
                Console.WriteLine("No hay mecanicos disponibles");
                return;
            }

            var busqueda= BuscarPlaca();

           
            
                Random rand = new Random();

                int numerorandom = rand.Next(0, mecanicosFiltro.Count);

                Mecanico mecanicoSeleccionado = mecanicosFiltro[numerorandom];


                mecanicoSeleccionado.vehiculosAsignados += 1;
                mecanicoSeleccionado.reparacionesRealizadas += 1;

                Console.WriteLine($"Vehiculo asignado: {busqueda.placa} asigando al mecanico: {mecanicoSeleccionado.nombre} para reparacion");


                servicio.Modificar(mecanicoSeleccionado);


        }


        public void InsertarRuta()
        {
            Console.WriteLine("Ingrese punto de partida de ruta");
            string inicio = Console.ReadLine();

            Console.WriteLine("Ingrese punto de destino de ruta");
            string final = Console.ReadLine();

            Console.WriteLine("Ingrese distancia (KM)");
            int distancia = int.Parse(Console.ReadLine());

            ServicioRuta ruta = new ServicioRuta();
            Rutas calles = new Rutas
            {
                origen = inicio,
                destino = final,
                distanciaKm = distancia,
            };

            if (ruta.Insertar(calles))
            {
                Console.WriteLine("Ruta registrada");
                //utilidad.Login();
                //utilidad.MenuEmpresaRutasCaso3();
            }
            else
                Console.WriteLine("Operación fallida");
            //utilidad.MenuEmpresaRutasCaso3();
        }

        public void InsertarProducto()
        {
            Console.WriteLine("Ingrese producto");
            string producto = Console.ReadLine();

            Console.WriteLine("Ingrese precio");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese precio en oferta");
            decimal oferta = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese stock");
            int stock = int.Parse(Console.ReadLine());

            ServicioProducto servicioProducto = new ServicioProducto();
            Producto productos = new Producto
            {
                producto = producto,
                precio = precio,
                oferta = oferta,
                stock = stock,
                devoluciones = 0
            };

            if (servicioProducto.Insertar(productos))
            {
                Console.WriteLine("Producto ingresado");
                utilidad.MenuEmpresaProductosCaso4();
            }
            else
                Console.WriteLine("Operación fallida");
            utilidad.MenuEmpresaProductosCaso4();
        }

        public void ListaProductos()
        {
            var productos = new ServicioProducto().listar();

            Console.WriteLine("Productos disponibles ");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Codigo: {producto.Idproducto}, Producto: {producto.producto}, Precio: {producto.precio}, Oferta: {producto.oferta}" +
                     $", Stock: {producto.stock}, Devoluciones: {producto.devoluciones}");
            }
            utilidad.MenuEmpresaProductosCaso4();
        }

        public void BuscarProducto()
        {
            Console.WriteLine("Escriba el id de producto a buscar");
            string buscarProducto = Console.ReadLine();

            ServicioProducto productoId = new ServicioProducto();
            productoId.Buscar(buscarProducto);
        }
    }
}
