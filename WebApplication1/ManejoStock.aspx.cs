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
                gvStock.DataSource = _stockNegocio.ListarStock();
                gvStock.DataBind();
            }
            else
            {
                string activeTab = HiddenFieldActiveTab.Value;
                if (!string.IsNullOrEmpty(activeTab))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SetActiveTab", "$('" + activeTab + "').tab('show');", true);
                }
            }
        }

        private void CargarPrendas()
        {
            PrendaNegocio prendaNegocio = new PrendaNegocio();
            List<Prenda> listaPrendas = prendaNegocio.Listar();

            ddlPrendasAgregar.DataSource = listaPrendas;
            ddlPrendasModificar.DataSource = listaPrendas;
            ddlPrendaEliminar.DataSource = listaPrendas;

            foreach (var ddl in new[] { ddlPrendasAgregar, ddlPrendasModificar, ddlPrendaEliminar })
            {
                ddl.DataTextField = "Descripcion";
                ddl.DataValueField = "Id";
                ddl.DataBind();
            }
        }

        private void CargarLotes()
        {
            StockNegocio stockNegocio = new StockNegocio();
            List<Stock> lotes = _stockNegocio.ObtenerLotes();

            foreach (var ddl in new[] { ddlLoteModificar, ddlLoteEliminar })
            {
                ddl.DataSource = lotes;
                ddl.DataTextField = "Lote";
                ddl.DataValueField = "Lote";
                ddl.DataBind();
            }

            if (lotes.Any())
            {
                foreach (var ddl in new[] { ddlLoteModificar, ddlLoteEliminar })
                {
                    ddl.DataSource = lotes;
                    ddl.DataTextField = "Lote";
                    ddl.DataValueField = "Lote";
                    ddl.DataBind();
                }
            }
            else
            {
                ddlLoteModificar.Items.Insert(0, new ListItem("No hay lotes disponibles", ""));
                ddlLoteEliminar.Items.Insert(0, new ListItem("No hay lotes disponibles", ""));
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
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

                ResetearFormularioAgregar();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al agregar el stock: " + ex.Message);
            }
        }
        private void ResetearFormularioAgregar()
        {
            ddlPrendasAgregar.SelectedIndex = -1;
            txtCantidadAgregar.Text = "";        
            ddlTalles.SelectedIndex = -1;        
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

            CargarLotes();
        }

        protected void ddlLoteModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loteSeleccionado = ddlLoteModificar.SelectedValue;
            Stock stockExistente = _stockNegocio.ObtenerStockPorLote(loteSeleccionado);
            if (stockExistente != null)
            {
                CargarTallesSegunPrenda(stockExistente.Lote, ddlTallesModificar);
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
                CargarTallesSegunPrenda(stockExistente.Lote, ddlTalleEliminar);
                ddlPrendaEliminar.SelectedValue = stockExistente.IdPrenda.ToString();
                ddlTalleEliminar.SelectedValue = stockExistente.Talle.ToString();
                txtCantidadEliminar.Text = stockExistente.Cantidad.ToString();

                ddlPrendaEliminar.Enabled = false;
                ddlTalleEliminar.Enabled = false;
                txtCantidadEliminar.ReadOnly = true;
            }

        }

        private string GenerarNuevoLote()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }



        protected void ddlPrendasAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPrendaSeleccionada = int.Parse(ddlPrendasAgregar.SelectedValue);
            PrendaNegocio prendaNegocio = new PrendaNegocio();
            Prenda prendaSeleccionada = prendaNegocio.BuscarUnaPrenda(idPrendaSeleccionada);

            CargarTallesSegunCategoria(prendaSeleccionada.Categoria);
        }

        private void LlenarTallesRemerasBuzos(DropDownList ddl)
        {
            ddl.Items.Clear();

            var talles = new List<string> { "XS", "S", "M", "L", "XL", "XXL" };
            foreach (var talle in talles)
            {
                ddl.Items.Add(new ListItem(talle, talle));
            }
        }
        private void LlenarTallesPantalones(DropDownList ddl)
        {
            ddl.Items.Clear();

            var talles = new List<int> { 32, 34, 36, 38, 40, 42 };
            foreach (var talle in talles)
            {
                ddl.Items.Add(new ListItem(talle.ToString(), talle.ToString()));
            }
        }

        private void CargarTallesSegunPrenda(string lote, DropDownList ddlTalles)
        {
            int idCategoria = _stockNegocio.ObtenerCategoriaPrenda(lote);

            if (idCategoria == 4)
            {
                LlenarTallesPantalones(ddlTalles);
            }
            else
            {
                LlenarTallesRemerasBuzos(ddlTalles);
            }
        }

        private void CargarTallesSegunCategoria(Categoria categoria)
        {
            if (categoria.Id == 4)
            {
                LlenarTallesPantalones(ddlTalles);
            }
            else
            {
                LlenarTallesRemerasBuzos(ddlTalles);
            }
        }

        protected void btnActualizarStock_Click(object sender, EventArgs e)
        {
            ActualizarListaStock();
        }

        private void ActualizarListaStock()
        {
            gvStock.DataSource = _stockNegocio.ListarStock();
            gvStock.DataBind();
        }

    }
}
