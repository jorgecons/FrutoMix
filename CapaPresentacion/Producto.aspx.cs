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
        //ViewState
        ViewState["orden"]="nombre";
        //cargar DropDownList Frutos
        ddlFrutos.DataSource = GestorProducto.listarFrutos();
        ddlFrutos.DataTextField = "nombre";
        ddlFrutos.DataValueField = "id_fruto";
        ddlFrutos.DataBind();

        //cargar grilla con Productos
        MostrarListaProductos();

        //deshabilito el panel
        pnlSeleccion.Visible = false;
    }
    protected void butBuscar_Click(object sender, EventArgs e)
    {
        
    }
    protected void gridProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridProductos.PageIndex = e.NewPageIndex;
        MostrarListaProductos();
    }
    protected void gridProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void gridProductos_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["Orden"] = e.SortExpression;
        MostrarListaProductos();
    }

    protected void MostrarListaProductos()
    {
        gridProductos.DataSource = GestorProducto.listarProductos(txtProducto.Text, ViewState["orden"].ToString());
        gridProductos.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        pnlListado.Visible = false;
        pnlSeleccion.Visible = true;

    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        pnlListado.Visible = false;
        pnlSeleccion.Visible = true;
        accion.Text = "Modificar";
    }
}