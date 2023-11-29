using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Checkout : System.Web.UI.Page
    {
        public List<MedioPago> ListPago {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                if (Session["carritoCheckout"] != null)
                {
                    var carritoCheckout = (List<Prenda>)Session["carritoCheckout"];
                    gvCarritoCheckout.DataSource = carritoCheckout;
                    gvCarritoCheckout.DataBind();
                    DropDownPagos();
                }
            }

            if (!Seguridad.sesionActiva(Session["usuario"]))
            {
                Session.Add("error", "Debes ingresar con tu usuario para realizar la compra");
                Response.Redirect("Login.aspx");
            }
        }
        private void DropDownPagos()
        {
            PagoNegocio pagoNegocio = new PagoNegocio();
            List<MedioPago> mediosDePago = pagoNegocio.Listar();
            ListPago = pagoNegocio.Listar();
            ddlMediosPago.DataSource = ListPago;
            ddlMediosPago.DataTextField = "Descripcion";
            ddlMediosPago.DataBind();
            ddlMediosPago.Items.Insert(0, new ListItem("Seleccione un medio de pago", "0"));
        }

    }
}