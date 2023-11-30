using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DetallePrenda : System.Web.UI.Page
    {
        public List<Prenda> ArticuloList;
        public int IDArt { get; set; }
        public List<Imagen> ListImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string idParametro = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParametro))
                {
                    IDArt = Convert.ToInt32(idParametro);
                    Session["IDArt"] = IDArt;
                }
                PrendaNegocio negocio = new PrendaNegocio();
                ArticuloList = negocio.Listar();
                Session["ArticuloList"] = ArticuloList;

                ImagenNegocio ima = new ImagenNegocio();
                ListImagenes = ima.Listar(IDArt);
                Session["ListImagenes"] = ListImagenes;
            }
        }



        protected void btnDecrement_Click(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento.
            Button btnDecrement = (Button)sender;

            // Obtén el TextBox asociado al botón.
            TextBox quantity = (TextBox)btnDecrement.Parent.FindControl("quantity");

            if (quantity != null)
            {
                int cantidad = int.Parse(quantity.Text);
                if (cantidad > 0)
                {
                    cantidad--;
                    quantity.Text = cantidad.ToString();
                }
            }
        }

        protected void btnIncrement_Click(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento.
            Button btnIncrement = (Button)sender;

            // Obtén el TextBox asociado al botón.
            TextBox quantity = (TextBox)btnIncrement.Parent.FindControl("quantity");

            if (quantity != null)
            {
                int cantidad = int.Parse(quantity.Text);
                cantidad++;
                quantity.Text = cantidad.ToString();
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento.
            Button btnAgregarCarrito = (Button)sender;

            // Obtén el TextBox asociado al botón.
            TextBox quantity = (TextBox)btnAgregarCarrito.Parent.FindControl("quantity");

            int productoId = (int)Session["IDArt"]; // Obtén el ID del artículo de tu modelo, puede variar según la estructura real.

            int cantidadAgregada = int.Parse(quantity.Text);

            // Inicializa el carrito como un diccionario si aún no se ha hecho.
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new Dictionary<int, int>();
            }

            var carrito = (Dictionary<int, int>)Session["carrito"];

            if (carrito.ContainsKey(productoId))
            {
                carrito[productoId] += cantidadAgregada; // Incrementa la cantidad si ya existe en el carrito.
            }
            else
            {
                carrito[productoId] = cantidadAgregada; // Si es la primera vez que se agrega, la cantidad es 1.
            }

            ((SiteMaster)this.Master).UpdateContadorCarrito();
        }
    }
}
