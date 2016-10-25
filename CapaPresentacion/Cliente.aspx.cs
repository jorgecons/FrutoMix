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

            cargarGrilla();
            pnlBuscar.Visible = true;
            pnlBotones.Visible = true;
            Panel_agregar.Visible = false;
        }
        Panel_agregar.Visible = false;


    }

    public void cargarGrilla()
    {

        if (TextBox1.Text == "")
        {
            List<Entidades.Cliente> cliente = GestorCliente.Buscar("");
            grvCliente.DataSource = cliente;

            grvCliente.DataBind();





        }

    }






    protected void btnAgregarArtGrv_Click1(object sender, EventArgs e)
    {

        pnlBuscar.Visible = false;
        pnlBotones.Visible = false;
        Panel_agregar.Visible = true;
    }
}