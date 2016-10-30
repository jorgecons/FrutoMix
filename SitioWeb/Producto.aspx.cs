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
        if (!Page.IsPostBack)
        {
            //ViewState
            ViewState["orden"] = "nombre";
            ViewState["asc"] = "asc";
            ViewState["accion"] = null;
            //cargar DropDownList Frutos
            ddlFrutos1.DataSource = GestorProducto.listarFrutos();
            ddlFrutos1.DataTextField = "nombre";
            ddlFrutos1.DataValueField = "id_fruto";
            ddlFrutos1.DataBind();
            ddlFrutos1.Items.Add(new ListItem("Seleccione", "-1"));
            ddlFrutos1.SelectedValue = "-1";

            ddlFrutos2.DataSource = ddlFrutos1.DataSource;
            ddlFrutos2.DataTextField = "nombre";
            ddlFrutos2.DataValueField = "id_fruto";
            ddlFrutos2.DataBind();
            ddlFrutos2.Items.Add(new ListItem("Seleccione", "-1"));
            ddlFrutos2.SelectedValue = "-1";


            ddlFrutos3.DataSource = ddlFrutos1.DataSource;
            ddlFrutos3.DataTextField = "nombre";
            ddlFrutos3.DataValueField = "id_fruto";
            ddlFrutos3.DataBind();
            ddlFrutos3.Items.Add(new ListItem("Seleccione", "-1"));
            ddlFrutos3.SelectedValue = "-1";

            ddlFrutos4.DataSource = ddlFrutos1.DataSource;
            ddlFrutos4.DataTextField = "nombre";
            ddlFrutos4.DataValueField = "id_fruto";
            ddlFrutos4.DataBind();
            ddlFrutos4.Items.Add(new ListItem("Seleccione", "-1"));
            ddlFrutos4.SelectedValue = "-1";


            //
            mostrar(false);

            txtId.ReadOnly = true;

            //cargar grilla con Productos
            MostrarListaProductos();

            //deshabilito el panel
            pnlSeleccion.Visible = false;
        }
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
        lblPrimero.Text = "";
    }

    protected void gridProductos_Sorting(object sender, GridViewSortEventArgs e)
    {
        gridProductos.SelectedIndex = -1;
        if (ViewState["orden"].ToString() != e.SortExpression)
        {
            ViewState["orden"] = e.SortExpression;
            ViewState["asc"] = "asc";
        }
        else
        {
            if (ViewState["asc"].ToString() == "asc")
            {
                ViewState["asc"] = "desc";
            }
            else
            {
                ViewState["asc"] = "asc";
            }

        }
        MostrarListaProductos();

    }

    protected void MostrarListaProductos()
    {
        gridProductos.DataSource = GestorProducto.listarProductos(txtNombre.Text, ViewState["orden"].ToString(), ViewState["asc"].ToString());
        gridProductos.DataBind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        btnGuardar.Enabled = true;
        bloquear(false);
        btnGuardar.Text = "Guardar";
        lblPrimero.Text = "";
        lblResultado.Text = "";
        accion.Text = "Agregar";
        ViewState["accion"] = "agregar";
        pnlListado.Visible = false;
        pnlSeleccion.Visible = true;
        mostrar(true);

    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        if (gridProductos.SelectedValue != null)
        {
            btnGuardar.Enabled = true;
            lblPrimero.Text = "";
            lblResultado.Text = "";
            ViewState["accion"] = "consultar";
            pnlListado.Visible = false;
            pnlSeleccion.Visible = true;
            bloquear(true);
            mostrar(false);
            accion.Text = "Consultar";
            Entidades.Producto p = GestorProducto.buscarPorId((int)gridProductos.SelectedValue);
            txtProducto.Text = p.nombre;
            txtId.Text = p.idProducto.ToString();
            txtCodigo.Text = p.codigo.ToString();
            txtDescripcion.Text = p.descripcion;

            txtFechaAlta.Text = p.fechaAlta.ToShortDateString();
            if (p.fechaBaja != null)
            {
                txtFechaBaja.Text = p.fechaBaja.GetValueOrDefault().ToShortDateString();
            }
            txtPrecio.Text = p.precioVenta.ToString();

            ddlFrutos1.SelectedValue = p.frutos[0].idFruto.ToString();
            foreach (ListItem item in ddlFrutos1.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            txtPorcentaje1.Text = p.porcentaje[0].ToString();


            if (p.frutos.Count > 1)
            {
                ddlFrutos2.SelectedValue = p.frutos[1].idFruto.ToString();
                foreach (ListItem item in ddlFrutos2.Items)
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                lblFruto2.Visible = true;
                lblPorcentaje2.Visible = true;
                ddlFrutos2.Visible = true;
                txtPorcentaje2.Visible = true;

                txtPorcentaje2.Text = p.porcentaje[1].ToString();
            }
            if (p.frutos.Count > 2)
            {
                ddlFrutos3.SelectedValue = p.frutos[2].idFruto.ToString();
                foreach (ListItem item in ddlFrutos3.Items)
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                lblFruto13.Visible = true;
                lblPorcentaje3.Visible = true;
                txtPorcentaje3.Text = p.porcentaje[2].ToString();
                txtPorcentaje3.Visible = true;
            }
            if (p.frutos.Count > 3)
            {
                ddlFrutos4.SelectedValue = p.frutos[3].idFruto.ToString();
                foreach (ListItem item in ddlFrutos4.Items)
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                lblFruto14.Visible = true;
                lblPorcentaje4.Visible = true;
                txtPorcentaje4.Text = p.porcentaje[3].ToString();
                txtPorcentaje4.Visible = true;
            }
            btnGuardar.Text = "Eliminar";
            btnCancelar.Text = "Volver";
        }
        else
        {
            lblPrimero.Text = "Seleccione un producto!";
        }

    }

    private void bloquear(bool x)
    {
        txtProducto.ReadOnly = x;
        txtCodigo.ReadOnly = x;
        txtDescripcion.ReadOnly = x;
        txtFechaAlta.ReadOnly = x;
        txtFechaBaja.ReadOnly = x;
        txtPrecio.ReadOnly = x;

        txtPorcentaje1.ReadOnly = x;

        txtPorcentaje2.ReadOnly = x;

        txtPorcentaje3.ReadOnly = x;

        txtPorcentaje4.ReadOnly = x;
    }


    private void mostrar(bool x)
    {
        lblFruto2.Visible = x;
        lblFruto13.Visible = x;
        lblFruto14.Visible = x;
        lblPorcentaje2.Visible = x;
        lblPorcentaje3.Visible = x;
        lblPorcentaje4.Visible = x;
        txtPorcentaje2.Visible = x;
        txtPorcentaje3.Visible = x;
        txtPorcentaje4.Visible = x;
        ddlFrutos3.Visible = x;
        ddlFrutos2.Visible = x;
        ddlFrutos4.Visible = x;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        bloquear(false);
        if (ViewState["accion"].ToString() == "agregar")
        {
            Entidades.Producto p = new Entidades.Producto();
            p.nombre = txtProducto.Text;
            p.codigo = int.Parse(txtCodigo.Text);
            p.descripcion = txtDescripcion.Text;
            p.fechaAlta = DateTime.Parse(txtFechaAlta.Text);
            if (txtFechaBaja.Text != "")
            {
                p.fechaBaja = DateTime.Parse(txtFechaBaja.Text);
            }
            p.precioVenta = int.Parse(txtPrecio.Text);
            p.frutos = new List<Fruto>();
            p.porcentaje = new List<int>();
            int valor;
            if (ddlFrutos1.SelectedValue != "-1")
            {
                Fruto fruto = new Fruto();
                fruto.idFruto = int.Parse(ddlFrutos1.SelectedValue);
                fruto.nombre = ddlFrutos1.SelectedItem.Text;
                p.agregarFruto(fruto);
                if (int.TryParse(txtPorcentaje1.Text, out valor))
                {
                    if(valor>0 && valor<=100)
                    {
                        p.porcentaje.Add(valor);
                    }else
                    {
                        lblErrorPorc1.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                        return;
                    }
                    
                }
                else
                {
                    lblErrorPorc1.Text="Debe ingresar un porcentaje numérico entre 0 y 100";
                    return;
                }
                
            }
            if (ddlFrutos2.SelectedValue != "-1")
            {
                Fruto fruto = new Fruto();
                fruto.idFruto = int.Parse(ddlFrutos2.SelectedValue);
                fruto.nombre = ddlFrutos2.SelectedItem.Text;
                p.agregarFruto(fruto);
                if (int.TryParse(txtPorcentaje2.Text, out valor))
                {
                    if (valor > 0 && valor <= 100)
                    {
                        p.porcentaje.Add(valor);
                    }
                    else
                    {
                        lblErrorPorc2.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                        return;
                    }

                }
                else
                {
                    lblErrorPorc2.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                    return;
                }
                
            }
            if (ddlFrutos3.SelectedValue != "-1")
            {
                Fruto fruto = new Fruto();
                fruto.idFruto = int.Parse(ddlFrutos3.SelectedValue);
                fruto.nombre = ddlFrutos3.SelectedItem.Text;
                p.agregarFruto(fruto);
                if (int.TryParse(txtPorcentaje3.Text, out valor))
                {
                    if (valor > 0 && valor <= 100)
                    {
                        p.porcentaje.Add(valor);
                    }
                    else
                    {
                        lblErrorPorc3.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                        return;
                    }

                }
                else
                {
                    lblErrorPorc3.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                    return;
                }
                

            }
            if (ddlFrutos4.SelectedValue != "-1")
            {
                Fruto fruto = new Fruto();
                fruto.idFruto = int.Parse(ddlFrutos4.SelectedValue);
                fruto.nombre = ddlFrutos4.SelectedItem.Text;
                p.agregarFruto(fruto);
                if (int.TryParse(txtPorcentaje4.Text, out valor))
                {
                    if (valor > 0 && valor <= 100)
                    {
                        p.porcentaje.Add(valor);
                    }
                    else
                    {
                        lblErrorPorc4.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                        return;
                    }

                }
                else
                {
                    lblErrorPorc4.Text = "Debe ingresar un porcentaje numérico entre 0 y 100";
                    return;
                }

            }
            if (p.frutos.Count > 1)
            {
                p.esCompuesto = true;
            }
            else
            {
                p.esCompuesto = false;
            }

            if (!p.esCien())
            {
                lblResultado.Text = "La suma de porcentajes debe ser 100";
                return;
            }


            txtId.Text = GestorProducto.guardar(p).ToString();
            bloquear(true);

            lblResultado.Text = "El producto " + txtNombre.Text + " se ha guardado exitosamente con id " + txtId.Text;
            String seleccion = ddlFrutos1.SelectedValue;
            foreach (ListItem item in ddlFrutos1.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            ddlFrutos1.SelectedValue = seleccion;

            seleccion = ddlFrutos2.SelectedValue;
            foreach (ListItem item in ddlFrutos2.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }

            ddlFrutos2.SelectedValue = seleccion;
            if (seleccion == "-1")
            {
                lblFruto2.Visible = false;
                ddlFrutos2.Visible = false;
                lblPorcentaje2.Visible = false;
                txtPorcentaje2.Visible = false;
            }
            seleccion = ddlFrutos3.SelectedValue;
            foreach (ListItem item in ddlFrutos3.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            if (seleccion == "-1")
            {
                lblFruto13.Visible = false;
                ddlFrutos3.Visible = false;
                lblPorcentaje3.Visible = false;
                txtPorcentaje3.Visible = false;
            }
            seleccion = ddlFrutos4.SelectedValue;
            foreach (ListItem item in ddlFrutos4.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            if (seleccion == "-1")
            {
                lblFruto14.Visible = false;
                ddlFrutos4.Visible = false;
                lblPorcentaje4.Visible = false;
                txtPorcentaje4.Visible = false;
            }
            btnGuardar.Text = "Nuevo";
            ViewState["accion"] = "nuevo";
            btnCancelar.Text = "Volver";
            MostrarListaProductos();
            return;
        }

        if (ViewState["accion"].ToString() == "nuevo")
        {
            limpiar();
            bloquear(false);
            mostrar(true);
            ViewState["accion"] = "agregar";
            btnGuardar.Text = "Guardar";
            btnCancelar.Text = "Cancelar";
            return;
        }

        if (ViewState["accion"].ToString() == "consultar")
        {
            btnGuardar.Text = "Eliminar";
           
            eliminar(int.Parse(txtId.Text));
            limpiar();
            lblResultado.Text = "Se ha eliminado el Producto exitosamente!";
            btnGuardar.Enabled = false;
            
            btnCancelar.Text = "Volver";
            return;
        }

        if (ViewState["accion"].ToString() == "modificar")
        {
            Entidades.Producto prod = new Entidades.Producto();
            prod.idProducto = int.Parse(txtId.Text);
            if (txtFechaBaja.Text != "")
            {
                prod.fechaBaja = DateTime.Parse(txtFechaBaja.Text);
            }
            prod.descripcion = txtDescripcion.Text;
            prod.precioVenta = int.Parse(txtPrecio.Text);
            GestorProducto.modificar(prod);
            bloquear(true);
            btnGuardar.Enabled = false;
            btnCancelar.Text = "Volver";
            string valor = ddlFrutos1.SelectedValue;
            foreach (ListItem item in ddlFrutos1.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
            ddlFrutos1.SelectedValue = valor;
       
            valor=ddlFrutos2.SelectedValue;
            foreach (ListItem item in ddlFrutos2.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
                
            ddlFrutos2.SelectedValue = valor;
            valor = ddlFrutos3.SelectedValue;
            foreach (ListItem item in ddlFrutos3.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }
                
            ddlFrutos3.SelectedValue = valor;
           
            valor=ddlFrutos4.SelectedValue;
            foreach (ListItem item in ddlFrutos4.Items)
            {
                item.Attributes.Add("disabled", "disabled");
            }    
            ddlFrutos4.SelectedValue = valor;
                
            
            lblResultado.Text = "El Producto ha sido modificado exitosamente!";
            return;



        }

    }

    private void limpiar()
    {
        txtId.Text = "";
        txtProducto.Text = "";
        txtCodigo.Text = "";
        txtDescripcion.Text = "";
        txtFechaAlta.Text = "";
        txtFechaBaja.Text = "";
        txtPrecio.Text = "";
        ddlFrutos1.SelectedValue = "-1";
        txtPorcentaje1.Text = "";
        ddlFrutos2.SelectedValue = "-1";
        txtPorcentaje2.Text = "";
        ddlFrutos3.SelectedValue = "-1";
        txtPorcentaje3.Text = "";
        ddlFrutos4.SelectedValue = "-1";
        txtPorcentaje4.Text = "";
        lblPrimero.Text = "";
        lblResultado.Text = "";
        gridProductos.SelectedIndex = -1;

    }

    private void eliminar(int id)
    {
        GestorProducto.eliminar(id);
        MostrarListaProductos();

    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (gridProductos.SelectedValue != null)
        {
            btnGuardar.Enabled = true;
            lblPrimero.Text = "";
            lblResultado.Text = "";
            ViewState["accion"] = "modificar";
            pnlListado.Visible = false;
            pnlSeleccion.Visible = true;
            bloquear(true);
            txtDescripcion.ReadOnly = false;
            txtFechaBaja.ReadOnly = false;
            txtPrecio.ReadOnly = false;
            accion.Text = "Modificar";
            Entidades.Producto p = GestorProducto.buscarPorId((int)gridProductos.SelectedValue);
            txtProducto.Text = p.nombre;
            txtId.Text = p.idProducto.ToString();
            txtCodigo.Text = p.codigo.ToString();
            txtDescripcion.Text = p.descripcion;

            txtFechaAlta.Text = p.fechaAlta.ToShortDateString();
            if (p.fechaBaja != null)
            {
                txtFechaBaja.Text = p.fechaBaja.GetValueOrDefault().ToShortDateString();
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

            btnGuardar.Text = "Modificar";
            btnCancelar.Text = "Cancelar";


        }
        else
        {
            lblPrimero.Text = "Seleccione un producto!";
        }

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ViewState["accion"] = "eliminar";
        if (gridProductos.SelectedValue != null)
        {
            int id = (int)(gridProductos.SelectedValue);
            eliminar(id);
            lblPrimero.Text = "Se ha eliminado el Producto exitosamente!";
            gridProductos.SelectedIndex = -1;
        }
        else
        {
            lblPrimero.Text = "Seleccione un producto!";
        }

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

        limpiar();
        pnlSeleccion.Visible = false;
        pnlListado.Visible = true;
        MostrarListaProductos();
    }

}