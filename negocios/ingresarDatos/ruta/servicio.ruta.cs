using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tablas_atributos;
using conexionaSQL;
namespace negocios.ingresarDatos.ruta
{
    public class ServicioRuta
    {


        public TablaDbContent conexionRutas;

        public ServicioRuta()
        { 
            conexionRutas = new TablaDbContent();
        }

        public bool Insertar(Rutas calles)
        {
            try
            {
                conexionRutas.Add(calles);
                conexionRutas.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool eliminar(Rutas callesEliminar)
        {
            try
            {

                conexionRutas.Remove(callesEliminar);
                conexionRutas.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }


        }

        public List<Rutas> listar()
        {
            return conexionRutas.Rutas.ToList();
        }

        public List<Rutas> Buscar(string ide)
        {

            IQueryable<Rutas> busqueda = conexionRutas.Rutas;
            try
            {
                //if (int.TryParse(ide, out int parseado))
                //{
                //    busqueda = busqueda.Where(t => t.placa == parseado);

                //}
                busqueda = busqueda.Where(t => t.codigo.ToString().Equals(ide));

                   

            }
            catch (Exception ex) { throw ex; }
            return busqueda.ToList();
        }
    }
}
