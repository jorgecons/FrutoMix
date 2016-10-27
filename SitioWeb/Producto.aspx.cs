using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using Entidades;

public partial class Producto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ViewState
        ViewState["orden"] = "nombre";
        //cargar DropDownList Frutos
        ddlFrutos1.DataSource = GestorProducto.listarFrutos();
        ddlFrutos1.DataTextField = "nombre";
        ddlFrutos1.DataValueField = "id_fruto";
        ddlFrutos1.DataBind();

        ddlFrutos2.DataSource = ddlFrutos1.DataSource;
        ddlFrutos2.DataTextField = "nombre";
        ddlFrutos2.DataValueField = "id_fruto";
        ddlFrutos2.DataBind();
        ddlFrutos2.Visible = false;

        ddlFrutos3.DataSource = ddlFrutos1.DataSource;
        ddlFrutos3.DataTextField = "nombre";
        ddlFrutos3.DataValueField = "id_fruto";
        ddlFrutos3.DataBind();
        ddlFrutos3.Visible = false;

        ddlFrutos4.DataSource = ddlFrutos1.DataSource;
        ddlFrutos4.DataTextField = "nombre";
        ddlFrutos4.DataValueField = "id_fruto";
        ddlFrutos4.DataBind();
        ddlFrutos4.Visible = false;

        //
        lblFruto2.Visible = false;
        lblFruto13.Visible = false;
        lblFruto14.Visible = false;
        lblPorcentaje2.Visible = false;
        lblPorcentaje3.Visible = false;
        lblPorcentaje4.Visible = false;
        txtPorcentaje2.Visible = false;
        txtPorcentaje3.Visible = false;
        txtPorcentaje4.Visible = false;


        //cargar grilla con Productos
        MostrarListaProductos();

        //deshabilito el panel
        pnlSeleccion.Visible = false;
    }
    protected void butBuscar_Click(object sender, EventArgs e)
    {
        MostrarListaProductos();
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
        gridProductos.DataSource = GestorProducto.listarProductos(txtNombre.Text, ViewState["orden"].ToString());
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
        bloquear(true);
        accion.Text = "Consultar";
        Entidades.Producto p = GestorProducto.buscarPorId((int)gridProductos.SelectedValue);
        txtProducto.Text = p.nombre;
        txtId.Text = p.idProducto.ToString();
        txtCodigo.Text = p.codigo.ToString();
        txtDescripcion.Text = p.descripcion.ToString();
        txtFechaAlta.Text = p.fechaAlta.ToShortDateString();
        if (p.fechaBaja != null)
        {
            txtFechaBaja.Text = p.fechaBaja.ToString();
        }
        txtPrecio.Text = p.precioVenta.ToString();

        ddlFrutos1.SelectedValue = p.frutos[0].idFruto.ToString();

        txtPorcentaje1.Text = p.porcentaje[0].ToString();

        foreach (ListItem item in ddlFrutos1.Items)
        {
            item.Attributes.Add("disabled", "disabled");
        }

        if (p.frutos.Count > 1)
        {
            ddlFrutos2.SelectedValue = p.frutos[1].idFruto.ToString();

            ddlFrutos2.Visible = true;
            foreach (ListItem item in ddlFrutos2.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            lblFruto2.Visible = true;
            lblPorcentaje2.Visible = true;
            txtPorcentaje2.Visible = true;
            txtPorcentaje2.Text = p.porcentaje[1].ToString();
        }
        if (p.frutos.Count > 2)
        {
            ddlFrutos3.SelectedValue = p.frutos[2].idFruto.ToString();
            ddlFrutos3.Visible = true;
            foreach (ListItem item in ddlFrutos3.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            lblFruto13.Visible = true;
            lblPorcentaje3.Visible = true;
            txtPorcentaje3.Visible = true;
            txtPorcentaje3.Text = p.porcentaje[2].ToString();
        }
        if (p.frutos.Count > 3)
        {
            ddlFrutos4.SelectedValue = p.frutos[3].idFruto.ToString();
            ddlFrutos4.Visible = true;
            foreach (ListItem item in ddlFrutos4.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            lblFruto14.Visible = true;
            lblPorcentaje4.Visible = true;
            txtPorcentaje4.Visible = true;
            txtPorcentaje4.Text = p.porcentaje[3].ToString();
        }

    }

    private void bloquear(bool x)
    {
        txtProducto.ReadOnly = x;
        txtId.ReadOnly = x;
        txtCodigo.ReadOnly = x;
        txtDescripcion.ReadOnly = x;
        txtFechaAlta.ReadOnly = x;
        txtFechaBaja.ReadOnly = x;
        txtPrecio.ReadOnly = x;
        ddlFrutos1.Enabled = x;
        txtPorcentaje1.ReadOnly = x;
        ddlFrutos2.Enabled = x;
        txtPorcentaje2.ReadOnly = x;
        ddlFrutos3.Enabled = x;
        txtPorcentaje3.ReadOnly = x;
        ddlFrutos4.Enabled = x;
        txtPorcentaje4.ReadOnly = x;
    }
}