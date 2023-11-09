using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        public List<Categoria> ListCategoria { get; set; }
        public List<Linea> ListLinea { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PrendaNegocio prendaNegocio = new PrendaNegocio();



                List<int> idsPrendas =prendaNegocio.listarIDPrendas() ;
                ddlPrendas.DataSource = idsPrendas;
                ddlPrendas.DataBind();
            }


        }

        protected void btnVerCategorias_Click(object sender, EventArgs e)
        {
           
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ListCategoria= categoriaNegocio.ObtenerCategorias();
      
            gvCategorias.DataSource = ListCategoria;
            gvCategorias.DataBind();

            gvCategorias.Visible = true;

        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
           
            string nuevaCategoria = txtNuevaCategoria.Text;
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            categoriaNegocio.AgregarCategoria(nuevaCategoria);

            // Limpiar el TextBox después de agregar la categoría.
            txtNuevaCategoria.Text = "";
            // Recargar la lista de categorías.
            btnVerCategorias_Click(sender, e);
        }

        protected void btnVerLineas_Click(object sender, EventArgs e)
        {

            LineaNegocio lineaNegocio = new LineaNegocio();
            ListLinea = lineaNegocio.ObtenerLineas();

            gvLineas.DataSource = ListLinea;
            gvLineas.DataBind();

            gvLineas.Visible = true;

        }

        protected void btnAgregarLinea_Click(object sender, EventArgs e)
        {

            string nuevaLinea = txtNuevaLinea.Text;
            LineaNegocio lineaNegocio = new LineaNegocio();

            lineaNegocio.AgregarLinea(nuevaLinea);

            // Limpiar el TextBox después de agregar la categoría.
            txtNuevaLinea.Text = "";
            // Recargar la lista de categorías.
            btnVerLineas_Click(sender, e);
        }


        protected void btnVerImagenes_Click(object sender, EventArgs e)
        {
            // Aquí obtienes el ID de la prenda, por ejemplo, desde un TextBox en tu página.
            int idPrenda = Convert.ToInt32(ddlPrendas.SelectedValue); // Asegúrate de tener un TextBox para ingresar el ID de la prenda.

            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> imagenes = imagenNegocio.Listar(idPrenda);

            gvImagenes.DataSource = imagenes;
            gvImagenes.DataBind();

            gvImagenes.Visible = true;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            // Obtén el ID de la prenda y la URL de la nueva imagen.
            int idPrenda = Convert.ToInt32(ddlPrendas.SelectedValue); // Asegúrate de tener un TextBox para ingresar el ID de la prenda.
            string nuevaImagenUrl = txtNuevaImagen.Text;

            // Crea una instancia de Imagen y configúrala con el ID de la prenda y la URL de la imagen.
            Imagen nuevaImagen = new Imagen
            {
                IdPrenda = idPrenda,
                ImagenURL = nuevaImagenUrl
            };

            // Utiliza la clase ImagenNegocio para agregar la nueva imagen.
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            imagenNegocio.Agregar(nuevaImagenUrl,idPrenda);

            // Limpia el TextBox después de agregar la imagen.
            txtNuevaImagen.Text = "";

            // Recarga la lista de imágenes.
            btnVerImagenes_Click(sender, e);
        }



        protected void ddlPrendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPrendaSeleccionada = Convert.ToInt32(ddlPrendas.SelectedValue);
            CargarImagenesPorPrendaID(idPrendaSeleccionada);


        }



        protected void CargarImagenesPorPrendaID(int idPrenda)
        {
            try
            {
                // Crear una instancia de la clase ImagenNegocio (o la clase que maneja la lógica de negocio de las imágenes)
                ImagenNegocio imagenNegocio = new ImagenNegocio();

                // Obtener la lista de imágenes para la prenda seleccionada
                List<Imagen> imagenes = imagenNegocio.Listar(idPrenda);

                // Mostrar las imágenes en el GridView
                gvImagenes.DataSource = imagenes;
                gvImagenes.DataBind();

                // Hacer visible el GridView
                gvImagenes.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tu lógica (puedes mostrar un mensaje de error, loggearlo, etc.)
                // Por ejemplo, puedes agregar una etiqueta en tu formulario para mostrar mensajes de error.
            }
        }

    }
}