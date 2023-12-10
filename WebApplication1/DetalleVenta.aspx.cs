using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DetalleVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si el parámetro "ID" está presente en la URL
                if (Request.QueryString["ID"] != null)
                {
                    // Obtén el valor del parámetro "ID" de la URL
                    int idProducto = int.Parse( Request.QueryString["ID"]);

                    DetalleVentasNegocio detalleVentasNegocio = new DetalleVentasNegocio();


                     
                    GridDetalle.DataSource = detalleVentasNegocio.BuscarDetallePorVenta(idProducto);
                    GridDetalle.DataBind();


                }
                else
                {
                    // Maneja el caso en el que no se proporciona un ID válido en la URL
                    // Por ejemplo, podrías redirigir a una página de error o mostrar un mensaje al usuario
                    Response.Redirect("Error.aspx");
                }
            }
        }
    }



  }
