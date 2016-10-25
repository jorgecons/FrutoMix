using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
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




        public static List<Cliente> buscarCliente(string nombreQueContenga)
        {
            List<Cliente> c = new List<Cliente>();
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            try
            {
                cn.Open();


                cmd.CommandText = "Select Id_Cliente, nombre, documento FROM Cliente where nombre like @Contiene";
                cmd.Parameters.Add(new SqlParameter("@Contiene", "%" + nombreQueContenga + "%"));

                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    Cliente a = new Cliente();
                    a.id_cliente = (int)dr["Id_Cliente"];
                    a.nombre = dr["nombre"].ToString();

                    a.documento = Convert.ToInt16(dr["documento"]);

                    c.Add(a);
                }
            }
            catch (SqlException)
            {

                throw;
            }





            finally
            {
                cn.Close();

            }
            return c;
        }




    }
}
