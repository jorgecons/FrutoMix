using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using CapaLogica;


public partial class Cliente : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grvCliente.Visible = true;
            lblerror.Visible = false;
            cargarGrilla(TextBox1.Text);
            pnlBuscar.Visible = true;
            pnlBotones.Visible = true;
            Panel_agregar.Visible = false;
            panelaccion.Visible = false;
        }
        Panel_agregar.Visible = false;
        lblerror.Visible = false;

    }
   


    public void recargar()
    {
        Response.Redirect("Cliente.aspx");
    
    
    }

    public void cargarGrilla(string texto)
    {

        if (TextBox1.Text == "")
        {
            List<Entidades.Cliente> cliente = GestorCliente.Buscar(texto);
            grvCliente.DataSource = cliente;

            grvCliente.DataBind();


        }
        else {



            List<Entidades.Cliente> cliente = GestorCliente.Buscar(texto);
            grvCliente.DataSource = cliente;

            grvCliente.DataBind();
        
        
        
        }



    }






    protected void btnAgregarArtGrv_Click1(object sender, EventArgs e)
    {
        Label_editar.Visible = false;
        Label_consultar.Visible = false;
        Label_eliminar.Visible = false;
        pnlBuscar.Visible = false;
        pnlBotones.Visible = false;
        panel_grilla.Visible = false;
        Panel_agregar.Visible = true;
        panelaccion.Visible = true;
        TextBox3.Visible = false;
        cargarDDLLocalidad();
        lblerror.Visible = false;


        btnAgregar.Visible = true;
        btnEliminar.Visible = false;
        btnEdita.Visible = false;
        btnVolver.Visible = true;



    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        cargarGrilla(TextBox1.Text);
    }


    protected void cargarDDLLocalidad()
    {

        ddl_loc.DataSource = GestorCliente.cargarComboLocalidad();
        ddl_loc.DataBind();

        ddl_loc.Items.Insert(0, new ListItem("Seleccione una Localidad", "0"));
    }

    protected void btnEditarArtGrv_Click(object sender, EventArgs e)
    {



        if (grvCliente.SelectedRow == null)
        {
            lblerror.Visible = true;
        }
        else
        {
            Label2.Visible = false;
            lblerror.Visible = false;
            Label_editar.Visible = true;
            Label_consultar.Visible = false;
            Label_eliminar.Visible = false;
            pnlBuscar.Visible = false;
            pnlBotones.Visible = false;
            panel_grilla.Visible = false;
            Panel_agregar.Visible = true;
            panelaccion.Visible = true;
            TextBox3.Visible = true;
            TextBox3.Enabled = false;
            mostrarConsulta();



            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnEdita.Visible = true;
            btnVolver.Visible = true;

        }







    }


   
    protected void brnAgregar_Click(object sender, EventArgs e)
    {
      

    

        Entidades.Cliente c = new Entidades.Cliente();
        c.nombre = txt_nombre.Text;
        c.documento = Int64.Parse(txt_doc.Text);

        try { 
        c.fecha_nacimiento = DateTime.Parse(txt_nac.Text);


        c.email = txt_email.Text;
        c.calle = txt_calle.Text;



        c.localidad = (ddl_loc.SelectedIndex).ToString();

        c.numero_calle = int.Parse(txt_numCalle.Text);

        c.codigo_postal = int.Parse(txt_codigo.Text);

        if (cbPrimeraCompra.Checked == true)
            c.primera_Vez = true;
        else { c.primera_Vez = false; }


        bool f = GestorCliente.agregar(c);
        if (f == true)
        {


            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cliente agregado')", true);

        }
        else
        {



            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cliente con documento invalido')", true);

        }
        recargar();
        
        
        
        
        
        
        
        }
        catch(Exception)
        {
         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('formato invalido de fecha')", true);
        }
      
    }


    private void mostrarConsulta()
    {
        Entidades.Cliente a = new Entidades.Cliente();

        int id = (int)grvCliente.SelectedValue;
        a = GestorCliente.mostarCliente(id);
        TextBox3.Text = a.id_cliente.ToString();
        txt_nombre.Text = a.nombre.ToString();
        txt_calle.Text = a.calle.ToString();
        txt_nac.Text = (a.fecha_nacimiento.ToString());
        txt_doc.Text = a.documento.ToString();
        txt_email.Text = a.email.ToString();
        cargarDDLLocalidad();
       int loc = int.Parse(a.localidad);
        ddl_loc.SelectedIndex = loc ;
        txt_numCalle.Text = a.numero_calle.ToString();
        txt_codigo.Text = a.codigo_postal.ToString();
       
        if (a.primera_Vez == true)
        {
            cbPrimeraCompra.Checked = true;
        }
        else
        {
            cbPrimeraCompra.Checked = false;
        }





    }
    protected void btnConsultarArtGrv_Click(object sender, EventArgs e)
    {



        if (grvCliente.SelectedRow == null)
        {
            lblerror.Visible = true;
        }
        else
        {
            Label2.Visible = false;
            lblerror.Visible = false;
            Label_editar.Visible = false;
            Label_consultar.Visible = true;
            Label_eliminar.Visible = false;
            pnlBuscar.Visible = false;
            pnlBotones.Visible = false;
            panel_grilla.Visible = false;
            Panel_agregar.Visible = true;
            panelaccion.Visible = true;
            TextBox3.Visible = true;
            TextBox3.Enabled = true;
            mostrarConsulta();

            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnEdita.Visible = false;
            btnVolver.Visible = true;

            Panel_agregar.Enabled = false;



        }





    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        recargar();

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {


        int id = (int)grvCliente.SelectedValue;
        GestorCliente.Eliminar(id);



        recargar();

    }
    protected void btnEdita_Click(object sender, EventArgs e)
    {

        Entidades.Cliente c = new Entidades.Cliente();
        c.id_cliente = int.Parse( TextBox3.Text);
        c.nombre = txt_nombre.Text;
        c.documento = Int64.Parse(txt_doc.Text);
        try
        {
            c.fecha_nacimiento = DateTime.Parse(txt_nac.Text);

            c.email = txt_email.Text;
            c.calle = txt_calle.Text;



            c.localidad = (ddl_loc.SelectedIndex).ToString();

            c.numero_calle = int.Parse(txt_numCalle.Text);

            c.codigo_postal = int.Parse(txt_codigo.Text);

            if (cbPrimeraCompra.Checked == true)
                c.primera_Vez = true;
            else { c.primera_Vez = false; }


            GestorCliente.Editar(c);

            recargar();
        
        
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('formato invalido de fecha')", true);
            
        }
        
      

    }
    protected void btnELiminarArtGrv_Click(object sender, EventArgs e)
    {
        if (grvCliente.SelectedRow == null)
        {
            lblerror.Visible = true;
        }
        else
        {
            Label2.Visible = false;
            lblerror.Visible = false;
            Label_editar.Visible = false;
            Label_consultar.Visible = false;
            Label_eliminar.Visible = true;
            pnlBuscar.Visible = false;
            pnlBotones.Visible = false;
            panel_grilla.Visible = false;
            Panel_agregar.Visible = true;
            panelaccion.Visible = true;
            TextBox3.Visible = true;
            TextBox3.Enabled = true;
            mostrarConsulta();

            btnAgregar.Visible = false;

            btnEliminar.Visible = true;

            btnEdita.Visible = false;

            Panel_agregar.Enabled = false;
        }






    }


protected void grvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    grvCliente.PageIndex = e.NewPageIndex;
        cargarGrilla(TextBox1.Text);
}
}