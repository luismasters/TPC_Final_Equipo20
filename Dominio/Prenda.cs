using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Prenda
    {
        public int  Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }
        public Genero Genero { get; set; }
        public Linea Linea { get; set; }
        public string Talle {  get; set; }
        public List<Imagen> Imagenes { get; set; }
        public string ImagenURL
        {
            get
            {
                if (Imagenes != null && Imagenes.Count > 0 && !string.IsNullOrEmpty(Imagenes[0].ImagenURL))
                    return Imagenes[0].ImagenURL;
                return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png";
            }
        }
    }
}
