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
    public partial class _Default : Page
    {

        public List<Prenda> PrendaList;

        protected void Page_Load(object sender, EventArgs e)
        {

            PrendaNegocio prenda = new PrendaNegocio();
            PrendaList = prenda.Listar();
            
            rptArticulos.DataSource = PrendaList;
            rptArticulos.DataBind();

        }
    }
}