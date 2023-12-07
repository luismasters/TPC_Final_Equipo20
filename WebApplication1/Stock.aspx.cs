
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApplication1
{
    public partial class Stock : System.Web.UI.Page
    {
        private StockNegocio stockNegocio = new StockNegocio();

        public int IdPrenda { get; private set; }
        public int Cantidad { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stockNegocio = new StockNegocio();
                CargarPrendas();
            }

        }

        private void CargarPrendas()
        {
            PrendaNegocio prendaNegocio = new PrendaNegocio();
            List<Prenda> listaPrendas = prendaNegocio.Listar();
            ddlPrendas.DataSource = listaPrendas;
            ddlPrendas.DataTextField = "Descripcion";
            ddlPrendas.DataValueField = "Id";
            ddlPrendas.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrenda = int.Parse(ddlPrendas.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);
                string talle = ddlTalles.SelectedValue;


                Dominio.Stock stock = new Dominio.Stock
                {
                    IdPrenda = idPrenda,
                    Cantidad = cantidad,
                    Talle = talle
                };


                stockNegocio.AgregarStock(stock);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Stock agregado exitosamente');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrenda = int.Parse(ddlPrendas.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);
                string talle = ddlTalles.SelectedValue;

                Dominio.Stock stock = new Dominio.Stock
                {
                    IdPrenda = idPrenda,
                    Cantidad = cantidad,
                    Talle = talle
                };

                stockNegocio.ActualizarStock(stock);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Stock modificado exitosamente');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al modificar stock: " + ex.Message + "');", true);
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrenda = int.Parse(ddlPrendas.SelectedValue);

                stockNegocio.EliminarStock(idPrenda);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Stock eliminado exitosamente');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al eliminar stock: " + ex.Message + "');", true);
            }

        }



    }
}