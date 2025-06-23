using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conexionaSQL;
using subclases;
using tablas_atributos;
namespace negocio.ingresarDatos.empleado
{ 
    public class ServiciosEmpleado
    {
        public TablaDbContent conexionEmpleado;

        public ServiciosEmpleado()
        {
            conexionEmpleado = new TablaDbContent();
        }

        public bool Insertar(Empleado empleado)
        {
            try
            {
                conexionEmpleado.Add(empleado);
                conexionEmpleado.SaveChanges();


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Eliminar(Empleado empleado)
        {
            try
            {
                conexionEmpleado.Remove(empleado);
                conexionEmpleado.SaveChanges();

                return true;

            }
            catch (Exception ex) { throw ex; }

        }

        public List<Empleado> listar()
        {
            return conexionEmpleado.Empleados.ToList();
        }


        public List<Conductor> filtrarConductor()
        {

            try
            {
                //el oftype ayuda a solo elehir la subclase
                var empleado = conexionEmpleado.Empleados.OfType<Conductor>().ToList();

                
                return empleado;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public List<Mecanico> filtrarMecanico()
        {

            try
            {
                //el oftype ayuda a solo elehir la subclase
                var empleado = conexionEmpleado.Empleados.OfType<Mecanico>().ToList();

                return empleado;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool Modificar(Empleado modifica)
        { 
            try
            {
                conexionEmpleado.Update(modifica);
                conexionEmpleado.SaveChanges();


                return true;
            }catch (Exception ex) { throw ex; }
        
        
        }
    }
}
