using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public int codigo{get; set;}
        public String nombre {get; set;}
        public String descripcion {get; set;}
        public float precioVenta {get; set;}
        public bool esCompuesto{get; set;}
        public List<Fruto> frutos {get; set;}

        public void agregarFruto(Fruto fruto)
        {
            //verifica que la lista no este vacía y que el fruto no este en la lista
            if (frutos.Count != 0 && frutos.Any(f => f.idFruto != fruto.idFruto))
            {
                frutos.Add(fruto);
            }
        }

    }
}
