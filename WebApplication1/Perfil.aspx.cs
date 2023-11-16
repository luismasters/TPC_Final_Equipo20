﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication1
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
           
        }
        protected string ObtenerNombreUsuario()
        {
            if (Session["usuario"] != null)
            {
                // Obtener el nombre de usuario de la sesión
                string nombreUsuario = ((Usuario)Session["usuario"]).User;

                // Devolver el nombre de usuario
                return nombreUsuario;
            }
            return "";
        }
        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cerrar la sesión y redirigir a la página de inicio de sesión
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}