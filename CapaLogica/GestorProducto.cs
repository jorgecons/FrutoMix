using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using System.Data;
using Entidades;

namespace CapaLogica
{
    public class GestorProducto
    {

        public static DataTable listarFrutos()
        {
            return Persistencia.cargarFrutos();
            
        }

        public static List<Producto> listarProductos(String contiene, String orden, String asc)
        {
            return Persistencia.cargarProdLista(contiene, orden, asc);

 
        }

        public static Producto buscarPorId(int id)
        {


            return Persistencia.cargarProdId(id);
        }

        public static int guardar(Producto prod)
        {
            return Persistencia.guardarProd(prod);
        }

        public static void eliminar(int id)
        {
            Persistencia.eliminarProd(id);
        }
        public static void modificar(Producto prod)
        {
            Persistencia.modificarProd(prod);
        }


    }
}
