using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tablas_atributos;
namespace subclases
{
    public class Conductor: Empleado
    {
        public decimal eficienciaBono {  get; set; }

        public string tipoLicencia { get; set; }
    }

    public class Mecanico : Empleado 
    {
        public int reparacionesRealizadas { get; set; }

        public int vehiculosAsignados { get; set; }
    }

    
}
