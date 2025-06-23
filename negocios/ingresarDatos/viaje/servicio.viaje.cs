using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tablas_atributos;
//using conectar;
using conexionaSQL;
using subclases;



namespace negocios.ingresarDatos.viajes
{
    public class ServicioViaje
    {
        public TablaDbContent conexionViaje;

        public ServicioViaje()
        {
            conexionViaje = new TablaDbContent();
        }

        public bool Insertar(viaje inser)
        {
            try
            {
                conexionViaje.Add(inser);
                conexionViaje.SaveChanges();


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Eliminar(viaje inser)
        {
            try
            {
                conexionViaje.Remove(inser);
                conexionViaje.SaveChanges();

                return true;

            }
            catch (Exception ex) { throw ex; }

        }

        public bool modificar(viaje modi)
        {
            try
            {
                conexionViaje.Update(modi);
                conexionViaje.SaveChanges();


                return true;

            }
            catch (Exception ex) { throw ex; }

        }

        public List<viaje> listar()
        {
            return conexionViaje.Viajes.ToList();
        }

        public List<viaje> Buscar(string ide)
        {

            IQueryable<viaje> busqueda = conexionViaje.Viajes;
            try
            {
                //if (int.TryParse(ide, out int parseado))
                //{
                //    busqueda = busqueda.Where(t => t.placa == parseado);

                //}
                busqueda = busqueda.Where(t => t.idViaje.ToString().Equals(ide));
                if (!string.IsNullOrEmpty(ide))
                {

                    foreach (var vuelos in busqueda)
                    {
                        Console.WriteLine($"Id del viaje: {vuelos.idViaje} Id del producto: {vuelos.productoId},Producto: {vuelos.NombreProducto}, Id del vehiculo: {vuelos.vehiculoId}, Id del conductor: {vuelos.empleadoid}, Costo total: {vuelos.costoTotal}");

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
