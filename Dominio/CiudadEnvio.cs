using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CiudadEnvio
    {
        public CiudadEnvio() { } 
        public CiudadEnvio(int id, string descripcion, int precio)
        {
            IDCiudad = id;
            Descripcion = descripcion;
            PrecioEnvio = precio;
        }
        public int IDCiudad { get; set; }  
        public string Descripcion { get; set; }
        public int PrecioEnvio { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
        public string DescripcionConPrecio => $"{Descripcion} ({PrecioEnvio:C})";
    }
}
