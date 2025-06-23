using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conexionaSQL;
using tablas_atributos;

namespace negocios.ingresarDatos.producto
{
    public class ServicioProducto
    {

        public TablaDbContent conexionProductos;

        public ServicioProducto()
        {

            conexionProductos = new TablaDbContent();
        }

        public bool Insertar(Producto product)
        {
            try
            {
                conexionProductos.Add(product);
                conexionProductos.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool eliminar(Producto product)
        {
            try
            {

                conexionProductos.Remove(product);
                conexionProductos.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }


        }

        public bool modificar(Producto modificar)
        {
            try
            {

                conexionProductos.Update(modificar);
                conexionProductos.SaveChanges();

                return true;
            }
            catch (Exception ex) { throw ex; }

                    
        }

        public List<Producto> listar()
        {
            return conexionProductos.Productos.ToList();
        }

        public List<Producto> Buscar(string ide)
        {

            IQueryable<Producto> busqueda = conexionProductos.Productos;
            try
            {
                //if (int.TryParse(ide, out int parseado))
                //{
                //    busqueda = busqueda.Where(t => t.placa == parseado);

                //}
                busqueda = busqueda.Where(t => t.Idproducto.ToString().Equals(ide));
                if (!string.IsNullOrEmpty(ide))
                {

                    foreach (var item in busqueda)
                    {
                        Console.WriteLine($"ID producto {item.Idproducto}, Producto {item.producto}, Precio: {item.precio}, Oferta: {item.oferta}, Stock: {item.stock}, Devoluciones: {item.devoluciones}");
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
