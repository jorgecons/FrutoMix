﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using CapaPersistencia;
namespace CapaLogica
{
    class GestorCliente
    {


        public static List<Cliente> Buscar(string busqueda)
        {


            List<Cliente> clientes = new List<Cliente>();
            return clientes = Persistencia.buscarCliente(busqueda);



        }

    }
}