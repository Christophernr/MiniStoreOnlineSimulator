using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace tablas_atributos
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int placa { get; set; }

        public string vehiculo { get; set; }

        public decimal capacidad { get; set; }

        public decimal rendimiento { get; set; } //los kilometros recorridos con un solo litro de gasolina
        public string tipoCombustible { get; set; } // Ej: "Gasolina", "Diésel"

        public decimal precioCombustible { get; set; } // Precio por litro



    }


    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma1
        public int idEmpleado { get; set; }

        public string nombre { get; set; }

        public int salario { get; set; }

        //public string tipoLicencia { get; set; }
    }

    public class Rutas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma1
        public int codigo { get; set; }

        public string origen { get; set; }

        public string destino { get; set; }

        public int distanciaKm { get; set; }

    }

    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma1
        public int Idproducto { get; set; }
        public string producto { get; set; }
        public decimal precio { get; set; }

        public decimal oferta { get; set; }

        public int stock { get; set; }

        public int devoluciones { get; set; }
    }

    //especial

    public class viaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma1
        public int idViaje { get; set; }//ya


        public int vehiculoId { get; set; }//ya
        [ForeignKey("vehiculoId")]
        public Vehiculo Vehiculo { get; set; }

        public int empleadoid { get; set; }//ya
        [ForeignKey("empleadoid")]
        public Empleado Empleado { get; set; }

        public int rutaId { get; set; } //ya
        [ForeignKey("rutaId")]
        public Rutas Rutas { get; set; }

        public int productoId { get; set; }//ya
        [ForeignKey("productoId")]

        public int compraOferta { get; set; } //le vvoy a poner un 1 si se compró en oferta para ver a la hora de devolucion, devolver el dinero con el precio de oferta o del precio real
        //culpa del profe porque nada esta bien especificado

        public string NombreProducto {  get; set; }
        public int cantidades { get; set; }

        public Producto Producto { get; set; }

        public decimal costoTotal { get; set; }
    }
}

