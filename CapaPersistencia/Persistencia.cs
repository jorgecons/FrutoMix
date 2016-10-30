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
            return ConfigurationManager.ConnectionStrings["FrutoMixDB"].ConnectionString;

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

        public static DataTable cargarProductos(String contiene, String orden, String asc)
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
                 "descripcion, fecha_alta, fecha_baja from Producto where nombre like @Contiene order by " + orden + " " + asc;
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

        public static Producto cargarProdId(int id)
        {
            Producto p = new Producto();
            p.porcentaje = new List<int>();
            p.frutos = new List<Fruto>();
            SqlDataReader dr = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select p.id_producto, p.nombre, p.codigo_barras, p.precio_vta, p.es_compuesto, " +
                    "p.descripcion, p.fecha_alta, p.fecha_baja, fxp.porcentaje, f.id_fruto, f.nombre as fruto " +
                    " FROM Producto p INNER JOIN FrutoXProducto fxp ON p.id_producto= fxp.id_producto " +
                    "INNER JOIN Fruto f ON fxp.id_fruto=f.id_fruto " +
                    " where p.id_producto=@id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p.idProducto = (int)dr["id_producto"];
                    p.nombre = dr["nombre"].ToString();
                    p.codigo = (int)dr["codigo_barras"];
                    p.precioVenta = float.Parse(dr["precio_vta"].ToString());
                    p.fechaAlta = DateTime.Parse(dr["fecha_alta"].ToString());
                    p.descripcion = dr["descripcion"].ToString();
                    if (dr["fecha_baja"] == DBNull.Value)
                    {
                        p.fechaBaja = null;
                    }
                    else
                    {
                        p.fechaBaja = DateTime.Parse(dr["fecha_baja"].ToString());
                    }



                    p.porcentaje.Add((int)dr["porcentaje"]);
                    Fruto f = new Fruto();
                    f.idFruto = (int)dr["id_fruto"];
                    f.nombre = dr["fruto"].ToString();
                    p.frutos.Add(f);

                }


            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                dr.Close();
                cn.Close();

            }
            return p;
        }

        public static int guardar(Producto prod)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Producto " +
                    "values (@nombre, @codigo, @precio, @esCompuesto, @descripcion, @fechaAlta, @fechaBaja); Select @@IDENTITY";
                cmd.Parameters.Add(new SqlParameter("@nombre", prod.nombre));
                cmd.Parameters.Add(new SqlParameter("@codigo", prod.codigo));
                cmd.Parameters.Add(new SqlParameter("@precio", prod.precioVenta));
                cmd.Parameters.Add(new SqlParameter("@esCompuesto", prod.esCompuesto));
                if (prod.descripcion != null || prod.descripcion != "")
                {
                    cmd.Parameters.Add(new SqlParameter("@descripcion", prod.descripcion));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@descripcion", DBNull.Value));
                }
                cmd.Parameters.Add(new SqlParameter("@fechaAlta", prod.fechaAlta));
                if (prod.fechaBaja != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@fechaBaja", prod.fechaBaja));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@fechaBaja", DBNull.Value));
                }


                prod.idProducto = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "insert into FrutoXProducto " +
                    "values (@idProd, @idFruto, @porcentaje)";
                foreach (var fruto in prod.frutos)
                {
                    int a = 0;


                    cmd.Parameters.Add(new SqlParameter("@idProd", prod.idProducto));
                    cmd.Parameters.Add(new SqlParameter("@idFruto", fruto.idFruto));
                    cmd.Parameters.Add(new SqlParameter("@porcentaje", prod.porcentaje[a]));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    a++;
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
            return prod.idProducto;
        }

        public static List<Producto> Buscar(string contiene, string orden)
        {
            ////string CadenaConexion = "Data Source=maquis;Initial Catalog=Pymes;User ID=avisuales2;password=avisuales2";
            //SqlConnection cn = new SqlConnection();
            ////cn.ConnectionString = CadenaConexion;
            //cn.ConnectionString = cadenaConexion();
            //cn.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandText = "Select id_producto, nombre, codigo_barras, precio_vta, es_compuesto," +
            //     "descripcion, fecha_alta, fecha_baja from Producto where nombre like @Contiene order by " + orden;
            //cmd.Parameters.Add(new SqlParameter("@Contiene", "%" + contiene + "%"));
            //SqlDataReader dr = cmd.ExecuteReader();
            //// con el resultado cargar un lista generica de clientes
            //List<Producto> Clientes = new List<Producto>();
            //while (dr.Read())
            //{
            //    Producto p = new Producto();
            //    p.idProducto = (int)dr["id_producto"];
            //    p.nombre = dr["nombre"].ToString();
            //   // p.codigo= dr;

            //    //if (dr["FechaNacimiento"] != DBNull.Value)  //nuleables   null != DBNull.Value
            //    //    c.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
            //    //else
            //    //    c.FechaNacimiento = null;  // estaria demas porque es valor por defecto del nuleable
            //    //c.Provincia = dr["provincia"].ToString();


            //    //if (dr["cuit"] != DBNull.Value)
            //    //{
            //    //    c.Cuit = int.Parse(dr["cuit"]);
            //    //}


            //    Clientes.Add(c);
            //}
            //dr.Close();
            //cn.Close();

            //return Clientes;

            return null;
        }

        public static void eliminar(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Delete from FrutoXProducto where id_producto=@id; " +
                    "Delete from Producto where id_producto=@id ";
                cmd.Parameters.Add(new SqlParameter("@id", id));


                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                cn.Close();
            }


        }

        public static void modificar(Producto prod)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion();

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update Producto " +
                    "set precio_vta=@precio, descripcion=@desc, fecha_baja=@fechaBaja " +
                    "where id_producto=@id ";

                cmd.Parameters.Add(new SqlParameter("@id", prod.idProducto));
                cmd.Parameters.Add(new SqlParameter("@precio", prod.precioVenta));
                if (prod.descripcion == "" || prod.descripcion == null)
                {
                    cmd.Parameters.Add(new SqlParameter("@desc", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@desc", prod.descripcion));
                }
                if (prod.fechaBaja == null)
                {
                    cmd.Parameters.Add(new SqlParameter("@fechaBaja", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@fechaBaja", prod.fechaBaja));
                }


                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
