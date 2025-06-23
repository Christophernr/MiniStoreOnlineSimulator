using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using conexion;
using conexionaSQL;
using subclases;
using tablas_atributos;
namespace negocio.ingresarDatos.vehiculo
{
    public class ServiciosVehiculo
    {
        public TablaDbContent conexionVehiculos;

        public ServiciosVehiculo()
        {
            conexionVehiculos = new TablaDbContent();
        }

        public bool Insertar(Vehiculo vehiculo)
        {
            try
            {
                conexionVehiculos.Add(vehiculo);
                conexionVehiculos.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool eliminar(Vehiculo vehiculo)
        {
            try
            {

                conexionVehiculos.Remove(vehiculo);
                conexionVehiculos.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }


        }

        public List<Vehiculo> listar()
        {
            return conexionVehiculos.Vehiculos.ToList();
        }

        public List<VehiculoLiguero> filtrarVehiculoLigero()
        {
           
            try
            {
                //el oftype ayuda a solo elehir la subclase
                var carro = conexionVehiculos.Vehiculos.OfType<VehiculoLiguero>().ToList();

                return carro;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<VehiculoPesado> filtrarVehiculoPesado()
        {

            try
            {
                //el oftype ayuda a solo elehir la subclase
                var carro = conexionVehiculos.Vehiculos.OfType<VehiculoPesado>().ToList();

                return carro;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Vehiculo> Buscar(string ide)
        {

            IQueryable<Vehiculo> busqueda = conexionVehiculos.Vehiculos;
            try
            {
                //if (int.TryParse(ide, out int parseado))
                //{
                //    busqueda = busqueda.Where(t => t.placa == parseado);

                //}
                busqueda = busqueda.Where(t => t.placa.ToString().Contains(ide));
                if (!string.IsNullOrEmpty(ide))
                {

                    foreach (var item in busqueda)
                    {
                        Console.WriteLine($"Placa {item.placa}, Vehiculo {item.vehiculo}, Capacidad: {item.capacidad}, Rendimiento: {item.rendimiento}");
                    }
                }
                else
                    Console.WriteLine("No existe o digite bien");
                
            }
            catch (Exception ex) { throw ex; }
            return busqueda.ToList();
        }
    }
}
