using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tablas_atributos;
namespace subclases
{
    public class VehiculoLiguero: Vehiculo
    {
        public string LicenciausoUrbano {  get; set; }
    }

    public class VehiculoPesado : Vehiculo
    {
        public string licenciaEspecial {  get; set; }
        
    }
}
