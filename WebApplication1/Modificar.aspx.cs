using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Modificar : System.Web.UI.Page
    {
        public List<Prenda> listPrenda { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {





        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            PrendaNegocio prenda = new PrendaNegocio();

            string Nombre = TxtDescripcion.Text;
            string cate = null;
            string genero = null;
            string linea = null;
            decimal? precio = null;

            listPrenda = prenda.ListarConFiltro(cate, genero, linea, precio, Nombre);
            rptArticulos.DataSource = listPrenda;
            rptArticulos.DataBind();




        }

        protected void Seleccionar_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            int idPrenda = int.Parse(button.CommandArgument);
            PrendaNegocio prendaNegocio = new PrendaNegocio();
            Prenda prenda = prendaNegocio.BuscarUnaPrenda(idPrenda);

            TxtDescripcionM.Text = prenda.Descripcion;
            TxtPrecio.Text = prenda.Precio.ToString("0.00");
            TxtStock.Text = prenda.Stock.ToString("0");
            TxtTalle.Text = prenda.Talle;



            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            DropListCategoria.DataSource = categoriaNegocio.ObtenerCategorias();
            DropListCategoria.DataTextField = "Descripcion";
            DropListCategoria.DataBind();

            LineaNegocio lineaNegocio = new LineaNegocio();
            lineaNegocio.ObtenerLineas();
            DropListLinea.DataSource = lineaNegocio.ObtenerLineas();

            DropListLinea.DataTextField = "Descripcion";
            DropListLinea.DataBind();


            string valorPredeterminado = prenda.Categoria.Descripcion; // Valor que se quiere establecer como predeterminado
            string valorPredeterminado1 = prenda.Linea.Descripcion; // Valor que se quiere establecer como predeterminado

            DropListCategoria.Items.FindByValue(valorPredeterminado).Selected = true;
            DropListLinea.Items.FindByValue(valorPredeterminado1).Selected = true;

            //string valorPredeterminado2 = prenda.Genero.Descripcion; // Valor que se quiere establecer como predeterminado

            //  DropListGenero.Items.FindByValue(valorPredeterminado2).Selected = true;

            ImagenNegocio imagenNegocio = new ImagenNegocio();

            List<Imagen> imageList = new List<Imagen>();
            imageList = imagenNegocio.Listar(idPrenda);

            if (imageList != null && imageList.Count > 0)
            {

                imgNueva.ImageUrl = imageList[0].ImagenURL;


            }
            else
            {
                imgNueva.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png";



            }
            Session["idPrenda"] = idPrenda;

            Session["ListaImagenes"] = imageList;


            listPrenda = new List<Prenda>(); // Asigna una lista vacía
            listPrenda.Add(prendaNegocio.BuscarUnaPrenda(idPrenda));
            rptArticulos.DataSource = listPrenda;
            rptArticulos.DataBind();

            BtnModificar.Visible = true;

        }

        protected void Ver_Click(object sender, EventArgs e)
        {
            if (Session["idPrenda"] == null)
            {
                // Código para mostrar una alerta en el navegador del cliente
                string script = "alert('Para mostrar la iamgen debes seleccionar una prenda en el Buscador');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);

            }
            else
            {
                int? idPrenda = (int)Session["idPrenda"];



                ImagenNegocio ima = new ImagenNegocio();


                List<Imagen> imagenesObtenidas = ima.Listar((int)idPrenda);
                int cantImg = imagenesObtenidas.Count;
                string Ruta = Server.MapPath("./Prenda_Img/");
                txtImage.PostedFile.SaveAs(Ruta + "Prenda-" + idPrenda + "-" + (cantImg + 1) + ".jpg");
                imgNueva.ImageUrl = "~/Prenda_Img/Prenda-" + idPrenda + "-" + (cantImg + 1) + ".jpg";
                Session["RutaPrendaActual"] = "./Prenda_Img/Prenda-" + idPrenda + "-" + (cantImg + 1) + ".jpg";


            }

        }

        protected void GuardarImg_Click(object sender, EventArgs e)
        {

            string imageURL = HiddenFieldURL.Value;



            string parteARemover = "./Prenda_Img/";
            string resultado = imageURL.Replace(parteARemover, "");

            if (txtImage.HasFile)
            {

                int idPrenda = (int)Session["idPrenda"];
                txtImage.PostedFile.SaveAs(Server.MapPath(parteARemover + resultado)); // Guardar el archivo en la ubicación deseada
                                                                                       //Actualizar la URL de la imagen mostrada en el control asp:Image
                imgNueva.ImageUrl = "~/Prenda_Img/" + resultado;
                Session["RutaPrendaActual"] = "./Prenda_Img/" + resultado;
                // Mostrar un mensaje de éxito
                string script = "alert('La imagen se guardó con éxito.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
            }
            else
            {
                // Mostrar una alerta si no se seleccionó ningún archivo
                string script = "alert('No se ha seleccionado ningún archivo.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
            }

        }


        protected void ArchivoSeleccionado(object sender, EventArgs e)
        {



            int idPrenda = (int)Session["idPrenda"];
            ImagenNegocio ima = new ImagenNegocio();


            List<Imagen> imagenesObtenidas = ima.Listar(idPrenda);
            int cantImg = imagenesObtenidas.Count;
            string Ruta = Server.MapPath("./Prenda_Img/");
            txtImage.PostedFile.SaveAs(Ruta + "Prenda-" + idPrenda + "-" + (cantImg + 1) + ".jpg");
            imgNueva.ImageUrl = "~/Prenda_Img/Prenda-" + idPrenda + "-" + (cantImg + 1) + ".jpg";
            Session["RutaPrendaActual"] = "./Prenda_Img/Prenda-" + idPrenda + "-" + (cantImg + 1) + ".jpg";




        }

        protected string FormatearPrecio(object precio)
        {
            if (precio != null)
            {
                decimal precioDecimal;
                if (decimal.TryParse(precio.ToString(), out precioDecimal))
                {
                    return precioDecimal.ToString("C"); // Formato de moneda
                }
            }
            return "Precio no disponible"; // O maneja la lógica para casos donde el precio no esté disponible
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {



            Prenda prenda = new Prenda();
            prenda.Id = (int)Session["idPrenda"];
            if (Session["idPrenda"] == null)
            {

                string script = "alert('buscar y seleccionar la prenda para Modificar ');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);

            }
            else
            {


                prenda.Descripcion = TxtDescripcionM.Text;
                prenda.Precio = Convert.ToDecimal(TxtPrecio.Text);
                prenda.Stock = Convert.ToInt32(TxtStock.Text);
                prenda.Talle = TxtTalle.Text;

                prenda.Categoria = new Categoria(); // Asegurar que se cree una nueva instancia de Categoria
                prenda.Linea = new Linea(); // Asegurar que se cree una nueva instancia de Linea
                prenda.Genero = new Genero(); // Asegurar que se cree una nueva instancia de Genero
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                foreach (Categoria item in categoriaNegocio.ObtenerCategorias())
                {
                    if (item.Descripcion == DropListCategoria.Text)
                    {
                        prenda.Categoria.Id = item.Id;
                        prenda.Categoria.Descripcion = item.Descripcion;
                        break; // Terminar el bucle una vez que se encuentre la categoría
                    }
                }
                LineaNegocio lineaNegocio = new LineaNegocio();
                foreach (var item in lineaNegocio.ObtenerLineas())
                {
                    if (item.Descripcion == DropListLinea.Text)
                    {
                        prenda.Linea.Id = item.Id;
                        prenda.Linea.Descripcion = item.Descripcion;
                        break; // Terminar el bucle una vez que se encuentre la línea
                    }
                }

                prenda.Genero.Id = (DropListGenero.SelectedValue == "Masculino") ? 1 : 2;
                prenda.Genero.Descripcion = (DropListGenero.SelectedValue == "Masculino") ? "Masculino" : "Femenino";


                PrendaNegocio prendaNegocio = new PrendaNegocio();

                prendaNegocio.Modificar(prenda);



                listPrenda = new List<Prenda>(); // Asigna una lista vacía
                listPrenda.Add(prendaNegocio.BuscarUnaPrenda((int)Session["idPrenda"]));
                rptArticulos.DataSource = listPrenda;
                rptArticulos.DataBind();


            }
        }
    }
}