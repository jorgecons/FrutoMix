using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using CapaPersistencia;
namespace CapaLogica
{
    public static class GestorCliente
    {


        public static List<Cliente> Buscar(string busqueda)
        {


            List<Cliente> clientes = new List<Cliente>();
            return null;//clientes = Persistencia.buscarCliente(busqueda);



        }

    }
}
