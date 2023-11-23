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
    public partial class _Default : System.Web.UI.Page
    {
        public List<Prenda> PrendaList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        public bool UrlExists(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                return false;
            }
        }
        protected void RptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int productoId = Convert.ToInt32(e.CommandArgument);
                TextBox quantity = e.Item.FindControl("quantity") as TextBox;
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

                // Actualizar el contador del carrito en el nav
                ((SiteMaster)this.Master).UpdateContadorCarrito();
            }
        }
        protected void BtnDecrement_Click(object sender, EventArgs e)
        {
            Button btnDecrement = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnDecrement.NamingContainer;
            TextBox quantity = (TextBox)item.FindControl("quantity");
            if (quantity != null)
            {
                int currentValue = int.Parse(quantity.Text);
                if (currentValue > 0)
                {
                    currentValue--;
                    quantity.Text = currentValue.ToString();
                }
            }
        }

        protected void BtnIncrement_Click(object sender, EventArgs e)
        {
            Button btnIncrement = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnIncrement.NamingContainer;
            TextBox quantity = (TextBox)item.FindControl("quantity");

            if (quantity != null)
            {
                int currentValue = int.Parse(quantity.Text);
                currentValue++;
                quantity.Text = currentValue.ToString();
            }
        }
    }
}