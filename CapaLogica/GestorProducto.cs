using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using System.Data;

namespace CapaLogica
{
    public class GestorProducto
    {

        public static DataTable listarFrutos()
        {
            return Persistencia.cargarFrutos();
            
        }

        public static DataTable listarProductos(String contiene, String orden)
        {
            return Persistencia.cargarProductos(contiene, orden);
        }
    }
}
