using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tablas_atributos;
using negocio;
using conexionaSQL;
using negocio.ingresarDatos.empleado;
using subclases;
using negocios.ingresarDatos.producto;
using negocios.ingresarDatos.ruta;
using negocios.ingresarDatos.viajes;

namespace negocios.logicaCompartida
{

    public class CompartirFunciones
    {
        //instancia 



        public void ListaRuta()
        {
            ServicioRuta listasGeneral = new ServicioRuta();
            List<Rutas> rutas = listasGeneral.listar();

            foreach (var calles in rutas)
            {
                Console.WriteLine($"Codigo: {calles.codigo}, Origen: {calles.origen}, Destino: {calles.destino}, Distancia: {calles.distanciaKm}Km");

            }
            
        }

        public Rutas BuscarRuta()
        {
            Console.WriteLine("Escriba codigo de ruta a buscar o de preferecia");
            string buscarRuta = Console.ReadLine();

            ServicioRuta codigo = new ServicioRuta();

            var enlce = codigo.Buscar(buscarRuta);

            Rutas rutaSeleccionada = enlce.FirstOrDefault();

            if (rutaSeleccionada == null )
            {
                Console.WriteLine("Ruta no encontrada");
            }
            else
                Console.WriteLine($"Ruta encontrada: Código: {rutaSeleccionada.codigo}, Origen: {rutaSeleccionada.origen}, Destino: {rutaSeleccionada.destino}, Distancia: {rutaSeleccionada.distanciaKm}Km");


            return rutaSeleccionada;

        }


        public void Historial()
        {
            ServicioViaje viajes = new ServicioViaje();
            List<viaje> historia = viajes.listar();


            if ( viajes != null)
            {
               

                Console.WriteLine("Historial de viajes realizados");

                foreach (var vuelos in historia)
                {
                    //if( viajes == historia.Where(c=>c.Vehiculo))
                    Console.WriteLine($"Id del viaje: {vuelos.idViaje} Id del producto: {vuelos.productoId}, Id del vehiculo: {vuelos.vehiculoId}, Id del conductor: {vuelos.empleadoid}, Costo total: {vuelos.costoTotal}");


                }

            }

            //return historia;
        }

    }
}
