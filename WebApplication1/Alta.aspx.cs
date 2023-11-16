
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Alta : System.Web.UI.Page
    {
        public List<Categoria> ListCategoria { get; set; }
        public List<Linea> ListLinea { get; set; }
        public List<Prenda> Listprenda { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ListCategoria = categoriaNegocio.ObtenerCategorias();
            DropListCategoria.DataSource = ListCategoria;
            DropListCategoria.DataTextField = "Descripcion";
            DropListCategoria.DataBind();

            LineaNegocio lineaNegocio = new LineaNegocio();
            ListLinea = lineaNegocio.ObtenerLineas();
            DropListLinea.DataSource = ListLinea;
            DropListLinea.DataTextField = "Descripcion";
            DropListLinea.DataBind();


            PrendaNegocio pre = new PrendaNegocio();
            Listprenda = pre.Listar();



        }

        protected void BtnAgregarCategoria_Click(object sender, EventArgs e)
        {
            TxtNuevaCategoria.Visible = true;
            BtnNuevaCategoria.Visible = true;
        }

        protected void BtnEnviarCategoria_Click(object sender, EventArgs e)
        {
            string NuevaCategoria = TxtNuevaCategoria.Text;
            TxtNuevaCategoria.Visible = false;
            BtnNuevaCategoria.Visible = false;

            if (!string.IsNullOrEmpty(NuevaCategoria))

            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categoriaNegocio.AgregarCategoria(NuevaCategoria);
                ListCategoria = categoriaNegocio.ObtenerCategorias();
                DropListCategoria.DataSource = ListCategoria;
                DropListCategoria.DataTextField = "Descripcion";
                DropListCategoria.DataBind();
            }
        }
        protected void BtnAgregarLinea_Click(object sender, EventArgs e)
        {
            TxtNuevaLinea.Visible = true;
            BtnNuevaLinea.Visible = true;
        }

        protected void BtnEnviarLinea_Click(object sender, EventArgs e)
        {
            string NuevaLinea = TxtNuevaLinea.Text;
            TxtNuevaLinea.Visible = false;
            BtnNuevaLinea.Visible = false;

            if (!string.IsNullOrEmpty(NuevaLinea))

            {
                LineaNegocio lineaNegocio = new LineaNegocio();
                lineaNegocio.AgregarLinea(NuevaLinea);
                ListLinea = lineaNegocio.ObtenerLineas();
                DropListLinea.DataSource = ListLinea;
                DropListLinea.DataTextField = "Descripcion";
                DropListLinea.DataBind();

            }
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {


            string mensaje = BuscarId(Listprenda).ToString();
            TxtDescripcion.Text = mensaje;





        }



        protected int BuscarId(List<Prenda> list)
        {
            int proximoID = 1; // Valor predeterminado si la lista está vacía
            if (list.Count > 0)
            {
                // Encuentra el máximo ID actual y luego agrega 1 para obtener el próximo ID disponible
                proximoID = list.Max(p => p.Id) + 1;
            }

            proximoID = proximoID;


            return proximoID;
        }
    }
}
