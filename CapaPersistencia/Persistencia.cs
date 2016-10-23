using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class Persistencia
    {
        public static string cadenaConexion()
        {
            return  ConfigurationManager.ConnectionStrings["FrutoMixDB"].ConnectionString;
            
            //return @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\GitHub\PAV2\FrutoMix\CapaPersistencia\FrutoMixDB.mdf;Integrated Security=True;Connect Timeout=30";
            
        }

        public static DataTable buscar(string nombreQueContenga)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();
            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select id_fruto, nombre from Fruto where nombre like @Contiene order by nombre";
                cmd.Parameters.Add(new SqlParameter("@Contiene", "%" + nombreQueContenga + "%"));
               
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            {
                
                throw;
            }
            finally
            {
                cn.Close();
            }
           
            return dt;
        }
    }
}
