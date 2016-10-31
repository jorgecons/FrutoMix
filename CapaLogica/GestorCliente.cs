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
            clientes = Persistencia.buscarCliente(busqueda);

        return clientes;

        }


        public static List<String> cargarComboLocalidad()
        {
            List<String> lista = new List<string>();


            return Persistencia.cargarComboProv();
        }



        public static bool agregar(Cliente c)
        {


           return  Persistencia.AgregarCliente(c);
        }



        public static Cliente mostarCliente(int id)
        
        
        { Cliente x = new Cliente();
        
         return  x = Persistencia.BuscarCliente(id);
        }


        public static void Eliminar(int id)
        {


            Persistencia.EliminarCliente(id);
        }



                public static void Editar( Cliente c){


                    Persistencia.EditarCliente(c);
                
                }


     

    }
}
