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

<<<<<<< HEAD
        public static DataTable listarProductos(String contiene, String orden)
        {
            return Persistencia.cargarProductos(contiene, orden);
=======
        public static List<Producto> listarProductos(String contiene, String orden)
        {
            DataTable dt = Persistencia.cargarProductos(contiene, orden);
            
            while(dt.)
>>>>>>> refs/remotes/origin/master
        }
    }
}
