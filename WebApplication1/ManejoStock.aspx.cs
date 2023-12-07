using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication1
{
    public partial class ManejoStock : System.Web.UI.Page
    {
        private readonly StockNegocio _stockNegocio = new StockNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPrendas();
                CargarLotes();
            }
        }

        private void CargarPrendas()
        {
            PrendaNegocio prendaNegocio = new PrendaNegocio();
            List<Prenda> listaPrendas = prendaNegocio.Listar();

            ddlPrendasAgregar.DataSource = listaPrendas;
            ddlPrendasModificar.DataSource = listaPrendas;
            foreach (var ddl in new[] { ddlPrendasAgregar, ddlPrendasModificar })
            {
                ddl.DataTextField = "Descripcion";
                ddl.DataValueField = "Id";
                ddl.DataBind();
            }
        }

        private void CargarLotes()
        {
            List<Stock> lotes = _stockNegocio.ObtenerLotesPorPrenda(-1); // -1 para 'todos los lotes'
            ddlLoteModificar.DataSource = lotes;
            ddlLoteModificar.DataTextField = "Lote"; 
            ddlLoteModificar.DataValueField = "Lote";
            ddlLoteModificar.DataBind(); 

            if (!lotes.Any())
            {
                
                ddlLoteModificar.Items.Insert(0, new ListItem("No hay lotes disponibles", ""));
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idPrenda = int.Parse(ddlPrendasAgregar.SelectedValue);
            int cantidad = int.Parse(txtCantidadAgregar.Text);
            string talle = ddlTalles.SelectedValue;

            Stock stock = new Stock
            {
                IdPrenda = idPrenda,
                Cantidad = cantidad,
                Talle = talle,
                Lote = GenerarNuevoLote()
            };

            _stockNegocio.AgregarStock(stock);
            MostrarMensaje("Stock agregado exitosamente");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
            string lote = ddlLoteModificar.SelectedValue;
            int idPrenda = int.Parse(ddlPrendasModificar.SelectedValue);
            int cantidad = int.Parse(txtCantidadModificar.Text);
            string talle = ddlTallesModificar.SelectedValue;

            Stock stockModificado = new Stock
            {
                IdPrenda = idPrenda,
                Cantidad = cantidad,
                Talle = talle,
                Lote = lote
            };

            _stockNegocio.ActualizarStock(stockModificado);
            MostrarMensaje("Stock modificado exitosamente");
            CargarLotes();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string lote = ddlLoteEliminar.SelectedValue;
            _stockNegocio.EliminarStockPorLote(lote);
            MostrarMensaje("Stock eliminado exitosamente");
        }

        protected void ddlLoteModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loteSeleccionado = ddlLoteModificar.SelectedValue;
            Stock stockExistente = _stockNegocio.ObtenerStockPorLote(loteSeleccionado);
            if (stockExistente != null)
            {
                ddlPrendasModificar.SelectedValue = stockExistente.IdPrenda.ToString();
                ddlTallesModificar.SelectedValue = stockExistente.Talle;
                txtCantidadModificar.Text = stockExistente.Cantidad.ToString();
            }

        }

        private void CargarDatosDelLote(string lote)
        {
            Stock stockExistente = _stockNegocio.ObtenerStockPorLote(lote);
            if (stockExistente != null)
            {
                ddlPrendasModificar.SelectedValue = stockExistente.IdPrenda.ToString();
                ddlTallesModificar.SelectedValue = stockExistente.Talle;
                txtCantidadModificar.Text = stockExistente.Cantidad.ToString();
            }
        }
        protected void ddlLoteEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loteSeleccionado = ddlLoteEliminar.SelectedValue;
            Stock stockExistente = _stockNegocio.ObtenerStockPorLote(loteSeleccionado);
            if (stockExistente != null)
            {
                lblPrendaEliminar.Text = stockExistente.IdPrenda.ToString();
                lblTalleEliminar.Text = stockExistente.Talle;
                lblCantidadEliminar.Text = stockExistente.Cantidad.ToString();
            }
        }

        private string GenerarNuevoLote()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void MostrarMensaje(string mensaje)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
        }


        protected void ddlPrendasAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPrendaSeleccionada = int.Parse(ddlPrendasAgregar.SelectedValue);
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
    }
}
