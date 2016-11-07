using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public String nombre { get; set; }
        public String email { get; set; }
        public String calle { get; set; }
        public string localidad { get; set; }
        public int numero_calle { get; set; }
        public int codigo_postal { get; set; }
        public Int64 documento { get; set; }
        public bool primera_Vez { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public string nom_localidad { get; set; }



    }
}
