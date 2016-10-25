using Entidades;
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
<<<<<<< HEAD
=======

        public static List<Producto> Buscar(string contiene, string orden)
        {
            //string CadenaConexion = "Data Source=maquis;Initial Catalog=Pymes;User ID=avisuales2;password=avisuales2";
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = CadenaConexion;
            cn.ConnectionString = cadenaConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select id_producto, nombre, codigo_barras, precio_vta, es_compuesto," +
                 "descripcion, fecha_alta, fecha_baja from Producto where nombre like @Contiene order by " + orden;
            cmd.Parameters.Add(new SqlParameter("@Contiene", "%" + contiene + "%"));
            SqlDataReader dr = cmd.ExecuteReader();
            // con el resultado cargar un lista generica de clientes
            List<Producto> Clientes = new List<Producto>();
            while (dr.Read())
            {
                Producto p = new Producto();
                p.idProducto = (int)dr["id_producto"];
                p.nombre = dr["nombre"].ToString();
                p.codigo= dr

                if (dr["FechaNacimiento"] != DBNull.Value)  //nuleables   null != DBNull.Value
                    c.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                else
                    c.FechaNacimiento = null;  // estaria demas porque es valor por defecto del nuleable
                c.Provincia = dr["provincia"].ToString();
               

                //if (dr["cuit"] != DBNull.Value)
                //{
                //    c.Cuit = int.Parse(dr["cuit"]);
                //}


                Clientes.Add(c);
            }
            dr.Close();
            cn.Close();

            return Clientes;


        }

>>>>>>> refs/remotes/origin/master
    }


}
