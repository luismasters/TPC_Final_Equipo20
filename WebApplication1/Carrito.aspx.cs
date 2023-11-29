using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["carrito"] != null)
                {
                    BindGrid();
                }
            }
        }
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (gvCarrito.Rows.Count > 0)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Checkout.aspx");
                    var carrito = ObtenerProductosPorIds((Dictionary<int, int>)Session["carrito"]);
                    Session["carritoCheckout"] = carrito;
                    Response.Redirect("Checkout.aspx");
                }
            }
            
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        private void CargarProductosCarrito()
        {
            if (Session["carrito"] != null)
            {
                List<int> carrito = (List<int>)Session["carrito"];
                PrendaNegocio negocio = new PrendaNegocio();

                // Obtener todos los productos
                List<Prenda> todosLosProductos = negocio.Listar();

                // Filtrar aquellos que están en el carrito
                List<Prenda> productosCarrito = todosLosProductos.Where(art => carrito.Contains(art.Id)).ToList();

                // Asigna la lista filtrada al GridView
                gvCarrito.DataSource = productosCarrito;
                gvCarrito.DataBind();
            }
        }
        private DataTable ObtenerProductosPorIds(Dictionary<int, int> carrito)
        {
            PrendaNegocio negocio = new PrendaNegocio();
            List<Prenda> todosLosProductos = negocio.Listar();
            List<Prenda> productosCarrito = todosLosProductos.Where(art => carrito.Keys.Contains(art.Id)).ToList();

            // Convertir la lista de Articulo a DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Genero", typeof(string));
            dt.Columns.Add("Linea", typeof(string));
            dt.Columns.Add("Talle", typeof(string));

            foreach (var art in productosCarrito)
            {
                dt.Rows.Add(art.Id, art.Descripcion, art.Precio, carrito[art.Id], art.Categoria.Descripcion, art.Genero.Descripcion, art.Linea.Descripcion, art.Talle);
            }

            return dt;
        }
        protected void gvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (gvCarrito.DataKeys.Count > e.RowIndex)
                {
                    int productoId = Convert.ToInt32(gvCarrito.DataKeys[e.RowIndex].Value);
                    var carrito = (Dictionary<int, int>)Session["carrito"];
                    carrito.Remove(productoId);
                    BindGrid();
                    // Actualizar el contador del carrito en el nav
                    ((SiteMaster)this.Master).UpdateContadorCarrito();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var carrito = (Dictionary<int, int>)Session["carrito"];

            int productoId = Convert.ToInt32(e.CommandArgument);

            if (carrito.ContainsKey(productoId))
            {
                if (e.CommandName == "Decrement")
                {
                    // Si la cantidad es mayor que 1, decremente. Si es 1, simplemente elimine el producto del carrito.
                    if (carrito[productoId] > 1)
                    {
                        carrito[productoId] -= 1;
                    }
                    else
                    {
                        carrito.Remove(productoId);
                    }
                }
                else if (e.CommandName == "Increment")
                {
                    // Aumenta la cantidad del producto en el carrito.
                    carrito[productoId] += 1;
                }
            }

            BindGrid();

            // Actualizar el contador del carrito en el nav
            ((SiteMaster)this.Master).UpdateContadorCarrito();
        }

        private void BindGrid()
        {
            if (Session["carrito"] != null)
            {
                var carrito = (Dictionary<int, int>)Session["carrito"];
                DataTable dtProductosCarrito = ObtenerProductosPorIds(carrito);
                gvCarrito.DataSource = dtProductosCarrito;
                gvCarrito.DataBind();

                if (carrito.Count == 0)
                {
                    pnlEmptyCart.Visible = true;
                    gvCarrito.Visible = false;
                    // Actualiza el total del carrito

                }
                else
                {
                    pnlEmptyCart.Visible = false;
                    gvCarrito.Visible = true;
                }

                decimal total = dtProductosCarrito.AsEnumerable().Sum(row => row.Field<decimal>("Precio") * row.Field<int>("Cantidad"));
                lblTotal.Text = "Total: " + total.ToString("C");
            }
            else
            {
                pnlEmptyCart.Visible = true;
                gvCarrito.Visible = false;
            }

        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");


        }
    }
}