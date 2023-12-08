using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MisCompras : System.Web.UI.Page
    {
        public List<Ventas> ventas = new List<Ventas>();
        public List<MedioPago> listaMedioPago { get; set; }
        public List<Envios> listaEnvios { get; set; }
        private int contadorCompras = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                MostrarCompras();
            }
        }

        protected void rptCompras_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Verificar si el elemento actual es un elemento de datos
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Incrementar el contador y mostrarlo
                contadorCompras++;
                Label lblContador = (Label)e.Item.FindControl("lblContador");
                lblContador.Text = "Compra #" + contadorCompras.ToString();
            }
        }
        private void MostrarCompras()
        {
            int idUsuario = ((Usuario)Session["usuario"]).Id;
            VentasNegocio negocioVentas = new VentasNegocio();
            List<Ventas> listaCompras = negocioVentas.ListarPorUsuario(idUsuario);

            rptCompras.DataSource = listaCompras;
            rptCompras.DataBind();

        }
        protected string ObtenerDescripcionMedioPago(object medioPagoID)
        {
            int idMedioPago = Convert.ToInt32(medioPagoID);

            PagoNegocio pagoNegocio = new PagoNegocio();
            listaMedioPago = pagoNegocio.Listar();

            foreach (MedioPago item in listaMedioPago)
            {
                if (item.IDPago == idMedioPago)
                {
                    return item.Descripcion;
                }
            }

            return "Descripción no encontrada";
        }
        protected string ObtenerDireccion(object Envio)
        {
            int IdEnvio = Convert.ToInt32(Envio);

            EnviosNegocio enviosNegocio = new EnviosNegocio();
            listaEnvios = enviosNegocio.Listar();

            foreach (Dominio.Envios item in listaEnvios)
            {
                if (item.IDEnvio == IdEnvio)
                {
                    return item.Direccion;
                }
            }

            return "Retira por local de cercanía";
        }
        protected string ObtenerEnviado(object Envio)
        {
            int IdEnvio = Convert.ToInt32(Envio);

            EnviosNegocio enviosNegocio = new EnviosNegocio();
            listaEnvios = enviosNegocio.Listar();

            foreach (Dominio.Envios item in listaEnvios)
            {
                if (item.IDEnvio == IdEnvio)
                {
                    if (item.Entregado) return "Entregado";
                    return "A entregar";
                }
            }
            return "A entregar";
        }
    }
}