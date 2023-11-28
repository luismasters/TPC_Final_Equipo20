using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requiere permiso de admin para ingresar a esta página");
                Response.Redirect("Error.aspx");
            } 
           
        }

        protected void Alta_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Alta.aspx");
        }

        protected void Modificar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Modificar.aspx");


        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Baja.aspx");


        }
    }
}



