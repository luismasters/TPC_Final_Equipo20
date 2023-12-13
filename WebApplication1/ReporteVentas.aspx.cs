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
        public List <Usuario> listaUsuario { get; set; }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                
            }
        }

        protected void MostrarVentas(List<Ventas> lista )
        {         


            rptVentas.DataSource = lista;
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

        protected string ObtenerUsuario(object User)
        {
            int Idusuario = Convert.ToInt32(User);

            UsuarioNegocio user = new UsuarioNegocio();
            listaUsuario = user.Listar();

            foreach (Dominio.Usuario item in listaUsuario)
            {
                if (item.Id == Idusuario)
                {
                    return item.User + "Email "+item.Email;
                }
            }

            return "No disponible"; // O un valor por defecto si no se encuentra la descripción
        }

        protected void VerDetalle_Click(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            Button btnVerDetalle = (Button)sender;

            // Obtener el ID de la venta del CommandArgument del botón
            string idVenta = btnVerDetalle.CommandArgument;

            // Redirigir a la página de detalles con el ID de la venta
            Response.Redirect($"DetalleVenta.aspx?ID={idVenta}");
         
        }
        protected void Despachar_Click(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            Button btnVerDetalle = (Button)sender;

            // Obtener el ID de la venta del CommandArgument del botón
            int idVenta =Convert.ToInt32(btnVerDetalle.CommandArgument);

            VentasNegocio ventasNeg= new VentasNegocio();
            ventasNeg.Despachar(idVenta);
            btnVerDetalle.Visible = false;
            Response.Redirect(Request.RawUrl);

        }


        protected void BtnVentasSinDespachar_Click(object sender, EventArgs e)
        {
            VentasNegocio negocioVentas = new VentasNegocio();
            List<Ventas> listaVentas = negocioVentas.Listar(); // Suponiendo que el método listar devuelve una lista de ventas
            listaVentas = listaVentas.Where(venta => !venta.Despachado).ToList();
            MostrarVentas(listaVentas);
                        
        }

        protected void BtnVentasDespachadas_Click(object sender, EventArgs e)
        {


            VentasNegocio negocioVentas = new VentasNegocio();
            List<Ventas> listaVentas = negocioVentas.Listar(); // Suponiendo que el método listar devuelve una lista de ventas
            listaVentas = listaVentas.Where(venta => venta.Despachado).ToList();
            MostrarVentas(listaVentas);
            
          

        }

        protected void buscarV_Click(object sender, EventArgs e)
        {
           
                try
                {
                    int Nventa = int.Parse(txtNVenta.Text);

                    VentasNegocio negocioVentas = new VentasNegocio();
                    List<Ventas> listaVentas = negocioVentas.ListarPorN_Venta(Nventa);
                    MostrarVentas(listaVentas);
                }
                catch (FormatException)
                {
                  
                }
            
        }
    }
}