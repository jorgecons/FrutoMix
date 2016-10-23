using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;

public partial class Producto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        frutos.DataSource = GestorProducto.buscar("");
        frutos.DataTextField = "nombre";
        frutos.DataValueField = "id_fruto";
        frutos.DataBind();
    }
}