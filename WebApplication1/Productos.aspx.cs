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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Prenda> PrendaList;
        public List<Categoria> ListCategoria { get; set; }
        public List<Linea> ListLinea { get; set; }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrendaNegocio prenda = new PrendaNegocio();
                PrendaList = prenda.Listar();

                rptArticulos.DataSource = PrendaList;
                rptArticulos.DataBind();



                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ListCategoria = categoriaNegocio.ObtenerCategorias();
                DropListCategoria.DataSource = ListCategoria;
                DropListCategoria.DataTextField = "Descripcion";
                DropListCategoria.DataBind();

                LineaNegocio lineaNegocio = new LineaNegocio();
                lineaNegocio.ObtenerLineas();
                ListLinea = lineaNegocio.ObtenerLineas();
                DropListLinea.DataSource = ListLinea;
                DropListLinea.DataTextField = "Descripcion";
                DropListLinea.DataBind();


                string valorPredeterminado = "Todas"; // Valor que se quiere establecer como predeterminado
                DropListCategoria.Items.FindByValue(valorPredeterminado).Selected = true;
                DropListLinea.Items.FindByValue(valorPredeterminado).Selected = true;


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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "UpdateCartCountScript", "updateCartCount();", true);
                //((SiteMaster)this.Master).UpdateContadorCarrito();
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
           

            string categoria = DropListCategoria.Text;
            string genero = DropListGenero.Text;
            string linea = DropListLinea.Text;
            decimal? precio = string.IsNullOrEmpty(txtFiltroPrecio.Text) ? null : (decimal?)Convert.ToDecimal(txtFiltroPrecio.Text);
            string nombre = txtFiltroNombre.Text;

            PrendaNegocio negocio = new PrendaNegocio();
            // Asumiendo que tienes un método en PrendaNegocio que permite filtrar por estos parámetros
            var listaFiltrada = negocio.ListarConFiltro(categoria, genero, linea, precio, nombre);

            rptArticulos.DataSource = listaFiltrada;
            rptArticulos.DataBind();
        }

    }
}