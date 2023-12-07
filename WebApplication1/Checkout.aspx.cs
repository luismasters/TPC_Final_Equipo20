using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["carritoCheckout"] != null)
                {
                    var carrito = (DataTable)Session["carritoCheckout"];

                    gvCarritoCheckout.DataSource = carrito;
                    gvCarritoCheckout.DataBind();
                    decimal total = carrito.AsEnumerable().Sum(row => row.Field<decimal>("Precio") * row.Field<int>("Cantidad"));
                    lblTotal.Text = "Total: " + total.ToString("C");


                }
                CargarMediosPago();
                CargarCiudadesEnvio();
            }
        }
        private decimal PrecioTotalConRecargos()
        {
            decimal precioTotal = ObtenerPrecioTotal();

            if (pnlCuotas.Visible)
            {
                int cuotas = Convert.ToInt32(ddlCuotas.SelectedValue);
                precioTotal = CalculoCuotas(cuotas);
            }

            if (chkEnvioDomicilio.Checked)
            {
                int idCiudad = Convert.ToInt32(ddlCiudades.SelectedValue);
                CiudadNegocio negocio = new CiudadNegocio();
                CiudadEnvio ciudad = negocio.ObtenerCiudadPorId(idCiudad);

                if (ciudad != null)
                {
                    precioTotal += ciudad.PrecioEnvio;
                }
            }

            return precioTotal;
        }
        private decimal ObtenerPrecioTotal()
        {

            var carrito = (DataTable)Session["carritoCheckout"];
            decimal total = carrito.AsEnumerable().Sum(row => row.Field<decimal>("Precio") * row.Field<int>("Cantidad"));
            return total;
        }
        private void CargarMediosPago()
        {
            PagoNegocio negocio = new PagoNegocio();
            List<MedioPago> mediosDePago = negocio.Listar();

            ddlMediosPago.DataSource = mediosDePago;
            ddlMediosPago.DataTextField = "Descripcion";
            ddlMediosPago.DataValueField = "IDPago";
            ddlMediosPago.DataBind();
        }
        private void CargarCiudadesEnvio()
        {
            CiudadNegocio negocio = new CiudadNegocio();
            List<CiudadEnvio> ciudadEnvio = negocio.Listar();

            ddlCiudades.DataSource = ciudadEnvio;
            ddlCiudades.DataTextField = "DescripcionConPrecio";
            ddlCiudades.DataValueField = "IDCiudad";
            ddlCiudades.DataBind();

        }
        protected void ddlMediosPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string medioPagoSeleccionado = ddlMediosPago.SelectedItem.Text;


            pnlTarjeta.Visible = false;
            pnlCuotas.Visible = false;

            if (medioPagoSeleccionado == "Debito")
            {
                pnlTarjeta.Visible = true;
            }
            else if (medioPagoSeleccionado == "Credito")
            {
                pnlTarjeta.Visible = true;
                pnlCuotas.Visible = true;
            }
        }
        private decimal CalculoCuotas(int cantCuotas)
        {
            decimal precioTotal = ObtenerPrecioTotal();
            decimal aumentoPorcentaje = 0;

            switch (cantCuotas)
            {
                case 3:
                    aumentoPorcentaje = 0.12m;
                    break;
                case 6:
                    aumentoPorcentaje = 0.18m;
                    break;
                case 12:
                    aumentoPorcentaje = 0.26m;
                    break;
            }
            decimal precioTotalConAumento = precioTotal * (1 + aumentoPorcentaje);
            return precioTotalConAumento;
        }
        protected void ddlCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cuotas = Convert.ToInt32(ddlCuotas.SelectedValue);
            decimal precioTotalConAumento = CalculoCuotas(cuotas);
            ListItem listItem = ddlCuotas.Items.FindByValue(cuotas.ToString());

            if (listItem != null)
            {
                listItem.Text = $"{cuotas} cuotas (total {precioTotalConAumento:C})";
            }
            lblTotalConRecargo.Text = "Total con recargos: " + PrecioTotalConRecargos().ToString("C");

        }
        protected void chkEnvioDomicilio_CheckedChanged(object sender, EventArgs e)
        {
            pnlDatosEnvio.Visible = chkEnvioDomicilio.Checked;
            lblTotalConRecargo.Text = "Total con recargos: " + PrecioTotalConRecargos().ToString("C");
        }
        protected void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            Session.Remove("carritoCheckout");
            Session.Remove("carrito");
            Response.Redirect("Default.aspx");
        }
        protected void ConfirmarVenta()
        {
            VentasNegocio negocio = new VentasNegocio();
            Ventas venta = new Ventas();

            try
            {

                venta.IDUsuario = ((Usuario)Session["usuario"]).Id;
                if (int.TryParse(ddlMediosPago.SelectedValue, out int idMedioPago)) venta.MedioPago = idMedioPago;
                venta.PrecioTotal = PrecioTotalConRecargos();
                if (ddlMediosPago.SelectedItem.Text == "Debito" || ddlMediosPago.SelectedItem.Text == "Credito")
                {
                    venta.Pagado = true;
                }
                else
                {
                    venta.Pagado = false;
                }
                negocio.RegistrarVenta(venta);

                int idVenta = negocio.ObtenerIdVenta();
                int idEnvio = 0;

                if (chkEnvioDomicilio.Checked)
                {
                    idEnvio = ConfirmarEnvio(idVenta);
                    negocio.RegistrarEnvio(idEnvio, idVenta);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected int ConfirmarEnvio(int idVenta)
        {
            EnviosNegocio negocio = new EnviosNegocio();
            Envios envio = new Envios();
            try
            {
                envio.IDVenta = idVenta;
                envio.IDUsuario = ((Usuario)Session["usuario"]).Id;
                envio.Direccion = txtDireccion.Text;
                envio.Telefono = txtTelefono.Text;
                envio.Observaciones = txtObservaciones.Text;
                envio.Entregado = false;
                if (int.TryParse(ddlCiudades.SelectedValue, out int idCiudad)) envio.IDCiudad = idCiudad;

                negocio.RegistrarEnvio(envio);
                int idEnvio = negocio.ObtenerIdEnvio();
                return idEnvio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            ConfirmarVenta();

        }
        protected void ddlCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDatosEnvio.Visible = chkEnvioDomicilio.Checked;
            lblTotalConRecargo.Text = "Total con recargos: " + PrecioTotalConRecargos().ToString("C");
        }
    }
}