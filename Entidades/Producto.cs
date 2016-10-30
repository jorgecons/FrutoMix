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
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public List<Fruto> frutos {get; set;}
        public List<int> porcentaje { get; set; }
        
        public void agregarFruto(Fruto fruto)
        {
            if (frutos == null)
            {
                frutos = new List<Fruto>();
                frutos.Add(fruto);
            }
            else
            {
                if (frutos.Count != 0)
                {
                    foreach (var f in frutos)
                    {
                        if (f.idFruto == fruto.idFruto)
                        {
                            return;
                        }

                    }
                    frutos.Add(fruto);

                }
                else
                {
                    frutos.Add(fruto);
                }
            }
            
        }

        public bool esCien()
        {
            int suma=0;
            foreach (var porc in porcentaje)
            {
                suma += porc;
            }
            return suma == 100;
        }
    }
}
