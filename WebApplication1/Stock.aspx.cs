
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
    public partial class StockManagement : System.Web.UI.Page
    {
        private StockNegocio StockNegocio = new StockNegocio();

        public int IdPrenda { get; private set; }
        public int Cantidad { get; private set; }
        public string Lote { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

            ddlPrendas.AutoPostBack = true;
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

                stock.Lote = GenerarNuevoLote();
                StockNegocio.AgregarStock(stock);
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
                string lote = ddlLote.SelectedValue;

                Dominio.Stock stock = new Dominio.Stock
                {
                    IdPrenda = idPrenda,
                    Cantidad = cantidad,
                    Lote = lote
                };
                stock.Lote = ddlLote.SelectedValue;
                StockNegocio.ActualizarStock(stock);
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

                StockNegocio.EliminarStock(idPrenda);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Stock eliminado exitosamente');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al eliminar stock: " + ex.Message + "');", true);
            }

        }
        protected void ddlPrendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPrendaSeleccionada = int.Parse(ddlPrendas.SelectedValue);
            PrendaNegocio prendaNegocio = new PrendaNegocio();
            Prenda prendaSeleccionada = prendaNegocio.BuscarUnaPrenda(idPrendaSeleccionada);

            if (prendaSeleccionada.Categoria.Id == 1 || prendaSeleccionada.Categoria.Id == 2 || prendaSeleccionada.Categoria.Id == 3)
            {
                LlenarTallesRemerasBuzos();
            }
            else if (prendaSeleccionada.Categoria.Id == 4)
            {
                LlenarTallesPantalones();
            }
            MostrarControlesParaModificar();

        }

        protected void ddlLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loteSeleccionado = ddlLote.SelectedValue;
            int idPrenda = int.Parse(ddlPrendas.SelectedValue);

            Stock stockExistente = StockNegocio.ObtenerStockPorLote(idPrenda, loteSeleccionado);
            if (stockExistente != null)
            {
                txtCantidad.Text = stockExistente.Cantidad.ToString();
                ddlTalles.SelectedValue = stockExistente.Talle;
                ddlLote.SelectedValue = stockExistente.Lote;
            }
        }

        private string GenerarNuevoLote()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void LlenarTallesRemerasBuzos()
        {
            ddlTalles.Items.Clear();
            ddlTalles.Items.Add(new ListItem("XS", "XS"));
            ddlTalles.Items.Add(new ListItem("S", "S"));
            ddlTalles.Items.Add(new ListItem("M", "M"));
            ddlTalles.Items.Add(new ListItem("L", "L"));
            ddlTalles.Items.Add(new ListItem("XL", "XL"));
            ddlTalles.Items.Add(new ListItem("XXL", "XXL"));
        }

        private void LlenarTallesPantalones()
        {
            ddlTalles.Items.Clear();
            ddlTalles.Items.Add(new ListItem("32", "32"));
            ddlTalles.Items.Add(new ListItem("34", "34"));
            ddlTalles.Items.Add(new ListItem("36", "36"));
            ddlTalles.Items.Add(new ListItem("38", "38"));
            ddlTalles.Items.Add(new ListItem("40", "40"));
            ddlTalles.Items.Add(new ListItem("42", "42"));
        }

        private void MostrarControlesParaAgregar()
        {
            loteModificar.Visible = false;
            talleAgregar.Visible = true;
            ddlLote.Items.Clear();
        }

        private void MostrarControlesParaModificar()
        {
            int idPrendaSeleccionada = int.Parse(ddlPrendas.SelectedValue);
            List<Stock> lotes = StockNegocio.ObtenerLotesPorPrenda(idPrendaSeleccionada);

            ddlLote.Items.Clear();
            foreach (Stock lote in lotes)
            {
                ddlLote.Items.Add(new ListItem(lote.Lote, lote.Lote));
            }

            loteModificar.Visible = true;
            talleAgregar.Visible = false;
        }


    }
}