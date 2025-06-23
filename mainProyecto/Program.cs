using System;
//using conexion;
using tablas_atributos;
using negocio.ingresarDatos;
using System.ComponentModel.Design;
using negocio.ingresarDatos.empleado;
using negocio.ingresarDatos.vehiculo;
using subclases;
using negocios.ingresarDatos.ruta;
using Microsoft.Data.SqlClient;
using negocios.ingresarDatos.producto;
using mainProyecto;
using menu;

namespace mainCarrosProyecto // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            Menus menus = new Menus();
            menus.Login();
        }
    }
}