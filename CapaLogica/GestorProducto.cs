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

        public static DataTable buscar(String busqueda)
        {
            return Persistencia.buscar(busqueda);
            
        }
    }
}
