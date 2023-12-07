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
    public partial class ReporteVentas : System.Web.UI.Page
    {

        public List<MedioPago> listaMedioPago { get; set; }
        public List<Envios> listaEnvios { get; set; }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarVentas();
                
            }
        }

        private void MostrarVentas()
        {
            // Aquí debes crear una instancia de VentasNegocio y llamar al método listar()
            VentasNegocio negocioVentas = new VentasNegocio();
            List<Ventas> listaVentas = negocioVentas.Listar(); // Suponiendo que el método listar devuelve una lista de ventas


            rptVentas.DataSource = listaVentas;
            rptVentas.DataBind();
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

            return "Descripción no encontrada"; // O un valor por defecto si no se encuentra la descripción
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

            return "No disponible"; // O un valor por defecto si no se encuentra la descripción
        }


    }
}