using Antlr.Runtime.Misc;
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
                    InicializarListaStock(IDArt);
                    ManejarVisibilidadControles();
                }
                PrendaNegocio negocio = new PrendaNegocio();
                ArticuloList = negocio.Listar();
                Session["ArticuloList"] = ArticuloList;

                ImagenNegocio ima = new ImagenNegocio();
                ListImagenes = ima.Listar(IDArt);
                Session["ListImagenes"] = ListImagenes;

            }
        }
        private void InicializarListaStock(int idPrenda)
        {
            StockNegocio stockNegocio = new StockNegocio();
            List<Stock> listaStock = stockNegocio.ObtenerStockPrenda(idPrenda);
            Session["ListaStock"] = listaStock;
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
        private void ManejarVisibilidadControles()
        {
            List<Stock> listaStock = (List<Stock>)Session["ListaStock"];

            // Manejar la visibilidad de los controles según la condición deseada
            if (listaStock != null && listaStock.Count > 1)
            {
                // Mostrar los controles
                btnDecrement.Visible = true;
                quantity.Visible = true;
                btnIncrement.Visible = true;
                btnAgregarCarrito.Visible = true;
            }
            else
            {
                // Ocultar los controles
                btnDecrement.Visible = false;
                quantity.Visible = false;
                btnIncrement.Visible = false;
                btnAgregarCarrito.Visible = false;
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

            // Obtén la cantidad ingresada
            if (int.TryParse(quantity.Text, out int cantidadAgregada))
            {
                // Obtén la cantidad disponible en el stock
                List<Stock> listaStock = (List<Stock>)Session["ListaStock"];
                int cantidadDisponible = ObtenerCantidadDisponibleDesdeListaStock(listaStock);

                // Verifica si la cantidad agregada es menor o igual a la cantidad disponible en el stock
                if (cantidadAgregada > 0 && cantidadAgregada <= cantidadDisponible)
                {
                    // Agrega la cantidad al carrito
                    int productoId = (int)Session["IDArt"];
                    var carrito = ObtenerCarrito();

                    if (carrito.ContainsKey(productoId))
                    {
                        carrito[productoId] += cantidadAgregada;
                    }
                    else
                    {
                        carrito[productoId] = cantidadAgregada;
                    }

                    // Actualiza el contador del carrito
                    ((SiteMaster)this.Master).UpdateContadorCarrito();
                }
                else
                {
                    // Muestra un mensaje de error al usuario
                    // Puedes mostrarlo en un Label, MessageBox, etc.
                    lblMensajeError.Text = "La cantidad ingresada no es válida o supera el stock disponible.";
                }
            }
            else
            {
                // Muestra un mensaje de error al usuario indicando que la cantidad no es válida
                // Ejemplo: lblMensajeError.Text = "La cantidad ingresada no es válida.";
            }
        }

        private Dictionary<int, int> ObtenerCarrito()
        {
            // Inicializa el carrito como un diccionario si aún no se ha hecho.
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new Dictionary<int, int>();
            }

            return (Dictionary<int, int>)Session["carrito"];
        }

        private int ObtenerCantidadDisponibleDesdeListaStock(List<Stock> listaStock)
        {
            return listaStock?.Sum(stock => stock.Cantidad) ?? 0;
        }
    }
}
