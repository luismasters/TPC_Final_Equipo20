using System;
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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateContadorCarrito();
        }

        public void UpdateContadorCarrito()
        {
            if (Session["carrito"] != null)
            {
                var carrito = (Dictionary<int, int>)Session["carrito"];
                int totalItems = carrito.Values.Sum();
                cartCount.InnerText = totalItems.ToString();
            }
            else
            {
                cartCount.InnerText = "0";
            }
        }

     

        protected void btnCerrarSesion_Click1(object sender, EventArgs e)
        {  FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
}