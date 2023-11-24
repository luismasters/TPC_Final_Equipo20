
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
        public List<Imagen> ListaImagenes { get; set; }

        private int indice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            ListCategoria = categoriaNegocio.ObtenerCategorias();


            LineaNegocio lineaNegocio = new LineaNegocio();
            ListLinea = lineaNegocio.ObtenerLineas();

            if (!IsPostBack)
            {
                DropListCategoria.DataSource = ListCategoria;
                DropListCategoria.DataTextField = "Descripcion";
                DropListCategoria.DataBind();
                DropListLinea.DataSource = ListLinea;
                DropListLinea.DataTextField = "Descripcion";
                DropListLinea.DataBind();

                MostrarElementoActual();
                Session["IdP"] = false;

            }


            PrendaNegocio pre = new PrendaNegocio();
            Listprenda = pre.Listar();
            if ((bool)Session["IdP"] == true)
            {

                ImagenNegocio imagenNegocio = new ImagenNegocio();
                ListaImagenes = imagenNegocio.Listar(BuscarId(Listprenda) - 1);


                foreach (Imagen item in ListaImagenes)
                {
                    // Crea un control Image para cada URL de imagen y lo agrega al div imageStrip
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                    img.ImageUrl = item.ImagenURL;
                    img.Width = new System.Web.UI.WebControls.Unit(150); // Define el ancho deseado para las imágenes
                    img.Style.Add("margin-right", "10px"); // Agrega margen derecho para separar las imágenes
                    imageStrip.Controls.Add(img); // Agrega la imagen al contenedor
                }

            }
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

            if (txtImage.HasFile == true)
            {

                ImagenNegocio ima = new ImagenNegocio();
                int id = BuscarId(Listprenda) - 1;
                List<Imagen> imagenesObtenidas = ima.Listar(id);
                int cantImg = imagenesObtenidas.Count;

                string Ruta = Server.MapPath("./Prenda_Img/");
                txtImage.PostedFile.SaveAs(Ruta + "Prenda-" + id + "-" + (cantImg + 1) + ".jpg");
                imgNueva.ImageUrl = "~/Prenda_Img/Prenda-" + id + "-" + (cantImg + 1) + ".jpg";
                Session["rutaImg"] = "./Prenda_Img/Prenda-" + id + "-" + (cantImg + 1) + ".jpg";
                ima.Agregar((String)Session["rutaImg"], BuscarId(Listprenda) - 1);
                Session["Idima"] = id;
            }

            else
            {
                string script = "alert('debes Seleccionar una imagen');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
            }

        }



        protected int BuscarId(List<Prenda> list)
        {
            int proximoID = 1; // Valor predeterminado si la lista está vacía
            if (list.Count > 0)
            {
                // Encuentra el máximo ID actual y luego agrega 1 para obtener el próximo ID disponible
                proximoID = list.Max(p => p.Id) + 1;
            }



            return proximoID;
        }

        protected void AddImg_Click(object sender, EventArgs e)
        {

            if (txtImage.HasFile == true)
            {

                ImagenNegocio ima = new ImagenNegocio();
                int id = BuscarId(Listprenda) - 1;
                List<Imagen> imagenesObtenidas = ima.Listar(id);
                int cantImg = imagenesObtenidas.Count;

                string Ruta = Server.MapPath("./Prenda_Img/");
                txtImage.PostedFile.SaveAs(Ruta + "Prenda-" + id + "-" + (cantImg + 1) + ".jpg");
                imgNueva.ImageUrl = "~/Prenda_Img/Prenda-" + id + "-" + (cantImg + 1) + ".jpg";
                Session["rutaImg"] = "./Prenda_Img/Prenda-" + id + "-" + (cantImg + 1) + ".jpg";
                ima.Agregar((String)Session["rutaImg"], BuscarId(Listprenda) - 1);
                Session["Idima"] = id;
            }

            else
            {
                string script = "alert('debes Seleccionar una imagen');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
            }

        }


        private void MostrarElementoActual()
        {
            divElemento1.Visible = false;
            divElemento2.Visible = false;

            switch (indice)
            {
                case 0:
                    divElemento1.Visible = true;
                    break;
                case 1:
                    divElemento2.Visible = true;
                    break;

                default:
                    // Manejo para un índice fuera de rango si es necesario
                    break;
            }
        }

        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            // Lógica para retroceder al elemento anterior
            indice--; // Reduces the index to go to the previous element
            MostrarElementoActual();
        }

        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {


            try
            {
                Prenda prenda = new Prenda();
                prenda.Descripcion = TxtDescripcion.Text;
                prenda.Precio = decimal.Parse(TxtPrecio.Text);
                prenda.Talle = TxtTalle.Text;
                prenda.Stock = int.Parse(TxtStock.Text);

                // Inicializar las propiedades dentro de Prenda
                prenda.Categoria = new Categoria(); // Asegurar que se cree una nueva instancia de Categoria
                prenda.Linea = new Linea(); // Asegurar que se cree una nueva instancia de Linea
                prenda.Genero = new Genero(); // Asegurar que se cree una nueva instancia de Genero

                foreach (Categoria item in ListCategoria)
                {
                    if (item.Descripcion == DropListCategoria.Text)
                    {
                        prenda.Categoria.Id = item.Id;
                        prenda.Categoria.Descripcion = item.Descripcion;
                        break; // Terminar el bucle una vez que se encuentre la categoría
                    }
                }

                foreach (var item in ListLinea)
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

                prendaNegocio.AgregarNuevaPrenda(prenda);
                Session["IdP"] = true;

            }
            catch (Exception ex)
            {
                // Manejo de la excepción (por ejemplo, mostrar un mensaje de error)
            }

            // Lógica para avanzar al siguiente elemento
            indice++; // Increases the index to go to the next element
            MostrarElementoActual();
        }


    }
}


