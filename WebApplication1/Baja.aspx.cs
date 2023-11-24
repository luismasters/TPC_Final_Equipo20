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
	public partial class Baja : System.Web.UI.Page
	{
        
            public List<Prenda> listPrenda { get; set; }


            protected void Page_Load(object sender, EventArgs e)
            {



            }

            protected void Buscar_Click(object sender, EventArgs e)
            {
                PrendaNegocio prenda = new PrendaNegocio();

                string Nombre = TxtDescripcionB.Text;
                string cate = null;
                string genero = null;
                string linea = null;
                decimal? precio = null;


                listPrenda = prenda.ListarConFiltro(cate, genero, linea, precio, Nombre);
                rptArticulos.DataSource = listPrenda;
                rptArticulos.DataBind();
               botonEli.Visible = true;



            }

            protected void Seleccionar_Click(object sender, EventArgs e)
            {

                Button button = (Button)sender;
                int idPrenda = int.Parse(button.CommandArgument);
               
                PrendaNegocio prendaNegocio = new PrendaNegocio();
                Prenda prenda = prendaNegocio.BuscarUnaPrenda(idPrenda);




              listPrenda = new List<Prenda>();
              listPrenda.Add(prendaNegocio.BuscarUnaPrenda(idPrenda));
              rptArticulos.DataSource = listPrenda;
              rptArticulos.DataBind();

            Session["idPrenda"] = idPrenda;

               }
 
            protected string FormatearPrecio(object precio)
            {
                if (precio != null)
                {
                    decimal precioDecimal;
                    if (decimal.TryParse(precio.ToString(), out precioDecimal))
                    {
                        return precioDecimal.ToString("C"); // Formato de moneda
                    }
                }
                return "Precio no disponible"; // O maneja la lógica para casos donde el precio no esté disponible
            }

        protected void Eliminar_Click(object sender, EventArgs e)
        {

        

            ImagenNegocio imagenNegocio = new ImagenNegocio();
            imagenNegocio.Eliminar((int)Session["idPrenda"]);

            PrendaNegocio prendaNegocio = new PrendaNegocio();
            prendaNegocio.Eliminar((int)Session["idPrenda"]);

            listPrenda = new List<Prenda>();
            listPrenda.Clear();
            rptArticulos.DataSource = listPrenda;
            rptArticulos.DataBind();



        }
    }



}