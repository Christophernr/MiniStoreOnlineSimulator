using mainProyecto;
using negocios.logicaCompartida;
using subclases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using 
namespace menu
{
    public class Menus
    {
        Instrucciones empresa;
        ProgramUsuario usuario;
        CompartirFunciones compartir;

        public Menus()
        {
            empresa = new Instrucciones(this);
            usuario = new ProgramUsuario(this);
            compartir = new CompartirFunciones();
        }

        public void Login()
        {
            Console.WriteLine("1-si es usuario");
            Console.WriteLine("2-si es de la empresa");
            string pregunta = Console.ReadLine();

            if (int.TryParse(pregunta, out int convertido))
            {
                if (convertido == 1) // usuario
                {
                    Console.WriteLine("ha ingresado");
                    MenuUsuarios();
                }
                else if (convertido == 2) // interno
                {
                    Console.WriteLine("dueño pa");
                    MenuEmpresa();
                }
                else
                {
                    Console.WriteLine("digite bien");
                    Login();
                }
            }
            else
            {
                Console.WriteLine("ha digitado mal");
                Login();
            }
        }

        public void MenuEmpresa()
        {
            Console.WriteLine("1- Gestion de vehiculos");
            Console.WriteLine("2- Gestion de empleados");
            Console.WriteLine("3- Rutas");
            Console.WriteLine("4- Inventario de productos");
            Console.WriteLine("5- Volver");

            string respuesta = Console.ReadLine();

            if (int.TryParse(respuesta, out int convertido))
            {
                switch (convertido)
                {
                    case 1:
                        MenuEmpresaVehiculosCaso1();
                        break;
                    case 2:
                        MenuEmpresaEmpleadoCaso2();
                        break;
                    case 3:
                        MenuEmpresaRutasCaso3();
                        break;
                    case 4:
                        MenuEmpresaProductosCaso4();
                        break;
                    case 5:
                        Login();
                        break;
                }

            }
        }



        public void MenuEmpresaVehiculosCaso1()
        {
            Console.WriteLine("1. registrar nuevo vehículo");
            Console.WriteLine("2. buscar informacion de vehiculos");
            Console.WriteLine("3.Enviar vehiculo a reparar");
            Console.WriteLine("4. volver al menú principal");

            string respuestacaso1 = Console.ReadLine();

            if (int.TryParse(respuestacaso1, out int convertido))
            {
                switch (convertido)
                {
                    case 1:
                        empresa.InsertarVehiculo();
                        break;

                    case 2:
                        MenuEmpresaVeiculoCaso1Caso2();
                        break;


                    case 3:
                        empresa.TallerMecanico();
                        MenuEmpresaVehiculosCaso1();
                        break;
                    case 4:
                        MenuEmpresa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("digite de nuevo");
                MenuEmpresaVehiculosCaso1();
            }
        }

        public void MenuEmpresaVeiculoCaso1Caso2()
        {
            Console.WriteLine("1. lista de vehiculos pesados");
            Console.WriteLine("2. lista de vehiculos ligeros");
            Console.WriteLine("3. buscar por placa");
            Console.WriteLine("4. volver");
            string respuesta2caso2 = Console.ReadLine();

            if (int.TryParse(respuesta2caso2, out int convertido1))
            {
                switch (convertido1)
                {
                    case 1:
                        empresa.ListarPesado();
                        break;
                    case 2:
                        empresa.ListarLigero();
                        break;
                    case 3:
                        empresa.BuscarPlaca();
                        break;
                    case 4:
                        MenuEmpresa();
                        break;
                }
                //MenuEmpresaVehiculosCaso1();
            }
            else
            {
                Console.WriteLine("digite bien un numero");
            }
            MenuEmpresaVehiculosCaso1();
            

        }

        public void MenuEmpresaEmpleadoCaso2()
        {
            Console.WriteLine("1-insertar nuevo empleado");
            Console.WriteLine("2-historial de viajes");
            Console.WriteLine("3-lista de empleados");
            Console.WriteLine("4-volver");

            string respuestacaso2 = Console.ReadLine();

            if (int.TryParse(respuestacaso2, out int convertido))
            {
                switch (convertido)
                {
                    case 1:
                        empresa.InsertarEmpleado();
                        break;
                    case 2:
                        usuario.HistorialPedidos();
                       
                        break;
                    case 3:
                        empresa.ListaEmpleados();
                        break;
                    case 4:
                        MenuEmpresa();
                        break;
                }
                MenuEmpresaEmpleadoCaso2();
            }
            else
            {
                Console.WriteLine("digite numero valido");
            }
            MenuEmpresaEmpleadoCaso2();
        }

        public void MenuEmpresaRutasCaso3()
        {
            Console.WriteLine("1. ingresar rutas");
            Console.WriteLine("2. lista de rutas");
            Console.WriteLine("3. buscar ruta por codigo");
            Console.WriteLine("4. volver");

            string respuesta3 = Console.ReadLine();

            if (int.TryParse(respuesta3, out int convertido))
            {
                switch (convertido)
                {
                    case 1:
                        empresa.InsertarRuta();
                        break;
                    case 2:
                        compartir.ListaRuta();
                        
                        break;
                    case 3:
                        compartir.BuscarRuta();
                        
                        break;
                    case 4:
                        MenuEmpresa();
                        break;
                }
                MenuEmpresaRutasCaso3();
            }
            else
            {
                Console.WriteLine("digite bien");
                MenuEmpresaRutasCaso3();
            }
        }

        public void MenuEmpresaProductosCaso4()
        {
            Console.WriteLine("1. insertar producto");
            Console.WriteLine("2. lista de productos");
            Console.WriteLine("3. buscar productos");
            Console.WriteLine("4. volver");

            string respuesta4 = Console.ReadLine();

            if (int.TryParse(respuesta4, out int convertido))
            {
                switch (convertido)
                {
                    case 1:
                        empresa.InsertarProducto();
                        break;
                    case 2:
                        empresa.ListaProductos();
                        break;
                    case 3:
                        empresa.BuscarProducto();
                        
                        break;
                    case 4:
                        MenuEmpresa();
                        break;
                }
                MenuEmpresaProductosCaso4();
            }
            else
            {
                Console.WriteLine("digite bien");
                MenuEmpresaProductosCaso4();
            }
        }

        public void MenuUsuarios()
        {
            Console.WriteLine("1- ver productos disponibles");
            Console.WriteLine("2- realizar un pedido");
            Console.WriteLine("3- ofertas especiales");
            Console.WriteLine("4- historial de pedidos");
            Console.WriteLine("5- devolver un producto");
            Console.WriteLine("6- volver");

            string respuesta = Console.ReadLine();

            if (int.TryParse(respuesta, out int convertido))
            {
                switch (convertido)
                {
                    case 1:
                        usuario.ProductoUsuario();
                        //MenuUsuarios();
                        break;
                    case 2:
                        usuario.RealizarPedido();
                        break;
                    case 3:
                        usuario.Ofertas();
                        //MenuUsuarios();
                        break;
                    case 4:
                        usuario.HistorialPedidos();
                        //MenuUsuarios();
                        break;
                    case 5:
                        usuario.Devoluciones();
                        break;
                    case 6:
                        MenuUsuarios();
                        break;
                    
                }
                MenuUsuarios();
            }
            else
            {
                Console.WriteLine("digite bien");
                MenuUsuarios();
            }
        }
    }
}