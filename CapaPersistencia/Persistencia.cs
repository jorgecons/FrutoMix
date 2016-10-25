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

        public static DataTable cargarFrutos()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();
            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select id_fruto, nombre from Fruto ";
               
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
            finally
            {
                cn.Close();
            }
           
            return dt;
        }

        public static DataTable cargarProductos(String contiene, String orden)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();
            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select id_producto, nombre, codigo_barras, precio_vta, es_compuesto," +
                 "descripcion, fecha_alta, fecha_baja from Producto where nombre like @Contiene order by "+orden;
                cmd.Parameters.Add(new SqlParameter("@Contiene", "%" + contiene + "%"));
                //cmd.Parameters.Add(new SqlParameter("@Orden", orden));
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return dt;
        }
    }
}
